using ClubeDaLeituraDaCamile.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraDaCamile.ConsoleApp.Compartilhado
{
    public class TelaMae
    {
        public Validador validador;

        public void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ReadLine();
        }
    }
}
