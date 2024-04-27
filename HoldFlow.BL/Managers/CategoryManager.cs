namespace HoldFlow.BL.Managers
{
    public class CategoryManager : Manager<Category>, ICategoryManager
    {
        public CategoryManager(ICategoryRepository repository) : base(repository)
        {
        }

        // Implement manager methods here
    }
}