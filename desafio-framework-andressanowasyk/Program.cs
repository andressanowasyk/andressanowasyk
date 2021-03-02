using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Linq;

namespace desafio_framework_andressanowasyk
{
    class Program
    {
        static class Global
        {
            public static string postStr = "posts";
            public static string albumStr = "albums";
            public static string toDoStr = "todos";

        }

        static void Main(string[] args)
        {
            // armazenamento principal
            List<Post> posts = new List<Post>();
            List<Album> albums = new List<Album>();
            List<ToDo> toDos = new List<ToDo>();
            List<User> users = new List<User>();

            // pegando as informações do Json
            GetJsonPlaceHolder(something: Global.postStr,
                                posts: posts,
                                albums: albums,
                                toDos: toDos);
            GetJsonPlaceHolder(something: Global.albumStr,
                                posts: posts,
                                albums: albums,
                                toDos: toDos);
            GetJsonPlaceHolder(something: Global.toDoStr,
                                posts: posts,
                                albums: albums,
                                toDos: toDos);
            string opcaoUsuario;
            do {
                opcaoUsuario = ObterOpcaoUsuario();



                switch (opcaoUsuario) {
                    case "1":
                        // Listar Posts
                        break;

                    case "2":
                        // Listar Albums
                        break;

                    case "3":
                        // Listar ToDos
                        break;

                    case "4":
                        // Listar Usuarios
                        break;

                    case "5":
                        // Listar Post, Album, ToDo por Usuário
                        break;
                    
                    case "6":
                        // Adicionar Post
                        break;

                    case "7":
                        // Adicionar Album
                        break;

                    case "8":
                        // Adicionar ToDo
                        break;

                    case "9":
                        // Adicionar Usuario
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                } 
            } while (opcaoUsuario.ToUpper() != "X");
               
        }

        public static void ListarPosts(List<Post> posts)
        {

        }

        public static bool StrToBool (string str)
        {
            if ((str == "true") || (str == "1") || (str == "True"))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static void InsertJson (JArray jsonArray, string something, List<Post> posts, List<Album> albums, List<ToDo> toDos)
        {
            if (something == Global.postStr)
            {
                for (int i = 0; i < jsonArray.Count(); i++)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());
                    Post p = new Post(id: int.Parse(data["id"].ToString()),
                                      title: data["title"].ToString(),
                                      body: data["body"].ToString());
                    posts.Add(p);
                }

                return;
            }

            if (something == Global.albumStr)
            {
                for (int i = 0; i < jsonArray.Count(); i++)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());
                    Album a = new Album(id: int.Parse(data["id"].ToString()),
                                        title: data["title"].ToString());
                    albums.Add(a);
                }

                return;
            }

            if (something == Global.toDoStr)
            {
                for (int i = 0; i < jsonArray.Count(); i++)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());
                    ToDo t = new ToDo(id: int.Parse(data["id"].ToString()),
                                       title: data["title"].ToString(),
                                       isCompleted: StrToBool(data["completed"].ToString()));
                    toDos.Add(t);
                }

                return;
            }

        }

        public static async void GetJsonPlaceHolder(string something, List<Post> posts, List<Album> albums, List<ToDo> toDos)
        {
            string baseUrl = "https://jsonplaceholder.typicode.com/" + something;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {

                                JArray jsonArray = JArray.Parse(data);
                                //dynamic dado = JObject.Parse(jsonArray[1].ToString());
                                //Console.WriteLine("data ------ {0}", dado["userId"]);
                                InsertJson(jsonArray: jsonArray,
                                           something: something,
                                           posts: posts,
                                           albums: albums,
                                           toDos: toDos);
                            } else
                            {
                                Console.WriteLine("NO Data -----------");
                            }
                        }
                    }

                }
            } catch (Exception exception)
            {
                Console.WriteLine("Exeption Hit -------------");
                Console.WriteLine(exception);
            }
        }

        private static string ObterOpcaoUsuario() {

            //Thread.Sleep(2000);

            Console.WriteLine();
            Console.WriteLine("Desafio FrameWork Padawans 2021");
            Console.WriteLine("May the Force be With You");
            Console.WriteLine("Escolha Sabiamente uma Opção Abaixo");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Todos Posts");
            Console.WriteLine("2 - Listar Todos Albums");
            Console.WriteLine("3 - Listar Todos ToDos");
            Console.WriteLine("4 - Listar Usuários");
            Console.WriteLine("5 - Listar Posts, Albums, ToDos por Usuário");
            Console.WriteLine("6 - Adicionar Posts");
            Console.WriteLine("7 - Adicionar Albums");
            Console.WriteLine("8 - Adicionar ToDos");
            Console.WriteLine("9 - Adicionar Usuario");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        }
    }
}
