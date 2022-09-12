using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

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
        public Voo(String destino, string aeronave, DateTime dataVoo, DateTime dataCadastro, char situacaoVoo)
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
            Random rand = new Random();
            int[] numero = new int[100];
            int aux = 0;
            for (int k = 0; k < numero.Length; k++)
            {
                int rnd = 0;
                do
                {
                    rnd = rand.Next(1000, 9999);
                } while (numero.Contains(rnd));
                numero[k] = rnd;
                aux = numero[k];
            }
            return aux;
        }
        public void CadastrarVoo(List<Voo> listaDeVoo)
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
            if (dataVoo <= DateTime.Now)
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
            Voo novoVoo = new Voo(destinoVoo, IdentificacaoAeronave, dataVoo, dataCadastro, situacaoVoo);
            listaDeVoo.Add(novoVoo);
            Console.Clear();
            Console.WriteLine(novoVoo.ImprimirVoo());
            GeraArquivoVoo(listaDeVoo);
            Console.WriteLine("Aperte uma tecla para prosseguir: ");
            Console.ReadKey();
        } //falta linkar com aeronaves.
        public void LocalizarVoo(List<Voo> listaDeVoo)
        {
            Console.Clear();
            Console.WriteLine("Opção: Localizar Voo");
            Console.WriteLine("Informe seu ID de voo para procurarmos em nosso Banco de Dados: ");
            string idVoo = Console.ReadLine();
            Voo encontrouVoo = listaDeVoo.Find(Voo => Voo.Id == idVoo);
            if (encontrouVoo == null)
            {
                Console.WriteLine("Não existe um registro para esse Id de Voo");
                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine(encontrouVoo.ImprimirVoo());
                Console.WriteLine("Pressione uma tecla para continuar.");
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
        public string DestinoVoo()
        {
            List<string> destinoVoo = new List<string>();
            destinoVoo.Add("BSB");
            destinoVoo.Add("CGH"); 
            destinoVoo.Add("GIG"); 
            Console.WriteLine("Destinos atualmente disponíves: ");
            Console.WriteLine("BSB - Aeroporto Internacional de Brasilia");
            Console.WriteLine("CGH - Aeroporto Internacional de Congonhas/SP");
            Console.WriteLine("GIG - Aeroporto Internacional do Rio de Janeiro");
            Console.WriteLine("");
            do
            {
                Console.Write("Informe a sigla do destino de voo: ");
                String destinoEscolhido = Console.ReadLine().ToUpper();
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
        public void EditarVoo(List<Voo> listaVoo)
        {
            Console.Clear();
            Console.WriteLine("Opção: Editar Voo");
            Console.WriteLine("Informe seu ID de voo para procurarmos em nosso Banco de Dados: ");
            string idVoo = Console.ReadLine();
            Voo encontrouVoo = listaVoo.Find(Voo => Voo.Id == idVoo);
            if (encontrouVoo == null)
            {
                Console.WriteLine("Não existe um registro para esse Id de Voo");
                Console.WriteLine("Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine(encontrouVoo.ImprimirVoo());
                Console.WriteLine("Voce deseja editar esse Voo: \n1. SIM \n2. NÃO");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("As opções mutáveis são: Destino, Aeronave, DataVoo, DataCadastro, Situação do Voo");
                        encontrouVoo.EditandoInfVoo(encontrouVoo);
                        //listaVoo.Add(encontrouVoo);
                        break;
                    case 2:
                        Console.WriteLine("Voltando ao menu...");
                        Thread.Sleep(1300);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }              
            }
            Console.Clear();
            Console.WriteLine("Os atributos que podem ser alterados são: Destino, Aeronave, Data do Voo e Situacao.");
            Console.ReadKey();
        }
        public void EditandoInfVoo(Voo EdicaoVoo)
        {
            string novoDestino = DestinoVoo();
            EdicaoVoo.Destino = novoDestino;
            Console.WriteLine("Insira a nova Aeronave: ");
            EdicaoVoo.Aeronave = Console.ReadLine();
            Console.WriteLine("Insira a nova data de Voo: ");
            EdicaoVoo.DataVoo = DateTime.Parse(Console.ReadLine());
            if (EdicaoVoo.DataVoo <= DateTime.Now)
            {
                Console.WriteLine("Essa data é inválida, informe novamente: ");
                EdicaoVoo.DataVoo = DateTime.Parse(Console.ReadLine());
            }
            Console.WriteLine("Informe a nova situacao do Voo: \n'A'- Ativo \n'C' - Cancelado");
            EdicaoVoo.Situacao = Char.Parse(Console.ReadLine().ToUpper());
            while (EdicaoVoo.Situacao != 'A' && EdicaoVoo.Situacao != 'C')
            {
                Console.WriteLine("O valor informado é inválido, por favor informe novamente!\n'A'- Ativo \n'C' - Cancelado");
                EdicaoVoo.Situacao = char.Parse(Console.ReadLine().ToUpper());
            }
            Console.WriteLine("Arquivo editado com sucesso!!");
            Console.WriteLine("Pressione alguma tecla para prosseguir");
            Console.ReadKey();
        }
        public void GeraArquivoVoo(List<Voo> listaDeVoo)
        {
            string msg = "";
            foreach (Voo voo in listaDeVoo)
            {
                msg = "\n" + voo.Id +
                      "\n" + voo.Destino +
                      "\n" + voo.Aeronave +
                      "\n" + voo.DataVoo.ToString("g") +
                      "\n" + voo.DataCadastro.ToString("g") +
                      "\n" + voo.Situacao;
            }
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Jhonatas\\source\\repos\\OnTheFly_projeto\\Arquivos\\Voo.dat", append: true);
                sw.WriteLineAsync(msg);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        } //gera arquivo, mas falta linkar com Aeronaves.
        public void ImprimeArquivoVoo(List<Voo> listaDeVoo) //Imprime mas precisa colocar no padrao.
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Jhonatas\\source\\repos\\OnTheFly_projeto\\Arquivos\\Voo.dat");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("\nFim da Leitura do Arquivo");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}

