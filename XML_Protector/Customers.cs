using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XML_Protector
{
    [XmlRoot("customers")]
    public class Customers
    {
        [XmlElement("customer")]
        public List<Customer> customers { get; set; }
    }
}
