using System;
namespace desafio_framework_andressanowasyk
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public ToDo(int id, string title, bool isCompleted)
        {
            Id = id;
            Title = title;
            IsCompleted = isCompleted;
        }

        public void Print()
        {
            char completedSymbol;

            if (IsCompleted)
            {
                completedSymbol = '✔';
            } else
            {
                completedSymbol = '▢';
            }

            Console.WriteLine($"{completedSymbol}   {Title}\t");
        }
    }
}
