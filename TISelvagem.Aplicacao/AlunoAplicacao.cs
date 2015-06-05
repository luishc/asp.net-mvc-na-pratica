using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TISelvagem.Repositorio;
using TISelvagem.Dominio;

namespace TISelvagem.Aplicacao
{
    public class AlunoAplicacao
    {
        private Contexto contexto;

        private void Insert(Aluno aluno)
        {
            var strQuery = "INSERT INTO ALUNO (Nome, Mae, DataNascimento)";
            strQuery += " VALUES('" + aluno.Nome + "', '" + aluno.Mae + "', '" + aluno.DataNascimento + "')";

            using (contexto = new Contexto())
            {
                contexto.executa(strQuery);
            }
        }

        private void Alterar(Aluno aluno)
        {
            var strQuery = "UPDATE ALUNO SET ";
            strQuery += string.Format("Nome = '{0}', Mae = '{1}', DataNascimento = '{2}' WHERE AlunoId = {3}", 
                aluno.Nome, aluno.Mae, aluno.DataNascimento, aluno.id);
            using (contexto = new Contexto())
            {
                contexto.executa(strQuery);
            }
        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.id > 0)
            {
                this.Alterar(aluno);
            }
            else
            {
                this.Insert(aluno);
            }
        }

        public void Delete(int id)
        {
            var strQuery = "DELETE FROM ALUNO WHERE ";
            strQuery += string.Format("AlunoId = {0}", id);

            using (contexto = new Contexto())
            {
                contexto.executa(strQuery);
            }
        }

        public List<Aluno> List()
        {
            var strQuery = "SELECT * FROM ALUNO";
            using (contexto = new Contexto())
            {
                var reader = contexto.select(strQuery);
                return transformaEmLista(reader);
            }
        }

        public Aluno getById(int id)
        {
            var strQuery = "SELECT * FROM ALUNO WHERE AlunoId = " + id;
            var aluno = new Aluno();
            using (contexto = new Contexto())
            {
                var reader = contexto.select(strQuery);
                while (reader.Read())
                {
                    aluno = new Aluno
                    {
                        id = int.Parse(reader["AlunoId"].ToString()),
                        Nome = reader["Nome"].ToString(),
                        Mae = reader["Mae"].ToString(),
                        DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())
                    };
                }
            }
            return aluno;
        }

        private List<Aluno> transformaEmLista(SqlDataReader reader)
        {
            var aluno = new List<Aluno>();
            while (reader.Read())
            {
                var alunoTmp = new Aluno {
                    id = int.Parse(reader["AlunoId"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Mae = reader["Mae"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())
                };
                aluno.Add(alunoTmp);
            }
            reader.Close();
            return aluno;
        }
    }
}
