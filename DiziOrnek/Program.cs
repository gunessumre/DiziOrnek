using System;
using System.Collections.Generic;
using System.Linq;

class Dizi
{
    public string Ad { get; set; }
    public int YapimYili { get; set; }
    public string Tur { get; set; }
    public int YayinaBaslamaYili { get; set; }
    public string Yoneten { get; set; }
    public string Platform { get; set; }
}

class KomediDizi
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public string Yoneten { get; set; }
}

class Program
{
    static void Main()
    {
        List<Dizi> diziler = new List<Dizi>();

        
        while (true)
        {
            Dizi dizi = new Dizi();

            Console.Write("Dizi Adı: ");
            dizi.Ad = Console.ReadLine();

            Console.Write("Yapım Yılı: ");
            dizi.YapimYili = int.Parse(Console.ReadLine());

            Console.Write("Türü: ");
            dizi.Tur = Console.ReadLine();

            Console.Write("Yayınlanmaya Başlama Yılı: ");
            dizi.YayinaBaslamaYili = int.Parse(Console.ReadLine());

            Console.Write("Yönetmen: ");
            dizi.Yoneten = Console.ReadLine();

            Console.Write("Yayınlandığı İlk Platform: ");
            dizi.Platform = Console.ReadLine();

            diziler.Add(dizi);

            Console.Write("Yeni bir dizi eklemek ister misiniz? (e/h): ");
            string cevap = Console.ReadLine().ToLower();
            if (cevap != "e") break;
        }

        
        List<KomediDizi> komediDiziler = diziler
            .Where(d => d.Tur.Contains("Komedi", StringComparison.OrdinalIgnoreCase))
            .Select(d => new KomediDizi
            {
                Ad = d.Ad,
                Tur = d.Tur,
                Yoneten = d.Yoneten
            })
            .OrderBy(d => d.Ad)
            .ThenBy(d => d.Yoneten)
            .ToList();

        
        Console.WriteLine("\nKomedi Dizileri:");
        foreach (KomediDizi d in komediDiziler)
        {
            Console.WriteLine($"Dizi Adı: {d.Ad}, Türü: {d.Tur}, Yönetmen: {d.Yoneten}");
        }
    }
}