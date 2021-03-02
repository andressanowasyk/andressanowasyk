﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace desafio_framework_andressanowasyk
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario;
            do {
                opcaoUsuario = ObterOpcaoUsuario();

                // armazenamento principal
                List<Post> posts = new List<Post>();
                List<Album> albums = new List<Album>();
                List<ToDo> toDos = new List<ToDo>();
                List<User> users = new List<User>();

                switch (opcaoUsuario) {
                    case "1":
                        // Listar Posts
                        GetSomething("posts");
                        break;

                    case "2":
                        // Listar Albums
                        GetSomething("albums");
                        break;

                    case "3":
                        // Listar ToDos
                        GetSomething("todos");
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

        public static async void GetSomething(string something)
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
                                Console.WriteLine("data ------ {0}", data);
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

            Thread.Sleep(2000);

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
