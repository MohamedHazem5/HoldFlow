namespace HoldFlow.BL.Interfaces
{
    public interface ICategoryManager : IManager<Category>
    {
        Task<CategoryDto> AddCategory(CategoryDto categoryDto);

        Task<CategoryDto> UpdateCategory(CategoryDto categoryDto);

        Task<CategoryDto> DeleteCategory(int id);

        Task<CategoryDto> GetCategoryById(int id);

        Task<IEnumerable<CategoryDto>> GetCategories();
    }
}