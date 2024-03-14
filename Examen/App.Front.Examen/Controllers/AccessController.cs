using App.Front.Examen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Front.Examen.BusinessLogic.Services.Interfaces;


namespace App.Front.Examen.Controllers
{
    public class AccessController : Controller
    {
        private readonly ILogger<AccessController> _logger;
        private readonly IAccesoService _accesoService;
        public AccessController(ILogger<AccessController> logger, IAccesoService accesoService)
        {
            _logger = logger;
            _accesoService = accesoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User _user)
        {
            _user.Name =string.Empty; 
            _user.Pais=string.Empty;
            _user.Id = 0;
           var resultUser= await _accesoService.validaLogin(_user);
            if (resultUser!=null)
            {
                if (resultUser.UserName != null)
                {
                    TempData["pais"] = resultUser.Pais;
                    return RedirectToAction("Index", "Busqueda");
                }
            }
            ViewBag.error = "El usuario y/o contraseña incorrectos";
            return View();
        }
    }
}
