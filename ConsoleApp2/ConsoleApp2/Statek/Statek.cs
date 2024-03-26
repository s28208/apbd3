using System.Text;

namespace ConsoleApp2;

public class Statek
{
    private static int count = 1;
    public readonly string number = "Statek" + count;
    public int MaxIlosc { get; set; }
    public double MaxWaga { get; set; }
    public double MaxPredkosc { get; set; }
    public List<Kontejner> Kontejners { get; set; }

    public Statek(int maxIlosc, double maxWaga, double maxPredkosc)
    {
        Kontejners = new List<Kontejner>();
        MaxIlosc = maxIlosc;
        MaxWaga = maxWaga;
        MaxPredkosc = maxPredkosc;
        count++;
    }

    public void Load(Kontejner kontejner)
    {
        double sumwaga = 0;
        foreach (Kontejner kontejnertmp in Kontejners)
        {
            sumwaga += kontejnertmp.MasaLadunku + kontejnertmp.WagaKon;
        }
        if (Kontejners.Count != MaxIlosc && sumwaga+kontejner.MasaLadunku+kontejner.WagaKon<=this.MaxWaga)
        {
            Kontejners.Add(kontejner);
            kontejner.StatekStatus = this;
            Console.WriteLine("Statek: "+number+" zostal zawadowany, MaxPojemnosc: "+MaxIlosc+" zaladowano kontejnerow: "+Kontejners.Count);
        }
        else
        {
            Console.WriteLine("Statek juz jest pelny");
        }
    }

    public void Load(List<Kontejner> kontejners)
    {
        double sumwaga = 0;
        foreach (Kontejner kontejnertmp in Kontejners)
        {
            sumwaga += kontejnertmp.MasaLadunku + kontejnertmp.WagaKon;
        }
        foreach(Kontejner tmp in Kontejners)
        {
            sumwaga += tmp.MasaLadunku + tmp.WagaKon;
        }
        if ((MaxIlosc-Kontejners.Count)>=kontejners.Count && sumwaga<=this.MaxWaga)
        {
            foreach (Kontejner kontejner in kontejners)
                    {
                        Kontejners.Add(kontejner);
                        Console.WriteLine("Statek: "+number+" zostal zawadowany, MaxPojemnosc: "+MaxIlosc+" zaladowano kontejnerow: "+Kontejners.Count);
                        kontejner.StatekStatus = this;
                    }
        }
        else
        {
            Console.WriteLine("Statek juz jest pelny");
        }
    }

    public void Unload(Kontejner kontejner)
    {
        Kontejners.Remove(kontejner);
        kontejner.StatekStatus = null;
        Console.WriteLine("Usuniento kontejner z statku: "+kontejner.Number);
    }

    public void ReplaceKontejner(Kontejner k1, Kontejner k2)
    {
        if (k1.StatekStatus != null)
        {
           k1.StatekStatus.Kontejners.Remove(k1); 
        }
        

        int index = Kontejners.IndexOf(k1);
        if (index != -1)
        {
            Kontejners[index] = k2;
            k1.StatekStatus = null;
            k2.StatekStatus = this;
            Console.WriteLine("Kontejner "+k1.Number+" zamieniony na "+k2.Number);
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Statek: " + number + " MaxIlosc: " + MaxIlosc + " MaxPredkosc: " + MaxPredkosc +
                             " MaxWaga: " + MaxWaga + " Kontejnery: ");
        foreach (Kontejner kontejner in Kontejners)
        {
            stringBuilder.Append(kontejner.Number + " ");
        }

        return stringBuilder.ToString();
    }
}