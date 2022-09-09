using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class PassagemVoo
    {
        public String Id { get; set; } //CHAVE!!PA0000 – Dois dígitos PA, seguidos de 4 dígitos numéricos.
        public String IdVoo { get; set; } //CHAVE!!O Aeroporto de Destino do voo cadastrado.
        public String Aeronave { get; set; } //Id da Aeronave Cadastrada. Esse registro deve existir previamente
        public DateTime DataVoo { get; set; }
        public DateTime DataCadastro { get; set; } //atual do sistema
        public double Valor { get; set; } // tam maximo 9.999,99
        public char Situacao { get; set; }


    }
}
