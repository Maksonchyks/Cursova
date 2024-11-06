using System.ComponentModel.DataAnnotations;

namespace Cursova.ViewModels
{
    public class UserRoleViewModel
    {
        [Required(ErrorMessage = "Поле Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Виберіть роль користувача")]
        public string Role { get; set; }
    }
}
