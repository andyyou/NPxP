using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace NPxP.Helper
{
    public static class SerializationHelper
    {
        public static T Deserialize<T>(XDocument doc)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var reader = doc.Root.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static XDocument Serialize<T>(T value)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            XDocument doc = new XDocument();
            XDeclaration dec = new XDeclaration("1.0", "utf-8", "no");
            doc.Declaration = dec;
            using (var writer = doc.CreateWriter())
            {
                xmlSerializer.Serialize(writer, value);
            }

            return doc;
        }
    }
}
