using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloAmigo;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloRevista;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            Validador validador = new Validador(repositorioCaixa, repositorioAmigo, repositorioRevista, repositorioEmprestimo);

            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa, validador);
            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo, validador);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa,telaCaixa, validador);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioRevista, repositorioAmigo, telaRevista, telaAmigo);

            bool continuar = true;
            PopularCamposParaTeste(repositorioAmigo.ListarAmigos(), repositorioRevista.ListarRevistas(), repositorioCaixa.ListarCaixas());

            do
            {
                string opcao = MostrarMenuPrincipal();

                switch (opcao)
                {
                    case "S":
                        continuar = false;
                        Console.ResetColor();
                        break;
                    case "1":
                        telaCaixa.VisualizarTela();
                        break;
                    case "2":
                        telaRevista.VisualizarTela();
                        break;
                    case "3":
                        telaAmigo.VisualizarTela();
                        break;
                    case "4":
                        telaEmprestimo.VisualizarTela();
                        break;

                }

            } while (continuar);

            string MostrarMenuPrincipal()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("                      Bem-vindo ao Clube da Leitura da Camile!                    ");
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("   Digite:                                                                        ");
                Console.WriteLine();
                Console.WriteLine("   1  - Para gestão de caixa.                                                     ");
                Console.WriteLine("   2  - Para gestão de revistas.                                                  ");
                Console.WriteLine("   3  - Para gestão de amigos.                                                    ");
                Console.WriteLine("   4  - Para gestão de emprestimos.                                               ");
                Console.WriteLine();
                Console.WriteLine("   S  - Para sair.                                                                ");
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.Write("   Opção escolhida: ");
                string opcao = Console.ReadLine().ToUpper();
                bool opcaoValida = opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S";
                while (opcaoValida)
                {
                    if (opcaoValida)
                    {
                        Console.WriteLine("\n   Opção inválida, tente novamente. ");
                        break;
                    }
                }
                return opcao;
            }
        }        
                
        public static void PopularCamposParaTeste(List<Amigo> listaAmigos, List<Revista> listaRevistas, List<Caixa> listaCaixas)
        {
            Amigo amigo = new Amigo("Tales", "Lins", "Rua Anápolis", "49 99999999");
            listaAmigos.Add(amigo);
            Caixa caixa = new Caixa("rosa", "caixa rosa");
            listaCaixas.Add(caixa);
            Revista revista = new Revista("Bátman", "colecao", 1, 2020, caixa);
            listaRevistas.Add(revista);

            Amigo amigo2 = new Amigo("Camile", "Cici", "Av.Luis De C.", "49 99999999");
            listaAmigos.Add(amigo2);
            Caixa caixa2 = new Caixa("azul", "caixa azul");
            listaCaixas.Add(caixa2);
            Revista revista2 = new Revista("Titas", "colecao2", 2, 2018, caixa);
            listaRevistas.Add(revista2);
        }


    }
}