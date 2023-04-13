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
        public int dataInicial { get; set; }
        public string devolucao { get; set; }
        public string nomeAmigo { get; set; }
        public string tituloRevista { get; set; }

        public Emprestimo()
        {

        }
        public Emprestimo(string nomeAmigo, string tituloRevista, int dataInicial)
        {
            id = idCounter++;
            this.nomeAmigo = nomeAmigo;
            this.tituloRevista = tituloRevista;
            this.dataInicial = dataInicial;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            this.devolucao = " PENDENTE ";
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void EditarEmprestimo(string nomeAmigo, string tituloRevista, int dataInicial)
        {
            this.nomeAmigo = nomeAmigo;
            this.tituloRevista = tituloRevista;
            this.dataInicial = dataInicial; 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            this.devolucao = " PENDENTE ";
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void RealizarDevolucao(string nomeAmigo, string tituloRevista, int dataInicial)
        {
            this.nomeAmigo = nomeAmigo;
            this.tituloRevista = tituloRevista;
            this.dataInicial = dataInicial;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            this.devolucao = " OK ";
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
//string cor = "";
//while (!ValidarString(cor))
//{
//    Console.Clear();
//    Console.Write("\n   Digite a cor da caixa que deseja cadastrar: ");
//    cor = Console.ReadLine();
//}