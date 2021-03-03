using System.Collections.Generic;
using System;

namespace desafio_framework_andressanowasyk


{
    public class User
    {
        public List<Album> albums = new List<Album>();
        public List<ToDo> todos = new List<ToDo>();
        public List<Post> posts = new List<Post>();


        public void PrintAlbums()
        {
            foreach (Album a in albums)
            {
                a.Print();
            }

            return;
        }

        public void PrintPosts()
        {
            foreach (Post p in posts)
            {
                p.Print();
            }

            return;
        }

        public void PrintToDos()
        {
            foreach (ToDo t in todos)
            {
                t.Print();
            }

            return;
        }

        public void PrintToDosCompleted()
        {
            foreach (ToDo t in todos)
            {
                if (t.IsCompleted)
                {
                    t.Print();
                }
            }
        }

        public void PrintToDosIncompleted()
        {
            foreach (ToDo t in todos)
            {
                if (!t.IsCompleted)
                {
                    t.Print();
                }
            }
        }

        public int GetCompletedToDos()
        {
            int count = 0;
            foreach (var t in todos)
            {
                if (t.IsCompleted)
                {
                    count++;
                }
            }

            return count;
        }

        public int GetIncompletedToDos()
        {
            return todos.Count - GetCompletedToDos();
        }

        public void PrintUser()
        {
            Console.WriteLine($"Total Posts: {posts.Count}");
            Console.WriteLine($"Total Albums: {albums.Count}");
            Console.WriteLine($"Total To-Dos: {todos.Count} | ✔ Completos: {GetCompletedToDos()}");
            Console.WriteLine();
        }


    }
}