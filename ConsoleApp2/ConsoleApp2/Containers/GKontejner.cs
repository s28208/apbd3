using System.Data;

namespace ConsoleApp2;

public class GKontejner: Kontejner, IHazardNotifier
{
    public double Cisnienie { get; set; }
    public string Zawartosc { get; set; }
    public bool Dangerous { get; set; }
    private static int count = 1;

    public GKontejner(double wagaKon, double glebokosc, double wysokosc, double maxLad, double cisnienie, bool dangerous, string zawartosc) : base(wagaKon, glebokosc, wysokosc, maxLad)
        {
            MasaLadunku = 0;
            Cisnienie = cisnienie;
            Dangerous = dangerous;
            Zawartosc = zawartosc;
            number = "KON-C-" + count;
            count++;
        }
    

    public override void Unload()
    {
        MasaLadunku = 0.05 * MasaLadunku;
    }
    
    public override void Load(double masaLadunku)
    {
        if (!Dangerous)
        {
            if (masaLadunku <= (MaxLad - MasaLadunku))
            {
                MasaLadunku += masaLadunku;
                Console.WriteLine("Kontejner: "+number+" zostal zawadowany, MaxPojemnosc: "+MaxLad+" zaladowano: "+MasaLadunku);
            }
            else
            {
                throw new OverfillException();
            }
        }
        else if(Dangerous){
            if (masaLadunku <= 0.5*(MaxLad)- MasaLadunku)
            {
                statusDanger();
                MasaLadunku += masaLadunku;
                Console.WriteLine("Kontejner: "+number+" zostal zawadowany, MaxPojemnosc: "+0.5*MaxLad+" zaladowano: "+MasaLadunku);
            }
            else
            {
                throw new OverfillException();
            }
        }
    }

    public void statusDanger()
    {
        Console.WriteLine("Niebezpieczne ladowanie - Kontejner: "+number);
    }
    
    public override string ToString()
    {
        return "Kontejner: "+number+" Niebezbeczny: "+Dangerous+base.ToString();
    }
}