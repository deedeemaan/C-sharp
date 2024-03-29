namespace Lab11.Domain;

public class Achizitie: Entity<string>
{
    private string produs;
    private int cantitate;
    private double pretProdus;
    private Factura _factura;

    public Achizitie(string produs, int cantitate, double pretProdus, Factura factura)
    {
        this.produs = produs;
        this.cantitate = cantitate;
        this.pretProdus = pretProdus;
        this._factura = factura;
    }

    public string Produs
    {
        get => produs;
        set => produs = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Cantitate
    {
        get => cantitate;
        set => cantitate = value;
    }

    public double PretProdus
    {
        get => pretProdus;
        set => pretProdus = value;
    }

    public Factura factura
    {
        get => _factura;
        set => _factura = value ?? throw new ArgumentNullException(nameof(value));
    }
}