using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

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

            PopularCamposParaTeste(listaAmigos, listaRevistas, listaCaixas);

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
                        ExcluirRevista(listaRevistas);
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
                        continuar = true;
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
                        continuar = true;
                        break;
                    case "17":
                        ExcluirEmprestimo(listaEmprestimos);
                        continuar = true;
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
            Revista revistaEscolhida = null;
            revistaEscolhida.disponivel = " DISPONÍVEL ";

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
                DateTime dataAbertura = DateTime.ParseExact(print.dataInicial, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (dataAbertura.Month == DateTime.Now.Month && print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-25}|{2,-25}|{3,-15}|{4,-25}", print.id, print.nomeAmigo, print.tituloRevista, print.dataInicial, print.devolucao);
                }
            }
        }

        private static void RealizarEmprestimo(List<Amigo> listaAmigos, List<Revista> listaRevistas, List<Emprestimo> listaEmprestimos)
        {
            Console.Clear();
            MostrarListaAmigos(listaAmigos);
            int idAmigoEscolhido;
            Amigo amigoEscolhido = null;
            while (true)
            {
                Console.Write("\n   Digite o id do Amigo que deseja realizar um empréstimo: ");
                idAmigoEscolhido = Convert.ToInt32(Console.ReadLine());

                amigoEscolhido = SelecionarAmigoPorID(listaAmigos, idAmigoEscolhido);

                if (amigoEscolhido != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Amigo não encontrado!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }

            string nomeAmigo = amigoEscolhido.nome;

            MostrarListaRevistas(listaRevistas);
            int idRevistaEscolhida;
            Revista revistaEscolhida = null;

            while (true)
            {
                Console.Write("\n   Digite o id da Revista que deseja emprestada (seu status tem que ser DISPONÍVEL): ");
                idRevistaEscolhida = Convert.ToInt32(Console.ReadLine());

                revistaEscolhida = SelecionarRevistaPorID(listaRevistas, idRevistaEscolhida);

                if (revistaEscolhida != null && revistaEscolhida.disponivel == " DISPONÍVEL ")
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Revista não encontrada! ", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }

            string tituloRevista = revistaEscolhida.titulo;

            revistaEscolhida.disponivel = " INISPONÍVEL ";

            string dataInicial = RegistrarDataInicial();

            Emprestimo emprestimo = new Emprestimo(amigoEscolhido, revistaEscolhida, dataInicial);

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
            int id;
            Emprestimo emprestimoEscolhido = null;
            while (true)
            {
                Console.Write("\n   Digite o id do emprestimo que deseja alterar: ");
                id = Convert.ToInt32(Console.ReadLine());

                emprestimoEscolhido = SelecionarEmprestimoPorID(listaEmprestimos, id);

                if (emprestimoEscolhido != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Empréstimo não encontrado!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }

            foreach (Emprestimo emprestimoEdit in listaEmprestimos)
            {
                if (emprestimoEdit.id == id)
                {
                    Console.Clear();
                    MostrarListaAmigos(listaAmigos);
                    int idAmigoEscolhido;
                    Amigo amigoEscolhido = null;
                    while (true)
                    {
                        Console.Write("\n   Digite o id do Amigo que deseja realizar um empréstimo: ");
                        idAmigoEscolhido = Convert.ToInt32(Console.ReadLine());

                        amigoEscolhido = SelecionarAmigoPorID(listaAmigos, idAmigoEscolhido);

                        if (amigoEscolhido != null)
                        {
                            break;
                        }
                        else
                        {
                            ExibirMensagem("\n   Amigo não encontrado!", ConsoleColor.DarkRed);
                            Console.ReadLine();
                            continue;
                        }
                    }

                    string nomeAmigo = amigoEscolhido.nome;

                    MostrarListaRevistas(listaRevistas);
                    int idRevistaEscolhida;
                    Revista revistaEscolhida = null;

                    while (true)
                    {
                        Console.Write("\n   Digite o id da Revista que deseja emprestar: ");
                        idRevistaEscolhida = Convert.ToInt32(Console.ReadLine());

                        revistaEscolhida = SelecionarRevistaPorID(listaRevistas, idRevistaEscolhida);

                        if (amigoEscolhido != null)
                        {
                            break;
                        }
                        else
                        {
                            ExibirMensagem("\n   Revista não encontrada!", ConsoleColor.DarkRed);
                            Console.ReadLine();
                            continue;
                        }
                    }

                    string tituloRevista = revistaEscolhida.titulo;

                    string revistaDisponivel = revistaEscolhida.disponivel;

                    string dataInicial = RegistrarDataInicial();

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
            int id;
            Emprestimo emprestimoEscolhido = null;
            while (true)
            {
                Console.Write("\n   Digite o id do emprestimo que deseja excluír: ");
                id = Convert.ToInt32(Console.ReadLine());

                emprestimoEscolhido = SelecionarEmprestimoPorID(listaEmprestimos, id);

                if (emprestimoEscolhido != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Empréstimo não encontrado!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }

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
            Console.WriteLine("{0,-5}|{1,-14}|{2,-14}|{3,-14}|{4,-12}|{5,-14}|{6,-14}", "ID ", "  TÍTULO ", "  COLEÇÃO ", "  EDIÇÃO ", "    ANO ", "  CAIXA ", "  STATUS ");
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine();

            foreach (Revista print in listaRevistas)
            {
                if (print != null)
                {
                    Console.WriteLine("{0,-5}|{1,-14}|{2,-14}|{3,-14}|{4,-12}|{5,-14}|{6,-14}", print.id, print.titulo, print.tipoColecao, print.numeroDaEdicao, print.ano, print.etiqueta, print.disponivel);
                }
            }
        }

        private static void CadastrarRevista(List<Revista> listaRevistas, List<Caixa> listaCaixas)
        {
            string titulo = "";
            while (!ValidarVazio(titulo))
            {
                Console.Clear();
                Console.Write("\n   Digite o titulo da revista que deseja cadastrar: ");
                titulo = Console.ReadLine();
            }
            string tipoColecao = "";
            while (!ValidarVazio(tipoColecao))
            {
                Console.Clear();
                Console.Write("\n   Digite a coleção dessa revista: ");
                tipoColecao = Console.ReadLine();
            }
            int numeroDaEdicao = LerApenasNumero();
            int ano = ObterAnoFormatoCorreto();

            Console.WriteLine();
            MostrarListaCaixa(listaCaixas);

            string etiqueta = EncontrarEtiquetaCaixaPeloId(listaCaixas);

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
            int id;
            while (true)
            {
                Console.Write("\n   Digite o id da revista que deseja alterar: ");
                id = Convert.ToInt32(Console.ReadLine());
                Revista revistaEscolhida = SelecionarRevistaPorID(listaRevistas, id);

                if (revistaEscolhida != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Revista não encontrada!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }
            

            foreach (Revista revistaEditada in listaRevistas)
            {
                if (revistaEditada.id == id)
                {
                    string titulo = "";
                    while (!ValidarVazio(titulo))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite o titulo da revista que deseja cadastrar: ");
                        titulo = Console.ReadLine();
                    }
                    string tipoColecao = "";
                    while (!ValidarVazio(tipoColecao))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite a coleção dessa revista: ");
                        tipoColecao = Console.ReadLine();
                    }
                    int numeroDaEdicao = LerApenasNumero();
                    int ano = ObterAnoFormatoCorreto();

                    string etiqueta = EncontrarEtiquetaCaixaPeloId(listaCaixas);

                    revistaEditada.EditarRevista(titulo, tipoColecao, numeroDaEdicao, ano, etiqueta, revistaEditada.disponivel);

                    break;
                }
            }
            Console.Clear();
            MostrarListaRevistas(listaRevistas);
            ExibirMensagem("\n   Revista editda com Sucesso! ", ConsoleColor.DarkGreen);
            Console.ReadLine();

        }

        public static void ExcluirRevista(List<Revista> listaRevistas)
        {
            Console.Clear();
            MostrarListaRevistas(listaRevistas);
            int id;
            while (true)
            {
                Console.Write("\n   Digite o id da revista que deseja exclir: ");
                id = Convert.ToInt32(Console.ReadLine());
                Revista revistaEscolhida = SelecionarRevistaPorID(listaRevistas, id);

                if (revistaEscolhida != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Revista não encontrada!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }

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
            string nome = "";
            while (!ValidarVazio(nome))
            {
                Console.Clear();
                Console.Write("\n   Digite o nome do amigo que deseja cadastrar: ");
                nome = Console.ReadLine();
            }
            string nomeResponsavel = "";
            while (!ValidarVazio(nomeResponsavel))
            {
                Console.Clear();
                Console.Write("\n   Digite o nome do responsável desse amigo: ");
                nomeResponsavel = Console.ReadLine();
            }
            string endereco = "";
            while (!ValidarVazio(endereco))
            {
                Console.Clear();
                Console.Write("\n   Digite o endereço desse amigo: ");
                endereco = Console.ReadLine();
            }
            string numeroParaContato = "";
            while (!ValidarVazio(numeroParaContato))
            {
                Console.Clear();
                Console.Write("\n   Digite o telefone desse amigo: ");
                numeroParaContato = Console.ReadLine();
            }

            Amigo amigo = new Amigo(nome, nomeResponsavel, endereco, numeroParaContato);

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
            int id;
            while (true)
            {
                Console.Write("\n   Digite o id do amigo que deseja alterar: ");
                id = Convert.ToInt32(Console.ReadLine());

                Amigo amigoEscolhido = SelecionarAmigoPorID(listaAmigos, id);

                if (amigoEscolhido != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Amigo não encontrado!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }
            foreach (Amigo amigoEditado in listaAmigos)
            {
                if (amigoEditado.id == id)
                {
                    string nome = "";
                    while (!ValidarVazio(nome))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite o nome do amigo que deseja cadastrar: ");
                        nome = Console.ReadLine();
                    }
                    string nomeResponsavel = "";
                    while (!ValidarVazio(nomeResponsavel))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite o nome do responsável desse amigo: ");
                        nomeResponsavel = Console.ReadLine();
                    }
                    string endereco = "";
                    while (!ValidarVazio(endereco))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite o endereço desse amigo: ");
                        endereco = Console.ReadLine();
                    }
                    string numeroParaContato = "";
                    while (!ValidarVazio(numeroParaContato))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite o telefone desse amigo: ");
                        nome = Console.ReadLine();
                    }

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
            int id;
            while(true)
            {
                Console.Write("\n   Digite o id do amigo que deseja exclir: ");
                id = Convert.ToInt32(Console.ReadLine());

                Amigo amigoEscolhido = SelecionarAmigoPorID(listaAmigos, id);

                if (amigoEscolhido != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Amigo não encontrado!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }

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
            while (!ValidarVazio(cor))
            {
                Console.Clear();
                Console.Write("\n   Digite a cor da caixa que deseja cadastrar: ");
                cor = Console.ReadLine();
            }
            string etiqueta = "";
            while (!ValidarVazio(etiqueta))
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
            int id; 
            Console.Clear();
            MostrarListaCaixa(listaCaixas);
            while (true)
            {
                Console.Write("\n   Digite o id da caixa que deseja alterar: ");
                id = Convert.ToInt32(Console.ReadLine());

                Caixa caixaEscolhida = SelecionarCaixaPorID(listaCaixas, id);

                if (caixaEscolhida != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Caixa não encontrada!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }

            foreach (Caixa caixaEdit in listaCaixas)
            {
                if (caixaEdit.id == id)
                {
                    string cor = "";
                    while (!ValidarVazio(cor))
                    {
                        Console.Clear();
                        Console.Write("\n   Digite a cor da caixa que deseja: ");
                        cor = Console.ReadLine();
                    }
                    string etiqueta = "";
                    while (!ValidarVazio(etiqueta))
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
            while (true)
            {
                Console.Write("\n   Digite o id da caixa que deseja descartar: ");
                id = Convert.ToInt32(Console.ReadLine());

                Caixa caixaEscolhida = SelecionarCaixaPorID(listaCaixas, id);

                if (caixaEscolhida != null)
                {
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Caixa não encontrada!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
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

        private static string EncontrarEtiquetaCaixaPeloId(List<Caixa> listaCaixas)
        {
            int idcaixaEscolhida;
            string etiqueta = "";
            while (true)
            {
                Console.Write("\n   Digite o id da caixa que deseja colocar essa revista: ");
                idcaixaEscolhida = int.Parse(Console.ReadLine());

                Caixa caixaEscolhida = SelecionarCaixaPorID (listaCaixas, idcaixaEscolhida);

                if (caixaEscolhida != null)
                {
                    etiqueta = caixaEscolhida.etiqueta;
                    break;
                }
                else
                {
                    ExibirMensagem("\n   Caixa não encontrada!", ConsoleColor.DarkRed);
                    Console.ReadLine();
                    continue;
                }
            }

            return etiqueta;
        }

        private static Emprestimo SelecionarEmprestimoPorID(List<Emprestimo> listaEmprestimos, int id)
        {
            return listaEmprestimos.Find(e => e.id == id);
        }

        private static Amigo SelecionarAmigoPorID(List<Amigo> listaAmigos, int id)
        {
            return listaAmigos.Find(amigo => amigo.id == id);
        }

        private static Revista SelecionarRevistaPorID(List<Revista> listaRevistas, int id)
        {
            return listaRevistas.Find(revista => revista.id == id);
        }

        private static Caixa SelecionarCaixaPorID(List<Caixa> listaCaixas, int id)
        {
            return listaCaixas.Find(caixa => caixa.id == id);
        }

        private static int ObterAnoFormatoCorreto()
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

        private static int LerApenasNumero()
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

        static string RegistrarDataInicial()
        {
            string dataInicial = "";
            continuar = true;
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

        public static bool ValidarVazio(string str)
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
            Console.WriteLine("   1  - Para cadastrar uma nova caixa.                                            ");    
            Console.WriteLine("   2  - Para visualizar suas caixas.                                              ");    
            Console.WriteLine("   3  - Para editar as características de uma de suas caixas.                     ");    
            Console.WriteLine("   4  - Para descartar uma de suas caixas.                                        ");    
            Console.WriteLine();                                                                                        
            Console.WriteLine("   5  - Para cadastrar uma revista.                                               ");    
            Console.WriteLine("   6  - Para visualizar as revistas cadastradas.                                  ");    
            Console.WriteLine("   7  - Para editar o cadastro de uma revista.                                    ");    
            Console.WriteLine("   8  - Para excluir o cadastro de uma revista.                                   ");    
            Console.WriteLine();                                                                                        
            Console.WriteLine("   9  - Para cadastrar um novo amigo.                                             ");    
            Console.WriteLine("   10 - Para visualizar os amigos já cadastrados.                                 ");    
            Console.WriteLine("   11 - Para editar o cadastro de um amigo.                                       ");    
            Console.WriteLine("   12 - Para excluir o cadastro de um amigo.                                      ");    
            Console.WriteLine();                                                                                              
            Console.WriteLine("   13 - Para realizar um empréstimo.                                              ");          
            Console.WriteLine("   14 - Para visualizar os empréstimos em aberto.                                 ");          
            Console.WriteLine("   15 - Para visualizar todos os empréstimos já realizados.                       ");          
            Console.WriteLine("   16 - Para editar um empréstimo.                                                ");          
            Console.WriteLine("   17 - Para excluir um empréstimo.                                               ");          
            Console.WriteLine();
            Console.WriteLine("   18 - Para realizar uma devolução.                                              ");
            Console.WriteLine();
            Console.WriteLine("   19 - Para visualizar o registro de empréstimos realizados no mês atual.        ");
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

        public static void PopularCamposParaTeste(List<Amigo> listaAmigos, List<Revista> listaRevistas, List<Caixa> listaCaixas)
        {
            Amigo amigo = new Amigo("Tales","Lins","Rua Anápolis","49 99999999");
            listaAmigos.Add(amigo);
            Caixa caixa = new Caixa("rosa","caixa rosa");
            listaCaixas.Add(caixa);
            Revista revista = new Revista("Bátman","colecao", 1, 2020, caixa.etiqueta);
            listaRevistas.Add(revista);

        }
    }
}