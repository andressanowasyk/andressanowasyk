// Desafio FrameWork Padawans
// Autora: Andressa Nowasyk
// Criação de uma aplicação para listar postagens, alguns e to-dos vindos da API jsonplaceholder

using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Linq;
using System.Net;

namespace desafio_framework_andressanowasyk
{
    class Program
    {
        static class Global
        {
            public static string postStr = "posts";
            public static string albumStr = "albums";
            public static string toDoStr = "todos";
            public static string adress = "https://jsonplaceholder.typicode.com/";

        }

        static void Main(string[] args)
        {
            // armazenamento principal

            SortedDictionary<int, User> usersMap = new SortedDictionary<int, User>();

            // pegando as informações do Json
            GetJsonPlaceHolder(something: Global.postStr,
                                users: usersMap);
            GetJsonPlaceHolder(something: Global.albumStr,
                                users: usersMap);
            GetJsonPlaceHolder(something: Global.toDoStr,
                                users: usersMap);


            string opcaoUsuario;
            do {
                opcaoUsuario = ObterOpcaoUsuario();



                switch (opcaoUsuario) {
                    case "1":
                        // Listar Posts
                        List(Global.postStr, usersMap);
                        break;

                    case "2":
                        // Listar Albums
                        List(Global.albumStr, usersMap);
                        break;

                    case "3":
                        // Listar ToDos
                        List(Global.toDoStr, usersMap);
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

                    case "X":
                        Console.Clear();
                        Console.WriteLine("Obrigada :)");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                } 
            } while (opcaoUsuario.ToUpper() != "X");
               
        }

        private static void List(string type, SortedDictionary<int, User> usersMap)
        {
            if (type == Global.postStr)
            {
                // listar posts
                foreach (var pair in usersMap)
                {
                    pair.Value.PrintPosts();
                }
                return;
            }

            if (type == Global.albumStr)
            {
                // listar albuns
                foreach (var pair in usersMap)
                {
                    pair.Value.PrintAlbums();
                }
                return;
            }

            if (type == Global.toDoStr)
            {
                // listar to-dos
                foreach (var pair in usersMap)
                {
                    pair.Value.PrintToDos();
                }
                return;
            }
        }

        // se já houver um usuario com id irei retornar o usuario
        // se nao houver, irei adicioná-lo
        public static void AddUser(int id, SortedDictionary<int, User> users)
        {
            User u = new User();
            try
            {
                users.Add(id,u);

            } catch (ArgumentException)
            {
                
            }

        }


        // tratamento do "completed" que aparece nos to-dos
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

        // pegando a informação do JsonPlaceHolder e criando objetos a partir deles
        public static void InsertJson (JArray jsonArray, string something, SortedDictionary<int, User> users)
        {
            if (something == Global.postStr)
            {
                for (int i = 0; i < jsonArray.Count(); i++)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());

                    int userId = int.Parse(data["userId"].ToString());
                    AddUser(userId, users);

                    // aqui eu ja tenho certeza que o usuario existe, entao posso adicionar o post na sua lista
                    Post p = new Post(id: int.Parse(data["id"].ToString()),
                                      title: data["title"].ToString(),
                                      body: data["body"].ToString());

                    users[userId].posts.Add(p);

                }

                return;
            }

            if (something == Global.albumStr)
            {
                for (int i = 0; i < jsonArray.Count(); i++)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());

                    int userId = int.Parse(data["userId"].ToString());
                    AddUser(userId, users);

                    Album a = new Album(id: int.Parse(data["id"].ToString()),
                                        title: data["title"].ToString());

                    users[userId].albums.Add(a);
                }

                return;
            }

            if (something == Global.toDoStr)
            {
                for (int i = 0; i < jsonArray.Count(); i++)
                {
                    dynamic data = JObject.Parse(jsonArray[i].ToString());

                    int userId = int.Parse(data["userId"].ToString());
                    AddUser(userId, users);

                    ToDo t = new ToDo(id: int.Parse(data["id"].ToString()),
                                       title: data["title"].ToString(),
                                       isCompleted: StrToBool(data["completed"].ToString()));

                    users[userId].todos.Add(t);
                }

                return;
            }

        }

        // baixando o arquivo json do JsonPlaceHolder
        public static void GetJsonPlaceHolder(string something, SortedDictionary<int, User> users)
        {
            string jsonStr;
            JArray jsonArray;
            try
            {
                WebClient wc = new WebClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                jsonStr = wc.DownloadString(Global.adress + something);
                jsonArray = JArray.Parse(jsonStr);
                InsertJson(jsonArray: jsonArray,
                           something: something,
                           users: users);

            }
            catch (WebException we)
            {
                Console.WriteLine("Erro ao baixar informações de JsonPlaceHolder");
                Console.WriteLine(we.ToString());
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
