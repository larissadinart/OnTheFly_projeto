using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class Voo
    {
        public String Id { get; set; } // CHAVE!! Digito inicial V, seguidos de 4 dígitos numéricos
        public String Destino { get; set; } //aeroporto de destino
        public String Aeronave { get; set; } //Id da Aeronave Cadastrada. Esse registro deve existir previamente
        public DateTime DataVoo { get; set; } //data da partida
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }


    }
}
