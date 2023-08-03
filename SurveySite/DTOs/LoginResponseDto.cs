using System.ComponentModel.DataAnnotations;

namespace SurveySite.DTOs
{
    public class LoginResponseDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Jwt { get; set; }
    }
}
