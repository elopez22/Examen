using BusinessLogic.Services;
using BusinessLogic.Services.Interface;
using DataAcces.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly IAccesoService _accesoService;
        private readonly ILogger _logger;
        public AccesoController(IAccesoService accesoService, ILogger<AccesoController> logger)
        {
            _accesoService = accesoService;
            _logger = logger;
        }
        
        /// <summary>
        /// Valida credenciales de acceso
        /// </summary>
        /// <param name="customer">Objeto de tipo usuario</param>
        /// <returns>regresa el objeto usuario</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ValidaAcceso(Users credenciales)
        {
            var user = _accesoService.ValidaUsuario(credenciales);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
