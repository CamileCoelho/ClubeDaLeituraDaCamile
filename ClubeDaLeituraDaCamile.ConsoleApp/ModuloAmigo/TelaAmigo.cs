using ClubeDaLeituraDaCamile.ConsoleApp.ModuloAmigo;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    public class TelaAmigo : TelaMae
    {
        bool continuar = true;

        RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repositorioAmigo, Validador validador)
        {
            this.repositorioAmigo = repositorioAmigo;
            this.validador = validador;
        }

        public void VisualizarTela()
        {
            do
            {
                string opcao = MostrarMenuAmigo();

                switch (opcao)
                {
                    case "5":
                        continuar = false;
                        Console.ResetColor();
                        break;
                    case "1":
                        Cadastrar();
                        continue;
                    case "2":
                        Visualizar();
                        continue;
                    case "3":
                        Editar();
                        continue;
                    case "4":
                        Excluir();
                        continue;
                }
            } while (continuar);

            string MostrarMenuAmigo()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("                                Gestão de Amigos!                                 ");
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("   Digite:                                                                        ");
                Console.WriteLine();
                Console.WriteLine("   1  - Para cadastrar um novo amigo.                                             ");
                Console.WriteLine("   2  - Para visualizar os amigos já cadastrados.                                 ");
                Console.WriteLine("   3  - Para editar o cadastro de um amigo.                                       ");
                Console.WriteLine("   4  - Para excluir o cadastro de um amigo.                                      ");
                Console.WriteLine();
                Console.WriteLine("   5  - Para voltar ao menu principal.                                            ");
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.Write("   Opção escolhida: ");
                string opcao = Console.ReadLine().ToUpper();
                bool opcaoValida = opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5";
                while (opcaoValida)
                {
                    if (opcaoValida)
                    {
                        ExibirMensagem("\n   Opção inválida, tente novamente. ", ConsoleColor.DarkRed);
                        break;
                    }
                }
                return opcao;
            }
        }

        private void Cadastrar()
        {
            string nome, nomeResponsavel, endereco, numeroParaContato;
            Imput(out nome, out nomeResponsavel, out endereco, out numeroParaContato);

            Amigo amigo = new Amigo(nome, nomeResponsavel, endereco, numeroParaContato);

            string validacaoAmigoAdd = repositorioAmigo.CadastrarAmigo(amigo);

            if (validacaoAmigoAdd == "\n   Amigo cadastrado com Sucesso!")
            {
                ExibirMensagem(validacaoAmigoAdd, ConsoleColor.DarkGreen);
            }
            else
            {
                ExibirMensagem(validacaoAmigoAdd, ConsoleColor.DarkRed);
            }
        }

        private void Visualizar()
        {
            if (repositorioAmigo.ListarAmigos().Count == 0)
            {
                ExibirMensagem("\n   Nenhum amigo cadastrado. " +
                    "\n   Você deve cadastrar um amigo para poder editar o cadastro de um amigo. ", ConsoleColor.DarkRed);
                return;
            }
            MostrarListaAmigos(repositorioAmigo);
            Console.ReadLine();
        }

        private void Editar()
        {
            if (repositorioAmigo.ListarAmigos().Count == 0)
            {
                ExibirMensagem("\n   Nenhum amigo cadastrado. " +
                    "\n   Você deve cadastrar um amigo para poder visualizar seus amigos cadastrados. ", ConsoleColor.DarkRed);
                return;
            }
            Amigo amigoToEdit = repositorioAmigo.SelecionarAmigoPorId(SelecionarIdAmigo(repositorioAmigo));

            if (amigoToEdit == null)
            {
                ExibirMensagem("\n   Amigo não encontrado!", ConsoleColor.DarkRed);
            }
            else
            {
                string nome, nomeResponsavel, endereco, numeroParaContato;
                Imput(out nome, out nomeResponsavel, out endereco, out numeroParaContato);
                string validacao = amigoToEdit.Validar(nome, nomeResponsavel, endereco, numeroParaContato);
                
                if (validacao == "REGISTRO_REALIZADO")
                {
                    repositorioAmigo.EditarAmigo(amigoToEdit, nome, nomeResponsavel, endereco, numeroParaContato);
                    ExibirMensagem(validacao, ConsoleColor.DarkGreen);
                }
                else
                {
                    ExibirMensagem(validacao, ConsoleColor.DarkRed);
                }
            }
        }

        private void Excluir()
        {
            if (repositorioAmigo.ListarAmigos().Count == 0)
            {
                ExibirMensagem("\n   Nenhum amigo cadastrado. " +
                    "\n   Você deve cadastrar um amigo para poder excluir o cadastro de um amigo. ", ConsoleColor.DarkRed);
                return;
            }
            string validacaoExclusao = repositorioAmigo.ExcluirAmigo(SelecionarIdAmigo(repositorioAmigo), validador);

            if (validacaoExclusao == "\n   Amigo excluido com sucesso! ")
            {
                ExibirMensagem(validacaoExclusao, ConsoleColor.DarkGreen);
            }
            else
            {
                ExibirMensagem(validacaoExclusao, ConsoleColor.DarkRed);
            }
        }

        public void Imput(out string nome, out string nomeResponsavel, out string endereco, out string numeroParaContato)
        {
            Console.Clear();
            Console.Write("\n   Digite o nome do amigo que deseja cadastrar: ");
            nome = Console.ReadLine();
            Console.Write("\n   Digite o nome do responsável desse amigo: ");
            nomeResponsavel = Console.ReadLine();
            Console.Write("\n   Digite o endereço desse amigo: ");
            endereco = Console.ReadLine();
            Console.Write("\n   Digite o telefone desse amigo (XX)XXXXX-XXXX: ");
            numeroParaContato = Console.ReadLine();

        }

        public int SelecionarIdAmigo(RepositorioAmigo repositorioAmigo)
        {
            Console.Clear();
            MostrarListaAmigos(repositorioAmigo);

            Console.Write("\n   Digite o id do amigo: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                ExibirMensagem("\n   Entrada inválida! Digite um número inteiro. ", ConsoleColor.DarkRed);
                Console.Write("\n   Digite o id do amigo: ");
            }
            return id;
        }

        public void MostrarListaAmigos(RepositorioAmigo repositorioAmigo)
        {
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                                    Lista de Amigos                                          ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-30}|{2,-30}|{3,-30}", "ID ", "  NOME ", "  RESPONSÁVEL ", "  TELEFONE ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Amigo print in repositorioAmigo.ListarAmigos())
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-30}|{2,-30}|{3,-30}", print.id, print.nome, print.nomeResponsavel, print.numeroParaContato);
                }
            }
        }
    }
}