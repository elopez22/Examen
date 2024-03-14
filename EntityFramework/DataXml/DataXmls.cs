using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using DataAcces.XmlEntities;
using DataAcces.DataXml.Interfaces;

namespace DataAcces.DataXml
{
    public class DataXmls: IDataXmls
    {
        public Usuario? getUsuarios()
        {
			try
			{
                var xmlSerializer = new XmlSerializer(typeof(Usuario));

                using (var reader = XmlReader.Create(Constans.XmlConsts.RutaXmlUsuarios))
                {
                    return xmlSerializer.Deserialize(reader) as Usuario;
                }
            }
			catch (Exception)
			{

				throw;
			}
        }
        public RiesgosLATAM? getProductos()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(RiesgosLATAM));

                using (var reader = XmlReader.Create(Constans.XmlConsts.RutaXmlProductos))
                {
                    return xmlSerializer.Deserialize(reader) as RiesgosLATAM;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
