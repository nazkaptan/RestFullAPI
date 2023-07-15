using System.ComponentModel.DataAnnotations;

namespace RestFullAPI.Models.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Must to type category name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        [RegularExpression(@"^[a-zA-Z- ]+$", ErrorMessage = "Only letters are allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must to type description")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Description { get; set; }

        public string Slug => Name.ToLower().Replace(' ', '-');
    }
}
