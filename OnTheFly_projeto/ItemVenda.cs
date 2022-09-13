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
        public PassagemVoo IdPassagem { get; set; }
        public PassagemVoo ValorUnitario { get; set; }
        public PassagemVoo passagem { get; set; }

        public ItemVenda(int id, PassagemVoo idPassagem, PassagemVoo valorUnitario)
        {
            Id = id;
            IdPassagem = idPassagem;
            ValorUnitario = valorUnitario;
        }
        public ItemVenda()
        {

        }
        public void CadastrarItemVenda()
        {
            ItemVenda itemVenda = new ItemVenda();

            itemVenda.Id = GeraNumero();
            //itemVenda.IdPassagem = passagem.Id;
            //itemVenda.ValorUnitario = passagem.Valor;
        }
        public int GeraNumero()
        {
            int nro = 0;

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
