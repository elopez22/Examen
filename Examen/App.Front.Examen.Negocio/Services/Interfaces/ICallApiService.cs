using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.Examen.BusinessLogic.Services.Interfaces
{
    public interface ICallApiService
    {
         Task<T> Post<T>(string url, T data);
    }
}
