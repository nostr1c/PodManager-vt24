using System.ServiceModel.Syndication;
using System.Collections.Generic;
using System.Xml;

namespace Models
{
    public class Pod
    {
        public Guid Guid { get; set; }
        public string? Title { get; set; }
        public List<Episode>? Episodes { get; set; }
        public Category? Category { get; set; }
        public string? Url { get; set; }
        public int? EpisodeCount { get => Episodes?.Count; }

        public Pod() {}

        public Pod (SyndicationFeed feed, string url, Category category, string title)
        {
            Guid = Guid.NewGuid();
            Url = url;
            Category = category;
            Episodes = new List<Episode>();

            if (string.IsNullOrWhiteSpace(title))
            {
                Title = feed.Title.Text;
            }
            else
            {
                Title = title;
            }
            
            foreach (SyndicationItem item in feed.Items)
            {
                Episodes.Add(new Episode(item));
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Pod other = (Pod)obj;

            return Title == other.Title
                && Url == other.Url
                && EpisodeCount == other.EpisodeCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Url, EpisodeCount);
        }
    }
}
