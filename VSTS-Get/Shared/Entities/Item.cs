namespace VSTSShared.Entities
{
    public class ItemResponse
    {
        public int Count { get; set; }

        public ItemDescriptor[] Value { get; set; }
    }

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