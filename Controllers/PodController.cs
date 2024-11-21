using System;
using System.Xml;
using Models;
using Repositories;
using Repositories.Serializer;
using System.ServiceModel.Syndication;
using System.Diagnostics;


namespace Controllers
{
    public class PodController
    {
        private PodRepository podRepository;
        private HttpClient client;

        public event EventHandler<PodEventArgs> NewPodEventHandler;
        public event EventHandler<PodEventArgs> DeletePodEventHandler;
        public event EventHandler<PodEventArgs> UpdatePodEventHandler;

        public PodController ()
        {
            podRepository = new PodRepository();
            client = new HttpClient();
        }

        /// <summary>
        /// Hämtar poddar från repository.
        /// </summary>
        /// <exception cref="SerializerException">Kastas om något gick fel med serialisering.</exception>
        public List<Pod> GetAllPods()
        {
            return podRepository.GetAll();
        }

        public void Delete(Pod pod)
        {   
            podRepository.Delete(pod.Guid);
            DeletePodEventHandler?.Invoke(this, new PodEventArgs(pod));
        }

        public void Update(Pod podToUpdate)
        {
            podRepository.Update(podToUpdate.Guid, podToUpdate);
            UpdatePodEventHandler?.Invoke(this, new PodEventArgs(podToUpdate));
        }

        /// <summary>
        /// Hämtar och tolkar ett RSS-flöde från den angivna URL:en och sparar resultatet i pod repository.
        /// </summary>
        /// <exception cref="HttpRequestException">Kastas om det inte är en giltig URL.</exception>
        /// <exception cref="XmlException">Kastas om det uppstår ett fel under XML-läsning.</exception>
        public async Task FetchRssAsync(string url, Category category, string title)
        {
            if (string.IsNullOrWhiteSpace(url)) return;

            string response = await client.GetStringAsync(url);

            StringReader reader = new StringReader(response);

            XmlReader xmlReader = XmlReader.Create(reader);

            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            Pod pod = new Pod(feed, url, category, title);

            podRepository.Add(pod);
            NewPodEventHandler?.Invoke(this, new PodEventArgs(pod));
        }
    }
}
