using System;
namespace desafio_framework.Models
{
    public class Post
    {
        private int Id { get; set; }
        private string Title { get; set; }
        private string Body { get; set; }

        public Post(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }
    }
}
