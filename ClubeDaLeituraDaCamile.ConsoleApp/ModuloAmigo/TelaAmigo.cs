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
                        string nome, nomeResponsavel, endereco, numeroParaContato;
                        ImputAmigo(out nome, out nomeResponsavel, out endereco, out numeroParaContato);

                        Amigo amigo = new Amigo(nome, nomeResponsavel, endereco, numeroParaContato);

                        if (repositorioAmigo.CadastrarAmigo(amigo) == "   Amigo cadastrado com sucesso!")
                        {
                            ExibirMensagem("   Amigo cadastrado com sucesso!", ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem("   Amigo não cadastrado. ", ConsoleColor.DarkRed);
                        }
                        continue;
                    case "2":
                        MostrarListaAmigos(repositorioAmigo);
                        Console.ReadLine();
                        continue;
                    case "3":
                        Amigo amigoToEdit = repositorioAmigo.SelecionarAmigoPorId(SelecionarIdAmigo(repositorioAmigo));

                        if (amigoToEdit == null)
                        {
                            ExibirMensagem("\n   Amigo não encontrado!", ConsoleColor.DarkRed);
                        }
                        else
                        {
                            ImputAmigo(out nome, out nomeResponsavel, out endereco, out numeroParaContato);
                            string validacao = amigoToEdit.Valdiar(nome, nomeResponsavel, endereco, numeroParaContato);
                            if (validacao == "REGISTRO_VALIDO")
                            {
                                ExibirMensagem(validacao, ConsoleColor.DarkGreen);
                            }
                            else
                            {
                                ExibirMensagem(validacao, ConsoleColor.DarkRed);
                            }

                        }
                        continue;
                    case "4":
                        string validacaoExclusao = repositorioAmigo.ExcluirAmigo(SelecionarIdAmigo(repositorioAmigo), validador);

                        if (validacaoExclusao == "   Amigo excluido com sucesso! ")
                        {
                            ExibirMensagem("   Amigo excluido com sucesso! ", ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem("   Amigo não excluido. ", ConsoleColor.DarkRed);
                        }

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

            void ImputAmigo(out string nome, out string nomeResponsavel, out string endereco, out string numeroParaContato)
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


        }

        public int SelecionarIdAmigo(RepositorioAmigo repositorioAmigo)
        {
            Console.Clear();
            MostrarListaAmigos(repositorioAmigo);

            Console.Write("\n   Digite o id do amigo: ");
            int id = Convert.ToInt32(Console.ReadLine());
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