using Lab11.Domain;

namespace Lab11.Repository;

public class RepositoryDocumente: AbstractFileRepository<string, Document>
{
    private List<Document> documente;

    public RepositoryDocumente(string filename) :  base(filename)
    {
        documente = new List<Document>();
        loadFile();
    }

    protected override Document fromLine(string s)
    {
        string[] parts = s.Split(',');

        Document document = new Document(parts[1], DateTime.Parse(parts[2]));
        document.Id = parts[0];

        return document;
    }

    protected override void save(Document entity)
    {
        documente.Add(entity);
    }

    public override IEnumerable<Document> findAll()
    {
        return documente;
    }

    public Document findOne(string id) {
        return documente.Find(document => document.Id.Equals(id));
    }
}