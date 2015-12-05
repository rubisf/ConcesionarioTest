using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IService<T>
    {
        void Añadir(T t);
        void Eliminar(T t);
        T Obtener(int id);
        ICollection<T> ObtenerTodos();

    }
}
