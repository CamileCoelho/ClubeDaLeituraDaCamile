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
                return "\n   Emprestimo cadastrado com sucesso!";
            }

            return "\n   Emprestimo Não Cadastrado: " + validacao;
        }

        public string EditarEmprestimo(Emprestimo emprestimoToEdit,  string dataInicial)
        {
            // NÃO PODE ALTERAR AMIGO E REVISTA CADASTRADOS
            emprestimoToEdit.dataInicial = dataInicial;

            return "\n   Empretimo editado com sucesso!";
        }

        public string ExcluirEmprestimo(int id, Validador validador)
        {
            Emprestimo emprestimoToDelete = SelecionarEmprestimoPorId(id);

            if (emprestimoToDelete != null)
            {
                listaEmprestimos.Remove(emprestimoToDelete);
                emprestimoToDelete.EncerrarEmprestimoEAtualizarDados();
                return "\n   Emprestimo excluido com sucesso!";
            }
            return "\n   Empréstimo não excluido!";
        }

        public string RealizarDevolucao(int id)
        {
            Emprestimo emprestimoToReturn = SelecionarEmprestimoPorId(id);

            listaEmprestimos.Find(revista => revista.id == id);

            if (emprestimoToReturn != null)
            {
                emprestimoToReturn.EncerrarEmprestimoEAtualizarDados();
                return "\n   Revista devolvida com sucesso!";
            }
            return "\n   Revista não devolvida! ";
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