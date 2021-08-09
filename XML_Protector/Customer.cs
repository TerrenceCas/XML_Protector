using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XML_Protector
{
    
    public class Customer
    {
        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("creditcard")]
        public string creditcard { get; set; }

        [XmlElement("password")]
        public string password { get; set; }
    }
}
