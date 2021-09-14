using Aplicacion.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IRepositorioBase<Empleado> _repositorioBase;
        private readonly IUnidadTrabajo _unidadDeTrabajo;
    }
}
