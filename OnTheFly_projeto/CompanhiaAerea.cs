using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class CompanhiaAerea
    {
        public double Cnpj { get; set; } // CHAVE!!! seguir definicoes do governo federal e qt de digitos
        public String RazaoSocial { get; set; } //ate 50 digitos
        public DateTime DataAbertura { get; set; } // não poderemos cadastrar empresas com menos de 6 meses de abertura
        public DateTime UltimoVoo { get; set; }//no momento do cadastro pode ser a data atual
        public DateTime DataCadastro { get; set; } //data atual do sistema
        public char Situacao { get; set; } //A-Ativou ou I-Inativo
    }
}
