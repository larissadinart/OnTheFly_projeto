using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class ItemVenda
    {
        public int Id { get; set; }
        public String IdPassagem { get; set; }
        public double ValorUnitario { get; set; }
        public PassagemVoo passagem { get; set; }
        public Venda venda { get; set; }

        public ItemVenda(int id, String idPassagem, double valorUnitario)
        {
            Id = id;
            IdPassagem = idPassagem;
            ValorUnitario = valorUnitario;
        }
        public ItemVenda()
        {

        }
        public void CadastrarItemVenda(PassagemVoo passagem)
        {
            ItemVenda itemVenda = new ItemVenda();

            itemVenda.Id = GeraNumero(Id);
            itemVenda.IdPassagem = passagem.IdVoo;
            itemVenda.ValorUnitario = passagem.Valor;
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
