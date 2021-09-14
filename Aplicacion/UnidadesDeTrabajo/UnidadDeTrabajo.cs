using Aplicacion.Contrato;
using Entidades.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.UnidadesDeTrabajo
{
    public class UnidadDeTrabajo: IUnidadTrabajo
    {
        public UnidadDeTrabajo(WebApiDbContext context)
        {
            Context = context;
        }
        public WebApiDbContext Context { get; }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
