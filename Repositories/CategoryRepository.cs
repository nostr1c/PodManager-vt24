using Repositories.Serializer;
using Models;
using System.Diagnostics;

namespace Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private List<Category> categories;
        private Serializer<List<Category>> serializer;
        private string filePath = "categories.xml";
        
        public CategoryRepository()
        {
            categories = new List<Category>();
            serializer  = new Serializer<List<Category>>(filePath);

            CreateXMLFileIfMissing();
            
            categories = GetAll();
            AddEmptyCategoryIfMissing();
        }

        /// <summary>
        /// Hämtar en kategori baserat på dess GUID.
        /// </summary>
        /// <returns>Ett kategoriobjekt om den hittades eller Null om inte.</returns>
        public Category? GetByGuid(Guid guid)
        {
            return categories.SingleOrDefault(category => category.Guid == guid);
        }

        /// <summary>
        /// Skapar och lägger till en ny kategori.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void Add(Category category)
        {
            categories.Add(category);
            SaveChanges();
        }

        /// <summary>
        /// Uppdatera den specifierad kategorien med nya data.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void Update(Guid guid, Category category)
        {
            int index = categories.FindIndex(category => category.Guid == guid);
            if (index == -1) return;

            categories[index] = category;
            SaveChanges();
        }

        /// <summary>
        /// Tar bort den specifierade kategorien.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void Delete(Guid guid)
        {
            int index = categories.FindIndex(category => category.Guid == guid);

            if (index == -1) return;

            categories.RemoveAt(index);
            SaveChanges();
        }

        /// <summary>
        /// Hämtar alla kategorier från XML filen.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public List<Category> GetAll()
        {
            return serializer.Deserialize();
        }

        /// <summary>
        /// Spara och serialisera kategorier till XML filen.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        public void SaveChanges()
        {
            serializer.Serialize(categories);
        }

        /// <summary>
        /// Skapa XML filen för kategorier om den inte finns.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel under serialiseringen.</exception>
        private void CreateXMLFileIfMissing()
        {
            if (!File.Exists(filePath))
            {
                SaveChanges();
            }
        }

        private void AddEmptyCategoryIfMissing()
        {
            Category? missing = categories.SingleOrDefault(category => category.Name == "<No Category>");
            if (missing == null)
            {
                categories.Insert(0, new Category() { Guid = Guid.NewGuid(), Name = "<No Category>" });
                SaveChanges();
            }
        }
    }
}
