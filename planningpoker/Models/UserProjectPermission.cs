using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using planningpoker.TOs;

namespace planningpoker.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PermissionType
    {
        [EnumMember( Value = "OWNER" )]
        OWNER,
        [EnumMember( Value = "READ_WRITE" )]
        READ_WRITE,
        [EnumMember( Value = "READ" )]
        READ,
    }

    //TODO unique pair of user-project in DB
    public class UserProjectPermission
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public PermissionType PermissionType { get; set; }

        public UserProjectPermissionTO toTO()
        {
            return new UserProjectPermissionTO()
            {
                ProjectId = ProjectId,
                UserId = UserId,
                PermissionType = PermissionType
            };
        }
    }
}