using System.ComponentModel.DataAnnotations;

namespace LibraryDomain.Model;

public partial class Author : Entity
{
    [Display(Name = "Прізвище")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [MaxLength(50, ErrorMessage = "Введіть коротше прізвище")]
    public string Surname { get; set; } = null!;

    [Display(Name = "Ім'я")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [MaxLength(50, ErrorMessage = "Введіть коротше ім'я")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
