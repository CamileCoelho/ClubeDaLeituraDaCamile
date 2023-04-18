using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;
using System.Threading.Tasks;
using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;
using System.Text.RegularExpressions;
using System.Runtime.ConstrainedExecution;

namespace ClubeDaLeituraDaCamile.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeMae
    {
        private static int idCounter = 1;
        public string titulo { get; set; }
        public string tipoColecao { get; set; }
        public int numeroDaEdicao { get; set; }
        public int ano { get; set; }
        public string disponivel { get; set; }
        public Caixa caixa { get; set; }

        public Revista()
        {

        }

        public Revista(string titulo, string tipoColecao, int numeroDaEdicao, int ano, Caixa caixa)
        {
            id = idCounter++;
            this.titulo = titulo;
            this.tipoColecao = tipoColecao;
            this.numeroDaEdicao = numeroDaEdicao;
            this.ano = ano;
            this.caixa = caixa;
            this.disponivel = " DISPONÍVEL ";
        }

        public string Validar(string titulo, string tipoColecao, Caixa caixa)
        {
            Validador valida = new Validador();
            string mensagem = "";

            if (valida.ValidarString(titulo))
                mensagem += "NOME_INVALIDO ";

            if (valida.ValidarString(tipoColecao))
                mensagem += "NOME_DO_RESPONSAVEL_INVALIDO ";

            if (caixa == null)
                mensagem += "CAIXA_INVALIDA ";

            if (mensagem != "")
                return mensagem;

            return "REGISTRO_REALIZADO";
        }

    }
}