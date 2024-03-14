using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAcces.XmlEntities
{
    [XmlRoot(ElementName = "User")]
    public class User
    {

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "UserName")]
        public string UserName { get; set; }

        [XmlAttribute(AttributeName = "Pws")]
        public string Pws { get; set; }

        [XmlAttribute(AttributeName = "Pais")]
        public string Pais { get; set; }
    }

    [XmlRoot(ElementName = "UserPais")]
    public class UserPais
    {

        [XmlElement(ElementName = "User")]
        public List<User> User { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Pais")]
        public string Pais { get; set; }

        [XmlAttribute(AttributeName = "Descripcion")]
        public string Descripcion { get; set; }
    }

    [XmlRoot(ElementName = "UsuariosLATAM")]
    public class Usuario
    {
        [XmlElement(ElementName = "UserPais")]
        public List<UserPais> UserPais { get; set; }
    }


}
