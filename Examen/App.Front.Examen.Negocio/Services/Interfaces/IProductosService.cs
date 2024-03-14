using App.Front.Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Front.Examen.BusinessLogic.Services.Interfaces
{
    public interface IProductosService
    {
        Task<Productos> buscaClave(Productos prod);
        Task<Productos> buscaDesc(Productos prod);
    }
}
