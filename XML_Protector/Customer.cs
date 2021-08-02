using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XML_Protector
{
    
    public class Customer
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("creditcard")]
        public string Creditcard { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }
    }
}
