using System;

namespace DIO.Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void DeleteSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSeries = int.Parse(Console.ReadLine());

            repository.Delete(indexSeries);
        }

        private static void ViewSeries()
        {
            Console.Write("Digite o id da série: ");
            int indexSeries = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(indexSeries);

            Console.WriteLine(serie);
        }

        private static void UpdateSeries()
        {
            Console.Write("Digite o id da série: ");
            int indexSeries = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entryGenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entryTitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entryYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entryDescription = Console.ReadLine();

            Serie updateSeries = new Serie(id: indexSeries,
                                        genre: (Genre)entryGenre,
                                        title: entryTitle,
                                        year: entryYear,
                                        description: entryDescription);

            repository.Update(indexSeries, updateSeries);
        }
        private static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var excluded = serie.returnDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (excluded ? "*Excluído*" : ""));
            }
        }

        private static void InsertSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entryGenre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entryTitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entryYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entryDescription = Console.ReadLine();

            Serie newSeries = new Serie(id: repository.NextId(),
                                        genre: (Genre)entryGenre,
                                        title: entryTitle,
                                        year: entryYear,
                                        description: entryDescription);

            repository.Insert(newSeries);
        }

        private static string GetUserOption()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("--------------------------------------");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
