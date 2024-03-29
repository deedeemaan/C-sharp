using Lab11.Domain;

namespace Lab11.Repository;

public class RepositoryFacturi : AbstractFileRepository<string, Factura>
{
    private RepositoryDocumente repositoryDocumente;
    private string filename;
    private List<Factura> facturi;

    public RepositoryFacturi(string filename, RepositoryDocumente repositoryDocumente) : base(filename)
    {
        this.repositoryDocumente = repositoryDocumente;
        facturi = new List<Factura>();
        loadFile();
    }
    
    protected override Factura fromLine(string s)
    {
        string[] parts = s.Split(',');

        Document document = repositoryDocumente.findOne(parts[0]);

        Categories categorie;
        if (parts[2] == "Utilities") categorie = Categories.Utilities;
        else if (parts[2] == "Groceries") categorie = Categories.Groceries;
        else if (parts[2] == "Fashion") categorie = Categories.Fashion;
        else if (parts[2] == "Entertainment") categorie = Categories.Entertainment;
        else categorie = Categories.Electronics;
        
        Factura factura = new Factura(document.Nume, document.DataEmitere, DateTime.Parse(parts[1]), categorie);
        factura.Id = parts[0];

        return factura;
    }

    protected override void save(Factura entity)
    {
        facturi.Add(entity);
    }

    public override IEnumerable<Factura> findAll()
    {
        return facturi;
    }

    public Factura findOne(string id) {
        return facturi.Find(factura => factura.Id.Equals(id));
    }

    public void updateFactura(string idFactura, Achizitie achizitie)
    {
        foreach (var factura in facturi)
            if (factura.Id.Equals(idFactura))
            {
                factura.addAchizitie(achizitie);
                return;
            }
    }
}