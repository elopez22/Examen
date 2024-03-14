using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAcces.XmlEntities
{
    [XmlRoot(ElementName = "Productos")]
    public class Productos
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Descripcion")]
        public string Descripcion { get; set; }

        [XmlAttribute(AttributeName = "Pais")]
        public string Pais { get; set; }
    }

    [XmlRoot(ElementName = "Ramo")]
    public class Ramo
    {

        [XmlElement(ElementName = "Productos")]
        public List<Productos> Productos { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Pais")]
        public string Pais { get; set; }

        [XmlAttribute(AttributeName = "Descripcion")]
        public string Descripcion { get; set; }
    }

    [XmlRoot(ElementName = "RiesgosLATAM")]
    public class RiesgosLATAM
    {

        [XmlElement(ElementName = "Ramo")]
        public List<Ramo> Ramo { get; set; }
    }

}
