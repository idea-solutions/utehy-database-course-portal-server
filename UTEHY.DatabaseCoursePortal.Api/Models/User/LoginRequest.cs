﻿using System.ComponentModel.DataAnnotations;

namespace UTEHY.DatabaseCoursePortal.Api.Models.UserViewModels
{
    public class LoginRequest
    {
        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string? UserName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
