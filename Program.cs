using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoSelecionada = Opcoes();
            
            while(opcaoSelecionada.ToLower() != "x")
            {
                switch(opcaoSelecionada)
                {
                     case "1":
                        ListarSeries();
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
                        VisualizarSerie();
                        break;
                    case "c":
                        Console.Clear();
                        break; 
                }
                Console.ReadKey();
                opcaoSelecionada = Opcoes();

            }

            Console.WriteLine("Saindo...");
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("----- Visualizar Série ------");

            Console.Write("Digite o ID da série: ");
            int indice = int.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(indice);
            Console.WriteLine(serie);
            
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("----- Excluir série ------");

            Console.Write("Digite o ID da série a ser excluida: ");
            int indice = int.Parse(Console.ReadLine());

            repositorio.Exclui(indice); 
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("----- Atualizar série ------");

            Console.Write("Digite o ID da série: ");
            int indice = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            Console.Write("Ano de Início da Série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Descricao: ");
            string descricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)genero,
                                    titulo: titulo,
                                    ano: ano,
                                    descricao: descricao);

            repositorio.Atualiza(indice, atualizaSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string titulo = Console.ReadLine();

            Console.Write("Ano de Início da Série: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Descricao: ");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)genero,
                                    titulo: titulo,
                                    ano: ano,
                                    descricao: descricao);

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                if(!(serie.SerieExcluida()))
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.Id, serie.retornaTitulo());
                }
            }

        }

        private static string Opcoes()
        {
            Console.Clear();
            string opcoes = "", resposta;

            opcoes += "======= SERIES =======\n";
            opcoes += "1 - Listar Series\n";
            opcoes += "2 - Inserir\n";
            opcoes += "3 - Atualizar\n";
            opcoes += "4 - Excluir\n";
            opcoes += "5 - Visualizar Serie\n";
            opcoes += "C - Limpar Tela\n";
            opcoes += "x - Sair\n";

            Console.WriteLine(opcoes);
            resposta = Console.ReadLine();

            return resposta;
        }
    }
}
