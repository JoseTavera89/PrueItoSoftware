using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Contrato
{
    public interface IRepositorioBase<TEntidad>
        where TEntidad : class
    {
        Task<TEntidad> ObtenerAsync(object id);
        Task<IEnumerable<TEntidad>> ObtenerTodoAsync();
        Task<IEnumerable<TEntidad>> Obtener(Expression<Func<TEntidad, bool>> predicate, params string[] includess);
        Task<bool> Crear(TEntidad entity);
    }
}
