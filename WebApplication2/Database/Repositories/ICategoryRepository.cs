using WebApplication2.Database.Entities;

namespace WebApplication2.Database.Repositories
{
    public interface ICategoryRepository
    {

        public CategoryEntity GetCategory(string id);
    }
}
