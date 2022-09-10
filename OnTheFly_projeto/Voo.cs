using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

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
        public Voo(String destino, string aeronave, DateTime dataVoo, DateTime dataCadastro, char situacaoVoo )
        {
            int valorId = RandomCadastroVoo();

            this.Id = "V" + valorId.ToString();//validar ID
            this.Destino = destino;
            this.Aeronave = aeronave;
            this.DataVoo = dataVoo;
            this.DataCadastro = dataCadastro;
            this.Situacao = situacaoVoo;
        }
        private static int RandomCadastroVoo()
        {
            Random numId = new Random();
            int valorId = 0;
            int[] verificador = new int[9999];
            
            for (int i = 0; i < verificador.Length; i++)
            {
                valorId = numId.Next(1000, 9999);
                for (int j = 0; j < verificador.Length; j++)
                {
                    if (verificador[j] == valorId)
                    {
                        valorId = numId.Next(1000, 9999);
                    } 
                }
                verificador[i] = valorId;
            }
            return verificador[valorId];
        }
        public void CadastrarVoo(Voo voo)
        {
            Aeronave aeronave = new Aeronave();
            Console.Clear();
            Console.WriteLine("Bem vindo ao cadastro de voo.");
            Console.WriteLine("_____________________________");
            string destinoVoo = DestinoVoo();
            string IdentificacaoAeronave = aeronave.Inscricao; //mudar pra valor de Aeronave | verificar se tem nave cadastrada
            Console.WriteLine("Aeronave definida como: " + IdentificacaoAeronave);
            Console.Write("Informe a data de Voo: ");
            DateTime dataVoo = DateTime.Parse(Console.ReadLine());
            if (dataVoo < DateTime.Now)
            {
                Console.WriteLine("Essa data é inválida, informe novamente: ");
                dataVoo = DateTime.Parse(Console.ReadLine());
            }
            DateTime dataCadastro = DateTime.Now;
            Console.WriteLine("Data de cadastro definifida como: " + dataCadastro);
            Console.WriteLine("Informe a situacao do Voo: \n'A'- Ativo \n'C' - Cancelado");
            char situacaoVoo = char.Parse(Console.ReadLine().ToUpper());
            while (situacaoVoo != 'A' && situacaoVoo != 'C')
            {
                Console.WriteLine("O valor informado é inválido, por favor informe novamente!\n'A'- Ativo \n'C' - Cancelado");
                situacaoVoo = char.Parse(Console.ReadLine().ToUpper());
            }
            new Voo(destinoVoo, IdentificacaoAeronave, dataVoo, dataCadastro, situacaoVoo);
            Console.WriteLine(voo.ImprimirVoo());
        }

        public void LocalizarVoo(List<Voo> listaVoos, string idVoo)
        {
            Console.Clear();
            Console.WriteLine("Opção: Localizar Voo");
            Console.WriteLine("Informe seu ID de voo para procurarmos em nosso Banco de Dados: ");
            idVoo = Console.ReadLine();
            Voo buscaIdVoo = null;
            foreach (Voo voo in listaVoos)
            {
                if (idVoo == voo.Id && voo.Situacao == 'A')
                {
                    buscaIdVoo = voo;
                }
            }
            if (buscaIdVoo == null)
            {
                Console.WriteLine("O voo com Id: " + idVoo + " não foi encontrado.");
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("O Voo de Id: " + idVoo + " foi encontrado.");
                Console.WriteLine(buscaIdVoo.ImprimirVoo());
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }
        public string ImprimirVoo()
        {
            return "***Dados do Vôo***\nID: " + Id +
                "\nDestino: " + Destino +
                "\nAeronave: " + Aeronave +
                "\nDataVôo: " + DataVoo +
                "\nDataCadastro: " + DataCadastro +
                "\nSituacao do Vôo: " + Situacao;
        }
        public string DestinoVoo() //retorna string
        {
            List<string> destinoVoo = new List<string>();
            destinoVoo.Add("BSB"); // - Aeroporto Internacional de Brasilia"
            destinoVoo.Add("CGH"); // - Aeroporto Internacional de Congonhas/SP"
            destinoVoo.Add("GIG"); // - Aeroporto Internacional do Rio de Janeiro

            Console.WriteLine("Destinos atualmente disponíves: ");
            destinoVoo.ForEach(i => Console.WriteLine(i));
            Console.WriteLine("--------------------------");
            do
            {
                Console.Write("Informe o destino do voo: ");
                String destinoEscolhido = Console.ReadLine();
                if (destinoVoo.Contains(destinoEscolhido))
                {
                    return destinoEscolhido;
                    break;
                }
                else
                {
                    Console.WriteLine("Destino inválido, informe novamente!");
                    Console.WriteLine("");
                }
            } while (true);         
        }

        public void EditarVoo(List<Voo> listaVoos)
        {
            Console.Clear();
            Console.WriteLine("Opção: Editar Voo");
            Console.WriteLine("Informe seu ID de voo que voce deseja editar para procurarmos em nosso Banco de Dados: ");
            string idVoo = Console.ReadLine();
            Voo buscaIdVoo = null;
            foreach (Voo voo in listaVoos)
            {
                if (idVoo == voo.Id )
                {
                    buscaIdVoo = voo;
                }
            }
            if (buscaIdVoo == null)
            {
                Console.WriteLine("O voo com Id: " + idVoo + " não foi encontrado.");
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("O Voo de Id: " + idVoo + " foi encontrado.");
                Console.WriteLine(buscaIdVoo.ImprimirVoo());
                Console.WriteLine("Pressione uma tecla para ir ao menu de alteração");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("Os atributos que podem ser alterados são: Destino, Aeronave, Data do Voo e Situacao.");
                //terminar metodo de editar informação

                //imprimir registro por registro 
            }
        }
    }
}
