using System.ComponentModel.DataAnnotations;

namespace BlogApp.Model.Dto
{
    public class RegisterDto

    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50,MinimumLength =5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }


        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int RegistrationCount { get; set; }
    }
}
