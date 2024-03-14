using BusinessLogic.Services.Interface;
using DataAcces.Dto;
using DataAcces.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _productosService;
        private readonly ILogger _logger;
        public ProductosController(IProductosService productosService, ILogger<ProductosController> logger)
        {
            _productosService = productosService;
            _logger = logger;
        }
        /// <summary>
        /// Obtiene el prodcuto por descripcion
        /// </summary>
        /// <param name="filtro">Objeto que contiene el filtro</param>
        /// <returns>objeto produtoc</returns>
        [HttpPost("ProdcutosByDesccripcion")]
        public IActionResult ProdcutosByDesccripcion(Product filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var produt =  _productosService.GetProdcutosByDesccripcion(filter);
            return Ok(produt);
        }
        /// <summary>
        /// Obtiene el prodcuto por clave
        /// </summary>
        /// <param name="filtro">Objeto que contiene el filtro</param>
        /// <returns>objeto produtoc</returns>
        [HttpPost("GetProdcutosByClave")]
        public IActionResult GetProdcutosByClave(Product filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var produt = _productosService.GetProdcutosByClave(filter);
            return Ok(produt);
        }
    }
}
