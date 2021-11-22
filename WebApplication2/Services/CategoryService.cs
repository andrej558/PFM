using WebApplication2.Database.Entities;
using WebApplication2.Database.Repositories;

namespace WebApplication2.Services
{
    public class CategoryService : ICategoryService
    {
        //private readonly string CategoryPath = "C:\\Users\\InternMK-10\\bankapp\\WebApplication2\\WebApplication2\\Content\\categories.csv";

        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public CategoryEntity GetCategory(string code)
        {
            return categoryRepository.GetCategory(code);
        }
    }
}
