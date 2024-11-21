using Models;

namespace Controllers
{
    public class CategoryEventArgs : EventArgs
    {   
        public Category Category { get; private set; }

        public CategoryEventArgs(Category category)
        {
            Category = category;
        }
    }
}