using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace API.Services
{
    public class XmlFileServices: IXmlFileServices
    {
        public string ReadKey(XMLFile xml,string key)
        {
            XDocument doc = XDocument.Load(xml.Path);
            var elements = doc.Descendants("appSettings").Descendants("add").Select(x => new {
                Key = x.Attribute("key").Value,
                Value = x.Attribute("value").Value
            }).ToList();
            var DbName = elements.Where(e => e.Key == key).Select(e => e.Value).FirstOrDefault();
            return DbName; 
        }
    }

    public interface IXmlFileServices
    {
      public  string ReadKey(XMLFile xml, string key);

    }
}


