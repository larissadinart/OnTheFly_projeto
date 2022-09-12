using System;
using System.Collections.Generic;

namespace OnTheFly_projeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            do
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
                    break;
                }
                else
                {
                    Console.WriteLine("Usuário ou senha inválidos!\n");
                    Console.WriteLine("Aperte enter para continuar....");
                    Console.ReadKey();
                }
            } while (true);
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
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Voos();
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 6);
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
                    case 2: //cadastrar
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
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
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
            List<Voo> listaVoos = new List<Voo>();
            Voo voo = new Voo();
            voo.LerArquivoVoo(listaVoos);
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Imprimir por Registro\n0- Sair");
                op = int.Parse(Console.ReadLine());
                while (op < 0 || op > 5)
                {
                    Console.WriteLine("Opção inválida, informe novamente: ");
                    Console.WriteLine("Escolha a opção desejada:\n\n1- Voltar ao Menu anterior\n2- Cadastrar\n3- Localizar\n4- Editar\n5- Imprimir por Registro\n0- Sair");
                    op = int.Parse(Console.ReadLine());
                }
                List<string> destinos = new List<string>();
      
                switch (op)
                {
                    case 0:
                        voo.GeraArquivoVoo(listaVoos);
                        Environment.Exit(0); // [OK]
                        break;
                    case 1:
                        Opcoes(); // [OK]
                        break;
                    case 2: //cadastrar [OK]
                        voo.CadastrarVoo(listaVoos);
                        break;
                    case 3: //localizar [OK]
                        voo.LocalizarVoo(listaVoos);
                        break;
                    case 4: //editar [OK] - mudar na lista depois grava tudo.
                        voo.EditarVoo(listaVoos);
                        break;
                    case 5:
                        voo.ImprimeArquivoVoo();
                        Console.ReadKey();                   
                        //teste de imprimir arquivo texto gerado.
                        //imprimir por registro
                        break;
                    default:
                        break;
                }
            } while (true);
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

    }
}
