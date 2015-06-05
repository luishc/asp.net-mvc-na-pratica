using System;
using System.Data;
using System.Data.SqlClient;

namespace TISelvagem.Repositorio
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection minhaConexao;

        public Contexto()
        {
           minhaConexao =
               new SqlConnection(@"Server=LUIS-PC\SQLEXPRESS;Database=FaculdadeTISelvagem;User Id=luis; Password=root;");
           
           minhaConexao.Open();
        }

        public void executa(string sql, bool debug = false)
        {
            if (debug == true)
                Console.WriteLine(sql);

            var cmdComando = new SqlCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text,
                Connection = minhaConexao
            };

            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader select(string sql)
        {
            var cmdComando = new SqlCommand(sql, minhaConexao);
            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (minhaConexao.State == ConnectionState.Open)
            {
                minhaConexao.Close();
            }
        }
    }
}
