using Models;
using Repositories.Serializer;
using System.Diagnostics;

namespace Repositories
{
    public class PodRepository : IRepository<Pod>
    {
        private List<Pod> pods;
        private Serializer<List<Pod>> serializer;
        private string filePath = "pods.xml";

        public PodRepository()
        {
            serializer = new Serializer<List<Pod>>(filePath);
            pods = new List<Pod>();

            CreateXMLFileIfMissing();
            pods = GetAll();
        }

        /// <summary>
        /// Hämtar en podd baserat på dess GUID.
        /// </summary>
        /// <returns>Ett poddobjekt om den hittades eller Null om inte.</returns>
        public Pod? GetByGuid(Guid guid)
        {
            return pods.SingleOrDefault(pod => pod.Guid == guid);
        }

        /// <summary>
        /// Skapar och lägger till en ny podd.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void Add(Pod pod)
        {
            pods.Add(pod);
            SaveChanges();
        }

        /// <summary>
        /// Uppdatera den specifierad podden med nya data.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void Update(Guid guid, Pod pod)
        {
            int index = pods.FindIndex(pod => pod.Guid == guid);
            if (index == -1) return;
            pods[index] = pod;
            SaveChanges();
        }

        /// <summary>
        /// Tar bort den specifierade podden.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void Delete(Guid guid)
        {
            int index = pods.FindIndex(pod => pod.Guid == pod.Guid);
            if (index == -1) return;

            pods.RemoveAt(index);
            SaveChanges();
        }

        /// <summary>
        /// Hämtar alla poddar från XML filen.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public List<Pod> GetAll()
        {
            return serializer.Deserialize();
        }

        /// <summary>
        /// Spara och serialisera poddarna till XML filen.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void SaveChanges()
        {   
            serializer.Serialize(pods);
        }

        /// <summary>
        /// Skapa XML filen för poddar om den inte finns.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        private void CreateXMLFileIfMissing()
        {
            if (!File.Exists(filePath))
            {
                SaveChanges();
            }
        }
    }
}