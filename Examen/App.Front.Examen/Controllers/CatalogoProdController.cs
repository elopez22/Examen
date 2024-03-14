using App.Front.Examen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Front.Examen.BusinessLogic.Services.Interfaces;
namespace App.Front.Examen.Controllers
{
    public class CatalogoProdController : Controller
    {
        private readonly ILogger<AccessController> _logger;
        private readonly IProductosService _productosService;
        public CatalogoProdController(ILogger<AccessController> logger, IProductosService productosService)
        {
            _logger = logger;
            _productosService = productosService;
        }
        public IActionResult Index()
        {
            Productos model = new Productos();
            return View("~/Views/CatalogoProd/Index.cshtml", model);
        }
        [HttpPost]
        public async Task<IActionResult> _BusquedaClave(Productos prod)
        {
            TempData.Keep("idramo");
            TempData.Keep("pais");
            prod.Pais = TempData["pais"].ToString();
            prod.Rama = int.Parse(TempData["idramo"].ToString());
            if (prod.Id > 0)
            {
                prod.Descripcion = string.Empty;
                var resultProd = await _productosService.buscaClave(prod);
                if (resultProd != null)
                    return View("~/Views/CatalogoProd/Index.cshtml", resultProd);

            }
            else if (prod.Descripcion != string.Empty)
            {
                var resultProd = await _productosService.buscaDesc(prod);
                if (resultProd != null)
                    return View("~/Views/CatalogoProd/Index.cshtml", resultProd);
            }
            return Json("");

        }
    }
}
