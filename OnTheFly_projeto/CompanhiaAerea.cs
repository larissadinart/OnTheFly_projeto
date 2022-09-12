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
        public String Cnpj { get; set; }
        public String RazaoSocial { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime UltimoVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public CompanhiaAerea(String cnpj, String razaoSocial, DateTime dataAbertura, DateTime ultimoVoo, DateTime dataCadastro, char situacao)
        {
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.DataAbertura = dataAbertura;
            this.UltimoVoo = ultimoVoo;
            this.DataCadastro = dataCadastro;
            this.Situacao = situacao;
        }
        public CompanhiaAerea()
        {

        }
        public void CadastrarCia(List<CompanhiaAerea> TodasCias) //VALIDAR DUPLICIDADE DE CNPJ
        {
            CompanhiaAerea cia = new CompanhiaAerea();

            cia.UltimoVoo = DateTime.Now;
            cia.DataCadastro = DateTime.Now;
            cia.Situacao = 'A';            
            Console.Clear();

            Console.WriteLine("Digite o CNPJ da Companhia Aérea: ");
            cia.Cnpj = Console.ReadLine();

            if (ValidarCnpj(cia.Cnpj))
            {
                if (VerificaDuplicidadeCnpj(TodasCias, cia.Cnpj) == true)
                {
                    Console.WriteLine("CNPJ já cadastrado, cadastre outro CNPJ.\n\nTecle enter para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Digite a data de abertura da Companhia: ");
                    cia.DataAbertura = DateTime.Parse(Console.ReadLine()); //try catch
                    System.TimeSpan tempoAbertura = DateTime.Now.Subtract(cia.DataAbertura);

                    if (tempoAbertura.TotalDays > 190)
                    {
                        do
                        {
                            Console.WriteLine("Digite a Razão Social (até 50 dígitos) : ");
                            cia.RazaoSocial = Console.ReadLine();

                        } while (cia.RazaoSocial.Length > 50);
                        TodasCias.Add(cia);
                        Console.WriteLine("Companhia Cadastrada com Sucesso!\n\nAperte enter para continuar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Impossível cadastrar! Tempo de abertura de empresa menor que 6 meses!\n\nTecle enter para continuar...");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.WriteLine("CNPJ inválido!\n\nAperte enter para continuar...");
                Console.ReadKey();
                CadastrarCia(TodasCias);
            }
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
        public bool VerificaDuplicidadeCnpj(List<CompanhiaAerea> TodasCias, string cnpj) //Está entrando em true todas as vezes
        {
            foreach (var item in TodasCias)
            {
                if (cnpj.Equals(item.Cnpj))
                {
                    return true;
                }

            }
            return false;
        }
        public void LocalizarCiaAerea(List<CompanhiaAerea> TodasCias)
        {
            Console.WriteLine("Digite o CNPJ que deseja buscar: ");
            string cnpj = Console.ReadLine();

            CompanhiaAerea encontrouCia = TodasCias.Find(delegate (CompanhiaAerea cia) { return cia.Cnpj == cnpj; });

            if (encontrouCia == null)
            {
                Console.WriteLine("Não existe um registro para esse CNPJ.\n\nAperte enter para continuar...");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Razão Social: " + encontrouCia.RazaoSocial);
                Console.WriteLine("Ultimo Vôo: " + encontrouCia.UltimoVoo);
                Console.WriteLine("Data Abertura: " + encontrouCia.DataAbertura);
                Console.WriteLine("Data Cadastro: " + encontrouCia.DataCadastro);
                Console.WriteLine("Situacao: " + encontrouCia.Situacao);
                Console.WriteLine("\n\nAperte enter para continuar...");
                Console.ReadKey();
            }


        }
        public void EditarCia(List<CompanhiaAerea> TodasCias) //VALIDAR DATA ABERTURA
        {
            Console.WriteLine("Digite o CNPJ que deseja editar: ");
            string cnpj = Console.ReadLine();
            CompanhiaAerea encontrouCia = TodasCias.Find(TodasCias => TodasCias.Cnpj == cnpj);

            if (encontrouCia == null)
            {
                Console.WriteLine("Companhia aérea não localizada");

            }

            else
            {
                Console.Clear();
                int opc;
                
                Console.WriteLine("Digite a opção que deseja editar");
                Console.WriteLine("1- Razão Social");
                Console.WriteLine("2- Data de Abertura");
                Console.WriteLine("3- Data do Ultimo Vôo");
                Console.WriteLine("4- Data cadastro");
                Console.WriteLine("5- Situação");
                opc = int.Parse(Console.ReadLine());
                while (opc < 1 || opc > 5)
                {
                    Console.WriteLine("Digite uma opcao valida:");
                    opc = int.Parse(Console.ReadLine());
                }

                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Informe a Razão Social: ");
                        string razao = Console.ReadLine();
                        encontrouCia.RazaoSocial = razao;
                        break;
                    case 2:
                        Console.WriteLine("Informe a data de abertura: "); //validação 6 meses
                        DateTime data = DateTime.Parse(Console.ReadLine());
                        encontrouCia.DataAbertura = data;
                        break;
                    case 3:
                        Console.WriteLine("Informe a data do ultimo vôo: ");
                        DateTime ultimoVoo = DateTime.Parse(Console.ReadLine());
                        encontrouCia.UltimoVoo = ultimoVoo;
                        break;

                    case 4:
                        Console.WriteLine("Informe a data de cadastro: ");
                        DateTime dataCadastro = DateTime.Parse(Console.ReadLine());
                        encontrouCia.DataCadastro = dataCadastro;
                        break;
                    case 5:
                        Console.WriteLine("Informe a situação: ");
                        char situacao = char.Parse(Console.ReadLine());
                        encontrouCia.Situacao = situacao;
                        break;
                }
            }
        }
        public void ImprimirCiaEspecifica(List<CompanhiaAerea> TodasCias)
        {
            Console.WriteLine("Digite o CNPJ: ");
            string cnpj = Console.ReadLine();
            CompanhiaAerea encontrouCia = TodasCias.Find(TodasCias => TodasCias.Cnpj == cnpj);

            if (encontrouCia == null)
            {
                Console.WriteLine("Não existe um registro para esse CNPJ.");
            }

            else
            {
                Console.WriteLine($"Razão Social: {encontrouCia.RazaoSocial}\n");
                Console.WriteLine($"CNPJ: {encontrouCia.Cnpj}\n");
                Console.WriteLine($"Data de abertura: {encontrouCia.DataAbertura}\n");
                Console.WriteLine($"Data Do Último Vôo: {encontrouCia.UltimoVoo}\n");
                Console.WriteLine($"Data do cadastro: {encontrouCia.DataCadastro}\n");
                Console.WriteLine($"Situacao: {encontrouCia.Situacao}\n");
            }

        }
        public void ImprimirTodasCias(List<CompanhiaAerea> TodasCias)
        {
            foreach (CompanhiaAerea cia in TodasCias)
            {
                if (cia.Situacao == 'A')
                {
                    Console.WriteLine($"Razão Social: {cia.RazaoSocial}\n");
                    Console.WriteLine($"CNPJ: {cia.Cnpj}\n");
                    Console.WriteLine($"Data de abertura: {cia.DataAbertura}\n");
                    Console.WriteLine($"Data Do Último Vôo: {cia.UltimoVoo}\n");
                    Console.WriteLine($"Data do cadastro: {cia.DataCadastro}\n");
                    Console.WriteLine($"Situacao: {cia.Situacao}\n");
                }
            }
        }
        public void CadastrarBloqueadas(List<string> bloqueadas)
        {
            Console.WriteLine("Digite o CNPJ bloqueado: ");
            string cnpj = Console.ReadLine();

            while (ValidarCnpj(cnpj) == false)

                Console.WriteLine("CNPJ inválido, tente novamente: ");
            cnpj = Console.ReadLine();

            string encontrouBloqueado = bloqueadas.Find(bloqueadas => bloqueadas == cnpj);

            if (encontrouBloqueado != null)
            {
                Console.WriteLine("CNPJ já cadastrado!!\n\nAperte enter para continuar...");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Cadastro efetuado com sucesso!\n\nAperte enter para continuar...");
                Console.ReadKey();
                bloqueadas.Add(cnpj);
            }

        }
        public void LocalizarBloqueadas(List<string> bloqueadas)
        {
            Console.WriteLine("Digite o CNPJ que deseja consultar: ");
            string cnpj = Console.ReadLine();
            string encontrouBloqueado = bloqueadas.Find(bloqueadas => bloqueadas == cnpj);

            if (encontrouBloqueado != null)
            {
                Console.WriteLine("Esse CNPJ é restrito!\n\nAperte enter para continuar...");
                Console.ReadKey();

            }

            else
            {
                Console.WriteLine("Não há nenhuma restrição para este CNPJ!\n\nAperte enter para continuar...");
                Console.ReadKey();
            }
        }
        public void RemoverBloqueadas(List<string> bloqueadas)
        {
            Console.WriteLine("Digite o CNPJ para remover: ");
            string cnpj = Console.ReadLine();
            string encontrouBloqueado = bloqueadas.Find(bloqueadas => bloqueadas == cnpj);

            if (encontrouBloqueado != null)
            {
                bloqueadas.Remove(encontrouBloqueado);
                Console.WriteLine("O CNPJ foi removido da lista de bloqueados\n\nAperte enter para continuar...");
                Console.ReadKey();
            }

        }
        public override string ToString()
        {
            return $"\nCNPJ: {Cnpj}\nRazão Social: {RazaoSocial}\nData de Abertura: {DataAbertura.ToShortDateString()}\nData Do Último Vôo: {UltimoVoo.ToShortDateString()}\nData de Cadastro: {DataCadastro.ToShortDateString()}\nSituação: {Situacao}\n\n";
        }
    }
}
