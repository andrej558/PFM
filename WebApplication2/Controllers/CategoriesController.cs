using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Database;
using WebApplication2.Database.Entities;
using WebApplication2.Helpers;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly AppDbContext _dbContext;


        private readonly string CategoryPath = "C:\\Users\\InternMK-10\\bankapp\\WebApplication2\\WebApplication2\\Content\\categories.csv";

        private CSVReader csv = new CSVReader();

        private List<CategoryEntity> CategoryList = new List<CategoryEntity>();

        public CategoriesController(IMapper mapper, AppDbContext dbContext)
        {
            //_dbContext = dbContext;
            _mapper = mapper;
            _dbContext = dbContext;

            if (_dbContext.Categories.Count() == 0)
            {
                var cats = csv.GetData(CategoryPath);

                foreach (var cat in cats)
                {
                    CategoryEntity ce = new CategoryEntity();
                    ce.Code = cat.code;
                    ce.Name = cat.name;

                    if (cat.parentcode != null)
                    {
                        string parentcode = (string)cat.parentcode;
                        ce.ParentCategory = _dbContext.Categories.FirstOrDefault(
                            z => z.Code == parentcode);

                        ce.ParentCode = cat.parentcode;
                    }

                    var code = (string)cat.code;
                    if (_dbContext.Categories.Any(z => z.Code == code)) {
                        continue;
                    }



                    _dbContext.Categories.Add(ce);
                    _dbContext.SaveChanges();

                }

            }
            
        }

        [HttpGet]
        public IActionResult Get() {


            //return Ok(_dbContext.categories.ToList());
            return Ok(_dbContext.Categories.ToList());
        }


        [HttpPost]
        public IActionResult Create(Category category) {


            /*if (category != null) {

                CategoryEntity ce = new CategoryEntity();
                ce.Code = category.Code;
                ce.Name = category.Name;
                if (category.ParentCode != null) {

                    ce.ParentCategory = _dbContext.categories.FirstOrDefault(z =>
                    z.Code == category.ParentCode);
                }

                _dbContext.categories.Add(ce);
                _dbContext.SaveChanges();
            }*/

            return Ok(category);
        }


    }
}
