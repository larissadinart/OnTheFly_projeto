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
        public String RazaoSocial { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime UltimoVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }


        public CompanhiaAerea()
        {

        }
        public CompanhiaAerea(String cnpj, String razaoSocial, DateTime dataAbertura, DateTime ultimoVoo, DateTime dataCadastro, char situacao)
        {
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.DataAbertura = dataAbertura;
            this.UltimoVoo = ultimoVoo;
            this.DataCadastro = dataCadastro;
            this.Situacao = situacao;
        }
        public CompanhiaAerea(string cnpj)
        {

        }
        public CompanhiaAerea CadastrarCia() ///VALIDAR SE CPF JA EXISTE NA LISTA
        {
            String cnpj = "", razaoSocial = "";
            DateTime dataAbertura = new DateTime();
            DateTime ultimoVoo = DateTime.Now;
            DateTime dataCadastro = DateTime.Now;
            char situacao = 'A';

            CompanhiaAerea ciaAerea = new CompanhiaAerea(cnpj, razaoSocial, dataAbertura, ultimoVoo, dataCadastro, situacao);
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

                }
                else
                {
                    Console.WriteLine("Impossível cadastrar! Tempo de abertura de empresa menor que 6 meses!\n\nTecle enter para continuar...");
                    Console.ReadKey();
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
        public override string ToString() //NÃO ESTÁ IMPRIMINDO AS INFOS
        {
            return $"CNPJ: {Cnpj}\nRazão Social: {RazaoSocial}\nData de Abertura: {DataAbertura.ToShortDateString()}\nData Do Último Vôo: {UltimoVoo.ToShortDateString()}\nData de Cadastro: {DataCadastro.ToShortDateString()}\nSituação: {Situacao}";
        }
    }
}




