using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloRevista;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using System.Runtime.ConstrainedExecution;
using System.ComponentModel.DataAnnotations;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    public class RepositorioRevista : RepositorioMae
    {
        public List<Revista> listaRevistas = new List<Revista>();

        public string CadastrarRevista(Revista revistaToAdd)
        {
            string validacao = revistaToAdd.Validar(revistaToAdd.titulo, revistaToAdd.tipoColecao, revistaToAdd.caixa);
            if (validacao == "REGISTRO_REALIZADO")
            {
                listaRevistas.Add(revistaToAdd);
                return "\n   Revista cadastrada com sucesso!";
            }

            return "\n   Revista Não Cadastrada: " + validacao;
        }

        public string EditarRevista(Revista revistaToEdit, string titulo, string tipoColecao, int numeroDaEdicao, int ano, Caixa caixa)
        {
            revistaToEdit.titulo = titulo;
            revistaToEdit.tipoColecao = tipoColecao;
            revistaToEdit.numeroDaEdicao = numeroDaEdicao;
            revistaToEdit.ano = ano;
            revistaToEdit.caixa = caixa;
            return "\n   Revista editada com sucesso!";
        }

        public string ExcluirRevista(int id, Validador validador)
        {
            Revista revistaToDelete = SelecionarRevistaPorId(id);

            string validacaoExclusao = validador.PermitirExclusaoDeRevista(id);

            if (revistaToDelete != null && validacaoExclusao == "SUCESSO!")
            {
                listaRevistas.Remove(revistaToDelete);
                return "\n   Revista excluida com sucesso!";
            }
            return "\n   Revista não excluida: " + validacaoExclusao;
        }

        public List<Revista> ListarRevistas()
        {
            return listaRevistas;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return listaRevistas.Find(revista => revista.id == id);
        }

    }
}