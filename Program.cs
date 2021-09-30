using System;

namespace Bob.filmes
{
    class Program
    {
        static FilmesRepositorio repositorio = new FilmesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while ( opcaoUsuario.ToUpper() != "X")
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

            Console.WriteLine("Agradecemos por prestigiar nossoa plataforma.");
            Console.ReadLine();
        }

        private static void ExcluirFilmes()
        {
            Console.Write("Digite o id do filme:");
            int indiceFilmes = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceFilmes);
        }

        private static void VisualizarFilmes()
        {
            Console.Write("Digite o id do filme:");
            int indiceFilmes = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(indiceFilmes);

            Console.WriteLine(filme);
        }

        private static void AtualizarFilmes()
        {
            Console.Write("Digite o id do filme:");
            int indiceFilmes = int.Parse(Console.ReadLine());

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero descrito nas opções existentes:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título de acordo com o gênero escolhido:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do filme:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme:");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilmes = new Filme(id: indiceFilmes,
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
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }    

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirFilmes()
        {
            Console.WriteLine("Inserir novo filme");
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Genero), i));
            }   
            Console.Write("Digite o gênero descrito nas opções existentes:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título de acordo com o gênero escolhido:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do filme:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme:");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novoFilme);                                                        
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao Bob Filmes!");
            Console.WriteLine("Selecione uma opção:");

            Console.WriteLine("1- Listar Filmes");
            Console.WriteLine("2- Inserir novo Filme");
            Console.WriteLine("3- Atualizar Filmes");
            Console.WriteLine("4- Excluir Filmes");
            Console.WriteLine("5- Visualizar Filmes");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        } 
    }      
}