using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cakes
{
    public class Order
    {
        private static Podpunkt FormaKrug = new Podpunkt(400, "Круг", "Форма");
        private static Podpunkt FormaKvadrat = new Podpunkt(450,"Квадрат", "Форма");
        private static Podpunkt FormaOval = new Podpunkt(350, "Овал", "Форма");

        private static Podpunkt RazmerMal = new Podpunkt(150, "Маленький", "Размер");
        private static Podpunkt RazmerSredn = new Podpunkt(250, "Средний", "Размер");
        private static Podpunkt RazmerBol = new Podpunkt(300, "Большой", "Размер");

        private static Podpunkt VkusMonkey = new Podpunkt(15, "\"Подмышка обезьяны\"", "Вкус");
        private static Podpunkt VkusKlubnika = new Podpunkt(40, "\"Клубника в бензине\"", "Вкус");
        private static Podpunkt VkusDesna = new Podpunkt(22, "\"Десна курильщика\"", "Вкус");

        private static Podpunkt Kolichestvo1 = new Podpunkt(300, "Один корж", "Количество");
        private static Podpunkt Kolichestvo2 = new Podpunkt(500, "Два коржа", "Количество");
        private static Podpunkt Kolichestvo3 = new Podpunkt(650,"Макс Корж", "Количество");

        private static Podpunkt GlazurFirm = new Podpunkt(144, "Глазурь фирменная", "Глазурь");
        private static Podpunkt GlazurZub = new Podpunkt(228,"Глазурь \"Зуб Медведева\"", "Глазурь");
        private static Podpunkt GlazurPutin = new Podpunkt(0, "!БЕСПЛАТНО! Глазурь со вкусом В.В.Путина", "Глазурь");

        private static Podpunkt DekorBrawl = new Podpunkt(2000, "Украшения в стиле Brawl Stars", "Декор");
        private static Podpunkt DekorNazi = new Podpunkt(1488, "Украшения времен нацистской Германии", "Декор");
        private static Podpunkt DekorMpt = new Podpunkt(165, "Украшение с Дзюбой и Скорогудаевой в МПТ", "Декор");

        private static List<Podpunkt> Forma = new List<Podpunkt>() {FormaKrug, FormaKvadrat, FormaOval};
        private static List<Podpunkt> Razmer = new List<Podpunkt>() {RazmerMal, RazmerSredn, RazmerBol};
        private static List<Podpunkt> Vkus = new List<Podpunkt>() {VkusMonkey, VkusKlubnika, VkusDesna};
        private static List<Podpunkt> Kolichestvo = new List<Podpunkt>() {Kolichestvo1, Kolichestvo2, Kolichestvo3};
        private static List<Podpunkt> Glazur = new List<Podpunkt>() {GlazurFirm, GlazurZub, GlazurPutin};
        private static List<Podpunkt> Dekor = new List<Podpunkt>() {DekorBrawl, DekorMpt, DekorNazi};



        private static bool IsDopMenu = false;
        private static string Strelka = "=>";
        private static int Price = 0;
        private static string MyCake = "";
        private static int StrelkaPos = 1;

        public static void StrelkaChange(int x,int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Strelka);
        }

        public static void MainMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Text();
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Strelochki("Вверх");
                        break;
                    case ConsoleKey.DownArrow:
                        Strelochki("Вниз");
                        break;
                    case ConsoleKey.Enter:
                        switch (StrelkaPos)
                        {
                            case 2:
                                DopMenu(Forma);
                                break;
                            case 3:
                                DopMenu(Razmer);
                                break;
                            case 4:
                                DopMenu(Vkus);
                                break;
                            case 5:
                                DopMenu(Kolichestvo);
                                break;
                            case 6:
                                DopMenu(Glazur);
                                break;
                            case 7:
                                DopMenu(Dekor);
                                break;
                            case 8: 
                                File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\имя заказа.txt", Print());
                                return;
                        }
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }

        private static string Print()
        {
            if (Tort.FinalTort.Count != 0)
            {
                var DoneTort = Tort.FinalTort[0];
                return $"\nЗаказ от {DateTime.Now}\n\tВаш торт: {DoneTort.NameForma}, {DoneTort.NameRazmer}, {DoneTort.NameVkus}," +
                $" {DoneTort.NameKolichestvo}, {DoneTort.NameDekor}," +
                $" {DoneTort.NameGlazur}\n\tЦена - {DoneTort.Summing()}\n";
            }
            else 
            {
                return "Вы не сделали заказ.\n";
            }
        }

        private static void DopMenu(List<Podpunkt> podpunkt)
        {
            StrelkaPos = 0;
            IsDopMenu = true;
            ConsoleKeyInfo key;
            bool FirstTime = true;
            do
            {
                if (FirstTime)
                {
                    Console.Clear();
                    FirstTime = false;
                }
                IsDopMenu = true;
                int i = 0;
                foreach (var item in podpunkt)
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine($"{item.name} - {item.price}");
                    i++;
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        Strelochki("Вниз");
                        break;
                    case ConsoleKey.UpArrow:
                        Strelochki("Вверх");
                        break;
                    case ConsoleKey.Enter:
                        switch (StrelkaPos)
                        {
                            case 0:
                                Baking(StrelkaPos, podpunkt);
                                break;
                            case 1:
                                Baking(StrelkaPos, podpunkt);
                                Price += podpunkt[1].price;
                                break;
                            case 2:
                                Baking(StrelkaPos, podpunkt);
                                Price += podpunkt[2].price;
                                break;
                        }
                        break;
                }
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            IsDopMenu = false;
            StrelkaPos = 1;
            Console.Clear();
        }

        private static void Baking(int StrPos, List<Podpunkt> podpunkt)
        {
            switch (podpunkt[StrelkaPos].type, Tort.FinalTort.Count)
            {
                case ("Форма", 0):
                    Tort.FinalTort.Add(new Tort(Fname: podpunkt[StrPos].name));
                    Tort.FinalTort[0].PriceForma = podpunkt[StrPos].price;
                    break;

                case ("Размер", 0):
                    Tort.FinalTort.Add(new Tort(Rname: podpunkt[StrPos].name));
                    Tort.FinalTort[0].PriceRazmer = podpunkt[StrPos].price;
                    break;

                case ("Вкус", 0):
                    Tort.FinalTort.Add(new Tort(Vname: podpunkt[StrPos].name));
                    Tort.FinalTort[0].PriceVkus = podpunkt[StrPos].price;
                    break;

                case ("Глазурь", 0):
                    Tort.FinalTort.Add(new Tort(Gname: podpunkt[StrPos].name));
                    Tort.FinalTort[0].PriceGlazur = podpunkt[StrPos].price;
                    break;

                case ("Количество", 0):
                    Tort.FinalTort.Add(new Tort(Kname: podpunkt[StrPos].name));
                    Tort.FinalTort[0].PriceKolichestvo = podpunkt[StrPos].price;
                    break;

                case ("Декор", 0):
                    Tort.FinalTort.Add(new Tort(Dname: podpunkt[StrPos].name));
                    Tort.FinalTort[0].PriceDekor = podpunkt[StrPos].price;
                    break;
                    

                case ("Форма", 1):
                    Tort.FinalTort[0].NameForma = podpunkt[StrPos].name;
                    Tort.FinalTort[0].PriceForma = podpunkt[StrPos].price;
                    break;

                case ("Размер", 1):
                    Tort.FinalTort[0].NameRazmer = podpunkt[StrPos].name;
                    Tort.FinalTort[0].PriceRazmer = podpunkt[StrPos].price;
                    break;

                case ("Вкус", 1):
                    Tort.FinalTort[0].NameVkus = podpunkt[StrPos].name;
                    Tort.FinalTort[0].PriceVkus = podpunkt[StrPos].price;
                    break;

                case ("Глазурь", 1):
                    Tort.FinalTort[0].NameGlazur = podpunkt[StrPos].name;
                    Tort.FinalTort[0].PriceGlazur = podpunkt[StrPos].price;
                    break;

                case ("Количество", 1):
                    Tort.FinalTort[0].NameKolichestvo = podpunkt[StrPos].name;
                    Tort.FinalTort[0].PriceKolichestvo = podpunkt[StrPos].price;
                    break;

                case ("Декор", 1):
                    Tort.FinalTort[0].NameDekor = podpunkt[StrPos].name;
                    Tort.FinalTort[0].PriceDekor = podpunkt[StrPos].price;
                    break;
            }
        }

        public static void Strelochki(string Where)
        {
            if (!IsDopMenu)
            {
                Console.Clear();
                if (Where == "Вверх")
                {
                    if (StrelkaPos > 2)
                    {
                        StrelkaPos--;
                        StrelkaChange(0, StrelkaPos);
                    }
                    else
                    {
                        StrelkaPos = 1;
                    }
                }
                else if (Where == "Вниз")
                {
                    if (StrelkaPos < 8)
                    {
                        StrelkaPos++;
                        StrelkaChange(0, StrelkaPos);
                    }
                    else
                    {
                        StrelkaPos = 9;
                    }
                }
            }
            else
            {
                Console.Clear();
                if (Where == "Вверх")
                {
                    if (StrelkaPos > 0)
                    {
                        StrelkaPos--;
                        StrelkaChange(0, StrelkaPos);
                    }
                }
                else if (Where == "Вниз")
                {
                    if (StrelkaPos < 2)
                    {
                        StrelkaPos++;
                        StrelkaChange(0, StrelkaPos);
                    }
                    else
                    {
                        StrelkaPos = 3;
                    }
                }
            }
        }
        private static void Text()
        {
            //Вот этот весь ужас был создан из-за багов со стрелочками, извините, но я вынужден был так сделать
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Добро пожаловать! Выбирайте нужные вам характеристики торта.");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("Форма торта");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Размер торта");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("Вкус коржей");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("Количество коржей");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("Глазурь");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("Декор");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("Конец заказа");
            Console.SetCursorPosition(2, 9);
                
            if (Tort.FinalTort.Count!=0)
            {
                var DoneTort = Tort.FinalTort[0];
                Console.WriteLine($"\nЦена: {DoneTort.Summing()}");
                Console.WriteLine($"Ваш торт: {DoneTort.NameForma}, {DoneTort.NameRazmer}, {DoneTort.NameVkus}," +
                $" {DoneTort.NameKolichestvo}, {DoneTort.NameDekor}," +
                $" {DoneTort.NameGlazur}");
            }
            else
            {
                Console.WriteLine($"\nЦена: ");
                Console.WriteLine($"Ваш торт: ");
            }
        }
    }
}
