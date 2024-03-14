using DataAcces.Dto;
using DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interface
{
    public interface IAccesoService
    {
        Users ValidaUsuario(Users cred);
    }
}
