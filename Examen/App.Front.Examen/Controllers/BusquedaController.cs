using App.Front.Examen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Front.Examen.BusinessLogic.Services.Interfaces;
namespace App.Front.Examen.Controllers
{
    public class BusquedaController : Controller
    {
        private readonly ILogger<AccessController> _logger;
        private readonly IRamoService _ramoService;
        private readonly IProductosService _productosService;

        public BusquedaController(ILogger<AccessController> logger, IRamoService ramoService, IProductosService productosService)
        {
            _logger = logger;
            _ramoService = ramoService;
            _productosService= productosService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> _BusquedaClave(int id)
        {
            TempData.Keep("pais");
            var resultRamo = await _ramoService.buscaClave(new Ramo { Id= id, Descripcion= "",Pais= TempData["pais"].ToString() });
            if (resultRamo != null)
            {
                TempData["idramo"] = resultRamo.Id;
                return Json(resultRamo.Descripcion);
            }
            else 
                return Json("");
        }

        [HttpPost]
        public async Task<IActionResult> _BusquedaclaveProd(int id)
        {
            TempData.Keep("idramo");
            TempData.Keep("pais");
            var resultProd = await _productosService.buscaClave(new Productos { Id = id,Rama= int.Parse(TempData["idramo"].ToString()), Descripcion = "", Pais = TempData["pais"].ToString() });
            if (resultProd != null)
            {
                return Json(resultProd.Descripcion);
            }
            else
                return Json("");
        }
    }
}
