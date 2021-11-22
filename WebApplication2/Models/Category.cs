namespace WebApplication2.Models
{
    public class Category
    {
        public Category()
        {

        }

        public string Code { get; set; }
        
        public string ParentCode { get; set; }

        public string Name { get; set; }
    }
}
