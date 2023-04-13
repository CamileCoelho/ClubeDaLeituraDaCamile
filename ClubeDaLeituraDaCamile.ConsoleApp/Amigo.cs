using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraDaCamile.ConsoleApp
{
    internal class Amigo
    {
        private static int idCounter = 1;
        public int id { get; set; }
        public string nome { get; set; }
        public string nomeResponsavel { get; set; }
        public string endereco { get; set; }
        public string numeroParaContato { get; set; }
        public bool possuiEmprestimoEmAberto { get; set; }

        public Amigo()
        {
                
        }
        public Amigo(string nome, string nomeResponsavel, string endereco, string numeroParaContato, bool possuiEmprestimoEmAberto)
        {
            id = idCounter++;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.endereco = endereco;
            this.numeroParaContato = numeroParaContato;
            this.possuiEmprestimoEmAberto = possuiEmprestimoEmAberto;
        }
        public void EditarAmigo(string nome, string nomeResponsavel, string endereco, string numeroParaContato, bool possuiEmprestimoEmAberto)
        {            
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.endereco = endereco;
            this.numeroParaContato = numeroParaContato;
            this.possuiEmprestimoEmAberto = possuiEmprestimoEmAberto;
        }
    }    
}
