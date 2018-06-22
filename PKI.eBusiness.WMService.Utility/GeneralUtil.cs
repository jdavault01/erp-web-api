using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace PKI.eBusiness.WMService.Utility
{
    public class GeneralUtil<T> where T : class
    {
        public T ConvertToObject(string input)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));          

            using (StringReader sr = new StringReader(input))
                return (T)ser.Deserialize(sr);
        }
     
    }   
}
