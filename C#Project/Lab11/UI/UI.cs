using Lab11.Service;

namespace Lab11.UI;

public class UI
{
    private ServiceAchizitii serviceAchizitii;
    private ServiceDocumente serviceDocumente;
    private ServiceFacturi serviceFacturi;

    public UI(ServiceAchizitii serviceAchizitii, ServiceDocumente serviceDocumente, ServiceFacturi serviceFacturi)
    {
        this.serviceAchizitii = serviceAchizitii;
        this.serviceDocumente = serviceDocumente;
        this.serviceFacturi = serviceFacturi;
    }

    public void run()
    {
        while(true)
        {
            meniu();
            Console.Write(">> ");
            string input = Console.ReadLine();
            try
            {
                int comanda = int.Parse(input);
                if(comanda == 1){ handleCerinta1(); }
                else if (comanda == 2) { handleCerinta2(); }
                else if(comanda == 3){ handleCerinta3(); }
                else if(comanda == 4){ handleCerinta4(); }
                else if(comanda == 5){ handleCerinta5(); }
                else if (comanda == 6)
                {
                    Console.WriteLine("Se iese din aplicatie...");
                    break;
                }
                else{ Console.WriteLine("Eroare! Numarul dat este invalid!");}
            }
            catch(Exception e)
            {
                Console.WriteLine("Eroare! Se asteapta un numar!");
            }
        }   
    }

    private void meniu()
    {
        Console.WriteLine("                     ~Meniu~               ");
        Console.WriteLine("1 -> Toate documentele emise in 2023");
        Console.WriteLine("2 -> Toate facturile scadente in luna curenta");
        Console.WriteLine("3 -> Toate facturile cu cel putin 3 produse achizitionate");
        Console.WriteLine("4 -> Toate achizitiile din categoria 'Utilities'");
        Console.WriteLine("5 -> Categoria care a inregistrat cele mai multe cheltuieli");
        Console.WriteLine("\n6 -> Exit");
    }

    private void handleCerinta1()
    {
        Console.WriteLine("Documentele emise in 2023: ");
        foreach (var document in serviceDocumente.findAllDocuments2023()) 
            Console.WriteLine("-> " + document.Nume + ", " + document.DataEmitere);
    }
    
    private void handleCerinta2()
    {
        Console.WriteLine("Facturile scadente in luna curenta: ");
        foreach (var factura in serviceFacturi.facturiScadenteLunaCurenta())
            Console.WriteLine("-> " + factura.Nume + ", " + factura.DataScadenta);
    }

    private void handleCerinta3()
    {
        Console.WriteLine("Facturile cu cel putin 3 produse: ");
        foreach (var keyValuePair in serviceFacturi.facturiCuTreiProduse()) 
            Console.WriteLine("-> " + keyValuePair.Key.Nume + " "  + keyValuePair.Value);
    }

    private void handleCerinta4()
    {
        Console.WriteLine("Achiztiile din categoria 'Utilities': ");
        foreach (var achizitie in serviceAchizitii.findAllAchizitiiDinUtilities())
            Console.WriteLine("-> " + achizitie.Produs + ", " + achizitie.factura.Nume);
    }

    private void handleCerinta5()
    {
        try
        {
            Console.WriteLine("Categoria cu cele mai multe cheltuieli -> " + serviceFacturi.categoriaMostSales());
        }
        catch (Exception e)
        {
            Console.WriteLine("Nu exista momentan cheltuieli!");
        }
    }
}