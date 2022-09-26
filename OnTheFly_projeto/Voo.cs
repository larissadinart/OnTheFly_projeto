using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace OnTheFly_projeto
{
    internal class Voo
    {
        public String Id { get; set; }
        public string Destino { get; set; }
        public Aeronave Aeronave { get; set; }
        public DateTime DataVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }
        public Voo()
        {

        }
        public Voo(string destino, DateTime dataVoo, DateTime dataCadastro, char situacaoVoo)
        {
            int valorId = RandomCadastroVoo();
            this.Id = "V" + valorId.ToString("D4");
            this.Destino = destino;
            this.Aeronave = null;
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
            bool existeAeronave = aeronave.ExisteAeronave();
            if (!existeAeronave)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Bem vindo ao cadastro de voo.");
                Console.WriteLine("-----------------------------");
                string destinoVoo = DestinoVoo();
                Console.WriteLine("Aeronave definida como: " + aeronave.Inscricao);
                Console.WriteLine("Informe a data e hora d Voo: (dd/MM/yyyy hh:mm) ");
                DateTime dataVoo = DateTime.Parse(Console.ReadLine());
                if (dataVoo <= DateTime.Now)
                {
                    Console.WriteLine("Essa data é inválida, informe novamente: ");
                    dataVoo = DateTime.Parse(Console.ReadLine());
                }
                DateTime dataCadastro = DateTime.Now;
                Console.WriteLine("Data de cadastro definifida como: " + dataCadastro);
                Console.WriteLine("Informe a situacao do Voo: \n[A] Ativo \n[C] Cancelado");
                char situacaoVoo = char.Parse(Console.ReadLine().ToUpper());
                while (situacaoVoo != 'A' && situacaoVoo != 'C')
                {
                    Console.WriteLine("O valor informado é inválido, por favor informe novamente!\n[A] Ativo \n[C] Cancelado");
                    situacaoVoo = char.Parse(Console.ReadLine().ToUpper());
                }
                Voo novoVoo = new Voo(destinoVoo, dataVoo, dataCadastro, situacaoVoo);
                listaDeVoo.Add(novoVoo);
                Console.Clear();
                Console.WriteLine(novoVoo.ImprimirVoo());
                GeraArquivoVoo(listaDeVoo);
            }
            else if (existeAeronave)
            {
                Console.Clear();
                Console.WriteLine("Desculpa, impossível cadastrar voo, pois nao temos nenhuma aeronave Ativa Cadastrada");
                Console.WriteLine("Pressione uma tecla para prosseguir");
                Console.ReadKey();
            }
        }
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
            return "### Dados do Vôo ###\nID: " + Id +
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
                Console.WriteLine("Voce deseja editar esse Voo: \n[1] Sim \n[2] Não");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("As opções mutáveis são: Destino, Aeronave, DataVoo, DataCadastro, Situação do Voo");
                        encontrouVoo.EditandoInfVoo(encontrouVoo, listaVoo);
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
        }
        public void EditandoInfVoo(Voo EdicaoVoo, List<Voo> listaVoo)
        {
            Console.Clear();
            Console.WriteLine("### Editando dados de voo ###");
            Console.WriteLine("");
            string novoDestino = DestinoVoo();
            EdicaoVoo.Destino = novoDestino;
            //Console.WriteLine("Insira a nova Aeronave: ");
            //EdicaoVoo.Aeronave = Console.ReadLine();
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
            GeraArquivoVoo(listaVoo);
            Console.WriteLine("Pressione alguma tecla para prosseguir");
            Console.ReadKey();
        }
        public void GeraArquivoVoo(List<Voo> listadeVoo)
        {
            string msg = "";
            foreach (Voo voo in listadeVoo)
            {
                msg = voo.Id + voo.Destino.ToString() + voo.Aeronave + voo.DataVoo.ToString("ddMMyyyy" + "hhmm") + voo.DataCadastro.ToString("ddMMyyyy" + "hhmm") + voo.Situacao;
            }
            try
            {
                StreamWriter sw = new StreamWriter("CC:\\Arquivo\\Voos.dat", append: true);
                sw.WriteLine(msg);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine("\nAperte uma tecla pra prosseguir!");
            Console.ReadKey();
        }
        public void ImprimeArquivoVoo()
        {
            Console.WriteLine("### Arquivos de Voo.Dat ####");
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Arquivo\\Voo.dat");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("\nFim da Leitura do Arquivo");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public void LerArquivoVoo(List<Voo> listadeVoo)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Arquivo\\Voo.dat");
                line = sr.ReadLine();
                string dv = line.Substring(8, 12);
                dv = dv.Substring(0, 2) + "/" + dv.Substring(2, 2) + "/" + dv.Substring(4, 2) + ' ' + dv.Substring(6, 2) + ':' + dv.Substring(8, 2);
                string dc = line.Substring(20, 12);
                dc = dc.Substring(0, 2) + "/" + dc.Substring(2, 2) + "/" + dc.Substring(4, 2) + ' ' + dc.Substring(6, 2) + ':' + dc.Substring(8, 2);
                Voo v = new Voo();
                while (line != null)
                {
                    v.Id = line.Substring(0, 5);
                    v.Destino = line.Substring(5, 3);
                    //v.Aeronave = line.Substring(0, 0);
                    v.DataVoo = DateTime.Parse(dv);
                    v.DataCadastro = DateTime.Parse(dc);
                    v.Situacao = char.Parse(line.Substring(32, 1));
                    listadeVoo.Add(v);
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("\nFim da Leitura do Arquivo");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}

