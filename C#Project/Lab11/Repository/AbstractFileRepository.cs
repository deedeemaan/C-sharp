using Lab11.Domain;

namespace Lab11.Repository;

public abstract class AbstractFileRepository<ID, E>: IRepository<ID, E> where E : Entity<ID>
{
    private string fileName;

    protected AbstractFileRepository(string fileName) { this.fileName = fileName; }

    protected abstract E fromLine(string s);

    protected abstract void save(E entity);
    
    protected void loadFile()
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                E entity= fromLine(s);
                save(entity);
            }
        }
    }

    public abstract IEnumerable<E> findAll();
}