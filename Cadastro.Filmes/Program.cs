using System;

namespace Cadastro.Filmes
{
    class Program
    {
        static FilmesRepositorio repositorio = new FilmesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarFilmes();
                    break;
                    case "2":
                    InserirFilmes();
                    break;
                    case "3":
                    AtualizarFilmes();
                    break;
                    case "4":
                    ExcluirFilmes();
                    break;
                    case "5":
                    VisualizarFilmes();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por ultilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void ExcluirFilmes()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilmes = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceFilmes);
		}

        private static void VisualizarFilmes()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilmes = int.Parse(Console.ReadLine());

			var Filmes = repositorio.RetornaPorId(indiceFilmes);

			Console.WriteLine(Filmes);
		}

        private static void AtualizarFilmes()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilmes = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filmes atualizaFilmes = new Filmes(id: indiceFilmes,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceFilmes, atualizaFilmes);
		}

        private static void ListarFilmes()
        {
            Console.WriteLine("Listar Filmes");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Filme Cadastrado.");
                return;
            }
            foreach (var Filmes in lista)
            {
                var excluido = Filmes.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", Filmes.retornaId(), Filmes.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirFilmes()
		{
			Console.WriteLine("Inserir novo Filme");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filmes novoFilmes = new Filmes(id: repositorio.ProximoId(),
										  genero: (Genero)entradaGenero,
										  titulo: entradaTitulo,
										  ano: entradaAno,
										  descricao: entradaDescricao);

			repositorio.Insere(novoFilmes);
		}

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Cadê Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
