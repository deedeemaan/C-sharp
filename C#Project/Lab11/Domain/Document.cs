namespace Lab11.Domain;

public class Document: Entity<string>
{
    private string nume;
    private DateTime dataEmitere;

    public Document(string nume, DateTime dataEmitere)
    {
        this.nume = nume;
        this.dataEmitere = dataEmitere;
    }

    public string Nume
    {
        get => nume;
        set => nume = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime DataEmitere
    {
        get => dataEmitere;
        set => dataEmitere = value;
    }
}