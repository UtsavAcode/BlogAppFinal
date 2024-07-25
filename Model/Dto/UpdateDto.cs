using System.ComponentModel.DataAnnotations;

namespace BlogApp.Model.Dto
{
    public class UpdateDto
    {
    
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        
    }
}
