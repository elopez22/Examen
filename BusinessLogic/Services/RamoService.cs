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
using Ramo = DataAcces.Entities.Ramo;

namespace BusinessLogic.Services
{
    public class RamoService : IRamoService
    {
        private readonly IDataXmls DataXmls;
        public RamoService(IDataXmls dataXmls)
        {
            DataXmls = dataXmls;
        }
        public Ramo? GetRamosByDesccripcion(Ramo filter)
        {
            try
            {
                var lstresult = DataXmls.getProductos().Ramo.Where(c => c.Pais == filter.Pais).ToList();
                if (lstresult.Count > 0)
                {
                    var lstRamo= lstresult.Where(c => c.Descripcion.Contains(filter.Descripcion)).ToList();
                    if(lstRamo.Count > 0)
                        return lstRamo.Select(r => new Ramo { Id = r.Id, Descripcion = r.Descripcion, Pais = r.Pais }).FirstOrDefault();
                }
                     
                return new Ramo();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Ramo? GetRamoByClave(Ramo filter)
        {
            try
            {
                var lstresult = DataXmls.getProductos().Ramo.Where(c => c.Pais == filter.Pais).ToList();
                if (lstresult.Count > 0)
                {
                    var lstRamo = lstresult.Where(c => c.Id==filter.Id).ToList();
                    if (lstRamo.Count > 0)
                        return lstRamo.Select(r => new Ramo { Id = r.Id, Descripcion = r.Descripcion, Pais = r.Pais }).FirstOrDefault();
                }

                return new Ramo();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
