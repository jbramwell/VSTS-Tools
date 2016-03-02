namespace VSTSShared.Entities
{
    /// <summary>
    /// Describes an item stored in version control.
    /// </summary>
    public class ItemDescriptor
    {
        public string ObjectId { get; set; }

        public string GitObjectType { get; set; }

        public string CommitId { get; set; }

        public string Path { get; set; }

        public bool IsFolder { get; set; }

        public string Url { get; set; }
    }
}