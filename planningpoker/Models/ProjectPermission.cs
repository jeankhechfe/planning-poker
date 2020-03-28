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
        public string HolderId;
        public PermissionType PermissionType;
    }
}