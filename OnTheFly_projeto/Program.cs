using System;
using System.Collections.Generic;
using System.IO;

namespace OnTheFly_projeto
{
    internal class Program
    {

        static CompanhiaAerea cia = new CompanhiaAerea();
        static List<string> bloqueadas = new List<string>();
        static List<CompanhiaAerea> TodasCias = new List<CompanhiaAerea>();

        static void Main(string[] args)
        {
            Menu();
        }

        #region menus 
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
            } while (op > 0 && op < 6);
        }
        public static void Cliente()
        {
            List<Passageiro> passageiros = new List<Passageiro>();
            Passageiro passageiro = new Passageiro();

            int op;
            do
            {

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
                        passageiro.CadastrarPassageiro(passageiros);
                        break;
                    case 3:
                        passageiro.ImprimirPassageiroEspecifico(passageiros);
                        break;
                    case 4:
                        passageiro.EditarPassageiro(passageiros);
                        break;
                    case 5:
                        passageiro.ImprimirTodosPassageiros(passageiros);
                        break;
                    case 6:
                        ClientesRestritos();
                        break;
                    default:
                        break;
                }
            } while (op > 0 && op < 6);
        }
        public static void CiaAerea()
        {
            int op;

            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Bloqueados\n6- Gravar arquivo de Cias Aéreas\n7- Ler arquivo de Cias Aéreas\n0- Sair");
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
                        cia.CadastrarCia(TodasCias);
                        Opcoes();
                        break;
                    case 3:
                        cia.LocalizarCiaAerea(TodasCias);
                        Opcoes();
                        break;
                    case 4:
                        cia.EditarCia(TodasCias);
                        Opcoes();
                        break;
                    case 5:
                        CiasBloqueadas();
                        Opcoes();
                        break;
                    case 6:
                        GerarArquivoTodasCias(TodasCias);
                        break;
                    case 7:LerArquivoCias(TodasCias);
                        break;
                    default:
                        break;
                }
            } while (op > 0 && op < 7);
        }
        public static void CiaAereaBloqueada()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar Bloqueado\n3- Localizar Bloqueado\n4- Remover CNPJ da lista\n0- Sair");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        CiaAerea();
                        break;
                    case 2:
                        cia.CadastrarBloqueadas(bloqueadas);
                        Opcoes();
                        break;
                    case 3:
                        cia.LocalizarBloqueadas(bloqueadas);
                        Opcoes();
                        break;
                    case 4:
                        cia.RemoverBloqueadas(bloqueadas);
                        Opcoes();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (op > 0 && op < 5);
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
            } while (op > 0 && op < 5);

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
            } while (op > 0 && op < 5);
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
            } while (op > 0 && op < 5);
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
            } while (op > 0 && op < 5);
        }
        public static void ClientesRestritos()
        {
            List<string> restritos = new List<string>();
            Passageiro restrito = new Passageiro();

            int op;
            do
            {

                Console.WriteLine("Escolha a opção desejada: \n1- Voltar ao Menu Anterior\n2-Cadastrar\n3- Localizar\n4-Remover\n0- Sair");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Cadastro();
                        break;
                    case 2:
                        restrito.CadastrarRestrito(restritos);
                        break;
                    case 3:
                        restrito.LocalizarRestrito(restritos);
                        break;
                    case 4:
                        restrito.RetirarRestrito(restritos);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        break;

                }
            } while (op > 0 && op < 5);
        }
        public static void CiasBloqueadas()
        {
            int op;

            Console.Clear();
            Console.WriteLine("Escolha a opção desejada: \n\n1- Voltar ao Menu Anterior\n2- Inserir Cia.Aérea\n3- Remover Cia. Aérea\n4- Buscar Cia. Aérea\n0- Sair");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Cadastro();
                    break;
                case 2:
                    cia.CadastrarBloqueadas(bloqueadas);
                    break;
                case 3:
                    cia.RemoverBloqueadas(bloqueadas);
                    break;
                case 4:
                    cia.LocalizarBloqueadas(bloqueadas);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region manipulação de arquivo cias aéreas
        public static void GerarArquivoTodasCias(List<CompanhiaAerea> TodasCias)
        {
            string msg = "";

            foreach (CompanhiaAerea cia in TodasCias)
            {
                msg = cia.RazaoSocial + cia.Cnpj.ToString() + cia.DataAbertura.ToString("ddMMyy" + "hhmm") + cia.UltimoVoo.ToString("ddMMyy" + "hhmm") + cia.DataCadastro.ToString("ddMMyy" + "hhmm") + cia.Situacao;
            }
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Listas_OnTheFly\\CiaAereas.dat", append: true);
                sw.WriteLine(msg);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine("\nAperte Enter para continuar...");
            Console.ReadKey();
        }
        public static void ImprimirArquivoCias()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Listas_OnTheFly\\CiaAereas.dat");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("\nFim da Leitura do Arquivo.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public static void LerArquivoCias(List<CompanhiaAerea> TodasCias)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("C:\\Listas_OnTheFly\\CiaAereas.dat");
                line = sr.ReadLine();
                string dv = line.Substring(8, 10);
                dv = dv.Substring(0, 2) + '/' + dv.Substring(2, 2) + "//" + dv.Substring(4, 2) + ' ' + dv.Substring(6, 2) + ':' + dv.Substring(8, 2);
                CompanhiaAerea c = new CompanhiaAerea();
                while (line != null)
                {
                    c.RazaoSocial = line.Substring(0, 49);
                    c.Cnpj = line.Substring(49, 14);
                    c.DataAbertura = DateTime.Parse(line.Substring(63, 10));
                    c.DataCadastro = DateTime.Parse(line.Substring(73, 10));
                    c.UltimoVoo = DateTime.Parse(dv);
                    c.Situacao = char.Parse(line.Substring(73));
                    TodasCias.Add(c);
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine("\nFim da Leitura do Arquivo.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        #endregion

    }
}
