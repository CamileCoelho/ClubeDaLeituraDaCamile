using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    internal class Revista
    {
        private static int idCounter = 1;
        public int id { get; set; }
        public string titulo { get; set; }
        public string tipoColecao { get; set; }
        public int numeroDaEdicao { get; set; }
        public int ano { get; set; }
        public string etiqueta { get; set; }

        public Revista()
        {

        }
        public Revista(string titulo, string tipoColecao, int numeroDaEdicao, int ano, string etiqueta)
        {
            id = idCounter++;
            this.titulo = titulo;
            this.tipoColecao = tipoColecao;
            this.numeroDaEdicao = numeroDaEdicao;
            this.ano = ano;
            this.etiqueta = etiqueta;
        }
        public void EditarRevista(string titulo, string tipoColecao, int numeroDaEdicao, int ano, string etiqueta)
        {
            this.titulo = titulo;
            this.tipoColecao = tipoColecao;
            this.numeroDaEdicao = numeroDaEdicao;
            this.ano = ano;
            this.etiqueta = etiqueta;
        }
    }
}
