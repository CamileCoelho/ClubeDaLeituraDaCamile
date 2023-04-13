using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    internal class Caixa
    {
        private static int idCounter = 1;
        public int id { get; set; }
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
        public void EditarCaixa(string cor, string etiqueta)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
        }
    }
}
