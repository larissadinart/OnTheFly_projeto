﻿using System;
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

        public void CadastrarPassageiro(List<Passageiro> passageiros) // não pode cadastrar o mesmo cpf 2x 
        {
            Passageiro passageiro = new Passageiro();

            Console.WriteLine("CADASTRO DE PASSAGEIRO");
            Console.WriteLine("Nome: ");
            passageiro.Nome = Console.ReadLine();
            //validação de tamanho
            while (passageiro.Nome.Length > 50)
            {
                Console.WriteLine("Digite um nome de até 50 digitos!");
                Console.WriteLine("Nome: ");
                passageiro.Nome = Console.ReadLine();
            }
            //validação do tamanho e condição de cpf valido
            Console.WriteLine("CPF: ");
            passageiro.Cpf = Console.ReadLine();
            while (ValidarCpf(passageiro.Cpf) == false || passageiro.Cpf.Length < 11)
            {
                Console.WriteLine("Cpf invalido, digite novamente");
                Console.WriteLine("CPF: ");
                this.Cpf = Console.ReadLine();
            }

            //validação da condição de não existir dois registros com cpfs iguais
            while (LocalizarPassageiro(passageiros, passageiro.Cpf) == true)
            {
                Console.WriteLine("Cpf já cadastrado, faça o cadastro com outro cpf");
                Console.WriteLine("CPF: ");
                passageiro.Cpf = Console.ReadLine();

            }

            Console.WriteLine("Data de nascimento: ");
            passageiro.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Sexo (M/F/N): ");
            passageiro.Sexo = char.Parse(Console.ReadLine());
            while (passageiro.Sexo != 'M' && passageiro.Sexo != 'F' && passageiro.Sexo != 'N')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Sexo (M/F/N): ");
                this.Sexo = char.Parse(Console.ReadLine());
            }

            Console.WriteLine("Ultima Compra: ");
            passageiro.UltimaCompra = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Data Cadastro: ");
            passageiro.DataCadastro = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Situação (A-Ativo / I- Inativo): ");
            passageiro.Situacao = char.Parse(Console.ReadLine());
            while (passageiro.Situacao != 'A' && passageiro.Situacao != 'I')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Situação(A - Ativo / I - Inativo): ");
                passageiro.Situacao = char.Parse(Console.ReadLine());
            }

            passageiros.Add(passageiro);

        }
        //Localiza pelo cpf e imprime um passageiro especifico 
        public void ImprimirPassageiroEspecifico(List<Passageiro> passageiros)
        {
            Console.WriteLine("Digite o cpf: ");
            string cpf = Console.ReadLine();
            Passageiro encontrouPassageiro = passageiros.Find(passageiro => passageiro.Cpf == cpf);

            if (encontrouPassageiro == null)
            {
                Console.WriteLine("Não existe um registro para esse cpf");
            }

            else
            {
                Console.WriteLine("Nome: " + encontrouPassageiro.Nome);
                Console.WriteLine("CPF: " + encontrouPassageiro.Cpf);
                Console.WriteLine("Data Nascimento: " + encontrouPassageiro.DataNascimento);
                Console.WriteLine("Sexo: " + encontrouPassageiro.Sexo);
                Console.WriteLine("Ultima Compra: " + encontrouPassageiro.UltimaCompra);
                Console.WriteLine("Data cadastro: " + encontrouPassageiro.DataCadastro);
                Console.WriteLine("Situacao: " + encontrouPassageiro.Situacao);
            }

        }

        public void ImprimirTodosPassageiros() // menos os com o status Inativo 
        {

        }

        //Localizar um passageiro espeficifico pelo cpf (usado na validação de cadastro) 
        public bool LocalizarPassageiro(List<Passageiro> passageiros, string cpf)
        {
            Passageiro encontrouPassageiro = passageiros.Find(passageiro => passageiro.Cpf == cpf);
            if (encontrouPassageiro == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // edita campos selecionados (menos o do cpf) 
        public void EditarPassageiro(List<Passageiro> passageiros, string nome, string cpf, DateTime dataNascimento, char sexo, DateTime ultimaCompra, DateTime dataCadastro, char situacao)
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
