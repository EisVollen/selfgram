﻿using System.ComponentModel.DataAnnotations;

namespace Selfgram.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
