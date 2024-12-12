using System;

namespace HesapMakinesi
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine("     HESAP MAKİNESİ     ");
                Console.WriteLine("=========================");
                Console.WriteLine("1. Toplama");
                Console.WriteLine("2. Çıkarma");
                Console.WriteLine("3. Çarpma");
                Console.WriteLine("4. Bölme");
                Console.WriteLine("5. Kare Alma");
                Console.WriteLine("6. Karekök Alma");
                Console.WriteLine("7. Faktöriyel Hesaplama");
                Console.WriteLine("8. Üstel Hesaplama (x^y)");
                Console.WriteLine("9. Çıkış");
                Console.WriteLine("=========================");
                Console.Write("Seçiminiz (1-9): ");

                string? secim = Console.ReadLine();

                if (secim == "9")
                {
                    Console.WriteLine("Hesap makinesi kapatılıyor. Hoşçakalın!");
                    break;
                }

                double sayi1 = 0, sayi2 = 0;

                if (secim == "7" || secim == "5" || secim == "6") // Tek sayı gerektiren işlemler
                {
                    Console.WriteLine("Bir sayı girin:");
                    sayi1 = GetValidNumber();
                }
                else if (secim == "8") // Üstel hesaplama için taban ve üs gerekiyor
                {
                    Console.WriteLine("Taban değerini girin:");
                    sayi1 = GetValidNumber();

                    Console.WriteLine("Üs değerini girin:");
                    sayi2 = GetValidNumber();
                }
                else // Diğer işlemler için iki sayı alıyoruz
                {
                    Console.WriteLine("Birinci sayıyı girin:");
                    sayi1 = GetValidNumber();

                    Console.WriteLine("İkinci sayıyı girin:");
                    sayi2 = GetValidNumber();
                }

                double sonuc = PerformOperation(secim, sayi1, sayi2);
                Console.WriteLine($"Sonuç: {sonuc}");
            }
        }

        static double GetValidNumber()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                {
                    return number;
                }
                Console.WriteLine("Geçersiz giriş! Lütfen bir sayı girin:");
            }
        }

        static double PerformOperation(string? secim, double sayi1, double sayi2)
        {
            switch (secim)
            {
                case "1":
                    return sayi1 + sayi2;
                case "2":
                    return sayi1 - sayi2;
                case "3":
                    return sayi1 * sayi2;
                case "4":
                    if (sayi2 != 0)
                    {
                        return sayi1 / sayi2;
                    }
                    else
                    {
                        Console.WriteLine("Hata: Sıfıra bölme işlemi yapılamaz!");
                        return 0;
                    }
                case "5":
                    return sayi1 * sayi1; // Kare alma
                case "6":
                    if (sayi1 >= 0)
                    {
                        return Math.Sqrt(sayi1); // Karekök
                    }
                    else
                    {
                        Console.WriteLine("Hata: Negatif bir sayının karekökü alınamaz!");
                        return 0;
                    }
                case "7":
                    return Factorial((int)sayi1); // Faktöriyel hesaplama
                case "8":
                    return Math.Pow(sayi1, sayi2); // Üstel hesaplama
                default:
                    Console.WriteLine("Geçersiz işlem seçimi.");
                    return 0;
            }
        }

        static double Factorial(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Hata: Negatif sayıların faktöriyeli hesaplanamaz!");
                return 0;
            }

            double sonuc = 1;
            for (int i = 1; i <= n; i++)
            {
                sonuc *= i;
            }
            return sonuc;
        }
    }
}
