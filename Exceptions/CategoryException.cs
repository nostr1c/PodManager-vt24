namespace Models
{
    public class CategoryException : Exception
    {
        public CategoryException() : base("Category related issue.") { }
        public CategoryException(string message) : base(message) {}
    }
}
