using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class Passageiro
    {
        public String Nome { get; set; } // até 50 dígitos
        public String Cpf { get; set; } // CHAVE!! atributo chave(11 dígitos, ver algoritmo de criação de cpf)
        public DateTime DataNascimento { get; set; } // não vender para menores de 18 anos
        public char Sexo { get; set; }
        public DateTime UltimaCompra { get; set; } // no cadastro pode ser a data atual
        public DateTime DataCadastro { get; set; } //data atual do sistema
        public char Situacao { get; set; } // A - Ativo ou I- Inativo

        public Passageiro()
        {

        }
        public Passageiro(string nome, string cpf, DateTime dataNascimento, char sexo, DateTime ultimaCompra, DateTime dataCadastro, char situacao)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.UltimaCompra = ultimaCompra;
            this.DataCadastro = dataCadastro;
            this.Situacao = situacao;
        }

        public void CadastrarPassageiro() // não pode cadastrar o mesmo cpf 2x 
        {
            Console.WriteLine("CADASTRO DE PASSAGEIRO");
            Console.WriteLine("Nome: ");
            this.Nome = Console.ReadLine();
            while (this.Nome.Length > 50)
            {
                Console.WriteLine("Digite um nome de até 50 digitos!");
                Console.WriteLine("Nome: ");
                this.Nome = Console.ReadLine();
            }
            Console.WriteLine("CPF: ");
            this.Cpf = Console.ReadLine();
            while  (ValidarCpf(this.Cpf) == false || this.Cpf.Length < 11)
            {
                Console.WriteLine("Cpf invalido, digite novamente");
                Console.WriteLine("CPF: ");
                this.Cpf = Console.ReadLine();
            }
            Console.WriteLine("Data de nascimento: ");
            this.DataNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Sexo (M/F/N): ");
            this.Sexo = char.Parse(Console.ReadLine());
            while (this.Sexo != 'M' && this.Sexo != 'F' && this.Sexo != 'N') ; 
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Sexo (M/F/N): ");
                this.Sexo = char.Parse(Console.ReadLine());
            }
            Console.WriteLine("Ultima Compra: ");
            this.UltimaCompra = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Data Cadastro: ");
            this.DataCadastro = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Situação (A-Ativo / I- Inativo): ");
            this.Situacao = char.Parse(Console.ReadLine());
            while (this.Situacao != 'A' && this.Situacao != 'I')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Situação(A - Ativo / I - Inativo): ");
                this.Situacao = char.Parse(Console.ReadLine());
            }
        }

        public void ImprimirPassageiro() 
        {
            Console.WriteLine("Nome: "+ this.Nome);
            Console.WriteLine("Data de nascimento: "+this.DataNascimento);
            Console.WriteLine("CPF: "+this.Cpf);
            Console.WriteLine("Sexo: "+this.Sexo);
            Console.WriteLine("Ultima compra: "+this.UltimaCompra);
            Console.WriteLine("Data cadastro: "+this.DataCadastro);
            Console.WriteLine("Situação: "+this.Situacao);
          
        }

        public void LocalizarPassageiro() //Localizar um passageiro espeficifico pelo cpf e imprimir 
        {
            
        }


        public void EditarPassageiro() // edita campos selecionados (menos o do cpf) 
        {

        }
        public void AlterarSituacao()
        {

        }

        public bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
