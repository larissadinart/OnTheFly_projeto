using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class Venda
    {
        public int Id { get; set; } // CHAVE!! Deverá ser um número sequencial que iniciará em 1 e, através deste sistema poderá ir apenas até a venda 99.999. Sendo assim, será numérico, mas deverá ter no máximo 5 dígitos.

        public DateTime DataVenda { get; set; }
        public String Passageiro { get; set; } //Deverá armazenar apenas o CPF do Passageiro, mas ao ser informado, deverá trazer o nome e a data de nascimento do cliente, para uma verificação junto ao mesmo.
        public int ValorTotal { get; set; } //Deverá armazenar apenas o CPF do Passageiro, mas ao ser informado, deverá trazer o nome e a data de nascimento do cliente, para uma verificação junto ao mesmo.




    }
}
