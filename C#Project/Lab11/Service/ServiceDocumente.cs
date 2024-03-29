using Lab11.Domain;
using Lab11.Repository;

namespace Lab11.Service;

public class ServiceDocumente
{
    private RepositoryDocumente repositoryDocumente;

    public ServiceDocumente(RepositoryDocumente repositoryDocumente)
    {
        this.repositoryDocumente = repositoryDocumente;
    }

    public IEnumerable<Document> findAllDocuments2023()
    {
        IEnumerable<Document> documente =
            repositoryDocumente.findAll().Where(document => document.DataEmitere.Year == 2023);
        return documente;
    }
}