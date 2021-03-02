using System;
namespace desafio_framework_andressanowasyk
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Post(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
        }

        public void Print()
        {
            Console.WriteLine($"ID: {Id}\t | Título: {Title}\t");
            Console.WriteLine("---------");
            Console.WriteLine($"Corpo: {Body}");
            Console.WriteLine("-------------------------------------------------------------------------------");
        }
    }
}
