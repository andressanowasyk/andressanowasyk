using System;

namespace desafio_framework_andressanowasyk
{
    public class Album
    {
        public int Id { get ; set; }
        public string Title { get; set; }

        public Album(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public void Print()
        {
            Console.WriteLine($"ID: {Id}\t | Título: {Title}\t");
        }

    }



}

