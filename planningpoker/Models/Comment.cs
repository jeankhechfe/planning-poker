using planningpoker.TOs;
using System.Collections.Generic;

namespace planningpoker.Models
{
    public class Comment
    {
        public string CommentId { get; set; }
        public string UserId { get; set; }
        public string TaskId{ get; set; }
        public string Body { get; set; }

    }
}