namespace VSTSShared.Entities
{
    public class Users
    {
        public long Count { get; set; }

        public Value[] Value { get; set; }
    }

    public class Value
    {
        public string Id { get; set; }

        public User User { get; set; }

        public AccessLevel AccessLevel { get; set; }

        public System.DateTimeOffset LastAccessedDate { get; set; }

        public object[] ProjectEntitlements { get; set; }

        public object[] Extensions { get; set; }

        public object[] GroupAssignments { get; set; }
    }

    public class AccessLevel

    {
        public string LicensingSource { get; set; }

        public string AccountLicenseType { get; set; }

        public string MsdnLicenseType { get; set; }

        public string LicenseDisplayName { get; set; }

        public string Status { get; set; }

        public string StatusMessage { get; set; }

        public string AssignmentSource { get; set; }
    }

    public class User
    {
        public string SubjectKind { get; set; }

        public string Domain { get; set; }

        public string PrincipalName { get; set; }

        public string MailAddress { get; set; }

        public string Origin { get; set; }

        public string OriginId { get; set; }

        public string DisplayName { get; set; }

        public Links Links { get; set; }

        public string Url { get; set; }

        public string Descriptor { get; set; }

        public string MetaType { get; set; }
    }

    public class Links
    {
        public MembershipState Self { get; set; }

        public MembershipState Memberships { get; set; }

        public MembershipState MembershipState { get; set; }

        public MembershipState StorageKey { get; set; }
    }

    public class MembershipState
    {
        public string Href { get; set; }
    }
}