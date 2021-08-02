﻿using System;
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
            //string xmlFile = "UnsecuredData.xml";
            //FromXmlFile<List<Customers>>(xmlFile);

            //var listOfCustomers = new List<Customers>
            //{
            //new Customer { name = "", creditcard = "", 
            //    password = ""}
            //};

            XmlSerializer serializer = new XmlSerializer(typeof(Datatable));
            FileStream loadStream = new FileStream("UnsecuredData.xml", FileMode.Open, FileAccess.Read);
            Datatable loadedObject = (Datatable)serializer.Deserialize(loadStream);
            loadStream.Close();



            //string password = "Admin1234";
            //string hashed = ProtectedClass.toMD5(password);
            //string hashed2 = ProtectedClass.SaltAndHash(password);
            //string hashed3 = string.Empty;

            //using (SHA256 sha256Hash = SHA256.Create())
            //{
            //    hashed3 = ProtectedClass.GetHash(sha256Hash, password);

            //    WriteLine($"The SHA256 hash of {password} is: {hashed3}.");
            //}

            //string userPassword = "Admin1234";
            //string hashedUserPassword = ProtectedClass.toMD5(userPassword);
            //string hashedUserPassword2 = ProtectedClass.SaltAndHash(userPassword);

            //WriteLine(hashed);
            //WriteLine(hashed2);
            //WriteLine(hashed3);

            //if (hashed2.Equals(hashedUserPassword2))
            //{
            //    WriteLine("signed in!!!");
            //}
            //else
            //{
            //    WriteLine("Incorrect password!!!");
            //}
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