using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Repositories.Serializer
{
    public class Serializer<T> where T : class
    {
        private string filePath;

        private XmlSerializer xmlSerializer;

        public Serializer(string filePath)
        {
            this.filePath = filePath;
            xmlSerializer = new XmlSerializer(typeof(T));
        }

        /// <summary>
        /// Serialiserar det angivna objektet till en XML fil.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void Serialize(T obj)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(fileStream, obj);
                }
            }
            catch (Exception)
            {
                throw new SerializerException($"Serialization to {filePath} failed.");
            }
        }
         
        /// <summary>
        /// Avserialiserar XML filen till ett objektet.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under avserialiseringen.</exception>
        public T Deserialize()
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    if (xmlSerializer.Deserialize(fileStream) is not T result)
                    {
                        throw new SerializerException($"Deserialization from {filePath} returned null.");
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new SerializerException($"Deserialization from {filePath} failed.", e);
            }
        }
    }
}
