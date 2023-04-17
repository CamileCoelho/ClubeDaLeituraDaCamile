using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using System.Drawing;
using System.Threading.Channels;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    public class TelaCaixa : TelaMae
    {
        bool continuar = true;

        RepositorioCaixa repositorioCaixa;

        public TelaCaixa(RepositorioCaixa repositorioCaixa, Validador validador)
        {
            this.repositorioCaixa = repositorioCaixa;
            this.validador = validador;
        }
        
        public void VisualizarTela()
        {
            do
            {
                string opcao = MostrarMenuCaixa();

                switch (opcao)
                {
                    case "5":
                        continuar = false;
                        Console.ResetColor();
                        break;
                    case "1":
                        string cor, etiqueta;
                        ImputCaixa(out cor, out etiqueta);

                        Caixa caixa = new Caixa(cor, etiqueta);
                        string validacao = repositorioCaixa.CadastrarCaixa(caixa);
                        if (validacao == "   Caixa Cadastrada com sucesso!")
                        {
                            ExibirMensagem(validacao, ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem(validacao, ConsoleColor.DarkRed);
                        }
                        continue;
                    case "2":
                        MostarListaCaixas(repositorioCaixa);
                        Console.ReadLine();
                        continue;
                    case "3":
                        Caixa caixaToEdit = repositorioCaixa.SelecionarCaixaPorId(SelecionarIdCaixa(repositorioCaixa));

                        if (caixaToEdit == null)
                        {
                            ExibirMensagem("\n   Caixa não encontrada!", ConsoleColor.DarkRed);
                        }
                        else
                        {
                            ImputCaixa(out cor, out etiqueta);
                            string validacaoEdit = caixaToEdit.Validar(cor, etiqueta);
                            if (validacaoEdit == "REGISTRO_VALIDO")
                            {
                                ExibirMensagem(validacaoEdit, ConsoleColor.DarkGreen);
                            }
                            else
                            {
                                ExibirMensagem(validacaoEdit, ConsoleColor.DarkRed);
                            }

                        }
                        continue;
                    case "4":
                        string validacaoExclusao = repositorioCaixa.ExcluirCaixa(SelecionarIdCaixa(repositorioCaixa), validador);

                        if (validacaoExclusao == "   Caixa excluida com sucesso! ")
                        {
                            ExibirMensagem(validacaoExclusao, ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem(validacaoExclusao , ConsoleColor.DarkRed);

                        }

                        continue;
                }
            } while (continuar) ;

            string MostrarMenuCaixa()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("                                Gestão das caixas!                                ");
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("   Digite:                                                                        ");
                Console.WriteLine();
                Console.WriteLine("   1  - Para cadastrar uma nova caixa.                                            ");
                Console.WriteLine("   2  - Para visualizar suas caixas.                                              ");
                Console.WriteLine("   3  - Para editar as características de uma de suas caixas.                     ");
                Console.WriteLine("   4  - Para descartar uma de suas caixas.                                        ");
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

            void ImputCaixa(out string cor, out string etiqueta)
            {
                Console.Clear();
                Console.Write("\n   Digite a cor da caixa que deseja cadastrar: ");
                cor = Console.ReadLine();
                Console.Write("\n   Digite a etiqueta para essa caixa: ");
                etiqueta = Console.ReadLine();
            }
                        
        }

        public int SelecionarIdCaixa(RepositorioCaixa repositorioCaixa)
        {
            Console.Clear();
            MostarListaCaixas(repositorioCaixa);

            Console.Write("\n   Digite o id da caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        public void MostarListaCaixas(RepositorioCaixa repositorioCaixa)
        {
            Console.Clear();
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                  Lista de Caixas                            ");
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-25}|{2,-35}", "ID ", "  COR ", "  ETIQUETA ");
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();

            foreach (Caixa print in repositorioCaixa.ListarCaixas())
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-35}", print.id, print.cor, print.etiqueta);
                }
            }
        }
    }
} 
