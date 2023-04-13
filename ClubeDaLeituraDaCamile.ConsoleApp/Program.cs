using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    internal class Program
    {          
        static bool continuar = true;
        static void Main(string[] args)
        {
            List<Emprestimo> listaEmprestimos = new List<Emprestimo>();
            List<Caixa> listaCaixas = new List<Caixa>();
            List<Revista> listaRevistas = new List<Revista>();
            List<Amigo> listaAmigos = new List<Amigo>();

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
                        CadastrarCaixa(listaCaixas);
                        break;
                    case "2":
                        Console.Clear();
                        MostrarListaCaixa(listaCaixas);
                        Console.ReadLine();
                        break;
                    case "3":
                        EditararCaixa(listaCaixas);
                        break;
                    case "4":
                        ExcluirCaixa(listaCaixas);
                        break;
                    case "5":
                        CadastrarRevista(listaRevistas, listaCaixas);
                        break;
                    case "6":
                        Console.Clear();
                        MostrarListaRevistas(listaRevistas);
                        Console.ReadLine();
                        break;
                    case "7":
                        EditarRevista(listaRevistas, listaCaixas);
                        break;
                    case "8":
                        ExcluirRevista(listaRevistas, listaCaixas);
                        break;
                    case "9":
                        CadastrarAmigo(listaAmigos);
                        break;
                    case "10":
                        Console.Clear();
                        MostrarListaAmigos(listaAmigos);
                        Console.ReadLine();
                        break;
                    case "11":
                        EdiatrAmigo(listaAmigos);
                        break;
                    case "12":
                        ExcluirAmigo(listaAmigos);
                        break;
                    case "13":
                        RealizarEmprestimo(listaAmigos,listaRevistas,listaEmprestimos);
                        break;
                    case "14":
                        Console.Clear();
                        MostrarListaEmprestimosEmAberto(listaEmprestimos);
                        Console.ReadLine();
                        break;
                    case "15":
                        Console.Clear();
                        MostrarListaEmprestimos(listaEmprestimos);
                        Console.ReadLine();
                        break;
                    case "16":
                        EditarEmprestimo(listaAmigos, listaRevistas, listaEmprestimos);
                        break;
                    case "17":
                        ExcluirEmprestimo(listaEmprestimos);
                        break;
                    case "18":
                        DevolverRevista(listaAmigos, listaRevistas, listaEmprestimos);
                        break;
                    case "19":
                        Console.Clear();
                        MostrarListaEmprestimosMes(listaEmprestimos);
                        Console.ReadLine();
                        break;
                }

            } while (continuar);
        }
        private static void DevolverRevista(List<Amigo> listaAmigos, List<Revista> listaRevistas, List<Emprestimo> listaEmprestimos)
        {
            Console.Clear();
            MostrarListaEmprestimosEmAberto(listaEmprestimos);
            Console.Write("\n   Digite o id do emprestimo que deseja encerrar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Emprestimo emprestimoEnd in listaEmprestimos)
            {
                if (emprestimoEnd.id == id)
                {
                    Emprestimo emprestimo = emprestimoEnd;

                    emprestimoEnd.RealizarDevolucao(emprestimo.nomeAmigo, emprestimo.tituloRevista, emprestimo.dataInicial);

                    break;
                }
            }

            Console.Clear();
            ExibirMensagem("\n   Revista devolvida com Sucesso! ", ConsoleColor.DarkGreen);
            Console.WriteLine();
            MostrarListaEmprestimos(listaEmprestimos);
            Console.ReadLine();
        }

        private static void MostrarListaEmprestimos(List<Emprestimo> listaEmprestimos)
        {
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                                    Lista de Empréstimos                                     ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", "ID ", "  NOME DO AMIGO ", "  TÍTULO DA REVISTA ", "  DATA INICIAL ", "  DEVOLUÇÃO ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Emprestimo print in listaEmprestimos)
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", print.id, print.nomeAmigo, print.tituloRevista, print.dataInicial, print.devolucao);
                }
            }
        }

        private static void MostrarListaEmprestimosEmAberto(List<Emprestimo> listaEmprestimos)
        {
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                              Lista de Empréstimos em Aberto                                 ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-25}", "ID ", "  NOME DO AMIGO ", "  TÍTULO DA REVISTA ", "  DATA INICIAL "); 
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Emprestimo print in listaEmprestimos)
            {
                if (print != null && print.devolucao == " PENDENTE " )
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-25}", print.id, print.nomeAmigo, print.tituloRevista, print.dataInicial);
                }
            }
        }

        private static void MostrarListaEmprestimosMes(List<Emprestimo> listaEmprestimos)
        {
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                                    Lista de Empréstimos                                     ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", "ID ", "  NOME DO AMIGO ", "  TÍTULO DA REVISTA ", "  DATA INICIAL ", "  DEVOLUÇÃO ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Emprestimo print in listaEmprestimos)
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", print.id, print.nomeAmigo, print.tituloRevista, print.dataInicial, print.devolucao);
                }
            }
        }

        private static void RealizarEmprestimo(List<Amigo> listaAmigos, List<Revista> listaRevistas, List<Emprestimo> listaEmprestimos)
        {
            Console.Clear();
            MostrarListaAmigos(listaAmigos);
            Console.Write("\n   Digite o id do Amigo que deseja realizar um empréstimo: ");
            int idAmigoEscolhido = int.Parse(Console.ReadLine());

            Amigo amigoEscolhido = SelecionarAmigoPorID(listaAmigos, idAmigoEscolhido);

            string nomeAmigo = amigoEscolhido.nome;

            MostrarListaRevistas(listaRevistas);
            Console.Write("\n   Digite o id da Revista que deseja emprestar: ");
            int idRevistaEscolhida = int.Parse(Console.ReadLine());

            Revista revistaEscolhida = SelecionarRevistaPorID(listaRevistas, idRevistaEscolhida);

            string tituloRevista = revistaEscolhida.titulo;

            Console.Write("\n   Digite a data em que foi realizado o empréstimo: ");
            int dataInicial = int.Parse(Console.ReadLine()); //----------------------------------------------------------------------------- verificacao formato data ---------------------------------

            Emprestimo emprestimo = new Emprestimo(nomeAmigo, tituloRevista, dataInicial);

            listaEmprestimos.Add(emprestimo);

            Console.Clear();
            MostrarListaEmprestimosEmAberto(listaEmprestimos);
            ExibirMensagem("\n   Empréstimo realizado com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        private static void EditarEmprestimo(List<Amigo> listaAmigos, List<Revista> listaRevistas, List<Emprestimo> listaEmprestimos)
        {
            Console.Clear();
            MostrarListaEmprestimosEmAberto(listaEmprestimos);
            Console.Write("\n   Digite o id do emprestimo que deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Emprestimo emprestimoEdit in listaEmprestimos)
            {
                if (emprestimoEdit.id == id)
                {
                    Console.Clear();
                    MostrarListaAmigos(listaAmigos);
                    Console.Write("\n   Digite o id do Amigo que deseja realizar um empréstimo: ");
                    int idAmigoEscolhido = int.Parse(Console.ReadLine());

                    Amigo amigoEscolhido = SelecionarAmigoPorID(listaAmigos, idAmigoEscolhido);

                    string nomeAmigo = amigoEscolhido.nome;

                    MostrarListaRevistas(listaRevistas);
                    Console.Write("\n   Digite o id da Revista que deseja emprestar: ");
                    int idRevistaEscolhida = int.Parse(Console.ReadLine());

                    Revista revistaEscolhida = SelecionarRevistaPorID(listaRevistas, idRevistaEscolhida);

                    string tituloRevista = revistaEscolhida.titulo;

                    Console.Write("\n   Digite a data em que foi realizado o empréstimo: ");
                    int dataInicial = int.Parse(Console.ReadLine());

                    emprestimoEdit.EditarEmprestimo(nomeAmigo, tituloRevista, dataInicial);

                    break;
                }
            }
            Console.Clear();
            MostrarListaEmprestimosEmAberto(listaEmprestimos);
            ExibirMensagem("\n   Empréstimo editado com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        private static void ExcluirEmprestimo(List<Emprestimo> listaEmprestimos)
        {
            Console.Clear();
            MostrarListaEmprestimosEmAberto(listaEmprestimos);
            Console.Write("\n   Digite o id do emprestimo que deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Emprestimo emprestimoRemove in listaEmprestimos)
            {
                if (emprestimoRemove.id == id)
                {
                    listaEmprestimos.Remove(emprestimoRemove);

                    break;
                }
            }
            Console.Clear();
            MostrarListaEmprestimosEmAberto(listaEmprestimos);
            ExibirMensagem("\n   Empréstimo excluído com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        private static void MostrarListaRevistas(List<Revista> listaRevistas)
        {
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                               Lista de Revistas                                             ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}", "ID ", "  TÍTULO ", "  COLEÇÃO ", "  EDIÇÃO ", "  ANO ", "  CAIXA ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Revista print in listaRevistas)
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}", print.id, print.titulo, print.tipoColecao, print.numeroDaEdicao, print.ano, print.etiqueta);
                }
            }
        }

        private static void CadastrarRevista(List<Revista> listaRevistas, List<Caixa> listaCaixas)
        {
            Console.Clear();
            Console.Write("\n   Digite o titulo da revista que deseja cadastrar: ");
            string titulo = Console.ReadLine();
            Console.Write("\n   Digite a coleção dessa revista: ");
            string tipoColecao = Console.ReadLine();
            Console.Write("\n   Digite numero da edição dessa revista: ");
            int numeroDaEdicao = int.Parse(Console.ReadLine());
            Console.Write("\n   Digite o ano dessa revista: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine();
            MostrarListaCaixa(listaCaixas);
            Console.Write("\n   Digite o id da caixa que deseja colocar essa revista: ");
            int idcaixaEscolhida = int.Parse(Console.ReadLine());
            
            Caixa caixaEscolhida = SelecionarCaixaPorID(listaCaixas, idcaixaEscolhida);

            string etiqueta = caixaEscolhida.etiqueta;

            Revista revista = new Revista(titulo, tipoColecao, numeroDaEdicao, ano, etiqueta);

            listaRevistas.Add(revista);

            Console.Clear();
            MostrarListaRevistas(listaRevistas);
            ExibirMensagem("\n   Revista cadastrada com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        public static void EditarRevista(List<Revista> listaRevistas, List<Caixa> listaCaixas)
        {
            Console.Clear();
            MostrarListaRevistas(listaRevistas);
            Console.Write("\n   Digite o id da revista que deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Revista revistaEditada in listaRevistas)
            {
                if (revistaEditada.id == id)
                {
                    Console.Write("\n   Digite o titulo da revista que deseja editar: ");
                    string titulo = Console.ReadLine();
                    Console.Write("\n   Digite a coleção dessa revista: ");
                    string tipoColecao = Console.ReadLine();
                    Console.Write("\n   Digite numero da edição dessa revista: ");
                    int numeroDaEdicao = int.Parse(Console.ReadLine());
                    Console.Write("\n   Digite o ano dessa revista: ");
                    int ano = int.Parse(Console.ReadLine());

                    Console.Write("\n   Digite o id da caixa que deseja colocar essa revista: ");
                    MostrarListaCaixa(listaCaixas);
                    int idcaixaEscolhida = int.Parse(Console.ReadLine());

                    Caixa caixaEscolhida = SelecionarCaixaPorID(listaCaixas, idcaixaEscolhida);

                    string etiqueta = caixaEscolhida.etiqueta;

                    revistaEditada.EditarRevista(titulo, tipoColecao, numeroDaEdicao, ano, etiqueta);

                    break;
                }
            }
            Console.Clear();
            MostrarListaRevistas(listaRevistas);
            ExibirMensagem("\n   Revista editda com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();

        }

        public static void ExcluirRevista(List<Revista> listaRevistas, List<Caixa> listaCaixas)
        {
            Console.Clear();
            MostrarListaRevistas(listaRevistas);

            Console.Write("\n   Digite o id da revista que deseja exclir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Revista revistaExcluída in listaRevistas)
            {
                if (revistaExcluída.id == id)
                {
                    listaRevistas.Remove(revistaExcluída);

                    break;
                }
            }
            Console.Clear();
            MostrarListaRevistas(listaRevistas);
            ExibirMensagem("\n   Revista excluída com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        private static void MostrarListaAmigos(List<Amigo> listaAmigos)
        {
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                                    Lista de Amigos                                          ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-30}|{2,-30}|{3,-30}", "ID ", "  NOME ", "  RESPONSÁVEL ", "  TELEFONE ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Amigo print in listaAmigos)
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-30}|{2,-30}|{3,-30}", print.id, print.nome, print.nomeResponsavel, print.numeroParaContato); 
                }
            }
        }

        private static void CadastrarAmigo(List<Amigo> listaAmigos)
        {
            Console.Clear();
            Console.Write("\n   Digite o nome do amigo que deseja cadastrar: ");
            string nome = Console.ReadLine();
            Console.Write("\n   Digite o nome do responsável desse amigo: ");
            string nomeResponsavel = Console.ReadLine();
            Console.Write("\n   Digite o endereço desse amigo: ");
            string endereco = Console.ReadLine();
            Console.Write("\n   Digite o telefone desse amigo: ");
            string numeroParaContato = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeResponsavel, endereco, numeroParaContato, false);

            listaAmigos.Add(amigo);
            Console.Clear();
            MostrarListaAmigos(listaAmigos);
            ExibirMensagem("\n   Amigo cadastrado com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        public static void EdiatrAmigo(List<Amigo> listaAmigos)
        {
            Console.Clear();
            MostrarListaAmigos(listaAmigos);

            Console.Write("\n   Digite o id do amigo que deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Amigo amigoEditado in listaAmigos)
            {
                if (amigoEditado.id == id)
                {
                    Console.Write("\n   Digite o nome do amigo que deseja editar: ");
                    string nome = Console.ReadLine();
                    Console.Write("\n   Digite o nome do responsável desse amigo: ");
                    string nomeResponsavel = Console.ReadLine();
                    Console.Write("\n   Digite o endereço desse amigo: ");
                    string endereco = Console.ReadLine();
                    Console.Write("\n   Digite o telefone desse amigo: ");
                    string numeroParaContato = Console.ReadLine();

                    amigoEditado.EditarAmigo(nome, nomeResponsavel, endereco, numeroParaContato, amigoEditado.possuiEmprestimoEmAberto);

                    break;
                }
            }
            Console.Clear();
            MostrarListaAmigos(listaAmigos);
            ExibirMensagem("\n   Amigo editdo com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();

        }

        public static void ExcluirAmigo(List<Amigo> listaAmigos)
        {
            Console.Clear();
            MostrarListaAmigos(listaAmigos);

            Console.Write("\n   Digite o id do amigo que deseja exclir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Amigo amigoExcluido in listaAmigos)
            {
                if (amigoExcluido.id == id)
                {
                    listaAmigos.Remove(amigoExcluido);

                    break;
                }
            }
            Console.Clear();
            MostrarListaAmigos(listaAmigos);
            ExibirMensagem("\n   Amigo excluído com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        private static void MostrarListaCaixa(List<Caixa> listaCaixas)
        {
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                  Lista de Caixas                            ");
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("{0,-5}|{1,-25}|{2,-35}", "ID ", "  COR ", "  ETIQUETA " );
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();

            foreach (Caixa print in listaCaixas)
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-35}", print.id, print.cor, print.etiqueta);
                }
            }
        }

        private static void CadastrarCaixa(List<Caixa> listaCaixas)
        {
            Console.Clear();
            string cor = "";
            while (!ValidarString(cor))
            {
                Console.Clear();
                Console.Write("\n   Digite a cor da caixa que deseja cadastrar: ");
                cor = Console.ReadLine();
            }
            string etiqueta = "";
            while (!ValidarString(etiqueta))
            {
                Console.Clear();
                Console.Write("\n   Digite a etiqueta para essa caixa: ");
                etiqueta = Console.ReadLine();
            }

            Caixa caixa = new Caixa(cor, etiqueta);
            listaCaixas.Add(caixa);
            Console.Clear();
            MostrarListaCaixa(listaCaixas);
            ExibirMensagem("\n   Caixa cadastrada com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        private static void EditararCaixa(List<Caixa> listaCaixas)
        {
            Console.Clear();
            MostrarListaCaixa(listaCaixas);
            Console.Write("\n   Digite o id da caixa que deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Caixa caixaEdit in listaCaixas)
            {
                if (caixaEdit.id == id)
                {
                    string cor = "";
                    while (!ValidarString(cor))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite a cor da caixa que deseja: ");
                        cor = Console.ReadLine();
                    }
                    string etiqueta = "";
                    while (!ValidarString(etiqueta))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite a etiqueta para essa caixa: ");
                        etiqueta = Console.ReadLine();
                    }

                    caixaEdit.EditarCaixa(cor, etiqueta);
                    Console.Clear();
                    MostrarListaCaixa(listaCaixas);
                    ExibirMensagem("\n   Caixa editada com Sucesso! ", ConsoleColor.DarkGreen);
                    Console.ReadLine();
                    break;
                }
            }
        }

        private static void ExcluirCaixa(List<Caixa> listaCaixas)
        {
            int id;

            Console.Clear();
            MostrarListaCaixa(listaCaixas);

            while (true){
                Console.Write("\n   Digite o id da caixa que deseja descartar: ");
                id = Convert.ToInt32(Console.ReadLine());
                Caixa caixa = null;
                int idcaixa = caixa.id;
                if (id < 1 || id > listaCaixas.Count + 1)
                {
                    ExibirMensagem("\n   ID inexistente. Digite um ID válido. ", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
               // if (listaCaixas.FindIndex(e => e.caixa.id == id == -1))
                //{
                //    ExibirMensagem("\n   ID inexistente. Digite um ID válido. ", ConsoleColor.DarkRed);
                //    Console.ReadLine();
                //    continue;
                //}
                else
                    break;
            }

            foreach (Caixa caixaRemove in listaCaixas)
            {
                if (caixaRemove.id == id)
                {
                    listaCaixas.Remove(caixaRemove);

                    break;
                }
            }
            Console.Clear();
            MostrarListaCaixa(listaCaixas);
            ExibirMensagem("\n   Caixa descartada com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();
        }

        private static Emprestimo SelecionarEmprestimoPorID(List<Emprestimo> listaEmprestimos, int idEmprestimoEscolhido)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo emprestimoEscolhido in listaEmprestimos)
            {
                if (emprestimoEscolhido.id == idEmprestimoEscolhido)
                {
                    emprestimo = emprestimoEscolhido;
                    break;
                }
            }
            return emprestimo;
        }

        private static Caixa SelecionarCaixaPorID(List<Caixa> listaCaixas, int idcaixaEscolhida)
        {
            Caixa caixa = null;

            foreach (Caixa caixaEscolhida in listaCaixas)
            {
                if (caixaEscolhida.id == idcaixaEscolhida)
                {
                    caixa = caixaEscolhida;
                    break;
                }
            }
            return caixa;
        }

        private static Amigo SelecionarAmigoPorID(List<Amigo> listaAmigos, int idAmigoEscolhido)
        {
            Amigo amigo = null;

            foreach (Amigo amigoEscolhido in listaAmigos)
            {
                if (amigoEscolhido.id == idAmigoEscolhido)
                {
                    amigo = amigoEscolhido;
                    break;
                }
            }
            return amigo;
        }

        private static Revista SelecionarRevistaPorID(List<Revista> listaRevistas, int idRevistaEscolhida)
        {
            Revista revista = null;

            foreach (Revista revistaEscolhida in listaRevistas)
            {
                if (revistaEscolhida.id == idRevistaEscolhida)
                {
                    revista = revistaEscolhida;
                    break;
                }
            }
            return revista;
        }

        public static bool ValidarString(string str)
        {
            if (!string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                return true;
            else
                return false;
        }

        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        static string MostrarMenuPrincipal()
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
            Console.WriteLine("   1  - Para cadastrar uma nova caixa.                                            ");    //  ok
            Console.WriteLine("   2  - Para visualizar suas caixas.                                              ");    //  ok
            Console.WriteLine("   3  - Para editar as características de uma de suas caixas.                     ");    //  ok
            Console.WriteLine("   4  - Para descartar uma de suas caixas.                                        ");    //  ok
            Console.WriteLine();                                                                                              
            Console.WriteLine("   5  - Para cadastrar uma revista.                                               ");    //  ok
            Console.WriteLine("   6  - Para visualizar as revistas cadastradas.                                  ");    //  ok
            Console.WriteLine("   7  - Para editar o cadastro de uma revista.                                    ");    //  ok
            Console.WriteLine("   8  - Para excluir o cadastro de uma revista.                                   ");    //  ok
            Console.WriteLine();                                                                                              
            Console.WriteLine("   9  - Para cadastrar um novo amigo.                                             ");    //  ok
            Console.WriteLine("   10 - Para visualizar os amigos já cadastrados.                                 ");    //  ok
            Console.WriteLine("   11 - Para editar o cadastro de um amigo.                                       ");    //  ok
            Console.WriteLine("   12 - Para excluir o cadastro de um amigo.                                      ");    //  ok
            Console.WriteLine();                                                                                              
            Console.WriteLine("   13 - Para realizar um empréstimo.                                              ");          
            Console.WriteLine("   14 - Para visualizar os empréstimos em aberto.                                 ");          
            Console.WriteLine("   15 - Para visualizar todos os empréstimos já realizados.                       ");          
            Console.WriteLine("   16 - Para editar um empréstimo.                                                ");          
            Console.WriteLine("   17 - Para excluir um empréstimo.                                               ");          
            Console.WriteLine();
            Console.WriteLine("   18 - Para realizar uma devolução.                                              ");
            Console.WriteLine();
            Console.WriteLine("   19 - Para visualizar o registro de empréstimos realizados nos ultimos 30 dias. ");
            Console.WriteLine();
            Console.WriteLine("   S  - Para sair.                                                                ");
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine();
            Console.Write("   Opção escolhida: ");
            string opcao = Console.ReadLine().ToUpper();
            bool opcaoValida = opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6" && 
                               opcao != "7" && opcao != "8" && opcao != "9" && opcao != "10" && opcao != "S";
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
}