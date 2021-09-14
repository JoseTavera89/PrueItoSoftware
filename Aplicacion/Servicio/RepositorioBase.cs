using Aplicacion.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
    public class RepositorioBase<TEntidad> : IRepositorioBase<TEntidad>
     where TEntidad : class
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public RepositorioBase(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public async Task<TEntidad> ObtenerAsync(object id)
        {
            if (id != null)
            {
                return _unidadTrabajo.Context.Set<TEntidad>().Find(id);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<TEntidad>> ObtenerTodoAsync()
        {
            return await _unidadTrabajo.Context.Set<TEntidad>().ToListAsync();
        }

        public async Task<IEnumerable<TEntidad>> Obtener(Expression<Func<TEntidad, bool>> predicate, params string[] includess)
        {
            IQueryable<TEntidad> query = _unidadTrabajo.Context.Set<TEntidad>();


            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.ToListAsync();
        }

        public async Task<bool> Crear(TEntidad entity)
        {
            bool result = false;

            try
            {
                var save = await _unidadTrabajo.Context.Set<TEntidad>().AddAsync(entity);

                if (save != null)
                    result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
