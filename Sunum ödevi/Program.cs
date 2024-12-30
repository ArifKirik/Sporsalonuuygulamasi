using System;
using System.Collections.Generic;

class Program
{
    // Kullanıcı bilgilerini saklayan sınıf
    class User
    {
        public string İsim { get; set; }    // Kullanıcının ismi
        public string Soyisim { get; set; } // Kullanıcının soyismi
        public string Şifre { get; set; }   // Kullanıcının şifresi
    }

    static void Main()
    {
        List<User> users = new List<User>(); // Kullanıcıların kaydedeceği liste

        Console.WriteLine("AltınYumruk Spor Salonu Web Sitesine Hoşgeldiniz!");
        Console.WriteLine("Lütfen öncelikle sisteme kaydolun.");
        Console.WriteLine("-----------------------------------------");

        Giriş(users); // Kullanıcı kaydını başlat

        Console.WriteLine("Tebrikler, kaydınız tamamlandı! Şimdi giriş yapabilirsiniz.");
        Console.WriteLine("-----------------------------------------");

        bool doğrugiriş = false; // Doğru giriş yapılıp yapılmadığını kontrol etmek için

        // Kullanıcıdan giriş bilgilerini alıyoruz
        while (!doğrugiriş)
        {
            Console.Write("Adınızı giriniz: ");
            string name = Console.ReadLine();

            Console.Write("Soyadınızı giriniz: ");
            string surname = Console.ReadLine();

            Console.Write("Şifrenizi giriniz: ");
            string password = Console.ReadLine();

            // Kullanıcıların listesinde, girilen bilgilerle eşleşen bir kullanıcı olup olmadığını kontrol et
            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                if (user.İsim == name && user.Soyisim == surname && user.Şifre == password)
                {
                    doğrugiriş = true; // Eşleşme bulunursa giriş doğru yapılmış demek
                    break;
                }
            }

            if (doğrugiriş)
            {
                Console.WriteLine("Doğru giriş yaptınız. Hoşgeldiniz!");
            }
            else
            {
                Console.WriteLine("Yanlış bilgi girdiniz. Lütfen tekrar deneyiniz:");
            }
        }

        // Günlük protein ihtiyacını gösterip, gerekli miktarı aldığını kontrol ediyoruz
        Console.WriteLine("Günlük almanız gereken protein miktarını görmek ister misiniz? (E: Evet, H: Hayır)?");
        string seçim = Console.ReadLine().ToUpper();

