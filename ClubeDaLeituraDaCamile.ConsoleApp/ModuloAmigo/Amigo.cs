using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;

namespace ClubeDaLeituraDaCamile.ConsoleApp.ModuloAmigo
{
    public class Amigo : EntidadeMae
    {
        private static int idCounter = 1;
        public string nome { get; set; }
        public string nomeResponsavel { get; set; }
        public string endereco { get; set; }
        public string numeroParaContato { get; set; }
        public string possuiEmprestimoEmAberto { get; set; }

        public Amigo()
        {

        }

        public Amigo(string nome, string nomeResponsavel, string endereco, string numeroParaContato)
        {
            id = idCounter++;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.endereco = endereco;
            this.numeroParaContato = numeroParaContato;
            possuiEmprestimoEmAberto = " NÃO ";
        }

        public string Validar(string nome, string nomeResponsavel, string endereco, string numeroParaContato)
        {
            Validador valida = new Validador();
            string mensagem = "";

            if (valida.ValidarString(nome))
                mensagem += "NOME_INVALIDO ";

            if (valida.ValidarString(nomeResponsavel))
                mensagem += "NOME_DO_RESPONSAVEL_INVALIDO ";

            if (valida.ValidarString(endereco))
                mensagem += "ENDEREÇO_INVALIDO ";

            if (valida.ValidaTelefone(numeroParaContato))
                mensagem += "NUMERO_PARA_CONTATO_INVALIDO ";

            if (mensagem != "")
                return mensagem;

            return "REGISTRO_REALIZADO";
        }
    }
}
