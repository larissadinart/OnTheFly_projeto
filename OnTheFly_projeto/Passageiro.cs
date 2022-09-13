using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFly_projeto
{
    internal class Passageiro
    {
        public String Nome { get; set; } 
        public String Cpf { get; set; } 
        public DateTime DataNascimento { get; set; } 
        public char Sexo { get; set; }
        public DateTime UltimaCompra { get; set; } 
        public DateTime DataCadastro { get; set; } 
        public char Situacao { get; set; } 

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
                passageiro.Cpf = Console.ReadLine();
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
                passageiro.Sexo = char.Parse(Console.ReadLine());
            }


            passageiro.UltimaCompra = DateTime.Now;

            passageiro.DataCadastro = DateTime.Now;

            Console.WriteLine("Situação (A-Ativo / I- Inativo): ");
            passageiro.Situacao = char.Parse(Console.ReadLine());
            while (passageiro.Situacao != 'A' && passageiro.Situacao != 'I')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Situação(A - Ativo / I - Inativo): ");
                passageiro.Situacao = char.Parse(Console.ReadLine());
            }


            Console.WriteLine("Deseja efetuar a gravação? ");
            Console.WriteLine("1- Sim");
            Console.WriteLine("2-Não");
            int opc = int.Parse(Console.ReadLine());

            if (opc == 1)
            {
                Console.WriteLine("Gravação efetuada com sucesso!");
                passageiros.Add(passageiro);
                GravarPassageiros(passageiros);
            }

            else

            {
                Console.WriteLine("Gravação não efetuada");
                passageiros.Add(passageiro);
            }


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

        public void ImprimirTodosPassageiros(List<Passageiro> passageiros) // menos os com o status Inativo 
        {
            foreach (Passageiro passageiro in passageiros)
            {
                if (passageiro.Situacao == 'A')
                {
                    Console.WriteLine("Nome: " + passageiro.Nome);
                    Console.WriteLine("CPF: " + passageiro.Cpf);
                    Console.WriteLine("Data Nascimento: " + passageiro.DataNascimento);
                    Console.WriteLine("Sexo: " + passageiro.Sexo);
                    Console.WriteLine("Ultima Compra: " + passageiro.UltimaCompra);
                    Console.WriteLine("Data cadastro: " + passageiro.DataCadastro);
                    Console.WriteLine("Situacao: " + passageiro.Situacao);
                }
            }
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
        public void EditarPassageiro(List<Passageiro> passageiros)
        {
            Console.WriteLine("Digite o cpf: ");
            string cpf = Console.ReadLine();
            Passageiro encontrouPassageiro = passageiros.Find(passageiro => passageiro.Cpf == cpf);

            if (encontrouPassageiro == null)
            {
                Console.WriteLine("Passageiro não localizado");

            }

            else
            {
                int opc;

                Console.WriteLine("Digite a opção que deseja editar");
                Console.WriteLine("1-Nome");
                Console.WriteLine("2-Data de nascimento");
                Console.WriteLine("3-Sexo (M/F/N)");
                Console.WriteLine("4-Ultima compra");
                Console.WriteLine("5-Data cadastro");
                Console.WriteLine("6-Situação");
                opc = int.Parse(Console.ReadLine());
                while (opc < 1 || opc > 6)
                {
                    Console.WriteLine("Digite uma opcao valida:");
                    opc = int.Parse(Console.ReadLine());
                }

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Informe o nome: ");
                        string nome = Console.ReadLine();
                        encontrouPassageiro.Nome = nome;
                        break;
                    case 2:
                        Console.WriteLine("Informe a data de nascimento: ");
                        DateTime dataNasc = DateTime.Parse(Console.ReadLine());
                        encontrouPassageiro.DataNascimento = dataNasc;
                        break;
                    case 3:
                        Console.WriteLine("Informe o sexo (M/F/N): ");
                        char sexo = char.Parse(Console.ReadLine());
                        encontrouPassageiro.Sexo = sexo;
                        break;
                    case 4:
                        Console.WriteLine("Informe a ultima compra: ");
                        DateTime ultimaCompra = DateTime.Parse(Console.ReadLine());
                        encontrouPassageiro.UltimaCompra = ultimaCompra;
                        break;
                    case 5:
                        Console.WriteLine("Informe a data de cadastro: ");
                        DateTime dataCadastro = DateTime.Parse(Console.ReadLine());
                        encontrouPassageiro.DataCadastro = dataCadastro;
                        break;
                    case 6:
                        Console.WriteLine("Informe a situação: ");
                        char situacao = char.Parse(Console.ReadLine());
                        encontrouPassageiro.Situacao = situacao;
                        break;
                }

                Console.WriteLine("Deseja efetuar a gravação? ");
                Console.WriteLine("1- Sim");
                Console.WriteLine("2-Não");
                int opcGravacao = int.Parse(Console.ReadLine());

                if (opcGravacao == 1)
                {

                    GravarPassageiros(passageiros);
                }

                else
                {
                    Console.WriteLine("Gravação não efetuada!");
                }
            }
        }

        public void CadastrarRestrito(List<string> restritos)
        {
            Console.WriteLine("Digite o CPF restrito: ");
            string cpf = Console.ReadLine();
            while (ValidarCpf(cpf) == false || cpf.Length < 11)
            {
                Console.WriteLine("CPF inválido, insira novamente: ");
                cpf = Console.ReadLine();
            }

            string encontrouRestrito = restritos.Find(restrito => restrito == cpf);

            if (encontrouRestrito != null)
            {
                Console.WriteLine("Esse CPF já existe na lista de restritos!");
                Console.WriteLine("Impossivel inserir novamente!");
            }

            else

            {
                Console.WriteLine("Cadastro efetuado com sucesso!");
                restritos.Add(cpf);
                GravarRestrito(restritos);
            }
        }

        public void LocalizarRestrito(List<string> restritos)
        {
            Console.WriteLine("Digite o CPF para consultar: ");
            string cpf = Console.ReadLine();
            string encontrouRestrito = restritos.Find(restrito => restrito == cpf);

            if (encontrouRestrito != null)
            {
                Console.WriteLine("Esse CPF é restrito pela Polícia Federal!");

            }

            else
            {
                Console.WriteLine("Não há nenhuma restrição desse CPF na Polícia Federal!");
            }
        }

        public void RetirarRestrito(List<string> restritos)
        {
            Console.WriteLine("Digite o CPF para remover: ");
            string cpf = Console.ReadLine();
            string encontrouRestrito = restritos.Find(restrito => restrito == cpf);

            if (encontrouRestrito != null)
            {
                restritos.Remove(encontrouRestrito);
                Console.WriteLine("O CPF foi removido da lista de restritros");
                GravarRestrito(restritos);
            }

        }

        public void LerPassageiros(List<Passageiro> passageiros)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Arquivo\\Passageiro.dat");
                line = sr.ReadLine();

                while (line != null)
                {

                    string dataNasc = line.Substring(61, 12);
                    dataNasc = dataNasc.Substring(0, 2) + '/' + dataNasc.Substring(2, 2) + "/" + dataNasc.Substring(4, 4) + ' ' + dataNasc.Substring(8, 2) + ':' + dataNasc.Substring(10, 2);
                    string ultimaC = line.Substring(74, 12);
                    ultimaC = ultimaC.Substring(0, 2) + '/' + ultimaC.Substring(2, 2) + "/" + ultimaC.Substring(4, 4) + ' ' + ultimaC.Substring(8, 2) + ':' + ultimaC.Substring(10, 2);
                    string dataC = line.Substring(86, 12);
                    dataC = dataC.Substring(0, 2) + '/' + dataC.Substring(2, 2) + "/" + dataC.Substring(4, 4) + ' ' + dataC.Substring(8, 2) + ':' + dataC.Substring(10, 2);
                    Passageiro passageiro = new Passageiro();
                    passageiro.Nome = line.Substring(0, 50).Replace(" ", "");
                    passageiro.Cpf = line.Substring(50, 11);
                    passageiro.DataNascimento = DateTime.Parse(dataNasc);
                    passageiro.Sexo = char.Parse(line.Substring(73, 1));
                    passageiro.UltimaCompra = DateTime.Parse(ultimaC);
                    passageiro.DataCadastro = DateTime.Parse(dataC);
                    passageiro.Situacao = char.Parse(line.Substring(98, 1));
                    passageiros.Add(passageiro);
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

        public void GravarPassageiros(List<Passageiro> passageiros)
        {
            string passageiro;
            try
            {
                StreamWriter streamWriter = new StreamWriter("C:\\Arquivo\\Passageiro.dat");
                foreach (Passageiro p in passageiros)
                {

                    passageiro = ((p.Nome.PadRight(50, ' ') + p.Cpf + p.DataNascimento.ToString("ddMMyyyy" + "hhmm") + p.Sexo + p.UltimaCompra.ToString("ddMMyyyy" + "hhmm") + p.DataCadastro.ToString("ddMMyyyy" + "hhmm") + p.Situacao).ToString());
                    streamWriter.WriteLineAsync(passageiro);

                }
                streamWriter.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public void GravarRestrito(List<string> restritos)
        {
            string restrito;
            try
            {
                StreamWriter streamWriter = new StreamWriter("C:\\Arquivo\\Restrito.dat");
                foreach (string r in restritos)
                {

                    restrito = r;
                    streamWriter.WriteLineAsync(restrito);

                }
                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void LerRestritos(List<string> restritos)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Arquivo\\Restrito.dat");
                line = sr.ReadLine();

                while (line != null)
                {
                    restritos.Add(line);
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
