using App.Front.Examen.BusinessLogic.Services.Interfaces;
using App.Front.Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.Examen.BusinessLogic.Services
{
    public class AccesoService: IAccesoService
    {
        private readonly ICallApiService _callApiService;
        public AccesoService(ICallApiService callApiService) {
            _callApiService = callApiService;
        }
        public async Task<User> validaLogin(User user)
        {
            try
            {
              return await _callApiService.Post<User>("Acceso", user);   
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
