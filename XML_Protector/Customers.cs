using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XML_Protector
{
    [XmlRoot("Datatable"), Serializable]
    public class Datatable
    {
        [XmlElement("Customers")]
        public Customers Customers { get; set; }
    }
    public class Customers
    {
        [XmlElement("Customers")]
        public List<Customer> Customer { get; set; }
    }
}
