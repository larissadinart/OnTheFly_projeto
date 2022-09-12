﻿using System;
using System.Collections.Generic;
using System.IO;

namespace OnTheFly_projeto
{
    internal class Program
    {
        static List<CompanhiaAerea> ListCiasBloqueadas = new List<CompanhiaAerea>();

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
                        GravarArquivoAtivas(cia);
                        GravarTodasCias(cia);
                        Menu();
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
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

        #endregion

        #region manipulação de arquivo cias aéreas
        public static void GravarArquivoAtivas(CompanhiaAerea ciaAerea) //MUDAR ARQUIVO PARA .DAT
        {
            StreamWriter sw = new System.IO.StreamWriter("c:\\Listas\\CadastroCiasAtivas.txt", true);
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
        public static void GravarTodasCias(CompanhiaAerea ciaAerea) //MUDAR ARQUIVO PARA .DAT
        {
            StreamWriter sw = new StreamWriter("c:\\Listas\\ListTodasCias.txt");
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
        public static void LerArquivoTodasCias() //MUDAR ARQUIVO PARA .DAT
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("c:\\Listas\\ListTodasCias.txt");
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
        public static CompanhiaAerea LerCiaArquivoAtivos()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("c:\\Listas\\CadastroCiasAtivas.txt");

                string[] informacoes;

                List<string> ciasAereas = new List<string>(); 

                foreach (string line in lines) 
                {
                    informacoes = line.Split(';');//TIRAR CARACTERE DELIMITADOR

                    if (informacoes.Length == 4) 
                    {
                        for (int i = 0; i < informacoes.Length; i++)
                            ciasAereas.Add(informacoes[i]); 
                    }
                    else
                        return new CompanhiaAerea(); 
                }
                return new CompanhiaAerea(ciasAereas[0].ToString(), ciasAereas[1].ToString(),DateTime.Parse(ciasAereas[2].ToString()),DateTime.Parse(ciasAereas[3].ToString()), DateTime.Parse(ciasAereas[4].ToString()),char.Parse(ciasAereas[5].ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comandos.\n\nPressione qualquer telcla para continuar...");
                Console.ReadLine();
            }
            return new CompanhiaAerea(); 
        }//MUDAR ARQUIVO PARA .DAT


        #endregion

    }
}
