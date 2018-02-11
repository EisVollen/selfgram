using System.ComponentModel.DataAnnotations;

namespace Selfgram.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name="Логин")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
