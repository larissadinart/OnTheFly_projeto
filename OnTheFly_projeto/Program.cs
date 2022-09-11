using System;
using System.Collections.Generic;
using System.IO;

namespace OnTheFly_projeto
{
    internal class Program
    {
        static List<CompanhiaAerea> ListCiasAtivas = new List<CompanhiaAerea>();
        static List<CompanhiaAerea> ListCiasInativas = new List<CompanhiaAerea>();
        static List<CompanhiaAerea> ListTodasCias = new List<CompanhiaAerea>();
        static List<CompanhiaAerea> ListCiasBloqueadas = new List<CompanhiaAerea>();

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine(">>>>> BEM VINDO AO AEROPORTO ON THE FLY! <<<<<\n\n");
            Console.WriteLine("Faça seu login para entrar: \n");
            string usuario, usu = "admin";
            string senha, sen = "admin";

            Console.WriteLine("Digite o usuário: ");
            usuario = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            senha = Console.ReadLine();

            if (usuario == usu && senha == sen)
            {
                Opcoes();
            }
            else
            {
                Console.WriteLine("Usuário ou senha inválidos!\n\n");
                Console.WriteLine("Aperte enter para continuar....");
                Console.ReadKey();
                Menu();
            }
        }
        public static void Opcoes()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cliente\n3- Cia.Aérea\n4- Destinos\n5- Vôos\n6- Aviões\n0- Sair");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Menu();
                        break;
                    case 2:
                        Cliente();
                        break;
                    case 3:
                        CiaAerea();
                        break;
                    case 4:
                        Destinos();
                        break;
                    case 5:
                        Voos();
                        break;
                    case 6:
                        Avioes();
                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 3);
        }
        public static void Cliente()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Imprimir por Registro\n6- Restritos\n0- Sair");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Opcoes();
                        break;
                    case 2:
                        Cadastro();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6: //restritos
                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 5);
        }
        public static void CiaAerea()
        {
            int op;
            CompanhiaAerea cia = new CompanhiaAerea();
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Imprimir por Registro\n6- Bloqueados\n0- Sair");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Opcoes();
                        break;
                    case 2:
                        cia.CadastrarCia();
                        Menu();
                        break;
                    case 3:
                        BuscarCiasAereasLista();
                        break;
                    case 4:
                        EditarCiaAereaLista();
                        break;
                    case 5: //imprimir por registro
                        break;
                    case 6: //bloqueados
                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 5);
        }
        public static void Destinos()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Imprimir por Registro\n0- Sair");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Opcoes();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 5);

        }
        public static void Voos()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Imprimir por Registro\n0- Sair");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Opcoes();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 5);
        }
        public static void Avioes()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Imprimir por Registro\n0- Sair");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Opcoes();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 5);
        }
        public static void Cadastro()
        {
            int op;

            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada: \n\n1- Cadastrar Cliente\n2- Cadastrar Cia. Aérea\n3- Cadastrar Vôo\n4- Cadastro de Destinos\n5- Cadastro de Aviões");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 5);
        }
        public static void ClientesRestritos()
        {
            int op;

            Console.Clear();
            Console.WriteLine("Escolha a opção desejada: \n1- Voltar ao Menu Anterior\n2-Inserir Cliente\n3- Remover Cliente\n4- Visualizar lista\n0- Sair");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Cadastro();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;

            }
        }
        public static void CiasBloqueadas()
        {
            int op;

            Console.Clear();
            Console.WriteLine("Escolha a opção desejada: \n1- Voltar ao Menu Anterior\n2-Inserir Cia. Aérea\n3- Remover Cia. Aérea\n4- Visualizar lista\n0- Sair");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Cadastro();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        public static void GravarArquivoAtivas(CompanhiaAerea ciaAerea) //MUDAR ARQUIVO PARA .DAT
        {
            StreamWriter sw = new System.IO.StreamWriter("c:\\Listas\\CadastroCiasAtivas.txt");
            sw.WriteLine(ciaAerea.ToString());
            sw.Close();
        }
        public static void GravarArquivoInativas(CompanhiaAerea ciaAerea) //MUDAR ARQUIVO PARA .DAT
        {
            StreamWriter sw = new StreamWriter("c:\\Listas\\CadastroCiasInativas.txt");
            sw.WriteLine(ciaAerea.ToString());
            sw.Close();
        }
        public static void GravarArquivoBloqueadas(CompanhiaAerea ciaAerea) //MUDAR ARQUIVO PARA .DAT
        {
            StreamWriter sw = new StreamWriter("c:\\Listas\\CadastroCiasBloqueadas.txt");
            sw.WriteLine(ciaAerea.ToString());
            sw.Close();
        }
        public static void LerArquivoAtivas() //MUDAR ARQUIVO PARA .DAT
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("c:\\Listas\\CadastroCiasAtivas.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("Fim do arquivo.");

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
        public static void LerArquivoInativas() //MUDAR ARQUIVO PARA .DAT
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("c:\\Listas\\CadastroCiasInativas.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("Fim do arquivo.");

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
        public static void LerArquivoBloqueadas() //MUDAR ARQUIVO PARA .DAT
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("c:\\Listas\\CadastroCiasBloqueadas.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("Fim do arquivo.");

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
        public static void AddCiaAereaAtiva(CompanhiaAerea ciaAerea)
        {
            ListCiasAtivas.Add(ciaAerea);
        }
        public static void AddCiaAereaInativa(CompanhiaAerea ciaAerea)
        {
            ListCiasInativas.Add(ciaAerea);
        }
        public static void AddCiaListBloqueadas(CompanhiaAerea ciaAerea)
        {
            ListCiasBloqueadas.Add(ciaAerea);
        }
        public static void AddListTodasCias(CompanhiaAerea ciaAerea)
        {
            ListTodasCias.Add(ciaAerea);
        }
        public static void RemoveCiaAereaAtiva(CompanhiaAerea ciaAerea)
        {
            ListCiasAtivas.Remove(ciaAerea);
        }
        public static void RemoveCiaAereaInativa(CompanhiaAerea ciaAerea)
        {
            ListCiasInativas.Remove(ciaAerea);
        }
        public static void RemoveCiaListBloqueadas(CompanhiaAerea ciaAerea)
        {
            ListCiasBloqueadas.Remove(ciaAerea);
        }
        public static CompanhiaAerea BuscarCiasAereasLista()
        {
            int opcao;

            foreach (var item in ListCiasAtivas)
                if (item != null)
                {
                    return item;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Não existem Companhias Aéreas cadastradas!\n\nO que deseja fazer?\n1- Cadastrar CCompanhia\n2- Sair");
                        opcao = int.Parse(Console.ReadLine());

                        switch (opcao)
                        {
                            case 1:
                                //cia.CadastrarCia();
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                        }
                    } while (opcao < 1 || opcao > 2);
                }
            return null;
        }
        public static CompanhiaAerea EditarCiaAereaLista() //COMO EDITAR E DEVOLVER PARA A LISTA EDITADO?
        {
            int opcao, op = 0;
            string cnpj = "";

            CompanhiaAerea ciaBuscada = new CompanhiaAerea(cnpj);

            Console.WriteLine("Digite o CNPJ da companhia aérea que deseja editar: ");
            ciaBuscada.Cnpj = Console.ReadLine();

            foreach (var item in ListCiasAtivas)
                if (ciaBuscada != null && ciaBuscada == item)
                {
                    Console.WriteLine("Qual informação deseja alterar?\n1- Razão Social\n2- Data do último vôo\n3- Data de Abertura\n4- Situação");
                    switch (op)
                    {
                        case 1:
                            do
                            {
                                Console.WriteLine("Digite a Razão Social (até 50 dígitos) : ");
                                ciaBuscada.RazaoSocial = Console.ReadLine();

                            } while (ciaBuscada.RazaoSocial.Length > 50);
                            Console.WriteLine("Alteração feita com sucesso!\n\nDigite enter para continuar...");
                            Console.ReadKey();
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("Data do último vôo:");
                                ciaBuscada.UltimoVoo = DateTime.Parse(Console.ReadLine());

                            } while (ciaBuscada.UltimoVoo > DateTime.Now);
                            Console.WriteLine("Alteração feita com sucesso!\n\nDigite enter para continuar...");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Digite a data de abertura:");
                            ciaBuscada.DataAbertura = DateTime.Parse(Console.ReadLine());
                            System.TimeSpan tempoAbertura = DateTime.Now.Subtract(ciaBuscada.DataAbertura);
                            if (tempoAbertura.TotalDays > 190)
                            {
                                Console.WriteLine("Alteração feita com sucesso!\n\nDigite enter para continuar...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Data inválida!\n\nAperte enter para continuar...");
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            do
                            {
                                Console.WriteLine("Digite a situação: \nA-Ativo\nI-Inativo");
                                ciaBuscada.Situacao = char.Parse(Console.ReadLine());
                                ciaBuscada.Situacao = Char.ToUpper(ciaBuscada.Situacao);

                            } while (ciaBuscada.Situacao != 'A' && ciaBuscada.Situacao != 'I');

                            if (ciaBuscada.Situacao == 'A')
                            {
                                RemoveCiaAereaInativa(ciaBuscada);
                                AddCiaAereaAtiva(ciaBuscada);
                                GravarArquivoAtivas(ciaBuscada);
                            }
                            else if (ciaBuscada.Situacao == 'I')
                            {
                                RemoveCiaAereaAtiva(ciaBuscada);
                                AddCiaAereaInativa(ciaBuscada);
                                GravarArquivoInativas(ciaBuscada);
                            }
                            break;
                    }

                }
                else
                {
                    do
                    {
                        Console.WriteLine("Não existem Companhias Aéreas cadastradas!\n\nO que deseja fazer?\n1- Cadastrar CCompanhia\n2- Sair");
                        opcao = int.Parse(Console.ReadLine());
                        switch (opcao)
                        {
                            case 1:
                                ciaBuscada.CadastrarCia();
                                break;
                            case 2:
                                Environment.Exit(0);
                                break;
                        }
                        return ciaBuscada;
                    } while (opcao < 1 || opcao > 2);
                }
            return null;
        }

    }
}
