using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using VSTSShared.BaseClasses;
using VSTSShared.Entities;

namespace VSTSShared.Helpers
{
    public class VstsHelper
    {
        /// <summary>
        /// Downloads a single file from VSTS and saves it to the specified location.
        /// </summary>
        /// <param name="authentication">The user's authentication credentials.</param>
        /// <param name="project">The VSTS (team) Project.</param>
        /// <param name="repo">The name of the Git Repo containing the file.</param>
        /// <param name="fileToDownload">The Path to the file (within the Repo) to be downloaded.</param>
        /// <param name="destination">The Destination Path where the file should be downloaded to.</param>
        /// <param name="baseIndent">Base indent level for verbose output.</param>
        /// <param name="verbose">When <c>true</c> a list of downloaded files is displayed.</param>
        /// <returns><c>true</c> if the file is downloaded successfully; otherwise, <c>false</c>.</returns>
        public bool DownloadFile(BasicAuthentication authentication, string project, string repo, string fileToDownload,
            string destination, bool verbose = true, int baseIndent = 0)
        {
            var callSucceeded = false;
            var restHttpClient = new RestHttpClient();
            var url = $"{authentication.AccountUrl}/{project}/_apis/git/repositories/{repo}/items?api-version=1.0&scopePath={fileToDownload}";

            using (var response = restHttpClient.RequestFile(authentication, url))
            {
                if (response != null)
                {
                    using (var responseStream = GetResponseStream(response))
                    {
                        var fileName = Path.GetFileName(fileToDownload ?? "");

                        using (var fileStream = File.Create(Path.Combine(destination, fileName)))
                        {
                            responseStream.CopyTo(fileStream);

                            if (verbose)
                            {
                                // Count folder levels for indentation purposes
                                var indent = (CountCharacters(destination, '\\') - baseIndent) * 2;
                                Console.WriteLine(new string(' ', indent) + fileName);
                            }

                            callSucceeded = true;
                        }
                    }
                }
            }

            return callSucceeded;
        }

        /// <summary>
        /// Downloads a folder and files from VSTS and saves it to the specified location.
        /// </summary>
        /// <param name="authentication">The user's authentication credentials.</param>
        /// <param name="project">The VSTS (team) Project.</param>
        /// <param name="repo">The name of the Git Repo containing the file.</param>
        /// <param name="folderPath">The folder (within the Repo) to be downloaded.</param>
        /// <param name="destination">The Destination Path where the file should be downloaded to.</param>
        /// <param name="verbose">When <c>true</c> a list of downloaded files is displayed.</param>
        /// <returns><c>true</c> if the folder is downloaded successfully; otherwise, <c>false</c>.</returns>
        public bool DownloadFolder(BasicAuthentication authentication, string project, string repo, string folderPath,
            string destination, bool verbose = true)
        {
            var callSucceeded = false;
            var restHttpClient = new RestHttpClient();
            var url = $"{authentication.AccountUrl}/{project}/_apis/git/repositories/{repo}/items?api-version=1.0&scopePath={folderPath}&recursionLevel=Full";
            var baseIndent = CountCharacters(destination, '\\');

            using (var response = restHttpClient.RequestFile(authentication, url))
            {
                if (response != null)
                {
                    var responseText = GetResponseText(response);
                    var results = JsonConvert.DeserializeObject<CollectionResult<ItemDescriptor>>(responseText);

                    callSucceeded = (results != null && results.Count > 0);

                    if (callSucceeded)
                    {
                        // Create directory tree recursively
                        foreach (var item in results.Value)
                        {
                            if (item.IsFolder)
                            {
                                // Create folder
                                var newFolder = Path.Combine(destination, item.Path.TrimStart('/')).Replace('/', '\\');

                                Directory.CreateDirectory(newFolder);

                                if (verbose)
                                {
                                    var indent = (CountCharacters(newFolder, '\\') - baseIndent) * 2;
                                    Console.WriteLine(new string(' ', indent) + newFolder);
                                }
                            }
                            else
                            {
                                // Download file
                                var newPath = Path.Combine(destination, Path.GetDirectoryName(item.Path.TrimStart('/')) ?? item.Path);

                                DownloadFile(authentication, project, repo, item.Path, newPath, verbose, baseIndent - 1);
                            }
                        }
                    }
                }
            }

            return callSucceeded;
        }

