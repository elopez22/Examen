using App.Front.Examen.BusinessLogic.Services.Interfaces;
using App.Front.Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.Examen.BusinessLogic.Services
{
    public class RamoService: IRamoService
    {
        private readonly ICallApiService _callApiService;
        public RamoService(ICallApiService callApiService)
        {
            _callApiService = callApiService;
        }
        public async Task<Ramo> buscaClave(Ramo ramo)
        {
            try
            {
                return await _callApiService.Post<Ramo>("Ramo/GetRamoByClave", ramo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Ramo> buscaDesc(Ramo ramo)
        {
            try
            {
                return await _callApiService.Post<Ramo>("Ramo/RamoByDesccripcion", ramo);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

}
