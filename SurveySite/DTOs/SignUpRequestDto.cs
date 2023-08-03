using System.ComponentModel.DataAnnotations;

namespace SurveySite.DTOs
{
    public class SignUpRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
