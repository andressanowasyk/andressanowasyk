using System;

namespace desafio_framework_andressanowasyk
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
        }

        private static string ObterOpcaoUsuario() {
            
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
