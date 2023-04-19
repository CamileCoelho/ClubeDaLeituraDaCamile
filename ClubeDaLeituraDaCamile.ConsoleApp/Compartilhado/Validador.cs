using System.Text.RegularExpressions;

namespace ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado
{
    public class Validador
    {
        public RepositorioCaixa? repositorioCaixa;
        public RepositorioAmigo? repositorioAmigo;
        public RepositorioRevista? repositorioRevista;
        public RepositorioEmprestimo? repositorioEmprestimo;

        public Validador()
        {
            
        }

        public Validador(RepositorioCaixa? repositorioCaixa, RepositorioAmigo? repositorioAmigo, RepositorioRevista? repositorioRevista, RepositorioEmprestimo? repositorioEmprestimo)
        {
            this.repositorioCaixa = repositorioCaixa;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
            this.repositorioEmprestimo = repositorioEmprestimo;
        }
        
        public bool ValidarString(string str)
        {
            if (string.IsNullOrEmpty(str) && string.IsNullOrWhiteSpace(str))
                return true;
            else
                return false;
        }

        public bool ValidaTelefone(string telefone)
        {
            // formato (XX)XXXXX-XXXX
            Regex Rgx = new Regex(@"^\(\d{2}\)\d{5}-\d{4}$");

            if (Rgx.IsMatch(telefone))
                return false;
            else
                return true;
        }

        public string PermitirExclusaoDeCaixa(int id)
        {
            if (repositorioRevista.ListarRevistas().Any(x => x.caixa.id == id))
                return " Esta caixa possuí uma revista dentro. ";
            else
                return "SUCESSO!";
        }

        public string PermitirExclusaoDeRevista(int id)
        {
            if (repositorioEmprestimo.ListarEmprestimos().Any(x => x.revista.id == id))
                return " Esta revista está emprestada. ";
            else
                return "SUCESSO!";
        }

        public string PermitirExclusaoDeAmigo(int id)
        {
            if (repositorioEmprestimo.ListarEmprestimos().Any(x => x.amigo.id == id))
                return " Está caixa possuí uma revista dentro.";
            else
                return "SUCESSO!";
        }
    }
}
