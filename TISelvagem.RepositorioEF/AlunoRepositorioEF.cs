using System;
using System.Collections.Generic;
using System.Linq;
using TISelvagem.Dominio;
using TISelvagem.Dominio.contrato;

namespace TISelvagem.RepositorioEF
{
    public class AlunoRepositorioEF : IRepositorio<Aluno>
    {

        private readonly Contexto contexto;

        public AlunoRepositorioEF()
        {
            contexto = new Contexto();
        }

        public void Save(Aluno entidade)
        {
            if (entidade.id > 0)
            {
                var alunoAlterar = contexto.Alunos.First(x => x.id == entidade.id);
                alunoAlterar.Nome = entidade.Nome;
                alunoAlterar.Mae = entidade.Mae;
                alunoAlterar.DataNascimento = entidade.DataNascimento;
            }
            else
            {
                contexto.Alunos.Add(entidade);
            }
            contexto.SaveChanges();
        }

        public void Delete(Aluno entidade)
        {
            var alunoExcluir = contexto.Alunos.First(x => x.id == entidade.id);
            contexto.Set<Aluno>().Remove(alunoExcluir);
            contexto.SaveChanges();
        }

        public IEnumerable<Aluno> List()
        {
            return contexto.Alunos;
        }

        public Aluno getById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return contexto.Alunos.First(x => x.id == idInt);
        }
    }
}