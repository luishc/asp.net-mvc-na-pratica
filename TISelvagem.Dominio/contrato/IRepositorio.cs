using System.Collections.Generic;

namespace TISelvagem.Dominio.contrato
{
    public interface IRepositorio<T> where T : class
    {
        void Save(T entidade);

        void Delete(T entidade);

        IEnumerable<T> List();

        T getById(string id);
    }
}
