using System.ServiceModel.Syndication;

namespace Models
{
    public class Episode
    {
        public Guid Guid { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        public Episode() {}

        public Episode(SyndicationItem item)
        {
            Guid = Guid.NewGuid();
            Title = item.Title.Text;
            Description = item.Summary?.Text;
            Date = item.PublishDate.Date;
        }

        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Episode other = (Episode)obj;

            return Title == other.Title
                && Description == other.Description
                && Date == other.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description, Date);
        }
    }
}
