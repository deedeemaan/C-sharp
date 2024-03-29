using Lab11.Domain;
using Lab11.Repository;

namespace Lab11.Service;

public class ServiceFacturi
{
    private RepositoryFacturi repositoryFacturi;

    public ServiceFacturi(RepositoryFacturi repositoryFacturi)
    {
        this.repositoryFacturi = repositoryFacturi;
    }

    public IEnumerable<Factura> facturiScadenteLunaCurenta()
    {
        int lunaCurenta = DateTime.Now.Month;
        IEnumerable<Factura> allFacturi = repositoryFacturi.findAll()
            .Where(factura => factura.DataScadenta.Month.Equals(lunaCurenta));
        return allFacturi;
    }

    public IEnumerable<KeyValuePair<Factura,int>> facturiCuTreiProduse()
    {
        List<KeyValuePair<Factura, int>> facturi = repositoryFacturi
            .findAll()
            .Where(factura => factura.Achizitii.Sum(achizitie => achizitie.Cantitate) >= 3)
            .Select(factura => new KeyValuePair<Factura, int>(factura, factura.Achizitii.Sum(achizitie => achizitie.Cantitate)))
            .ToList();
        return facturi;
    }

    public Categories categoriaMostSales()
    {
        Dictionary<Categories, double> sales = repositoryFacturi
            .findAll()
            .SelectMany(factura => factura.Achizitii, (factura, achizitie) => new { Factura = factura, Achizitie = achizitie })
            .GroupBy(x => x.Factura.Categorie, x => x.Achizitie.PretProdus * x.Achizitie.Cantitate)
            .ToDictionary(g => g.Key, g => g.Sum());

        double maxim = -1;
        Categories categorie = Categories.Utilities;
        foreach (var keyValuePair in sales)
        {
            if (keyValuePair.Value > maxim)
            {
                maxim = keyValuePair.Value;
                categorie = keyValuePair.Key;
            }
        }
        return categorie;
    }
}