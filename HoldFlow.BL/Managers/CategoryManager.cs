using HoldFlow.Models.DTOs;

namespace HoldFlow.BL.Managers
{
    public class CategoryManager : Manager<Category>, ICategoryManager
    {
        private readonly ICategoryRepository _repository;

        public CategoryManager(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDto> AddCategory(CategoryDto categorydto)
        {
            var category = new Category
            {
                Name = categorydto.Name
            };
            var newEntity = await _repository.AddAsync(category);
            categorydto.Id = newEntity.Id;
            return categorydto;
        }

        public async Task<CategoryDto> DeleteCategory(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;

            var removedEntity = _repository.Delete(entity);
            var categoryDto = new CategoryDto
            {
                Id = removedEntity.Id,
                Name = removedEntity.Name
            };
            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var entities = await _repository.GetAllAsync();
            var categoryDtos = entities.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name
            });
            return categoryDtos;
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return null;
            var categoryDto = new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
            return categoryDto;
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == categoryDto.Id);
            if (entity == null)
                return null;
            entity.Name = categoryDto.Name;

            var updatedEntity = _repository.Update(entity);
            return categoryDto;
        }
    }
}