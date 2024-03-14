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
    public class AccesoService : IAccesoService
    {
        private readonly IDataXmls DataXmls;
        public AccesoService(IDataXmls dataXmls)
        {
            DataXmls = dataXmls;
        }
        public Users ValidaUsuario(Users cred)
        {
            try
            {
                var clsxml = DataXmls.getUsuarios();
                foreach (var cls in clsxml.UserPais)
                {
                   var lstuser = cls.User.Where(c => c.UserName == cred.UserName && c.Pws == cred.Pws).ToList();
                    if (lstuser.Count()>0)
                         return lstuser.Select(u => new Users { Id = u.Id, Name = u.Name, UserName = u.UserName, Pais = u.Pais }).First();
                }
                return new Users();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
