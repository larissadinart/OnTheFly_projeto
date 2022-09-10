using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class CompanhiaAerea
    {
        public String Cnpj { get; set; } // CHAVE!!! 
        public String RazaoSocial { get; set; } //ate 50 digitos
        public DateTime DataAbertura { get; set; } // não poderemos cadastrar empresas com menos de 6 meses de abertura
        public DateTime UltimoVoo { get; set; }//no momento do cadastro pode ser a data atual
        public DateTime DataCadastro { get; set; } //data atual do sistema
        public char Situacao { get; set; } //A-Ativou ou I-Inativo

        public CompanhiaAerea(String cnpj, string razaoSocial)
        {
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
        }

        public CompanhiaAerea CadastrarCia()
        {
            String cnpj = "", razaoSocial = "";
            DateTime dataAbertura;
            DateTime ultimoVoo = DateTime.Now;
            DateTime dataCadastro = DateTime.Now;
            char situacao;

            CompanhiaAerea ciaAerea = new CompanhiaAerea(cnpj, razaoSocial);
            Console.Clear();
            Console.WriteLine("Digite o CNPJ da Companhia Aérea (somente números): ");
            cnpj = Console.ReadLine();
            if (ValidarCnpj(cnpj))
            {
                Console.WriteLine("Digite a data de abertura da Companhia: ");

                dataAbertura = DateTime.Parse(Console.ReadLine());
                System.TimeSpan tempoAbertura = DateTime.Now.Subtract(dataAbertura);

                if (tempoAbertura.TotalDays > 190)
                {
                    do
                    {
                        Console.WriteLine("Digite a Razão Social (até 50 dígitos) : ");
                        razaoSocial = Console.ReadLine();

                    } while (razaoSocial.Length > 50);

                    Console.WriteLine("Digite a situação: \nA-Ativo\nI-Inativo");
                    try
                    {
                        situacao = char.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Opção inválida!");
                    }
                    GravarArquivo(ciaAerea);
                }
                else
                {
                    Console.WriteLine("Impossível cadastrar! Tempo de abertura de empresa menor que 6 meses!\n\nTecle enter para continuar...");
                    Console.ReadKey();
                    CadastrarCia();
                }
            }
            else
            {
                Console.WriteLine("CNPJ inválido!\n\nAperte enter para continuar...");
                Console.ReadKey();
                CadastrarCia();
            }
            return ciaAerea;
        }
        public bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;


            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else

                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        public void GravarArquivo(CompanhiaAerea ciaAerea)
        {
            StreamWriter sw = new StreamWriter("c:\\Listas\\CadastroCias.txt");
            sw.WriteLine(ciaAerea.ToString());
            sw.Close();
        }
        public void LerArquivo()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("c:\\Listas\\CadastroCias.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("Fim do arquivo.");

            }catch(Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }



        }
        public override string ToString() //NÃO ESTÁ IMPRIMINDO AS INFOS
        {
            return $"CNPJ: {Cnpj}\nRazão Social: {RazaoSocial}\nData de Abertura: {DataAbertura.ToShortDateString()}\nData Do Último Vôo: {UltimoVoo.ToShortDateString()}\nData de Cadastro: {DataCadastro.ToShortDateString()}\nSituação: {Situacao}";
        }
        

    }
}
