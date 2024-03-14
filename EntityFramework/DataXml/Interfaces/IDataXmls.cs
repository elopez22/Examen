using DataAcces.XmlEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.DataXml.Interfaces
{
    public interface IDataXmls
    {
        Usuario? getUsuarios();
        RiesgosLATAM? getProductos();
    }
}
