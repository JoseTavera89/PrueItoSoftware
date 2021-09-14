using Aplicacion.Contrato;
using Empresas.Servicio;
using Entidades.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IRepositorioBase<Empresa> _repositorioBase;
        private readonly IUnidadTrabajo _unidadDeTrabajo;

        public EmpresasController(IRepositorioBase<Empresa> repositorioBase, IUnidadTrabajo unidadDeTrabajo)
        {
            this._repositorioBase = repositorioBase;
            this._unidadDeTrabajo = unidadDeTrabajo;
        }

        [HttpGet]
        [Route("obtener")]
        public async Task<IEnumerable<Empresa>> Obtener()
        {
                return await _repositorioBase.ObtenerTodoAsync();
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> Crear([FromBody] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                var resp = await _repositorioBase.Crear(empresa);

                if (resp)
                    _unidadDeTrabajo.Commit();
                return Ok(resp);
            }

            return BadRequest();
        }

        //[HttpGet]
        //[Route("ObtenerEmpleados")]
        //public async Task<IEnumerable<Empleado>> ObtenerEmpleados(int idEmpresa)
        //{
        //    ConsumirApi consumirApi = new ConsumirApi();
        //    return await consumirApi.ConsumirServicioGET<Empleado>(idEmpresa);
        //}
    }
}
