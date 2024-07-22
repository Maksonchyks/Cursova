using System.ComponentModel.DataAnnotations;

namespace Cursova.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Поле Email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Пароль є обов'язковим")]
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
