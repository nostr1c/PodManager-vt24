namespace Models
{
    public class Category
    {
        public Guid Guid { get; set; }
        public string? Name { get; set; }

        public Category() {}

        public Category(string name)
        {
            Guid = Guid.NewGuid();
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Category other = (Category)obj;

            return Name == other.Name || Guid == other.Guid;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
