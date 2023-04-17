using ClubeDaLeituraDaCamile.ConsoleApp.ModuloAmigo;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    public class RepositorioAmigo : RepositorioMae
    {
        private List<Amigo> listaAmigos = new List<Amigo>();

        public string CadastrarAmigo(Amigo amigoToAdd)
        {
            string validacao = amigoToAdd.Validar(amigoToAdd.nome, amigoToAdd.nomeResponsavel, amigoToAdd.endereco, amigoToAdd.numeroParaContato);
            
            if (validacao == "REGISTRO_REALIZADO")
            {
                listaAmigos.Add(amigoToAdd);
                return "\n   Amigo cadastrado com Sucesso!";
            }
            
                return "\n   Amigo Não Cadastrado: " + validacao;
        }
                
        public string EditarAmigo(Amigo amigoToEdit, string nome, string nomeResponsavel, string endereco, string numeroParaContato)
        {
            amigoToEdit.nome = nome;
            amigoToEdit.nomeResponsavel = nomeResponsavel;
            amigoToEdit.endereco = endereco;
            amigoToEdit.numeroParaContato = numeroParaContato;
            return "\n   Amigo editado com sucesso!";
        }

        public string ExcluirAmigo(int id, Validador validador)
        {
            Amigo amigoToDelete = SelecionarAmigoPorId(id);

            string validacaoExclusao = validador.PermitirExclusaoDeAmigo(id);

            if (amigoToDelete != null && validacaoExclusao == "SUCESSO!")
            {
                listaAmigos.Remove(amigoToDelete);
                return "\n   Amigo excluido com sucesso! ";
            }
            return "\n   Amigo não excluido: " + validacaoExclusao;
        }

        public List<Amigo> ListarAmigos()
        {
            return listaAmigos;
        }

        public Amigo SelecionarAmigoPorId(int id)
        {
            return listaAmigos.Find(amigo => amigo.id == id);
        }

    }
}