using App.Front.Examen.BusinessLogic.Services.Interfaces;
using App.Front.Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.Examen.BusinessLogic.Services
{
    public class ProductosService: IProductosService
    {
        private readonly ICallApiService _callApiService;
        public ProductosService(ICallApiService callApiService)
        {
            _callApiService = callApiService;
        }
        public async Task<Productos> buscaClave(Productos prod)
        {
            try
            {
                return await _callApiService.Post<Productos>("Productos/GetProdcutosByClave", prod);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Productos> buscaDesc(Productos prod)
        {
            try
            {
                return await _callApiService.Post<Productos>("Productos/ProdcutosByDesccripcion", prod);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