        public bool KeepForever(BasicAuthentication authentication, string project, string buildNumber, bool keepForever, bool verbose = true)
        {
            bool callSucceeded;

            try
            {
                var restHttpClient = new RestHttpClient();
                var url = $"{authentication.AccountUrl}/{project}/_apis/build/builds?api-version=2.0&buildNumber={buildNumber}";

                // Call the Build API to obtain details for the specified build number
                var results = restHttpClient.GetAsync<CollectionResult<BuildResult>>(authentication, url);

                // Return false if no match was found
                callSucceeded = results.Result != null && results.Result.Count > 0;

                if (callSucceeded)
                {
                    var buildId = results.Result.Value[0].id;

                    if (verbose)
                    {
                        Console.WriteLine($"Build Number {buildNumber} mapped to Build ID {buildId}");
                    }

                    // Now we need to make a PATCH call to set the retention accordingly
                    url = $"{authentication.AccountUrl}/{project}/_apis/build/builds/{buildId}?api-version=2.0";

                    // Setup the input to the API call
                    var model = new Retention { keepForever = keepForever };

                    var result = restHttpClient.PatchAsync<BuildResult, Retention>(authentication, url, model).Result;

                    callSucceeded = (result != null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                callSucceeded = false;
            }

            return callSucceeded;
        }

        public CollectionResult<VstsUser> GetVstsUsers(BasicAuthentication authentication)
        {
            CollectionResult<VstsUser> users = null;

            try
            {
                var restHttpClient = new RestHttpClient();
                var url =
                    $"https://{authentication.Account}.vsaex.visualstudio.com/_apis/userentitlements?api-version=4.1-preview&top=1000";

                // Call the Build API to obtain details for the specified build number
                var results = restHttpClient.GetAsync<CollectionResult<VstsUser>>(authentication, url);

                // Return false if no match was found
                if (results.Result != null && results.Result.Count > 0)
                {
                    users = results.Result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return users;
        }

        /// <summary>
        /// Counts the occurrences of the specified character within a string.
        /// </summary>
        /// <param name="text">The text to search.</param>
        /// <param name="charToCount">The character to be counted.</param>
        /// <returns>The number of occurrences of the specified character.</returns>
        private static int CountCharacters(string text, char charToCount)
        {
            return text.Count(textChar => textChar.Equals(charToCount));
        }

        /// <summary>
        /// Obtains a Stream from an HttpWebResponse.
        /// </summary>
        /// <param name="response">The HttpWebResponse to obtain the Stream from.</param>
        /// <returns>A Stream from the HttpWebResponse that can be read.</returns>
        private static Stream GetResponseStream(HttpWebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            {
                var streamToRead = responseStream;

                if (streamToRead != null)
                {
                    if (response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        streamToRead = new GZipStream(streamToRead, CompressionMode.Decompress);
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))
                    {
                        streamToRead = new DeflateStream(streamToRead, CompressionMode.Decompress);
                    }
                }

                // Be sure to close the stream in the calling method!
                return streamToRead;
            }
        }

        /// <summary>
        /// Obtains the String results from an HttpWebResponse.
        /// </summary>
        /// <param name="response">The HttpWebResponse to obtain the text from.</param>
        /// <returns>A String from the HttpWebResponse that can be read.</returns>
        private static string GetResponseText(HttpWebResponse response)
        {
            var responseText = string.Empty;

            using (var responseStream = response.GetResponseStream())
            {
                var streamToRead = responseStream;

                if (streamToRead != null)
                {
                    if (response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        streamToRead = new GZipStream(streamToRead, CompressionMode.Decompress);
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))
                    {
                        streamToRead = new DeflateStream(streamToRead, CompressionMode.Decompress);
                    }

                    var streamReader = new StreamReader(streamToRead, Encoding.UTF8);

                    responseText = streamReader.ReadToEnd();

                    streamToRead.Close();
                }
            }

            return responseText;
        }
    }
}