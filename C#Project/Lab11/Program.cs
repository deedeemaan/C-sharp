// See https://aka.ms/new-console-template for more information

using Lab11.Repository;
using Lab11.Service;
using Lab11.UI;

RepositoryDocumente repositoryDocumente = new RepositoryDocumente("C:\\Users\\denis\\RiderProjects\\Lab11\\Lab11\\Data\\documente.txt");
RepositoryFacturi repositoryFacturi = new RepositoryFacturi("C:\\Users\\denis\\RiderProjects\\Lab11\\Lab11\\Data\\facturi.txt", repositoryDocumente);
RepositoryAchizitii repositoryAchizitii = new RepositoryAchizitii("C:\\Users\\denis\\RiderProjects\\Lab11\\Lab11\\Data\\achizitii.txt", repositoryFacturi);

    
ServiceAchizitii serviceAchizitii = new ServiceAchizitii(repositoryAchizitii);
ServiceDocumente serviceDocumente = new ServiceDocumente(repositoryDocumente);
ServiceFacturi serviceFacturi = new ServiceFacturi(repositoryFacturi);

UI ui = new UI(serviceAchizitii, serviceDocumente, serviceFacturi);
ui.run();