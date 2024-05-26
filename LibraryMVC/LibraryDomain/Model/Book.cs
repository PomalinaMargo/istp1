using System.ComponentModel.DataAnnotations;

namespace LibraryDomain.Model;

public partial class Book : Entity
{

    [Display(Name = "Назва")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [MaxLength(50, ErrorMessage = "Введіть коротшу назву")]
    public string? Title { get; set; } 

    [Display(Name = "Жанр")]
    public int Genreid { get; set; }

    [Display(Name = "Автор")]
    public int Authorid { get; set; }

    [Display(Name = "Кількість сторінок")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public int NumberOfPages { get; set; }

    [Display(Name = "Опис")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string? Description { get; set; } 

    [Display(Name = "Адміністратор")]
    public int Administratorid { get; set; }

    [Display(Name = "Адміністратор")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public virtual Administrator? Administrator { get; set; } 


    [Display(Name = "Автор")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public virtual Author? Author { get; set; } 
    

    [Display(Name = "Жанр")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public virtual Genre? Genre { get; set; } 

    public virtual ICollection<Possession> Possessions { get; set; } = new List<Possession>();
}
