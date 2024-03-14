using App.Front.Examen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Front.Examen.BusinessLogic.Services.Interfaces;
namespace App.Front.Examen.Controllers
{
    public class CatalogoRamaController : Controller
    {
        private readonly ILogger<AccessController> _logger;
        private readonly IRamoService _ramoService;
        public CatalogoRamaController(ILogger<AccessController> logger, IRamoService ramoService)
        {
            _logger = logger;
            _ramoService = ramoService;
        }
        public IActionResult Index()
        {
            Ramo model = new Ramo();
            return View("~/Views/CatalogoRama/Index.cshtml", model);
        }
        [HttpPost]

        public async Task<IActionResult> _BusquedaClave(Ramo ramo)
        {
            TempData.Keep("idramo");
            TempData.Keep("pais");
            ramo.Pais = TempData["pais"].ToString();
            if (ramo.Id > 0)
            {
                ramo.Descripcion = string.Empty;
                var resultRamo = await _ramoService.buscaClave(ramo);
                if (resultRamo != null)
                    return View("~/Views/CatalogoRama/Index.cshtml", resultRamo);
            }
            else if (ramo.Descripcion != string.Empty)
            {
                var resultRamo = await _ramoService.buscaDesc(ramo);
                if (resultRamo != null)
                    return View("~/Views/CatalogoRama/Index.cshtml", resultRamo);

            }
            return Json("");
        }
    }
}
