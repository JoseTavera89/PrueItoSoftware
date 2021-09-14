using Entidades.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Contrato
{
    public interface IUnidadTrabajo : IDisposable
    {
        WebApiDbContext Context { get; }
        void Commit();

    }
}
