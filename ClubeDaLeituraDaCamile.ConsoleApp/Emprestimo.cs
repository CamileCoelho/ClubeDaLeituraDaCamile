using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    internal class Emprestimo
    {
        private static int idCounter = 1;
        public int id { get; set; }
        public string dataInicial { get; set; }
        public string devolucao { get; set; }
        public string nomeAmigo { get; set; }
        public string tituloRevista { get; set; }
        public Revista revista { get; set; }
        public Amigo amigo { get; set; }    

        public Emprestimo()
        {

        }
        public Emprestimo(string nomeAmigo, string tituloRevista, string dataInicial)
        {
            id = idCounter++;
            this.nomeAmigo = nomeAmigo;
            this.tituloRevista = tituloRevista;
            this.dataInicial = dataInicial;
            this.devolucao = " PENDENTE ";
        }
        public Emprestimo(Amigo amigo, Revista revista, string dataInicial)
        {
            id = idCounter++;
            this.nomeAmigo = nomeAmigo;
            this.revista = revista;
            this.dataInicial = dataInicial;
            this.devolucao = " PENDENTE ";
            this.revista.disponivel = " INISPONÍVEL ";
        }
        public void EditarEmprestimo(string nomeAmigo, string tituloRevista, string dataInicial)
        {
            this.nomeAmigo = nomeAmigo;
            this.tituloRevista = tituloRevista;
            this.dataInicial = dataInicial;
            this.devolucao = " PENDENTE ";
        }
        public void EditarEmprestimo(Amigo amigo, Revista revista, string dataInicial)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataInicial = dataInicial; 
            this.devolucao = " PENDENTE ";
        }
        public void RealizarDevolucao(string nomeAmigo, string tituloRevista, string dataInicial)
        {
            this.nomeAmigo = nomeAmigo;
            this.tituloRevista = tituloRevista;
            this.dataInicial = dataInicial;
            this.devolucao = " OK ";
        }
        public void RealizarDevolucao(Amigo amigo, Revista revista, string dataInicial)
        {
            this.amigo = amigo;
            this.revista = revista;
            this.dataInicial = dataInicial;
            this.devolucao = " OK ";
            this.revista.disponivel = " DISPONÍVEL ";
        }
    }
}