using System.Collections.Generic;
using TISelvagem.Dominio;
using TISelvagem.Dominio.contrato;

namespace TISelvagem.Aplicacao
{
    public class AlunoAplicacao
    {
        private readonly IRepositorio<Aluno> repositorio;

        public AlunoAplicacao(IRepositorio<Aluno> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Aluno aluno)
        {
            repositorio.Save(aluno);
        }

        public void Delete(Aluno aluno)
        {
            repositorio.Delete(aluno);
        }

        public IEnumerable<Aluno> List()
        {
            return repositorio.List();
        }

        public Aluno getById(string id)
        {
            return repositorio.getById(id);
        }

    }
}
