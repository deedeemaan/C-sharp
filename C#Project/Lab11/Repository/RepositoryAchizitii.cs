using Lab11.Domain;

namespace Lab11.Repository;

public class RepositoryAchizitii: AbstractFileRepository<string, Achizitie>
{
    private List<Achizitie> achizitii;
    private RepositoryFacturi repositoryFacturi;

    public RepositoryAchizitii(string filename, RepositoryFacturi repositoryFacturi) : base(filename)
    {
        this.repositoryFacturi = repositoryFacturi;
        achizitii = new List<Achizitie>();
        loadFile();
    }

    protected override Achizitie fromLine(string s)
    {
        string[] parts = s.Split(',');

        
        Factura factura = repositoryFacturi.findOne(parts[4]);
        Achizitie achizitie = new Achizitie(parts[1],int.Parse(parts[2]),double.Parse(parts[3]),factura);
        achizitie.Id = parts[0];

        repositoryFacturi.updateFactura(parts[4], achizitie);
        
        return achizitie;
    }

    protected override void save(Achizitie entity)
    {
        achizitii.Add(entity);
    }

    public override IEnumerable<Achizitie> findAll()
    {
        return achizitii;
    }

}