using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class Aeronave
    {
        public String Inscricao { get; set; } //CHAVE!!! ver padrão ANAC
        public int Capacidade { get; set; } //qt de passageiros que aeronave comporta
        public int AssentosOcupados { get; set; } //qt de assentos já vendidos
        public DateTime UltimaVenda { get; set; }
        public DateTime DataCadastro { get; set; } // data atual do sistema
        public char Situacao { get; set; }
    }
}
