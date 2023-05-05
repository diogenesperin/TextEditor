using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
           Menu(); 
        }

        static void Menu()
        {
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Abrir");
            Console.WriteLine("2 - Editar");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());

            switch(option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }

        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine ("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine (text);    
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (Precione a tecla ESQ para sair)");
            Console.WriteLine("--------------------------------------------------------");
            
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine; //Colocando uma nova linha
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            Salvar(text);

        }

        static void Salvar (string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            //StreamReader // Abrir arquivos
            using (var file = new StreamWriter(path)) // Todo objeto criado aqui, sera aberto e fechado.
            {
                file.Write(text);
            } 

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();

        }
    }
}

