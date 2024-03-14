using BusinessLogic.Services.Interface;
using DataAcces.Dto;
using DataAcces.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamoController : ControllerBase
    {
        private readonly IRamoService _ramoService;
        private readonly ILogger _logger;
        public RamoController(IRamoService ramoService, ILogger<ProductosController> logger)
        {
            _ramoService = ramoService;
            _logger = logger;
        }
        /// <summary>
        /// Obtiene el ramo por descripcion
        /// </summary>
        /// <param name="filtro">Objeto que contiene el filtro</param>
        /// <returns>objeto ramo</returns>
        [HttpPost("RamoByDesccripcion")]
        public IActionResult RamoByDesccripcion(Ramo filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ramo =  _ramoService.GetRamosByDesccripcion(filter);
            return Ok(ramo);
        }
        /// <summary>
        /// Obtiene el ramo por clave
        /// </summary>
        /// <param name="filtro">Objeto que contiene el filtro</param>
        /// <returns>objeto ramo</returns>
        [HttpPost("GetRamoByClave")]
        public IActionResult GetRamoByClave(Ramo filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ramo = _ramoService.GetRamoByClave(filter);
            return Ok(ramo);
        }
    }
}
