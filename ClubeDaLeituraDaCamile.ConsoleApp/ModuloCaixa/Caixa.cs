using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado;

namespace ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa
{
    public class Caixa : EntidadeMae
    {
        private static int idCounter = 1;
        public string cor { get; set; }
        public string etiqueta { get; set; }

        public Caixa()
        {

        }

        public Caixa(string cor, string etiqueta) 
        {
            id = idCounter++;
            this.cor = cor;
            this.etiqueta = etiqueta;
        }

        public string Validar(string cor, string etiqueta)
        {
            Validador valida = new Validador();
            string mensagem = "";

            if (valida.ValidarString(cor))
                mensagem += "COR_INVALIDA ";

            if (valida.ValidarString(etiqueta))
                mensagem += "ETIQUETA_INVALIDA ";

            if (mensagem != "")
                return mensagem;

            return "REGISTRO_REALIZADO";
        }
    }
}
