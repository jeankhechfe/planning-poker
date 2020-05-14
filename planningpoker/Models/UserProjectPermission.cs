using System.ComponentModel.DataAnnotations;

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
        public string UserProjectPermissionId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}