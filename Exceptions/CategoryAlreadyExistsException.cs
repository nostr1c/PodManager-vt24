namespace Models
{
    public class CategoryAlreadyExistsException : CategoryException
    {
        public CategoryAlreadyExistsException(string message) : base(message) { }
    }
}
