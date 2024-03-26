namespace ConsoleApp2;

public abstract class Kontejner : IKontejner
{
    public double MasaLadunku { get; set; }
    
    public double Wysokosc { get; set; }
    
    public double WagaKon { get; set; }
    
    public double Glebokosc { get; set; }

    public double MaxLad { get; set; }
    public Statek StatekStatus { get; set; }
    
    protected string number;
    

    public string Number
    {
        get { return number; }
    }
    
    protected Kontejner(double wagaKon, double glebokosc, double wysokosc,  double maxLad)
    {
        WagaKon = wagaKon;
        Glebokosc = glebokosc;
        MaxLad = maxLad;
        MasaLadunku = 0;
    }

    public virtual void Unload()
    {
        MasaLadunku = 0;
    }
    public virtual void Load(double masaLadunku)
    {
        if (masaLadunku > MaxLad-MasaLadunku)
        {
            throw new OverfillException();
        }
        else
        {
            MasaLadunku += masaLadunku;
        }
        
    }

    public void ReplaceStatek(Statek s1, Statek s2)
    {
        s1.Kontejners.Remove(this);
        s2.Kontejners.Add(this);
        this.StatekStatus = s2;
        Console.WriteLine("Statek "+s1.number+" zostaw zmieniony na "+s2.number+" dla "+this.number);
    }

    public override string ToString()
    {
        return " Wysokosc: " + Wysokosc + " WagaKontejnera: " + WagaKon + " Glebokosc: " + Glebokosc + " MaxMasaLadunku: " + MaxLad + " MasaLadunku: "  + MasaLadunku+" Statek: "+StatekStatus.number;
    }
}
