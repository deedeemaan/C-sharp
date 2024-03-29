namespace Lab11.Domain;

public enum Categories
{
    Utilities, Groceries, Fashion, Entertainment, Electronics
}
public class Factura: Document
{
    private DateTime dataScadenta;
    private List<Achizitie> achizitii;
    private Categories categorie;


    public Factura(string nume, DateTime dataEmitere,
        DateTime dataScadenta, List<Achizitie> achizitii, Categories categorie) : base(nume, dataEmitere)
    {
        this.dataScadenta = dataScadenta;
        this.achizitii = achizitii;
        this.categorie = categorie;
    }
    
    public Factura(string nume, DateTime dataEmitere, DateTime dataScadenta, Categories categorie) : base(nume, dataEmitere)
    {
        this.dataScadenta = dataScadenta;
        this.categorie = categorie;
        achizitii = new List<Achizitie>();
    }

    public void addAchizitie(Achizitie achizitie)
    {
        achizitii.Add(achizitie);
    }

    public DateTime DataScadenta
    {
        get => dataScadenta;
        set => dataScadenta = value;
    }

    public Categories Categorie
    {
        get => categorie;
        set => categorie = value;
    }

    public List<Achizitie> Achizitii
    {
        get => achizitii;
        set => achizitii = value ?? throw new ArgumentNullException(nameof(value));
    }

}