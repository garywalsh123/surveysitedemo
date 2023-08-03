using System.ComponentModel.DataAnnotations;

namespace SurveySite.DTOs
{
    public class RegisterResponseDto
    {
        [Required]
        public string UserName { get; set; }
    }
}
