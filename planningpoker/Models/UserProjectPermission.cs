namespace planningpoker.Models
{
    public enum PermissionType
    {
        OWNER,
        READ_WRITE,
        READ,
    }

    public class UserProjectPermission
    {
        public string UserProjectPermitionId { get; set; }
        public string UserId { get; set; }
        public string ProjectId { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}