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
    }
}