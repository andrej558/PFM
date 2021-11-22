using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Database.Entities
{
    public class CategoryEntity
    {

        /*[Key]
        [Required]
        public int Id { get; set; }*/

        
        [Required]
        [Key]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("ParentCategoryCode")]

        public string ParentCode { get; set; }

        public virtual CategoryEntity? ParentCategory { get; set; }

    }
}
