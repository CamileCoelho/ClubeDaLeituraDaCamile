using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{    
    public class RepositorioCaixa : RepositorioMae
    {
        private List<Caixa> listaCaixas = new List<Caixa>();

        public string CadastrarCaixa(Caixa caixaToAdd)
        {
            string validacao = caixaToAdd.Validar(caixaToAdd.cor, caixaToAdd.etiqueta);
            if (validacao  == "REGISTRO_REALIZADO")
            {
                listaCaixas.Add(caixaToAdd);
                return "\n   Caixa Cadastrada com sucesso!";
            }

            return "\n   Caixa Não Cadastrada: " + validacao;
        }

        public string EditarCaixa(Caixa caixaToEdit, string cor, string etiqueta)
        {
            caixaToEdit.cor = cor;
            caixaToEdit.etiqueta = etiqueta;
            return "\n   Caixa editada com sucesso!";
        }

        public string ExcluirCaixa(int id, Validador validador)
        {
            Caixa caixaToDelete = SelecionarCaixaPorId(id);

            string validacaoExclusao = validador.PermitirExclusaoDeCaixa(id);

            if (caixaToDelete != null && validacaoExclusao == "SUCESSO!")
            {
                listaCaixas.Remove(caixaToDelete);
                return "\n   Caixa excluida com sucesso!";
            }
            return "\n   Caixa não excluida: " + validacaoExclusao;
        }

        public List<Caixa> ListarCaixas()
        {
            return listaCaixas;
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return listaCaixas.Find(caixa => caixa.id == id);
        }
    }
}