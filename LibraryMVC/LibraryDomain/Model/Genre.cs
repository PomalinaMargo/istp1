using System.ComponentModel.DataAnnotations;

namespace LibraryDomain.Model;

public partial class Genre : Entity
{
    [Display(Name = "Назва жанру")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [MaxLength(50, ErrorMessage = "Введіть коротшу назву жанру")]
    public string GenreName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
