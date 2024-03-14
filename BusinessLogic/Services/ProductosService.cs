using BusinessLogic.Services.Interface;
using DataAcces.DataXml.Interfaces;
using DataAcces.XmlEntities;
using DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Users = DataAcces.Entities.Users;
using DataAcces.Dto;

namespace BusinessLogic.Services
{
    public class ProductosService : IProductosService
    {
        private readonly IDataXmls DataXmls;
        public ProductosService(IDataXmls dataXmls)
        {
            DataXmls = dataXmls;
        }
        public Product? GetProdcutosByDesccripcion(Product filter)
        {
            try
            {
                var lstresult = DataXmls.getProductos().Ramo.Where(c => c.Id == filter.Rama && c.Pais==filter.Pais).ToList();
                if (lstresult.Count() > 0)
                {
                    var lstpro = lstresult.FirstOrDefault().Productos.Where(c => c.Descripcion.Contains(filter.Descripcion)).ToList();
                    if (lstpro.Count() > 0)
                       return lstpro.Select(p => new Product { Id = p.Id, Descripcion = p.Descripcion, Pais = p.Pais , Rama=filter.Rama}).FirstOrDefault();
                }
                return new Product();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Product? GetProdcutosByClave(Product filter)
        {
            try
            {
                var lstresult = DataXmls.getProductos().Ramo.Where(c => c.Id == filter.Rama && c.Pais == filter.Pais).ToList();
                if (lstresult.Count() > 0)
                {
                    var lstpro = lstresult.FirstOrDefault().Productos.Where(c => c.Id==filter.Id).ToList();
                    if (lstpro.Count() > 0)
                        return lstpro.Select(p => new Product { Id = p.Id, Descripcion = p.Descripcion, Pais = p.Pais, Rama = filter.Rama }).FirstOrDefault();
                }
                return new Product();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
