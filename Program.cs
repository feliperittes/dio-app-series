using System;
using DIO.Series.Enum;
using DIO.Series.Classes;
using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series.Classes.EntidadeBase
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = Console.ReadLine().ToUpper();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        private static void ListarSerie()
        {
            System.Console.WriteLine("Listar serie");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma serie cadastrada!");
            }

            foreach (var serie in lista)
            {
                System.Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}: - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite uma Descrição da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }
        private static string ObterOpcaoUsuario()
        {

            System.Console.WriteLine();
            System.Console.WriteLine("DIO series ao seu dispor!");
            System.Console.WriteLine("Informe a opção desejada:");
            System.Console.WriteLine("1 - Listar Series");
            System.Console.WriteLine("2 - Inserir nova Serie");
            System.Console.WriteLine("3 - Atualizar series");
            System.Console.WriteLine("5 -Vizualizar serie");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("x - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}