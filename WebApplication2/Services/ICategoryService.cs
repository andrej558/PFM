using WebApplication2.Database.Entities;

namespace WebApplication2.Services
{
    public interface ICategoryService
    {

        public CategoryEntity GetCategory(string code);

    }
}
