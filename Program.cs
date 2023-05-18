StreamReader sikeresSr = new StreamReader("D:\\zs\\hegyes\\nyelvvizsga\\bin\\Debug\\net6.0\\sikeres.csv");
StreamReader sikertelenSr = new StreamReader("D:\\zs\\hegyes\\nyelvvizsga\\bin\\Debug\\net6.0\\sikertelen.csv");
List<string> sikeres = new List<string>();
List<string> sikertelen = new List<string>();

sikeresSr.ReadLine();
string sor;
while ((sor = sikeresSr.ReadLine()) !=null )
{
    sikeres.Add(sor);

}sikertelenSr.ReadLine();
while ((sor = sikertelenSr.ReadLine()) !=null )
{
    sikertelen.Add(sor);
}


List<int> nepszerusegSikeres = new List<int>();    
string legnepszerubb;
int osszeg = 0;

foreach (string elem in sikeres)
{
    
    var split = elem.Split(";");

    foreach (var item in split.Skip(1))
    {
        osszeg += Convert.ToInt32(item);
        
    }
    nepszerusegSikeres.Add(osszeg);
    osszeg = 0;

}
osszeg = 0;
List<int> nepszerusegSikertelen = new List<int>();
foreach (string elem in sikertelen)
{

    var split = elem.Split(";");

    foreach (var item in split.Skip(1))
    {
        osszeg += Convert.ToInt32(item);

    }
    nepszerusegSikertelen.Add(osszeg);
    osszeg = 0;

}

List<int>nepszerusegOsszeg = new List<int>();
osszeg = 0;
int i = 0;
foreach (var elem in nepszerusegSikeres)
{
    nepszerusegOsszeg.Add( Convert.ToInt32(elem) + nepszerusegSikertelen[i]);
    i++;
}


 nepszerusegOsszeg.Sort();


int elso = nepszerusegOsszeg.Last();
int masodik = nepszerusegOsszeg[nepszerusegOsszeg.Count()-2];
int harmadik = nepszerusegOsszeg[nepszerusegOsszeg.Count() - 3];

nepszerusegOsszeg.Reverse();
Console.WriteLine($"{elso};{masodik};{harmadik}");
i = 0;
foreach (var item in nepszerusegOsszeg)
{
    if (item==elso||item==masodik||item==harmadik)
    {
        Console.WriteLine(sikertelen[i]);
    }
    i++;
}

sikeresSr.Close();
sikertelenSr.Close();