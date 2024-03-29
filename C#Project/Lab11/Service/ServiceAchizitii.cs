using Lab11.Domain;
using Lab11.Repository;

namespace Lab11.Service;

public class ServiceAchizitii
{
    private RepositoryAchizitii repositoryAchizitii;

    public ServiceAchizitii(RepositoryAchizitii repositoryAchizitii)
    {
        this.repositoryAchizitii = repositoryAchizitii;
    }

    public IEnumerable<Achizitie> findAllAchizitiiDinUtilities()
    {
        IEnumerable<Achizitie> achizitii = repositoryAchizitii.findAll()
            .Where(achizitie => achizitie.factura.Categorie.Equals(Categories.Utilities));
        return achizitii;
    }
}