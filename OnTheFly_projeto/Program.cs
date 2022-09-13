using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace OnTheFly_projeto
{
    internal class Program
    {
        static Voo voo = new Voo();
        static Passageiro passageiro = new Passageiro();
        static List<string> restritos = new List<string>();
        static List<Passageiro> passageiros = new List<Passageiro>();
        static CompanhiaAerea cia = new CompanhiaAerea();
        static Venda venda = new Venda();
        static List<string> bloqueadas = new List<string>();
        static List<CompanhiaAerea> TodasCias = new List<CompanhiaAerea>();
        static List<Voo> listaVoos = new List<Voo>();
        //___________________Listas Para Aeronaves__________________________\\
        static List<Aeronave> lista = new List<Aeronave>();
        static List<Aeronave> ativo = new List<Aeronave>();
        static List<Aeronave> inativo = new List<Aeronave>();
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
                Console.WriteLine("Escolha a opção desejada:\n\n1- Vender Passagem\n2- Cliente\n3- Cia.Aérea\n4- Destinos\n5- Vôos\n6- Aviões\n0- Sair");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        venda.CadastrarVenda(passageiro, voo, passageiros, restritos, listaVoos);
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
            } while (op < 0 || op > 6);
        }
        public static void Cliente()
        {
            
            
            passageiro.LerPassageiros(passageiros);

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
           
            voo.LerArquivoVoo(listaVoos);
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5-  Imprimir dados do Arquivo\n0- Sair");
                op = int.Parse(Console.ReadLine());
                while (op < 0 || op > 5)
                {
                    Console.WriteLine("Opção inválida, informe novamente: ");
                    Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Imprimir dados do Arquivo\n0- Sair");
                    op = int.Parse(Console.ReadLine());
                }
                List<string> destinos = new List<string>();
      
                switch (op)
                {
                    case 0:
                        voo.GeraArquivoVoo(listaVoos);
                        Environment.Exit(0); 
                        break;
                    case 1:
                        Opcoes(); 
                        break;
                    case 2: 
                        voo.CadastrarVoo(listaVoos);
                        break;
                    case 3: 
                        voo.LocalizarVoo(listaVoos);
                        break;
                    case 4: 
                        voo.EditarVoo(listaVoos);
                        break;
                    case 5:
                        voo.ImprimeArquivoVoo();
                        Console.WriteLine("Aperte alguma tecla pra prosseguir!");
                        Console.ReadKey();                   
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        public static void Avioes()
        {
            Aeronave aero = new Aeronave();
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Consultar\n4-Ler Registro\n5-Localizar Editar\n0- Sair");
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
                        aero.CadastroAeronaves(lista, ativo, inativo);
                        break;
                    case 3:
                        aero.ConsultarAeronave(lista, ativo, inativo);
                        break;
                    case 4:
                        Console.WriteLine("\n*** Documentos da Aeronave ***");
                        Console.WriteLine("1-Documento Aeronaves Ativas");
                        Console.WriteLine("2-Documento Aeronaves Inativa");
                        Console.WriteLine("3-Documento Aeronaves em Geral");
                        Console.Write("\nInforme: ");
                        int opc = int.Parse(Console.ReadLine());
                        switch (opc)
                        {

                            case 1:
                                aero.LerAtivos(ativo);
                                Console.Clear();
                                break;
                            case 2:
                                aero.LerInativos(inativo);
                                Console.Clear();
                                break;

                            case 3:
                                aero.LerDocumento(lista);
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("\nOpção Inválida!!!");
                                break;
                        }
                        break;
                    case 5:
                        aero.LocalizarEditar(lista, ativo, inativo);
                        break;
                    default:
                        Console.WriteLine("\nOpcao Invalida...");
                        break;
                }

            } while (op > 0 && op < 6);
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
            
            Passageiro restrito = new Passageiro(); 

            restrito.LerRestritos(restritos);
            

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
                string dv = line.Substring(62, 12);
                dv = dv.Substring(0, 2) + "/" + dv.Substring(2, 2) + "/" + dv.Substring(4, 2) + ' ' + dv.Substring(6, 2) + ':' + dv.Substring(8, 2);
                
                string dc = line.Substring(74, 12);
                dc = dc.Substring(0, 2) + "/" + dc.Substring(2, 2) + "/" + dc.Substring(4, 2) + ' ' + dc.Substring(6, 2) + ':' + dc.Substring(8, 2);
                
                string da = line.Substring(50, 12);
                da = da.Substring(0, 2) + "/" + da.Substring(2, 2) + "/" + da.Substring(4, 2) + ' ' + da.Substring(6, 2) + ':' + da.Substring(8, 2);
                CompanhiaAerea c = new CompanhiaAerea();
                while (line != null)
                {
                    c.RazaoSocial = line.Substring(0, 50);
                    c.Cnpj = line.Substring(50, 14);
                    c.DataAbertura = DateTime.Parse(da);
                    c.UltimoVoo = DateTime.Parse(dv);
                    c.DataCadastro = DateTime.Parse(dc);
                    c.Situacao = char.Parse(line.Substring(75, 1));
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
