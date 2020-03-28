namespace planningpoker.Models
{
    public enum PermissionType
    {
        OWNER,
        READ_WRITE,
        READ,
    }

    public class ProjectPermission
    {
        public string Id { get; set; }
        public string HolderId { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}