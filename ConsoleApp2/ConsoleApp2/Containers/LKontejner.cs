namespace ConsoleApp2;

public class LKontejner : Kontejner, IHazardNotifier
{
    public bool Dangerous { get; set; }
    public string Zawartosc { get; set; }
    private static int count = 1;

    
    

    public LKontejner(double wagaKon, double glebokosc, double wysokosc, double maxLad, bool dangerous, string zawartosc) : base(wagaKon, glebokosc, wysokosc, maxLad)
        {
            MasaLadunku = 0;
            Dangerous = dangerous;
            Zawartosc = zawartosc;
            number = "KON-L-" + count; 
            count++;
        }
    
    public override void Load(double masaLadunku)
    {
        if (Dangerous == false)
        {
            if (masaLadunku <= 0.9*(MaxLad) - MasaLadunku)
            {
                MasaLadunku += masaLadunku;
                Console.WriteLine("Kontejner: "+number+" zostal zawadowany, MaxPojemnosc: "+0.9*MaxLad+" zaladowano: "+MasaLadunku);

            }
            else
            {
                statusDanger();
                //throw new OverfillException();

            }
        }
        else if(Dangerous == true){
            if (masaLadunku <= 0.5*(MaxLad) - MasaLadunku)
            {
                MasaLadunku += masaLadunku;
                Console.WriteLine("Kontejner: "+number+" zostal zawadowany, MaxPojemnosc: "+0.5*MaxLad+" zaladowano: "+MasaLadunku);

            }
            else
            {
                statusDanger();
                //throw new OverfillException();
            }
        }

    }
    


    public void statusDanger()
    {
        Console.WriteLine("Nieberpeczna operacja - Kontejner: "+number);
    }

    public override string ToString()
    {
        return "Kontejner: "+number+" Niebezbeczny: "+Dangerous+" Zawartosc: "+Zawartosc+base.ToString();
    }
}
