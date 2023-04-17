using System.Globalization;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloRevista;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloAmigo;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;
using System.Text.RegularExpressions;
using System.Runtime.ConstrainedExecution;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    public class TelaEmprestimo : TelaMae
    {
        bool continuar = true;

        RepositorioEmprestimo repositorioEmprestimo;
        RepositorioRevista repositorioRevista;
        RepositorioAmigo repositorioAmigo;
        TelaRevista telaRevista; 
        TelaAmigo telaAmigo;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioRevista repositorioRevista, RepositorioAmigo repositorioAmigo, TelaRevista telaRevista, TelaAmigo telaAmigo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
            this.telaRevista = telaRevista; 
            this.telaAmigo = telaAmigo;
        }

        public void VisualizarTela()
        {
            bool continuar = true;

            do
            {
                string opcao = MostrarMenuEmprestimo();

                switch (opcao)
                {
                    case "8":
                        continuar = false;
                        Console.ResetColor();
                        break;
                    case "1":
                        Amigo amigoToSelect = repositorioAmigo.SelecionarAmigoPorId(telaAmigo.SelecionarIdAmigo(repositorioAmigo));

                        Revista revistaToSelect = repositorioRevista.SelecionarRevistaPorId(telaRevista.SelecionarIdRevista(repositorioRevista));

                        string dataInicial = RegistrarDataInicial();

                        Emprestimo emprestimoToAdd = new Emprestimo(amigoToSelect, revistaToSelect, dataInicial);

                        string validacaoCadastro = repositorioEmprestimo.CadastrarEmprestimo(emprestimoToAdd);

                        if (validacaoCadastro == "   Emprestimo cadastrado com sucesso!")
                        {
                            ExibirMensagem(validacaoCadastro, ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem(validacaoCadastro, ConsoleColor.DarkRed);
                        }
                        continue;
                    case "2":
                        MostrarListaEmprestimosEmAberto(repositorioEmprestimo);
                        Console.ReadLine();
                        continue;
                    case "3":
                        MostrarListaEmprestimos(repositorioEmprestimo);
                        Console.ReadLine();
                        continue;
                    case "4":
                        
                        string dataInicial2 = RegistrarDataInicial();

                        Emprestimo emprestimoToEdit = repositorioEmprestimo.SelecionarEmprestimoPorId(SelecionarIdEmprestimo(repositorioEmprestimo));
                        
                        if (emprestimoToEdit == null)
                        {
                            ExibirMensagem("\n   Emprestimo não encontrado!", ConsoleColor.DarkRed);
                        }
                        else
                        {
                            ExibirMensagem(repositorioEmprestimo.EditarEmprestimo(emprestimoToEdit, dataInicial2), ConsoleColor.DarkGreen);
                        }
                        continue;
                    case "5":
                        string validacaoExclusao = repositorioEmprestimo.ExcluirEmprestimo(SelecionarIdEmprestimo(repositorioEmprestimo), validador);

                        if (validacaoExclusao == "   Empréstimo excluído com sucesso! ")
                        {
                            ExibirMensagem("   Empréstimo excluído com sucesso! ", ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem("   Empréstimo não excluído. ", ConsoleColor.DarkRed);
                        }
                        continue;
                    case "6":
                        MostrarListaEmprestimosEmAberto(repositorioEmprestimo);

                        if (repositorioEmprestimo.RealizarDevolucao(SelecionarIdEmprestimo(repositorioEmprestimo)) == "   Revista devolvida com sucesso! ")
                        {
                            ExibirMensagem("   Revista devolvida com sucesso! ", ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem("   Revista não devolvida. ", ConsoleColor.DarkRed);
                        }
                        continue;
                    case "7":
                        MostrarListaEmprestimosMes(repositorioEmprestimo);
                        Console.ReadLine();
                        continue;


                }
            } while (continuar);

        string MostrarMenuEmprestimo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                              Gestão de Emprestimos!                              ");
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("   Digite:                                                                        ");
            Console.WriteLine();
            Console.WriteLine("   1  - Para realizar um empréstimo.                                              ");
            Console.WriteLine("   2  - Para visualizar os empréstimos em aberto.                                 ");
            Console.WriteLine("   3  - Para visualizar todos os empréstimos já realizados.                       ");
            Console.WriteLine("   4  - Para editar um empréstimo.                                                ");
            Console.WriteLine("   5  - Para excluir um empréstimo.                                               ");
            Console.WriteLine();
            Console.WriteLine("   6  - Para realizar uma devolução.                                              ");
            Console.WriteLine();
            Console.WriteLine("   7  - Para visualizar o registro de empréstimos realizados no mês atual.        ");
            Console.WriteLine();
            Console.WriteLine("   8  - Para voltar ao menu principal.                                            ");
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine();
            Console.Write("   Opção escolhida: ");
            string opcao = Console.ReadLine().ToUpper();
            bool opcaoValida = opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6"
                && opcao != "7" && opcao != "8";
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

        public int SelecionarIdEmprestimo(RepositorioEmprestimo repositorioEmprestimo)
        {
            Console.Clear();
            MostrarListaEmprestimosEmAberto(repositorioEmprestimo);
            Console.Write("\n   Digite o id do emprestimo: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        public string RegistrarDataInicial()
        {
            string dataInicial = "";
            bool continuar = true;
            while (continuar)
            {
                Console.Write("   Digite a data em que foi realizado o empréstimo (dd/mm/aaaa): ");
                dataInicial = Console.ReadLine();

                Regex regex = new Regex(@"^(\d{2})/(\d{2})/(\d{4})$");
                Match match = regex.Match(dataInicial);

                if (match.Success)
                {
                    int dia = int.Parse(match.Groups[1].Value);
                    int mes = int.Parse(match.Groups[2].Value);
                    int ano = int.Parse(match.Groups[3].Value);

                    DateTime data;
                    bool dataValida = DateTime.TryParseExact(dataInicial, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data);

                    if (dataValida && data >= DateTime.Today)
                    {
                        continuar = false;
                    }
                    else if (dia >= 1 && dia <= 31 && mes >= 1 && mes <= 12 && ano >= 1900 && ano <= 2023)
                    {
                        continuar = false;
                    }
                    else
                    {
                        ExibirMensagem("   Data inválida. Tente novamente.", ConsoleColor.DarkRed);
                    }
                }
                else
                {
                    ExibirMensagem("   Data inválida. O formato esperado é dd/mm/aaaa. Tente novamente.", ConsoleColor.DarkRed);
                }
            }

            return dataInicial;
        }

        public void MostrarListaEmprestimos(RepositorioEmprestimo repositorioEmprestimo)
        {
            Console.Clear();
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                                    Lista de Empréstimos                                     ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", "ID ", "  NOME DO AMIGO ", "  TÍTULO DA REVISTA ", "  DATA INICIAL ", "  DEVOLUÇÃO ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Emprestimo print in repositorioEmprestimo.ListarEmprestimos())
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", print.id, print.amigo.nome, print.revista.titulo, print.dataInicial, print.devolucao);
                }
            }
        }

        public void MostrarListaEmprestimosEmAberto(RepositorioEmprestimo repositorioEmprestimo)
        {
            Console.Clear();
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                              Lista de Empréstimos em Aberto                                 ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-25}", "ID ", "  NOME DO AMIGO ", "  TÍTULO DA REVISTA ", "  DATA INICIAL ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Emprestimo print in repositorioEmprestimo.ListarEmprestimos())
            {
                if (print != null && print.devolucao == " PENDENTE ")
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-25}", print.id, print.amigo.nome, print.revista.titulo, print.dataInicial);
                }
            }
        }

        public void MostrarListaEmprestimosMes(RepositorioEmprestimo repositorioEmprestimo)
        {
            Console.Clear();
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                                    Lista de Empréstimos                                     ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", "ID ", "  NOME DO AMIGO ", "  TÍTULO DA REVISTA ", "  DATA INICIAL ", "  DEVOLUÇÃO ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Emprestimo print in repositorioEmprestimo.ListarEmprestimos())
            {
                DateTime dataAbertura = DateTime.ParseExact(print.dataInicial, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (dataAbertura.Month == DateTime.Now.Month && print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", print.id, print.amigo.nome, print.revista.titulo, print.dataInicial, print.devolucao);
                }
            }
        }

    }
}