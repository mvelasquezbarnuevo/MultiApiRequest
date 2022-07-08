using System.Xml;
using System.Xml.Serialization;

namespace RequestConsole.Extensions
{
    internal static class XmlExtensions
    {
        public static string ToXml<T>(this T value)
        {
            var stringWriter = new StringWriter();
            using var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            });
            var serializer = new XmlSerializer(typeof(T));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            serializer.Serialize(writer, value, namespaces);
            return stringWriter.ToString();
        }

        public static T? DeserializeXml<T>(this string value) where T : class

        {
            var serializer = new XmlSerializer(typeof(T));
            using TextReader reader = new StringReader(value);
            return (T?)serializer.Deserialize(reader);
        }
    }
}
