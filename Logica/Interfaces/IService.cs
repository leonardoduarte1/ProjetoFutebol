using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IService<T> where T : new()
    {
        void Inserir(T obj);

        void Atualizar(T obj);

        void Remover(int id);

        T BuscarPeloId(int id);

        IList<T> Listar();
    }
}
