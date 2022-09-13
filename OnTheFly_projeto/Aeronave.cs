using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class Aeronave
    {
        public String Inscricao { get; set; }
        public String Capacidade { get; set; }
        public String AssentosOcupados { get; set; } 
        public DateTime UltimaVenda = DateTime.Now;
        public DateTime DataCadastro = DateTime.Now;
        public char Situacao { get; set; }
        public Aeronave() { }
        public Aeronave(String Inscrição, char Situacao, String Capacidade, String AssentosOcupados)
        {

            this.Inscricao = Inscrição;
            this.Capacidade = Capacidade;
            this.AssentosOcupados = AssentosOcupados;
            this.Situacao = Situacao;
        }
        #region GeraNumeros
        public String GeraNumero()
        {
            Random rand = new Random();
            int[] numero = new int[100];
            int aux = 0;
            String convert = "";
            for (int k = 0; k < numero.Length; k++)
            {
                int rnd = 0;
                do
                {
                    rnd = rand.Next(100, 999);
                } while (numero.Contains(rnd));
                numero[k] = rnd;
                aux = numero[k];
                convert = aux.ToString();
                break;
            }
            return convert;
        }
        #endregion

        #region Cadastra Aeronave
        public void CadastroAeronaves(List<Aeronave> lista, List<Aeronave> ativo, List<Aeronave> inativo)
        {
            this.Inscricao = "PR-" + GeraNumero();
            #region Capacidade Aeronave
            int cap = 0;
            do
            {
                Console.Write("Informe a Capacidade da Aeronave: ");
                cap = int.Parse(Console.ReadLine());
                if (cap < 100 || cap > 999)
                {
                    Console.Clear();
                    Console.WriteLine("\nCapacidade Informada Inválida...!!!" +
                                      "\nInforme Novamente!!!");

                    Thread.Sleep(2000);
                    Console.Clear();
                }
                Capacidade = cap.ToString();

            } while (cap < 100 || cap > 999);
            #endregion

            #region Situação Aeronave
            do
            {
                Console.Write("\nInfome a Situação da Aeronave:" +
                              "\nA-Ativo ou I-Inativo\n" +
                              "\nSituação: ");
                Situacao = char.Parse(Console.ReadLine().ToUpper());

                if (Situacao == 'A')
                {
                    ativo.Add(new Aeronave(Inscricao, Situacao, Capacidade, AssentosOcupados));
                    GravarDocumento(Situacao, lista, ativo, inativo);
                    break;
                }
                else
                {
                    inativo.Add(new Aeronave(Inscricao, Situacao, Capacidade, AssentosOcupados));
                    GravarDocumento(Situacao, lista, ativo, inativo);
                }

            } while (!Situacao.Equals('A') && !Situacao.Equals('I'));
            #endregion
            lista.Add(new Aeronave(Inscricao, Situacao, Capacidade, AssentosOcupados));
            // GravaDocumento();
        }
        #endregion

        #region Consulta Aeronave
        public void ConsultarAeronave(List<Aeronave> lista, List<Aeronave> ativo, List<Aeronave> inativo)
        {
            char consulta;
            Aeronave aero = new Aeronave();
            Console.Write("\nDeseja Concultar Situação de Aeronave" +
                             "\nA-Ativo , I-Inativo ou G-Geral\n" +
                             "\nConsulta: ");
            consulta = char.Parse(Console.ReadLine().ToUpper());

            if (consulta.CompareTo('A') == 0)
            {
                foreach (Aeronave nave in ativo)
                {

                    Console.WriteLine(nave.ImprimeAeronaves(consulta));
                    Console.WriteLine("\n");
                }
            }
            else
            {
                if (consulta.CompareTo('I') == 0)
                {
                    foreach (Aeronave nave in inativo)
                    {
                        Console.WriteLine(nave.ImprimeAeronaves(consulta));
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    foreach (Aeronave nave in lista)
                    {
                        Console.WriteLine(nave.ImprimeAeronaves(consulta));
                        Console.WriteLine("\n");
                    }
                }
            }
        }
        #endregion

        #region Verifica Aeronaves Ativas
        public bool ExisteAeronave(List<Aeronave> lista, List<Aeronave> ativo, List<Aeronave> inativo)
        {
            if (Situacao == 'A')
            {
                return true;
            }
            else
            {
                return false;
                Console.WriteLine("\nNão Existe Aeronaves Ativas para Voo...");
            }
        }
        #endregion

        #region Imprime Aeronaves
        public String ImprimeAeronaves(char consulta)
        {
            if (consulta == 'A')
            {
                return "*** Aeronave Inativas OnTheFly ***" +
                   "\nIscricao: " + this.Inscricao +
                   "\nSituacao: " + this.Situacao +
                   "\nCapacidade: " + this.Capacidade +
                   "\nAssentos Ocupados: " + this.AssentosOcupados +
                   "\nUltima Venda: " + this.UltimaVenda +
                   "\nData do Cadastro: " + this.DataCadastro;
            }
            else
            {
                if (consulta == 'I')
                {
                    return "*** Aeronave Inativas OnTheFly ***" +
                   "\nIscricao: " + this.Inscricao +
                   "\nSituacao: " + this.Situacao +
                   "\nCapacidade: " + this.Capacidade +
                   "\nAssentos Ocupados: " + this.AssentosOcupados +
                   "\nUltima Venda: " + this.UltimaVenda +
                   "\nData do Cadastro: " + this.DataCadastro;
                }
                else
                {
                    return "*** Aeronave Gerais OnTheFly ***" +
                   "\nIscricao: " + this.Inscricao +
                   "\nSituacao: " + this.Situacao +
                   "\nCapacidade: " + this.Capacidade +
                   "\nAssentos Ocupados: " + this.AssentosOcupados +
                   "\nUltima Venda: " + this.UltimaVenda +
                   "\nData do Cadastro: " + this.DataCadastro;

                }
            }
        }
        #endregion
        public void LocalizarEditar(List<Aeronave> aero, List<Aeronave> atv, List<Aeronave> itv)
        {
            Aeronave aviao = new Aeronave();
            Console.Write("Informe a Inscricao de Aeronave que deseja Consultar:  ");
            string navinha = Console.ReadLine();
            Aeronave encontrouAeronave = aero.Find(viao => viao.Inscricao.Equals(navinha));

            if (encontrouAeronave == null)
            {
                Console.WriteLine("Aeronave não Encontrado...");
            }
            else
            {
                Console.WriteLine("\nIscricao: " + this.Inscricao +
                                  "\nSituacao: " + this.Situacao +
                                  "\nCapacidade: " + this.Capacidade +
                                  "\nAssentos Ocupados: " + this.AssentosOcupados +
                                  "\nData do Cadastro: " + this.DataCadastro);
            }

            Console.WriteLine("\n\nDeseja alterar as Informações da Aeronave?");
            Console.WriteLine("\nSim -S ou Não -N");
            Console.Write("\nInforme: ");
            char escolha = char.Parse(Console.ReadLine());

            if (escolha.CompareTo('S') == 0)
            {
                Console.Write("\n Alterare a situação da Aeronave:" +
                            "\nA-Ativo ou I-Inativo\n" +
                            "\nSituação: ");
                char st = char.Parse(Console.ReadLine());

                Console.Write("Altere a Capacidade da Aeronave: ");
                int cp = int.Parse(Console.ReadLine());

                Console.Write("Altere a Quantidade de Assentos Ocupados da Aeronave: ");
                int asocp = int.Parse(Console.ReadLine());
                aviao.Situacao = st;
                aviao.Capacidade = cp.ToString();
                aviao.AssentosOcupados = cp.ToString();
                aero.Add(aviao);
                GravarDocumento(st, aero, atv, itv);
            }
            else
            {
                Console.WriteLine("\nDados não Foram Alterados continuam estaveis!!! ");
            }
        }
        public void GravarDocumento(Char gera, List<Aeronave> lista, List<Aeronave> ativo, List<Aeronave> inativo)
        {
            String msg = "";
            if (gera.CompareTo('A') == 0)
            {
                foreach (Aeronave nave in ativo)
                {
                    msg = this.Inscricao + this.Situacao + this.Capacidade + this.AssentosOcupados +
                           this.UltimaVenda.ToString("ddMMyyyy" + "HHmm") + this.DataCadastro.ToString("ddMMyyyy" + "HHmm");
                }
                try
                {
                    StreamWriter sw = new StreamWriter("C:\\Users\\zejul\\source\\repos\\TesteAeronave\\Ativos\\AeronavesAtivas.dat", append: true);
                    sw.WriteLineAsync(msg);
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            else
            {
                if (gera.CompareTo('I') == 0)
                {
                    foreach (Aeronave nave in inativo)
                    {
                        msg = this.Inscricao + GeraNumero().ToString() + this.Situacao + this.Capacidade + this.AssentosOcupados +
                           this.UltimaVenda.ToString("ddMMyyyy" + "HHmm") + this.DataCadastro.ToString("ddMMyyyy" + "HHmm");
                    }
                    try
                    {
                        StreamWriter sw = new StreamWriter("C:\\Users\\zejul\\source\\repos\\TesteAeronave\\Inativos\\AeronavesInativas.dat", append: true);
                        sw.WriteLineAsync(msg);
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                }
            }
            foreach (Aeronave nave in lista)
            {
                msg = this.Inscricao + GeraNumero().ToString() + this.Situacao + this.Capacidade + this.AssentosOcupados +
                          this.UltimaVenda.ToString("ddMMyyyy" + "HHmm") + this.DataCadastro.ToString("ddMMyyyy" + "HHmm");
            }
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\zejul\\source\\repos\\TesteAeronave\\Geral\\Aeronave.dat", append: true);
                sw.WriteLineAsync(msg);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public void LerDocumento(List<Aeronave> nave)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\zejul\\source\\repos\\TesteAeronave\\Geral\\Aeronave.dat");
                line = sr.ReadLine();
                string dv = line.Substring(8, 10);
                dv = dv.Substring(0, 2) + '/' + dv.Substring(2, 2) + "/" + dv.Substring(4, 2) + ' ' + dv.Substring(6, 2) + ':' + dv.Substring(8, 2);
                Aeronave aero = new Aeronave();
                while (line != null)
                {
                    aero.Inscricao = line.Substring(0, 6);
                    aero.Capacidade = line.Substring(6, 3);
                    aero.AssentosOcupados = line.Substring(9, 3);
                    aero.UltimaVenda = DateTime.Parse(dv); // passar valor fixo para teste
                    aero.DataCadastro = DateTime.Parse(dv);
                    aero.Situacao = char.Parse(line.Substring(29));
                    nave.Add(aero);

                    Console.WriteLine(line);
                    line = sr.ReadLine();
                    Console.WriteLine("\nAperte Enter");
                    Console.ReadKey();
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
        public void LerAtivos(List<Aeronave> nave)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\zejul\\source\\repos\\TesteAeronave\\Ativos\\AeronavesAtivas.dat");
                line = sr.ReadLine();
                string dv = line.Substring(8, 10);
                dv = dv.Substring(0, 2) + '/' + dv.Substring(2, 2) + "/" + dv.Substring(4, 2) + ' ' + dv.Substring(6, 2) + ':' + dv.Substring(8, 2);
                Aeronave aero = new Aeronave();
                while (line != null)
                {
                    aero.Inscricao = line.Substring(0, 6);
                    aero.Capacidade = line.Substring(6, 3);
                    aero.AssentosOcupados = line.Substring(9, 3);
                    aero.UltimaVenda = DateTime.Parse(dv); // passar valor fixo para teste
                    aero.DataCadastro = DateTime.Parse(dv);
                    aero.Situacao = char.Parse(line.Substring(29));
                    nave.Add(aero);

                    Console.WriteLine(line);
                    line = sr.ReadLine();
                    Console.WriteLine("\nAperte Enter");
                    Console.ReadKey();
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
        public void LerInativos(List<Aeronave> nave)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\zejul\\source\\repos\\TesteAeronave\\Inativos\\AeronavesInativas.dat");
                line = sr.ReadLine();
                string dv = line.Substring(8, 10);
                dv = dv.Substring(0, 2) + '/' + dv.Substring(2, 2) + "/" + dv.Substring(4, 2) + ' ' + dv.Substring(6, 2) + ':' + dv.Substring(8, 2);
                Aeronave aero = new Aeronave();
                while (line != null)
                {
                    aero.Inscricao = line.Substring(0, 6);
                    aero.Capacidade = line.Substring(6, 3);
                    aero.AssentosOcupados = line.Substring(9, 3);
                    aero.UltimaVenda = DateTime.Parse(dv); // passar valor fixo para teste
                    aero.DataCadastro = DateTime.Parse(dv);
                    aero.Situacao = char.Parse(line.Substring(29));
                    nave.Add(aero);

                    Console.WriteLine(line);
                    line = sr.ReadLine();
                    Console.WriteLine("\nAperte Enter");
                    Console.ReadKey();
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