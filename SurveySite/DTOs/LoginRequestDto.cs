﻿using System.ComponentModel.DataAnnotations;

namespace SurveySite.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
