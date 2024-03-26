// See https://aka.ms/new-console-template for more information

using ConsoleApp2;

LKontejner kontejner = new LKontejner(3.0, 2.0, 4.0, 4.0, false, "mleko");
Console.WriteLine(kontejner.Number);
LKontejner kontejner2 = new LKontejner(3, 5, 6, 3,  true, "paliwo");
Console.WriteLine(kontejner2.Number);
LKontejner kontejner3 = new LKontejner(3, 5, 6, 6,  true, "maslo");
Console.WriteLine(kontejner3.Number);
GKontejner kontejner4 = new GKontejner(3, 5, 6, 10,  2, true, "gaz");
Console.WriteLine(kontejner4.Number);
CKontejner kontejner5 = CKontejner.NewCKontejner(3, 5, 2, 7, CKontejner.Produkty.Egg, 20);
Console.WriteLine(kontejner5.Number);
CKontejner kontejner6 =  CKontejner.NewCKontejner(2, 5, 3, 7, CKontejner.Produkty.Frozen_Pizza, 20);
//Console.WriteLine(kontejner6.Number);
//Console.WriteLine(kontejner6.MaxLad);
//Console.WriteLine(kontejner6.WagaKon);

kontejner.Load(2);
kontejner.Load(2);
kontejner2.Load(1.5);
kontejner2.Load(1.5);
kontejner4.Load(5);
//kontejner4.Load(5);
kontejner4.Unload();
//Console.WriteLine(kontejner4);
kontejner5.Load(7);
Statek statek = new Statek(3, 20, 3);
Statek statek2 = new Statek(3, 10, 10);
statek2.Load(kontejner);
List<Kontejner> list = new List<Kontejner>();
list.Add(kontejner5);
list.Add(kontejner4);
list.Add(kontejner3);
statek.Load(list);
statek.Unload(kontejner3);
Console.WriteLine(kontejner5.ToString());
kontejner5.ReplaceStatek(statek, statek2);
Console.WriteLine(kontejner5.ToString());
Console.WriteLine(statek.ToString());
statek2.ReplaceKontejner(kontejner4, kontejner2);
Console.WriteLine(kontejner5.ToString());
Console.WriteLine(statek2.ToString());
Console.WriteLine(statek.ToString());
