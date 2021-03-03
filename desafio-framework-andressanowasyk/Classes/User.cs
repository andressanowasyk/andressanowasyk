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
            //int i = 0;
            foreach (ToDo t in todos)
            {
                t.Print();
                //i++;
                //if (!WannaContinue(i, 5))
                //{
                //    break;
                //}
            }

            return;
        }

        //// verifica se quer continuar a cada qtde que o i atinge
        //private static bool WannaContinue(int i, int qtde)
        //{
        //    if (i % qtde == 0)
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine("X para sair, Qualquer tecla para continuar");
        //        Console.WriteLine();
        //        //ConsoleKeyInfo key = Console.ReadKey(true);
        //        if (Console.ReadKey().Key == ConsoleKey.X)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }

        //    }

        //    return true;
        //}
    }
}