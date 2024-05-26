using System.ComponentModel.DataAnnotations;


namespace LibraryDomain.Model;

public partial class User : Entity
{
    [Display(Name = "Прізвище")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [MaxLength(50, ErrorMessage = "Введіть коротше прізвище")]
    public string Surname { get; set; } = null!;

    [Display(Name = "Ім'я")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [MaxLength(50, ErrorMessage = "Введіть коротше ім'я")]
    public string Name { get; set; } = null!;

    [Display(Name = "Електронна пошта")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [EmailAddress(ErrorMessage = "Невірний формат E-mail")]
    public string Email { get; set; } = null!;

    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [MinLength(4, ErrorMessage = "Пароль повинен містити як мінімум 4 символа")]
    [MaxLength(50, ErrorMessage = "Введіть коротший пароль")]
    public string Password { get; set; } = null!;

    public virtual ICollection<Possession> Possessions { get; set; } = new List<Possession>();
}
