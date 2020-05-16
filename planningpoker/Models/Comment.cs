using System;
using planningpoker.TOs;
using System.Collections.Generic;

namespace planningpoker.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public DateTimeOffset Created { get; set; } //should be in ISO
        public string TaskId{ get; set; }
        public Task Task { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }

        public CommentTO toTO()
        {
            return new CommentTO()
            {
                Id = Id,
                Created = Created,
                Text = Text,
                Task = Task.toTO(),
                User = User?.ToTo()
            };
        }
    }
}