using planningpoker.Models;

namespace planningpoker.TOs
{
    public class UserProjectPermissionTO
    {
        public string UserId { get; set; }
        public string ProjectId { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}