        if (seçim == "E")
        {
            Console.WriteLine("Kilonuzu giriniz:");
            decimal kilo = decimal.Parse(Console.ReadLine());
            decimal alınmasıgerekenprotein = kilo * 8 / 10;
            Console.WriteLine($"Günlük almanız gereken protein miktarı: {alınmasıgerekenprotein} Gram");

            Console.WriteLine("Bugün toplam aldığınız proteini gram olarak giriniz:");
            decimal toplamalınanprotein = decimal.Parse(Console.ReadLine());

            if (toplamalınanprotein >= alınmasıgerekenprotein)
            {
                Console.WriteLine("Yeterli miktarda protein aldığınız gözüküyor, ekstra toza ihtiyacınız yok.");
            }
            else
            {
                Console.WriteLine("Yeterli miktarda protein almadığınız gözüküyor. Menümüzdeki protein tozlarını görmek ister misiniz? (E: Evet, H: Hayır)");
                string menuseçim = Console.ReadLine().ToUpper();

                if (menuseçim == "E")
                {
                    GymMenu(); // Kullanıcı menüyü görmek istiyorsa protein tozları menüsünü açıyoruz
                }
                else
                {
                    Console.WriteLine("Çıkış yapılıyor, iyi günler dileriz!");
                }
            }
        }
        else if (seçim == "H")
        {
            Console.WriteLine("Çıkış yapılıyor. İyi günler dileriz!");
        }
        else
        {
            Console.WriteLine("Geçersiz giriş. Program sonlandırılıyor.");
        }
    }

    // Kullanıcı kaydını işleyecek fonksiyon
    static void Giriş(List<User> users)
    {
        Console.Write("Adınızı giriniz: ");
        string isim = Console.ReadLine();

        Console.Write("Soyadınızı giriniz: ");
        string soyisim = Console.ReadLine();

        Console.Write("Şifrenizi belirleyiniz: ");
        string şifre = Console.ReadLine();

        // Kullanıcıyı listeye ekliyoruz
        users.Add(new User { İsim = isim, Soyisim = soyisim, Şifre = şifre });
    }

    // Spor salonu menüsünü ve alışveriş işlemini başlatan fonksiyon
    static void GymMenu()
    {
        // Menüyü ve fiyatlarını tutan bir sözlük
        Dictionary<string, decimal> menu = new Dictionary<string, decimal>
        {
            { "HIQ High Pro+(900 Gram)", 1200m },
            { "Supplementler Whey Protein(1 kg)", 1000m },
            { "Protein ocn(400 gram)", 600m },
            { "BeWolf (2.5kg)", 1800m },
            { "HIQ High Pro+(510 gram)", 749m },
            { "Supplementler Whey Protein (500 gram)", 700m },
            { "Protein ocn (400 gram)", 400m },
            { "BeWolf (500 gram)", 600m }
        };

        Console.Clear();
        Console.WriteLine("Spor Salonu Menüsü:");
        Console.WriteLine("--------------------");

        List<string> menuList = new List<string>(menu.Keys);

        // Menüdeki ürünleri listeliyoruz
        for (int i = 0; i < menuList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menuList[i]}: {menu[menuList[i]]} TL");
        }

        Console.WriteLine("Menüyü gördünüz. Protein tozu satın almak için tuşlayınız: E: Evet, H: Hayır");
        string alışverişseçim = Console.ReadLine().ToUpper();
        if (alışverişseçim == "E")
        {
            Console.WriteLine("Lütfen bakiyenizi giriniz:");
            decimal bakiye = decimal.Parse(Console.ReadLine());

            List<string> satınalınanşeyler = new List<string>();
            decimal toplammaliyet = 0;

            // Kullanıcının alışveriş yapmak için ürün seçmesi işlemi
            while (true)
            {
                Console.WriteLine("Satın almak istediğiniz ürünün numarasını giriniz (Çıkmak için 0 yazınız):");
                int selectedIndex;
                bool Geçerliseçim = int.TryParse(Console.ReadLine(), out selectedIndex);

                if (selectedIndex == 0)
                {
                    // Alışveriş tamamlandığında bakiyeyi ve alınan ürünleri gösteriyoruz
                    Console.WriteLine($"Çıkış yapıldı. Kalan Bakiyeniz: {bakiye} TL");
                    if (satınalınanşeyler.Count > 0)
                    {
                        Console.WriteLine("Fatura almak ister misiniz? (E: Evet, H: Hayır)");
                        string invoiceChoice = Console.ReadLine().ToUpper();

                        if (invoiceChoice == "E")
                        {
                            Console.WriteLine("Fatura:");
                            Console.WriteLine("------------------");
                            for (int i = 0; i < satınalınanşeyler.Count; i++)
                            {
                                Console.WriteLine(satınalınanşeyler[i]);
                            }
                            Console.WriteLine($"Toplam Tutar: {toplammaliyet} TL");
                            Console.WriteLine("------------------");
                            Console.WriteLine("Afiyet olsun, çıkış yapılıyor. İyi günler!");
                        }
                        else
                        {
                            Console.WriteLine("Afiyet olsun, çıkış yapılıyor. İyi günler!");
                        }
                    }
                    break;
                }

                // Ürün seçildiğinde, yeterli bakiyeniz varsa ürünü satın alıyoruz
                if (Geçerliseçim && selectedIndex > 0 && selectedIndex <= menuList.Count)
                {
                    string selectedItem = menuList[selectedIndex - 1];
                    decimal fiyat = menu[selectedItem];

                    if (bakiye >= fiyat)
                    {
                        bakiye -= fiyat;
                        satınalınanşeyler.Add($"{selectedItem}: {fiyat} TL");
                        toplammaliyet += fiyat;
                        Console.WriteLine($"{selectedItem} satın alındı. Afiyet olsun! Kalan bakiyeniz: {bakiye} TL");
                    }
                    else
                    {
                        Console.WriteLine($"Yetersiz bakiye! {selectedItem} için en az {fiyat - bakiye} TL gerekiyor.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen menüdeki geçerli bir numarayı giriniz.");
                }
            }
        }
    }
}
