using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class Banco
    {
        static string Conexao = "Data Source=localhost;Initial Catalog=OnTheFly;User Id=sa;Password=Lari123*;";

        public Banco()
        {
        }
        public string Caminho()
        {
            return Conexao;
        }

    }
}
