using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using static System.Console;

namespace XML_Protector
{
    

    class Program
    {
        static void Main(string[] args)
        {
            // string sk = ProtectedClass.GenerateSecretKey();
            string sk = "iD_OSRlWb]wEax8c]Ejvd4dFEHNp0D]`";     // Generating Secret Key

            string UnsecuredData = "UnsecuredData.xml";
            Customers UObj = FromXmlFile<Customers>(UnsecuredData);

            foreach (var c in UObj.customers)
            {
                WriteLine("Unsecures Data:");
                WriteLine("Name: " + c.name +
                            "\nCredit Card: " + c.creditcard +
                            "\nPassword: " + c.password);
                string password = ProtectedClass.SaltAndHash(c.password);
                string eStr = ProtectedClass.EncryptString(sk, c.creditcard);

                List<Customer> listOfCustomers = new List<Customer> {
                    new Customer { name = c.name , creditcard = eStr, password = password}
                };

                Customers obj2 = new Customers {
                    customers = listOfCustomers
                };
                
                ToXmlFile("SecuredData.xml", obj2);
            }

            string SecuredData = "SecuredData.xml";
            Customers SObj = FromXmlFile<Customers>(SecuredData);

            foreach (var c in SObj.customers)
            {
                string dStr = ProtectedClass.DecryptString(sk, c.creditcard);
                WriteLine("\nSecured Data:");
                WriteLine("Name: "+ c.name +
                            "\nCredit Card: " +dStr + 
                            "\nPassword: " + c.password);
            }
        }

        public static T FromXmlFile<T>(string file)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(T));
            var xmlContent = File.ReadAllText(file);

            using (StringReader sr = new StringReader(xmlContent))
            {
                return (T)xmls.Deserialize(sr);
            }
        }

        public static void ToXmlFile<T>(string file, T obj)
        {
            using (StringWriter sw =
                new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                xmls.Serialize(sw, obj);
                File.WriteAllText(file, sw.ToString());
            }
        }
    }
}
