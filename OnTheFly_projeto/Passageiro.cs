using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class Passageiro
    {
        public String Nome { get; set; } // até 50 dígitos
        public double Cpf { get; set; } // CHAVE!! atributo chave(11 dígitos, ver algoritmo de criação de cpf)
        public DateTime DataNascimento { get; set; } // não vender para menores de 18 anos
        public char Sexo { get; set; }
        public DateTime UltimaCompra  { get; set; } // no cadastro pode ser a data atual
        public DateTime DataCadastro { get; set; } //data atual do sistema
        public char Situacao { get; set; } // A - Ativo ou I- Inativo
    }
}
