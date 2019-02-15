using System;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
{

    public static class GenericExtensions
    {
        public static string SerializeToJson<T>(this T obj, OutPutType outPutType)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            if (outPutType == OutPutType.Formatted)
            {
                jsonString = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            }
            return jsonString;
        }

        public static string SerializeToXml<T>(this T obj, string docTypeName = "", string sysId = "", bool omitXmlDeclaration = true)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlWriterSettings settings = new XmlWriterSettings();

            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.Encoding = new UnicodeEncoding(false, false); // little-endian, omit byte order mark
            settings.OmitXmlDeclaration = omitXmlDeclaration;

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                if (!(String.IsNullOrEmpty(docTypeName)))
                    writer.WriteDocType(docTypeName, null, sysId, null);
                ser.Serialize(writer, obj, ns);
            }

            return sb.ToString();

        }
        public static T ConfigValue<T>(this string key)
        {
            string value = ConfigurationManager.AppSettings[key].ToString();
            if (!(String.IsNullOrEmpty(value)))
                return (T)Convert.ChangeType(value, typeof(T));
            else
                return default(T);

        }
        ///// <summary>
        ///// This method will get Attribute value for the respective type
        ///// </summary>
        ///// <typeparam name="T">type</typeparam>
        ///// <param name="element">element</param>
        ///// <param name="attributeName">attributeName</param>
        ///// <param name="defaultValue">defaultValue</param>
        ///// <returns>specific type value</returns>
        //public static T AttributeNullValue<T>(this XElement element, string attributeName, T defaultValue = default(T))
        //{
        //    string s = element.GetAttributeValue(attributeName);

        //    if (String.IsNullOrEmpty(s))
        //    {
        //        return defaultValue;

        //    }
        //    else
        //        return (T)Convert.ChangeType(s, typeof(T));

        //}
        /// <summary>
        /// This method will get Attribute value for the respective type
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="element">element</param>
        /// <param name="attributeName">attributeName</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>specific type value</returns>
        public static T ElementNullValue<T>(this XElement element, string childElementName, T defaultValue = default(T))
        {
            string s = element.GetElementValue(childElementName);

            if (String.IsNullOrEmpty(s))
            {
                return defaultValue;

            }
            else
                return (T)Convert.ChangeType(s, typeof(T));

        }
        public static string GetElementValue(this XElement element, string childElementName)
        {
            if (element == null)
                return "";
            else
            {
                XElement elem = element.Element(childElementName);
                return elem == null ? "" : elem.Value;
            }
        }
        /// <summary>
        /// This is an extension method for XElement, checks if the element is null or if the attribute with value is null and assigns default enum value
        /// </summary>
        /// <param name="element">element</param>
        /// <param name="attributeName">attribute</param>
        /// <returns>default enum</returns>
        public static T EnumElementNull<T>(this XElement element, string elementName, T defaultValue)
        {
            string s = element.GetElementValue(elementName);
            if (String.IsNullOrEmpty(s))
                return defaultValue;
            else
                return (T)Enum.Parse(typeof(T), s);


        }
        /// <summary>
        /// This is an extension method for XElement, checks if the element is null or if the attribute with value is null and assigns default string value
        /// </summary>
        /// <param name="element">element</param>
        /// <param name="attributeName">attribute</param>
        /// <returns>default string</returns>
        public static string GetAttributeValue(this XElement element, string attributeName)
        {
            if (element == null)
                return "";
            else
            {
                XAttribute attr = element.Attribute(attributeName);
                return attr == null ? "" : attr.Value;
            }
        }

        /// <summary>
        /// This method will get Attribute value for the respective type
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="element">element</param>
        /// <param name="attributeName">attributeName</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>specific type value</returns>
        public static T AttributeNullValue<T>(this XElement element, string attributeName, T defaultValue = default(T))
        {
            string s = element.GetAttributeValue(attributeName);

            if (String.IsNullOrEmpty(s))
            {
                return defaultValue;

            }
            else
                return (T)Convert.ChangeType(s, typeof(T));

        }
    }

    public enum OutPutType
    {
        Formatted,
        Unformatted
    }

}
