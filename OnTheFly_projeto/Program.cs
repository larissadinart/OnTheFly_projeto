using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnTheFly_projeto
{
    internal class Program
    {
        static Voo voo = new Voo();
        static Passageiro p = new Passageiro();
        static CompanhiaAerea cia = new CompanhiaAerea();
        static Venda venda = new Venda();

        static void Main(string[] args)
        {
            Menu();
        }
        #region menus 

        public static void Menu()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine(">>>>> BEM VINDO AO AEROPORTO ON THE FLY! <<<<<\n\n");
                Console.WriteLine("Escolha a opção desejada:\n\n1- Vender Passagem\n2- Passageiro\n3- Cia.Aérea\n4- Destinos\n5- Vôos\n6- Aviões\n0- Sair");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        break;
                    case 2:
                        Passageiro();
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    default:
                        break;
                }
            } while (op < 0 || op > 6);
        }
        public static void Passageiro()
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
                        Menu();
                        break;
                    case 2:
                        p = p.CadastrarPassageiro();
                        InserirPassageiro(p);
                        Console.WriteLine("Passageiro cadastrado com sucesso!Aperte enter para voltar ao menu.");
                        Console.ReadKey();
                        Menu();
                        break;
                    case 3:
                        LocalizarPassageiro();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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
                        Menu();
                        break;
                    case 2:
                        Menu();
                        break;
                    case 3:
                        Menu();
                        break;
                    case 4:
                        Menu();
                        break;
                    case 5:
                        CiasBloqueadas();
                        Menu();
                        break;
                    case 6:
                        break;
                    case 7:
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
                        Menu();
                        break;
                    case 3:
                        Menu();
                        break;
                    case 4:
                        Menu();
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
                        Menu();
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
                        Menu();
                        break;
                    case 2:

                        break;
                    case 3:

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

                                Console.Clear();
                                break;
                            case 2:

                                Console.Clear();
                                break;

                            case 3:

                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("\nOpção Inválida!!!");
                                break;
                        }
                        break;
                    case 5:

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


        public static void InserirPassageiro(Passageiro passageiro)
        {
            Banco conn = new Banco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            string sql = $"insert into Passageiro(nome, cpf, data_nasc, sexo, data_ultimacompra, data_cadastro,situação) values ('{p.Cpf}' , " +
                $"'{p.Nome}', '{p.DataNascimento}', '{p.Sexo}', '{DateTime.Now}', '{DateTime.Now}', '{p.Situacao}');";
            SqlCommand cmd = new SqlCommand(sql, conexaosql);
            cmd.ExecuteNonQuery();
            conexaosql.Close();
        }
        public static Passageiro LocalizarPassageiro()
        {
            string sql = $"select * from passageiro Where cpf = '{p.Cpf}';";
            Console.Clear();
            Console.WriteLine("Digite o cpf do passageiro buscado: ");
            p.Cpf = Console.ReadLine();
            try
            {
                Banco conn = new Banco();
                SqlConnection conexaosql = new SqlConnection(conn.Caminho());
                conexaosql.Open();
                SqlCommand cmd = new SqlCommand(sql, conexaosql);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Cadastro não localizado!Aperte enter para continuar...");
                        Console.ReadKey();
                        return null;
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.Clear();
                            Console.WriteLine($"CPF: {reader.GetString(0)}");
                            Console.WriteLine($"Nome: {reader.GetString(1)}");
                            Console.WriteLine($"Data de Nascimento: {reader.GetDateTime(2)}");
                            Console.WriteLine($"Sexo: {reader.GetString(3)}");
                            Console.WriteLine($"Data Última Compra: {reader.GetDateTime(4)}");
                            Console.WriteLine($"Data Cadastro: {reader.GetDateTime(5)}");
                            Console.WriteLine($"Situação:  {reader.GetString(6)}");

                            Console.WriteLine("\n\nAperte enter para confirmar.");
                            Console.ReadKey();
                           return new Passageiro(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetDateTime(4), reader.GetDateTime(5), reader.GetString(6));
                        }
                        conexaosql.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Erro número {e.Number}, tente novamente.");
            }
            return null;






        }
    }
}
