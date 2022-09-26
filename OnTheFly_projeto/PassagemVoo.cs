using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnTheFly_projeto
{
    internal class PassagemVoo
    {

        public String Id { get; set; }//CHAVE!!PA0000 – Dois dígitos PA, seguidos de 4 dígitos numéricos.
        public Voo IdVoo { get; set; } //CHAVE!!O Aeroporto de Destino do voo cadastrado.
        public Aeronave IdAero { get; set; } //Id da Aeronave Cadastrada. Esse registro deve existir previamente

        public DateTime DataUltimaOperacao = DateTime.Now;
        public double Valor { get; set; } // tam maximo 9.999,99
        public char Situacao { get; set; }

        public PassagemVoo() { }

        public PassagemVoo(string id, Voo idvoo, Aeronave idnave, DateTime dataUltimaOperacao, double valor, char situacao)
        {
            this.Id = id;
            this.IdVoo = idvoo;
            this.IdAero = idnave;
            this.DataUltimaOperacao = dataUltimaOperacao;
            this.Valor = valor;
            this.Situacao = situacao;
        }
        public String GeraNumero()
        {
            Random rand = new Random();
            int[] numero = new int[100];
            string convert = "";
            int aux = 0;
            for (int k = 0; k < numero.Length; k++)
            {
                int rnd = 0;
                do
                {
                    rnd = rand.Next(999, 9999);
                } while (numero.Contains(rnd));
                numero[k] = rnd;
                aux = numero[k];
                convert = aux.ToString();
            }
            return convert;
        }
        public void CadastrarPassagem(List<PassagemVoo> listaPassagem, List<Voo> listaVoo)
        {

            double preco = 0;
            PassagemVoo passagem = new PassagemVoo();
            IdVoo = new Voo();
            IdAero = new Aeronave();
            do
            {
                this.Id = "PA" + GeraNumero();

                Console.Write("Digite o Preço da Passagem: ");
                preco = double.Parse(Console.ReadLine());
                if (preco > 9999.99 || preco < 0)
                {
                    Console.WriteLine("Preço da Passagem Excedeu o Valor Máximo Permitido!!!!");
                }
            } while (preco > 999.99 || preco < 0);

            Console.Write("Informe Quantas Passagens Deseja Adquirir Minimo 1 e máximo 3: ");
            int qtdPassagem = int.Parse(Console.ReadLine());

            if (qtdPassagem > 0 && qtdPassagem < 4)
            {
                for (int k = 0; k < qtdPassagem; k++)
                {
                    do
                    {
                        Console.Write("\nInfome a Situação da Passagem:" +
                                  "\nL-Livre/ R-Reservado\n" +
                                  "\nSituação: ");
                        Situacao = char.Parse(Console.ReadLine().ToUpper());
                    } while (!Situacao.Equals('L') && !Situacao.Equals('R'));

                    passagem.DataUltimaOperacao = DateTime.Now;
                    passagem.Valor = preco;
                    if (Situacao.CompareTo('L') == 0)
                    {
                        listaPassagem.Add(passagem);
                        Console.WriteLine("Passagem Livre Cadastrada com Sucesso!!!");
                    }
                    else
                    {
                        if (CancelarReserva() == true)
                        {
                            Console.WriteLine("Reserva de Passagem foi Cancelada!!!");
                        }
                        else
                        {
                            listaPassagem.Add(passagem);
                            Console.WriteLine("Passagen Reservada Cadastrada com Sucesso!!!");
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Quantidade de Passagem Invalidas!!");
            }
        }
        public bool CancelarReserva()
        {
            char cancelar;
            do
            {
                Console.WriteLine("\nDeseja Cancelar a Reserva Sim-S/ ou Não-N");
                cancelar = char.Parse(Console.ReadLine().ToUpper());
            } while (!cancelar.Equals('S') && !cancelar.Equals('N'));

            if (cancelar.CompareTo('S') == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region Imprime Passagem
        public void ImprimePassagem(List<PassagemVoo> pas)
        {
            foreach (PassagemVoo item in pas)
            {
                Console.WriteLine("\nID da Passagem: " + item.Id +
                                   "\nID do Voo: " + item.IdVoo +
                                   "\nData da Ultima Operação: " + item.DataUltimaOperacao +
                                   "\nPreço da Passagem: " + item.Valor +
                                   "\nSituação da passagem: " + item.Situacao);
            }
        }
        #endregion
        public PassagemVoo EditarPassagem(List<PassagemVoo> listaPassagem, List<Voo> listaVoo)
        {
            PassagemVoo psv = new PassagemVoo();
            Console.WriteLine("\nInforme o Numero Identificador da passagem que deseja editar: ");
            int idpassagem = int.Parse(Console.ReadLine());
            Console.WriteLine("\nInforme o Identificador de 4 digitos do voo para localizar a passagem: ");
            int idvoo = int.Parse(Console.ReadLine());
            PassagemVoo busca = listaPassagem.Find(busca => busca.Id == idpassagem.ToString());
            // PassagemVoo voo = listaVoo.Find(voo => voo.Idvoo == idvoo.ToString());
            int opcao = 0;
            if (busca != null)
            {
                do
                {
                    Console.WriteLine("1 - Preço");
                    Console.WriteLine("2 - Situação");
                    Console.WriteLine("0 - Sair");
                    Console.Write("\nDigite: ");
                    opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            double valor = 0;
                            do
                            {
                                Console.WriteLine("\nInforme o Novo Preço da passagem:");
                                valor = double.Parse(Console.ReadLine());
                            } while (valor > 999.99 || valor < 0);
                            psv.Valor = valor;
                            Console.WriteLine("\nPreço da Passagem foi Editado com Sucesso");
                            break;
                        case 2:
                            char situacao;

                            do
                            {
                                Console.WriteLine("\nInforme a Situação Nova da Passagem:");
                                situacao = char.Parse(Console.ReadLine());
                            } while (!Situacao.Equals('L') && !Situacao.Equals('R') && !Situacao.Equals('P'));

                            psv.Situacao = situacao;
                            Console.WriteLine("\nSituação Editado foi Editado com Sucesso!!! ");
                            break;
                        default:
                            if (opcao > 0 || opcao < 3)
                            {
                                Console.WriteLine("\nOpção Ivalida!!!");
                            }
                            break;
                    }
                } while (opcao != 0);

                return psv;
            }
            else
            {
                Console.WriteLine("\nPassagem ou Voo não Encontrados!!!");
                return null;
            }
        }
        public void GravarPassagem(List<PassagemVoo> listaPassagem)
        {
            String msg = "";
            int opc = 0;
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\zejul\\source\\repos\\TesteAeronave\\Passagens\\Passagens.dat", append: true);
                foreach (PassagemVoo i in listaPassagem)
                {
                    msg = i.Id + i.IdVoo + i.DataUltimaOperacao.ToString("ddMMyyyy" + "HHmm") + i.Valor + i.Situacao;
                    sw.WriteLineAsync(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine("\nAperte Enter");
            Console.ReadKey();
        }
        public void LerRegistro(List<PassagemVoo> pas)
        {
            string line = "";
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\zejul\\source\\repos\\TesteAeronave\\Passagens\\Passagens.dat");
                string dv = line.Substring(8, 10);
                dv = dv.Substring(0, 2) + '/' + dv.Substring(2, 2) + "/" + dv.Substring(4, 2) + ' ' + dv.Substring(6, 2) + ':' + dv.Substring(8, 2);
                PassagemVoo pss = new PassagemVoo();
                line = sr.ReadLine();
                while (line != null)
                {
                    pss.Id = line.Substring(0, 6);
                    //  pss.IdVoo = line.Substring(6, 3);
                    // pss.IdAero = line.Substring(9, 3);
                    pss.DataUltimaOperacao = DateTime.Parse(dv);
                    // pss.Valor = line.Substring(9, 3);
                    pss.Situacao = char.Parse(line.Substring(29));
                    pas.Add(pss);

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