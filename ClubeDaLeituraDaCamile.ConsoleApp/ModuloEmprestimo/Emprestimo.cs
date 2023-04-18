using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloRevista;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloAmigo;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;


namespace ClubeDaLeituraDaCamile.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeMae
    {
        private static int idCounter = 1;
        public string dataInicial { get; set; }
        public string devolucao { get; set; }
        public Revista revista { get; set; }
        public Amigo amigo { get; set; }

        public Emprestimo()
        {

        }

        public Emprestimo(Amigo amigo, Revista revista, string dataInicial)
        {
            id = idCounter++;
            this.amigo = amigo;
            this.revista = revista;
            this.dataInicial = dataInicial;
        }

        public void AbrirUmEmprestimoEAtualizarDados()
        {
            this.devolucao = " PENDENTE ";
            this.revista.disponivel = " INISPONÍVEL ";
            this.amigo.possuiEmprestimoEmAberto = " SIM ";
        }

        public void EncerrarEmprestimoEAtualizarDados()
        {
            devolucao = " OK ";
            revista.disponivel = " DISPONÍVEL ";
            amigo.possuiEmprestimoEmAberto = " NÃO ";
        }

        public string Validar(Amigo amigo, Revista revista)
        {
            string mensagem = "";

            if (amigo == null)
                mensagem += "AMIGO_INVÁLIDO ";
            else if (amigo.possuiEmprestimoEmAberto == " SIM ")
                mensagem += "AMIGO_INDISPONÍVEL ";

            if (revista == null)
                mensagem += "REVISTA_INVALIDA ";
            else if (revista.disponivel == " INISPONÍVEL " || revista == null)
                mensagem += "REVISTA_INDISPONÍVEL ";

            if (mensagem != "")
                return mensagem;

            return "REGISTRO_VALIDO";
        }
    }
}