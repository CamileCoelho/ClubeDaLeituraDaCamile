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
                        if (repositorioRevista.ListarRevistas().Count == 0)
                        {
                            ExibirMensagem("\n   Nenhuma revista cadastrada. " +
                                "\n   Você deve cadastrar uma revista para poder realizar um emprestimo.", ConsoleColor.DarkRed);
                            continue;
                        }
                        if (repositorioAmigo.ListarAmigos().Count == 0)
                        {
                            ExibirMensagem("\n   Nenhum amigo cadastrado. " +
                                "\n   Você deve cadastrar um amigo para poder realizar um emprestimo.", ConsoleColor.DarkRed);
                            continue;
                        }
                        Amigo amigoToSelect = repositorioAmigo.SelecionarAmigoPorId(telaAmigo.SelecionarIdAmigo(repositorioAmigo));

                        Revista revistaToSelect = repositorioRevista.SelecionarRevistaPorId(telaRevista.SelecionarIdRevista(repositorioRevista));

                        string dataInicial = RegistrarDataInicial();

                        Emprestimo emprestimoToAdd = new Emprestimo(amigoToSelect, revistaToSelect, dataInicial);

                        string validacaoCadastro = repositorioEmprestimo.CadastrarEmprestimo(emprestimoToAdd);

                        if (validacaoCadastro == "\n   Emprestimo cadastrado com sucesso!")
                        {
                            ExibirMensagem(validacaoCadastro, ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem(validacaoCadastro, ConsoleColor.DarkRed);
                        }
                        continue;
                    case "2":
                        if (repositorioEmprestimo.ListarEmprestimos().Count == 0)
                        {
                            ExibirMensagem("\n   Nenhum empréstimo cadastrado. " +
                                "\n   Você deve cadastrar um emprestimo para visualizar seus emprestimos em aberto.", ConsoleColor.DarkRed);
                            continue;
                        }
                        foreach (Emprestimo emprestimo in repositorioEmprestimo.ListarEmprestimos())
                        {
                            if (emprestimo.devolucao == " OK ")
                            {
                                ExibirMensagem("\n   Nenhum empréstimo em aberto. ", ConsoleColor.DarkRed);
                                break;
                            }
                        }
                        MostrarListaEmprestimosEmAberto(repositorioEmprestimo);
                        Console.ReadLine();
                        continue;
                    case "3":
                        if (repositorioEmprestimo.ListarEmprestimos().Count == 0)
                        {
                            ExibirMensagem("\n   Nenhum empréstimo cadastrado. " +
                                "\n   Você deve cadastrar um emprestimo para visualizar seus emprestimos. ", ConsoleColor.DarkRed);
                            continue;
                        }
                        MostrarListaEmprestimos(repositorioEmprestimo);
                        Console.ReadLine();
                        continue;
                    case "4":
                        if (repositorioEmprestimo.ListarEmprestimos().Count == 0)
                        {
                            ExibirMensagem("\n   Nenhum empréstimo cadastrado. " +
                                "\n   Você deve cadastrar um emprestimo para editar um emprestimo. ", ConsoleColor.DarkRed);
                            continue;
                        }
                        Console.WriteLine("\n   Obs.: Os campos de Amigo e Revista não podem ser editados. " +
                            "\n   Caso queira alterá-los, apague esse empréstimo e registre um novo.");

                        Emprestimo emprestimoToEdit = repositorioEmprestimo.SelecionarEmprestimoPorId(SelecionarIdEmprestimo(repositorioEmprestimo));
                        
                        string dataInicial2 = RegistrarDataInicial();
                        
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
                        if (repositorioEmprestimo.ListarEmprestimos().Count == 0)
                        {
                            ExibirMensagem("\n   Nenhum empréstimo cadastrado. " +
                                "\n   Você deve cadastrar um emprestimo para excluir um emprestimo. ", ConsoleColor.DarkRed);
                            continue;
                        }
                        string validacaoExclusao = repositorioEmprestimo.ExcluirEmprestimo(SelecionarIdEmprestimo(repositorioEmprestimo), validador);

                        if (validacaoExclusao == "\n   Emprestimo excluido com sucesso!")
                        {
                            ExibirMensagem("\n   Emprestimo excluido com sucesso!", ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem("\n   Empréstimo não excluído. ", ConsoleColor.DarkRed);
                        }
                        continue;
                    case "6":
                        if (repositorioEmprestimo.ListarEmprestimos().Count == 0)
                        {
                            ExibirMensagem("\n   Nenhum empréstimo cadastrado. " +
                                "\n   Você deve cadastrar um emprestimo para realizar uma devolução. ", ConsoleColor.DarkRed);
                            continue;
                        }
                        MostrarListaEmprestimosEmAberto(repositorioEmprestimo);

                        string validacaoDevolucao = repositorioEmprestimo.RealizarDevolucao(SelecionarIdEmprestimo(repositorioEmprestimo));

                        if (validacaoDevolucao == "\n   Revista devolvida com sucesso!")
                        {
                            ExibirMensagem("\n   Revista devolvida com sucesso!", ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem("\n   Revista não devolvida. ", ConsoleColor.DarkRed);
                        }
                        continue;
                    case "7":
                        if (repositorioEmprestimo.ListarEmprestimos().Count == 0)
                        {
                            ExibirMensagem("\n   Nenhum empréstimo cadastrado. " +
                                "\n   Você deve cadastrar um emprestimo para visualizar seus empréstimos desse mês. ", ConsoleColor.DarkRed);
                            continue;
                        }
                        foreach (Emprestimo emprestimo in repositorioEmprestimo.ListarEmprestimos())
                        {
                            DateTime dataAbertura = DateTime.ParseExact(emprestimo.dataInicial, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                            if (dataAbertura.Month == DateTime.Now.Month && emprestimo == null)
                            {
                                ExibirMensagem("\n   Nenhum registro de empréstimo no mês atual. ", ConsoleColor.DarkRed);
                                continue;
                            }
                        }
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
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                ExibirMensagem("\n   Entrada inválida! Digite um número inteiro. ", ConsoleColor.DarkRed);
                Console.Write("\n   Digite o id do emprestimo: ");
            }
            return id;
        }

        public string RegistrarDataInicial()
        {
            string dataInicial = "";
            bool continuar = true;
            while (continuar)
            {
                Console.Write("\n   Digite a data em que foi realizado o empréstimo (dd/mm/aaaa): ");
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
                        ExibirMensagem("\n   Data inválida. Tente novamente.", ConsoleColor.DarkRed);
                    }
                }
                else
                {
                    ExibirMensagem("\n   Data inválida. O formato esperado é dd/mm/aaaa. Tente novamente.", ConsoleColor.DarkRed);
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