namespace ConsoleApp2;

public class CKontejner : Kontejner
{
    public enum Produkty
    {
        Banana, Chocolate, Fish, Meat, Ice_Cream, Frozen_Pizza, Cheese, Sausage, Butter, Egg  
    }
    private static int count = 1;
    public Produkty Produkt { get; set; }
    
    public double Temperatura { get; set; }
    private CKontejner(double wagaKon, double glebokosc, double wysokosc, double maxLad, Produkty produkt,  double temperatura) : base(wagaKon, glebokosc, wysokosc, maxLad)
    {
        
            Temperatura = temperatura;
            MasaLadunku = 0;
            count++;
            Produkt = produkt;
            number = "KON-C-" + count;
        
    }

    public static CKontejner NewCKontejner(double wagaKon, double glebokosc, double wysokosc, double maxLad, Produkty produkt,  double temperatura)
    {
        if (checkTemperatura(temperatura, produkt))
        {
            return new CKontejner(wagaKon, glebokosc, wysokosc, maxLad, produkt, temperatura);
        }
        else
        {
            Console.WriteLine("Temperatura nie spewnia warunki");
            return null;
        }
    }
    private static bool checkTemperatura(double temperatura, Produkty produkt)
    {
        if (produkt.Equals(Produkty.Banana) && temperatura>=13.3 && temperatura<=18.3)
        {
            return true;
        }else if(produkt.Equals(Produkty.Chocolate) && temperatura>=18 && temperatura<=23)
        {
            return true;
        }else if(produkt.Equals(Produkty.Fish) && temperatura>=2 && temperatura<=7)
        {
            return true;
        }else if(produkt.Equals(Produkty.Meat) && temperatura>=-15 && temperatura<=-10)
        {
            return true;
        }else if(produkt.Equals(Produkty.Ice_Cream) && temperatura>=-18 && temperatura<=-13)
        {
            return true;
        }else if(produkt.Equals(Produkty.Frozen_Pizza) && temperatura>=-30 && temperatura<=-25)
        {
            return true;
        }else if(produkt.Equals(Produkty.Cheese) && temperatura>=7.2 && temperatura<=12.2)
        {
            return true;
        }else if(produkt.Equals(Produkty.Sausage) && temperatura>=5 && temperatura<=10)
        {
            return true;
        }else if(produkt.Equals(Produkty.Butter) && temperatura>=20.5 && temperatura<=25.5)
        {
            return true;
        }else if(produkt.Equals(Produkty.Egg) && temperatura>=19 && temperatura<=24)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Load(double masaLadunku)
    {
        if (masaLadunku <= MaxLad - MasaLadunku)
        {
            MasaLadunku += masaLadunku;
            Console.WriteLine("Kontejner: "+number+" zostal zawadowany, Produktem: "+Produkt+", MaxPojemnosc: "+MaxLad+", zaladowano: "+MasaLadunku);
        }
        else
        {
            throw new OverfillException();
        }
        
    }
    public override string ToString()
    {
        return "Kontejner: "+number+" Produkt: "+Produkt+" Temperatura: "+Temperatura+base.ToString();
    }
}