using WebApplication2.Database.Entities;

namespace WebApplication2.Database.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {

        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }


        public CategoryEntity GetCategory(string code) {

            return _context.Categories.Find(code);
        }

    }
}
