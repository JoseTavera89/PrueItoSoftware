using Aplicacion.Contrato;
using Entidades.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatosEmpleado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IRepositorioBase<Empleado> _repositorioBase;
        private readonly IUnidadTrabajo _unidadDeTrabajo;
        public EmpleadosController(IRepositorioBase<Empleado> repositorioBase, IUnidadTrabajo unidadDeTrabajo)
        {
            this._repositorioBase = repositorioBase;
            this._unidadDeTrabajo = unidadDeTrabajo;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<IEnumerable<Empleado>> Obtener()
        {
            return await _repositorioBase.ObtenerTodoAsync();
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Crear([FromBody] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var resp = await _repositorioBase.Crear(empleado);

                if (resp)
                    _unidadDeTrabajo.Commit();
                return Ok(resp);
            }

            return BadRequest();
        }
        [HttpGet]
        [Route("ObtenerEmpleados")]
        public async Task<IEnumerable<Empleado>> ObtenerEmpleados(int idEmpresa)
        {

            return await _repositorioBase.Obtener( a => a.IdEmpresa == idEmpresa);
        }
    }

    
}
