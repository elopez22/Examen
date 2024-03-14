using App.Front.Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Front.Examen.BusinessLogic.Services.Interfaces
{
    public interface IAccesoService
    {
        Task<User> validaLogin(User user);
    }
}
