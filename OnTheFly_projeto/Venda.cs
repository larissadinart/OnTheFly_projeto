using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{

    internal class Venda
    {
        private int id;

        public int Id { get; set; } // CHAVE!!
        public DateTime DataVenda { get; set; }
        public String Passageiro { get; set; } //Deverá armazenar apenas o CPF do Passageiro, mas ao ser informado, deverá trazer o nome e a data de nascimento do cliente, para uma verificação junto ao mesmo.
        public int ValorTotal { get; set; } //Deverá armazenar apenas o CPF do Passageiro, mas ao ser informado, deverá trazer o nome e a data de nascimento do cliente, para uma verificação junto ao mesmo.
        public Passageiro passageiro { get; set; }
        public Voo Voo { get; set; }

        public Venda()
        {

        }
        public Venda(int Id, DateTime datavenda, String passageiro, int total)
        {
            this.Id = Id;
            this.DataVenda = datavenda;
            this.Passageiro = passageiro;
            this.ValorTotal = total;
        }
        public void CadastrarVenda(Passageiro passageiro, Voo voo, List<Passageiro> passageiros, List<string> restritos)
        {
            Venda venda = new Venda();

            venda.Id = GeraNumero(id);
            venda.DataVenda = DateTime.Now;

            Console.WriteLine("Digite o CPF do passageiro: ");
            passageiro.Cpf = Console.ReadLine();
            foreach (var item in restritos)
            {
                if (restritos.Equals(item))
                {
                    Console.WriteLine("CPF restrito!Venda não pode ser realizada!\n\nAperte enter para continuar...");
                    Console.ReadKey();
                }
            }
            foreach (var item in passageiros)
            {
                if (passageiro.Cpf == item.Cpf)
                {
                    int op = 0;

                    Console.WriteLine(item.Nome);
                    Console.WriteLine(item.DataNascimento);
                    do
                    {
                        Console.WriteLine("Deseja continuar?\n1- Sim\n2- Não");

                        switch (op)
                        {
                            case 1:
                                voo.LocalizarVoo(listaDeVoo);
                                break;
                            case 2:
                                CadastrarVenda(passageiro, voo, passageiros, restritos);
                                break;
                        }
                    } while (op < 0 || op > 2);
                }
                else
                {
                    Console.WriteLine("Passageiro não cadastrado!\n\nAperte enter para continuar...");
                    Console.ReadKey();
                }
            }
        }
        public int GeraNumero(int nro)
        {
            int n = nro;
            if (n > 99999)
            {
                n = 0;
            }
            else
            {
                n++;
            }
            return n;
        }




    }
}
