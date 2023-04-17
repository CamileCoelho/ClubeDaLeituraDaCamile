using System.Globalization;
using System.Text.RegularExpressions;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloAmigo;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloRevista;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    public class RepositorioEmprestimo : RepositorioMae
    {
        List<Emprestimo> listaEmprestimos = new List<Emprestimo>();

        public string CadastrarEmprestimo(Emprestimo emprestimoToAdd)
        {
            string validacao = emprestimoToAdd.Validar(emprestimoToAdd.amigo, emprestimoToAdd.revista);
            if (validacao == "REGISTRO_VALIDO")
            {
                listaEmprestimos.Add(emprestimoToAdd);
                emprestimoToAdd.AbrirUmEmprestimoEAtualizarDados();
                return "   Emprestimo cadastrado com sucesso!";
            }

            return "   Emprestimo Não Cadastrado: "+ validacao;
        }

        public string EditarEmprestimo(Emprestimo emprestimoToEdit,  string dataInicial)
        {
            // NÃO PODE ALTERAR AMIGO E REVISTA CADASTRADOS
            emprestimoToEdit.dataInicial = dataInicial;

            return "   Empretimo editado com sucesso!";
        }

        public string ExcluirEmprestimo(int id, Validador validador)
        {
            Emprestimo emprestimoToDelete = SelecionarEmprestimoPorId(id);

            if (emprestimoToDelete != null)
            {
                listaEmprestimos.Remove(emprestimoToDelete);
                emprestimoToDelete.EncerrarEmprestimoEAtualizarDados();
                return "   Emprestimo excluido com sucesso!";
            }
            return "   Empréstimo não excluido!";
        }

        public string RealizarDevolucao(int id)
        {
            Emprestimo emprestimoToReturn = SelecionarEmprestimoPorId(id);

            listaEmprestimos.Find(revista => revista.id == id);

            if (emprestimoToReturn != null)
            {
                emprestimoToReturn.EncerrarEmprestimoEAtualizarDados();
                return "   Revista devolvida com sucesso!";
            }
            return "   Revista não devolvida! ";
        }

        public List<Emprestimo> ListarEmprestimos()
        {
            return listaEmprestimos;
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return listaEmprestimos.Find(revista => revista.id == id);
        }

    }
}