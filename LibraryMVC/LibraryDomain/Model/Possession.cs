namespace LibraryDomain.Model;


public partial class Possession
{
    public int Id { get; set; }


    public int Userid { get; set; }

    public int Bookid { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
