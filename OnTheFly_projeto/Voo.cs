using System;

namespace OnTheFly_projeto
{
    internal class Voo
    {
        public String Id { get; set; } // CHAVE!! Digito inicial V, seguidos de 4 dígitos numéricos
        public String Destino { get; set; } //aeroporto de destino.
        public String Aeronave { get; set; } //Id da Aeronave Cadastrada. Esse registro deve existir previamente
        public DateTime DataVoo { get; set; } //data da partida
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Voo()
        {

        }
        public Voo(String destino, string aeronave, DateTime dataVoo, DateTime dataCadastro)
        {
            int valorId = RandomCadastroVoo();

            this.Id = "V" + valorId.ToString();
            this.Destino = destino;
            this.Aeronave = aeronave;
            this.DataVoo = dataVoo;
            this.DataCadastro = dataCadastro;
            this.Situacao = 'A';
        }
        private static int RandomCadastroVoo()
        {
            Random numId = new Random();
            int valorId = numId.Next(1000, 9999);
            return valorId;
        }
        public void CadastrarVoo()
        {
            Aeronave aeronave = new Aeronave();

            Console.Clear();
            Console.WriteLine("Bem vindo ao cadastro de voo.");
            Console.WriteLine("_____________________________");
            Console.Write("Informe o destino do voo: ");
            String destinoVoo = Console.ReadLine();
            string IdentificacaoAeronave = aeronave.Inscricao;
            Console.Write("Aeronave definida como: " + IdentificacaoAeronave);
            Console.WriteLine("Informe a data de Voo: ");
            DateTime dataVoo = DateTime.Parse(Console.ReadLine());
            DateTime dataCadastro = DateTime.Now;
            Console.WriteLine("Data de cadastro definifida como: " + dataCadastro);

            Voo voo = new(destinoVoo, IdentificacaoAeronave, dataVoo, dataCadastro);
        }
        public string ImprimirPassagem()
        {
            return "***Dados do Vôo***\nID: " + Id +
                "\nDestino: " + Destino +
                "\nAeronave: " + Aeronave +
                "\nDataVôo: " + DataVoo +
                "\nDataCadastro: " + DataCadastro +
                "\nSituacao do Vôo: " + Situacao;
        }
    }
}
