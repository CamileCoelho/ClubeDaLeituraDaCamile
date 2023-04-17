﻿using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloRevista;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    public class TelaRevista : TelaMae
    {
        bool continuar = true;

        RepositorioRevista repositorioRevista;
        RepositorioCaixa repositorioCaixa;
        TelaCaixa telaCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa, TelaCaixa telaCaixa, Validador validador)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;
            this.telaCaixa = telaCaixa;
            this.validador = validador;
        }

        public void VisualizarTela()
        {
            do
            {
                string opcao = MostrarMenuRevista();

                switch (opcao)
                {
                    case "5":
                        continuar = false;
                        Console.ResetColor();
                        break;
                    case "1":
                        string titulo, tipoColecao;
                        int numeroDaEdicao, ano;
                        Caixa caixaToSelect;

                        Console.Clear();
                        Console.Write("\n   Digite o titulo da revista que deseja cadastrar: ");
                        titulo = Console.ReadLine();
                        Console.Write("\n   Digite a coleção dessa revista: ");
                        tipoColecao = Console.ReadLine();
                        Console.Write("\n   Digite numero da edição dessa revista: ");
                        numeroDaEdicao = LerApenasNumero();
                        Console.Write("\n   Digite o ano dessa revista: ");
                        ano = ObterAnoFormatoCorreto();

                        telaCaixa.MostarListaCaixas(repositorioCaixa);

                        caixaToSelect = repositorioCaixa.SelecionarCaixaPorId(telaCaixa.SelecionarIdCaixa(repositorioCaixa));

                        Revista revista = new Revista(titulo, tipoColecao, numeroDaEdicao, ano, caixaToSelect);

                        string validacao = repositorioRevista.CadastrarRevista(revista);

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
                        MostrarListaRevistas(repositorioRevista);
                        Console.ReadLine();
                        continue;
                    case "3":

                        Revista revistaToEdit = repositorioRevista.SelecionarRevistaPorId(SelecionarIdRevista(repositorioRevista));

                        if (revistaToEdit == null)
                        {
                            ExibirMensagem("\n   Caixa não encontrada!", ConsoleColor.DarkRed);
                        }
                        else
                        {
                            string tituloToEdit, tipoColecaoToEdit;
                            int numeroDaEdicaoToEdit, anoToEdit;
                            Caixa caixaToEdit;

                            Console.Clear();
                            Console.Write("\n   Digite o titulo da revista que deseja cadastrar: ");
                            tituloToEdit = Console.ReadLine();
                            Console.Write("\n   Digite a coleção dessa revista: ");
                            tipoColecaoToEdit = Console.ReadLine();
                            Console.Write("\n   Digite numero da edição dessa revista: ");
                            numeroDaEdicaoToEdit = LerApenasNumero();
                            Console.Write("\n   Digite o ano dessa revista: ");
                            anoToEdit = ObterAnoFormatoCorreto();

                            telaCaixa.MostarListaCaixas(repositorioCaixa);

                            caixaToEdit = repositorioCaixa.SelecionarCaixaPorId(telaCaixa.SelecionarIdCaixa(repositorioCaixa));

                            string validacaoEdit = revistaToEdit.Valdiar(tituloToEdit, tipoColecaoToEdit, caixaToEdit);

                            if (validacaoEdit == "REGISTRO_VALIDO")
                            {
                                ExibirMensagem(repositorioRevista.EditarRevista(revistaToEdit, tituloToEdit, tipoColecaoToEdit, numeroDaEdicaoToEdit, anoToEdit, caixaToEdit), ConsoleColor.DarkGreen);
                            }
                            else
                            {
                                ExibirMensagem(validacaoEdit, ConsoleColor.DarkRed);
                            }

                        }
                        continue;
                    case "4":
                        string validacaoExclusao = repositorioRevista.ExcluirRevista(SelecionarIdRevista(repositorioRevista), validador);

                        if (validacaoExclusao == "   Revista excluída com sucesso! ")
                        {
                            ExibirMensagem("   Revista excluída com sucesso! ", ConsoleColor.DarkGreen);
                        }
                        else
                        {
                            ExibirMensagem("   Revista não excluída. ", ConsoleColor.DarkRed);
                        }
                        continue;
                }
            } while (continuar);

            string MostrarMenuRevista()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("                               Gestão de revistas!                                ");
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("   Digite:                                                                        ");
                Console.WriteLine();
                Console.WriteLine("   1  - Para cadastrar uma revista.                                               ");
                Console.WriteLine("   2  - Para visualizar as revistas cadastradas.                                  ");
                Console.WriteLine("   3  - Para editar o cadastro de uma revista.                                    ");
                Console.WriteLine("   4  - Para excluir o cadastro de uma revista.                                   ");
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

        public int SelecionarIdRevista(RepositorioRevista repositorioRevista)
        {
            Console.Clear();
            MostrarListaRevistas(repositorioRevista);
            Console.Write("\n   Digite o id da revista: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        public void MostrarListaRevistas(RepositorioRevista repositorioRevista)
        {
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                               Lista de Revistas                                             ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-14}|{2,-14}|{3,-14}|{4,-12}|{5,-14}|{6,-14}", "ID ", "  TÍTULO ", "  COLEÇÃO ", "  EDIÇÃO ", "    ANO ", "  CAIXA ", "  STATUS ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Revista print in repositorioRevista.ListarRevistas())
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-14}|{2,-14}|{3,-14}|{4,-12}|{5,-14}|{6,-14}", print.id, print.titulo, print.tipoColecao, print.numeroDaEdicao, print.ano, print.caixa.etiqueta, print.disponivel);
                }
            }
        }

        public int LerApenasNumero()
        {
            int numeroDaEdicao = 0;
            while (true)
            {
                Console.Write("\n   Digite numero da edição dessa revista: ");
                string numeroInput = Console.ReadLine();

                if (int.TryParse(numeroInput, out numeroDaEdicao))
                {
                    // Verifica se a entrada do usuário consiste apenas em dígitos numéricos
                    if (numeroInput.All(char.IsDigit))
                    {
                        break;
                    }
                    else
                    {
                        ExibirMensagem("\n   O numero da edição deve conter apenas numeros. Tente novamente. ", ConsoleColor.DarkRed);
                        continue;
                    }
                }
                else
                {
                    ExibirMensagem("\n   O numero da edição deve conter apenas numeros. Tente novamente. ", ConsoleColor.DarkRed);
                    continue;
                }
            }

            return numeroDaEdicao;
        }

        public int ObterAnoFormatoCorreto()
        {
            int ano;

            while (true)
            {
                Console.Write("\n   Digite o ano dessa revista: ");
                string anoInput = Console.ReadLine();

                if (int.TryParse(anoInput, out ano))
                {
                    if (ano >= 1700 && ano <= 2023)
                    {
                        break;
                    }
                    else
                    {
                        ExibirMensagem("\n   O ano deve estar no formato 'aaaa', e ser válido. Tente novamente. ", ConsoleColor.DarkRed);
                        continue;
                    }
                }
                else
                {
                    ExibirMensagem("\n   O ano deve estar no formato 'aaaa', e conter apenas numeros. Tente novamente. ", ConsoleColor.DarkRed);
                    continue;
                }
            }

            return ano;
        }

    }
}