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
            public static string commandNotFound = "Comando não encontrado. Tente Novamente.";
            public static string userNotFound = "Usuário não encontrado.";

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
                        ListUsers(usersMap);
                        break;

                    case "5":
                        // Listar Post, Album, ToDo por Usuário
                        ListByUser(usersMap);
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    case "X":
                        Console.Clear();
                        Console.WriteLine("Obrigada :)");
                        break;

                    default:
                        Console.WriteLine(Global.commandNotFound);
                        break;
                } 
            } while (opcaoUsuario.ToUpper() != "X");
               
        }

        private static void ListSomethingByUser(User user)
        {
            bool unkownCommand = false;
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine();
                Console.WriteLine("O que deseja listar?");
                Console.WriteLine("1 - Posts");
                Console.WriteLine("2 - Albums");
                Console.WriteLine("3 - To-Dos");
                Console.WriteLine("4 - Apenas To-Dos Completos");
                Console.WriteLine("5 - Apenas To-Dos Não Completos");
                Console.WriteLine("6 - Voltar");
                cki = Console.ReadKey();

                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        // Listar Posts
                        Console.WriteLine();
                        user.PrintPosts();
                        break;

                    case ConsoleKey.D2:
                        // Listar Albums
                        Console.WriteLine();
                        user.PrintAlbums();
                        break;

                    case ConsoleKey.D3:
                        // Listar To-Dos
                        Console.WriteLine();
                        user.PrintToDos();
                        break;

                    case ConsoleKey.D4:
                        // Listar To-Dos Completos
                        Console.WriteLine();
                        user.PrintToDosCompleted();
                        break;

                    case ConsoleKey.D5:
                        // Listar To-Dos Incompletos
                        Console.WriteLine();
                        user.PrintToDosIncompleted();
                        break;

                    case ConsoleKey.D6:
                        // Voltar para o Menu Principal
                        unkownCommand = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine(Global.commandNotFound);
                        break;
                }
            } while (!unkownCommand);

            return;

        }




        private static void SimpleUserList (SortedDictionary<int, User> usersMap)
        {
            Console.WriteLine("Usuarios Disponíveis: ");
            foreach (var pair in usersMap)
            {
                Console.Write(pair.Key + " | ");
            }
            Console.WriteLine();
        }


        private static void ListByUser(SortedDictionary<int, User> usersMap)
        {
            SimpleUserList(usersMap);

            Console.WriteLine("Qual usuário deseja Listar?");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            if (DoesUserExists(int.Parse(opcaoUsuario), usersMap))
            {
                usersMap[int.Parse(opcaoUsuario)].PrintUser();
                ListSomethingByUser(usersMap[int.Parse(opcaoUsuario)]);

            } else {
                Console.WriteLine(Global.userNotFound);
                Thread.Sleep(500);
            }

        }

        private static bool DoesUserExists (int id, SortedDictionary<int, User> usersMap)
        {
            bool exists = false;
            foreach (var pair in usersMap)
            {
                if (pair.Key == id)
                {
                    exists = true;
                }
            }

            return exists;
        }

        private static void ListUsers(SortedDictionary<int, User> usersMap)
        {
            Console.WriteLine();
            foreach(var pair in usersMap)
            {
                Console.WriteLine($"User {pair.Key}");
                pair.Value.PrintUser();
            }
        }



        // listagem de post, album e to-dos
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
            Console.WriteLine("Autora: Andressa Nowasyk");
            Console.WriteLine("Escolha Sabiamente uma Opção Abaixo");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Todos Posts");
            Console.WriteLine("2 - Listar Todos Albums");
            Console.WriteLine("3 - Listar Todos ToDos");
            Console.WriteLine("4 - Listar Usuários");
            Console.WriteLine("5 - Listar Posts, Albums, ToDos por Usuário");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        }
    }
}
