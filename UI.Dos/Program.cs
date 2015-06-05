using System;
using System.Collections.Generic;
using TISelvagem.Dominio;
using TISelvagem.Aplicacao;

namespace UI.Dos
{
    class Program
    {

        //static void MainAntiga(string[] args)
        //{
        //    SqlConnection minhaConexao = new SqlConnection(@"Server=LUIS-PC\SQLEXPRESS;Database=FaculdadeTISelvagem;User Id=luis; Password=root;");

        //    minhaConexao.Open();

        //    //string strQuerySelect = "SELECT * FROM ALUNO";
        //    //SqlCommand cmdComandoSelect = new SqlCommand(strQuerySelect, minhaConexao);
        //    //SqlDataReader dados = cmdComandoSelect.ExecuteReader();

        //    string strQueryUpdate= "UPDATE ALUNO SET Nome = 'Luis Henrique' WHERE AlunoId = 1";
        //    SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, minhaConexao);
        //    cmdComandoUpdate.ExecuteNonQuery();

        //    Console.WriteLine("Digite o nome do aluno: ");
        //    string nome = Console.ReadLine();

        //    Console.WriteLine("Digite o nome da mae do aluno: ");
        //    string mae = Console.ReadLine();

        //    Console.WriteLine("Digite a data de nascimento do aluno: ");
        //    string data = Console.ReadLine();

        //    string strQueryInsert = string.Format("INSERT INTO ALUNO (Nome, Mae, DataNascimento) VALUES ('{0}', '{1}', '{2}')", nome, mae, data);
        //    SqlCommand cmdComandoInsert = new SqlCommand(strQueryInsert, minhaConexao);
        //    cmdComandoInsert.ExecuteNonQuery();

        //    string strQueryDelete = "DELETE FROM ALUNO WHERE AlunoId = 4";
        //    SqlCommand cmdComandoDelete = new SqlCommand(strQueryDelete, minhaConexao);
        //    cmdComandoDelete.ExecuteNonQuery();

        //    string strQuerySelect = "SELECT * FROM ALUNO";
        //    SqlCommand cmdComandoSelect = new SqlCommand(strQuerySelect, minhaConexao);
        //    SqlDataReader dados = cmdComandoSelect.ExecuteReader();

        //    while (dados.Read())
        //    {
        //        Console.WriteLine("Id: {0}, Nome: {1}, Mae: {2}, DataNascimento: {3}", dados["AlunoId"], dados["Nome"], dados["Mae"], dados["DataNascimento"]);
        //    }
            
        //    Console.ReadLine();
        //}

        //static void Main(string[] args)
        //{
        //    var contexto = new Contexto();

        //    Console.WriteLine("1 - Inserir Aluno");
        //    Console.WriteLine("2 - Listar Aluno");
        //    Console.WriteLine("3 - Atualizar Aluno");
        //    int opcao = int.Parse(Console.ReadLine());

        //    switch (opcao)
        //    {
        //        case 1:
        //            Console.WriteLine("Digite o nome do aluno: ");
        //            string nome = Console.ReadLine();

        //            Console.WriteLine("Digite o nome da mae do aluno: ");
        //            string mae = Console.ReadLine();

        //            Console.WriteLine("Digite a data de nascimento do aluno: ");
        //            string data = Console.ReadLine();

        //            string strQueryInsert = string.Format("INSERT INTO ALUNO (Nome, Mae, DataNascimento) VALUES ('{0}', '{1}', '{2}')", nome, mae, data);
        //            contexto.executa(strQueryInsert);
        //            break;

        //        case 2:
        //            string strQuerySelect = "SELECT * FROM ALUNO";
        //            SqlDataReader dados = contexto.select(strQuerySelect);

        //            while (dados.Read())
        //            {
        //                Console.WriteLine("Id: {0}, Nome: {1}, Mae: {2}, DataNascimento: {3}", dados["AlunoId"], dados["Nome"], dados["Mae"], dados["DataNascimento"]);
        //            }
        //            break;
        //        case 3:
        //            Console.WriteLine("Digite o id do aluno: ");
        //            string id = Console.ReadLine();

        //            Console.WriteLine("Digite o nome do aluno: ");
        //            nome = Console.ReadLine();

        //            Console.WriteLine("Digite o nome da mae do aluno: ");
        //            mae = Console.ReadLine();

        //            Console.WriteLine("Digite a data de nascimento do aluno: ");
        //            data = Console.ReadLine();

        //            string strQueryUpdate = string.Format("UPDATE ALUNO SET Nome = '{0}', Mae = '{1}', DataNascimento = '{2}' WHERE AlunoId = {3}", nome, mae, data, id);
        //            contexto.executa(strQueryUpdate, true);
        //            break;
        //        default:
        //            break;
        //    }

        //}

        public static void Main(string[] args)
        {
            Console.WriteLine("1 - Inserir Aluno");
            Console.WriteLine("2 - Listar Aluno");
            Console.WriteLine("3 - Atualizar Aluno");
            Console.WriteLine("4 - Deletar Aluno");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    {
                        Console.WriteLine("Digite o nome do aluno: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Digite o nome da mae do aluno: ");
                        string mae = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascimento do aluno: ");
                        string data = Console.ReadLine();

                        var aluno = new Aluno
                        {
                            Nome = nome,
                            Mae = mae,
                            DataNascimento = DateTime.Parse(data)
                        };

                        AlunoAplicacaoConstrutor.AlunoAplicacaoADO().Salvar(aluno);
                        break;
                    }

                case 2:
                    {
                        IEnumerable<Aluno> dados = AlunoAplicacaoConstrutor.AlunoAplicacaoADO().List();

                        foreach (var item in dados)
                        {
                            Console.WriteLine("Id: {0}, Nome: {1}, Mae: {2}, DataNascimento: {3}", item.id, item.Nome, item.Mae, item.DataNascimento);
                        }
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Digite o id do aluno: ");
                        string id = Console.ReadLine();

                        Console.WriteLine("Digite o nome do aluno: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Digite o nome da mae do aluno: ");
                        string mae = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascimento do aluno: ");
                        string data = Console.ReadLine();

                        var aluno = new Aluno
                        {
                            Nome = nome,
                            Mae = mae,
                            DataNascimento = DateTime.Parse(data),
                            id = int.Parse(id)
                        };

                        AlunoAplicacaoConstrutor.AlunoAplicacaoADO().Salvar(aluno);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Digite o id do aluno: ");
                        int id = int.Parse(Console.ReadLine());

                        var appAluno = AlunoAplicacaoConstrutor.AlunoAplicacaoADO();
                        var aluno = appAluno.getById(id.ToString());

                        AlunoAplicacaoConstrutor.AlunoAplicacaoADO().Delete(aluno);
                        break;
                    }
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
