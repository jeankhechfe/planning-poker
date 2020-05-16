using System;
using planningpoker.Models;

namespace planningpoker.TOs
{
    public class CommentCreateTO
    {
        public string Text { get; set; }
        public string TaskId { get; set; }
        public string UserId { get; set; }
    }
    
}