using System;
namespace desafio_framework_andressanowasyk
{
    public class ToDo
    {
        private int Id { get; set; }
        private string Title { get; set; }
        private bool IsCompleted { get; set; }

        public ToDo(int id, string title, bool isCompleted)
        {
            Id = id;
            Title = title;
            IsCompleted = isCompleted;
        }
    }
}
