using System;
using planningpoker.Models;

namespace planningpoker.TOs
{
    public class CommentTO
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Created { get; set; } //should be in ISO
        public TaskTO Task { get; set; }
        public UserTO User { get; set; }
    }
    
}