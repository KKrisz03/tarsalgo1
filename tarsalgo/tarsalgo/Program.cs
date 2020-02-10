using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tarsalgo
{
    class Program
    {
        private static List<adat> adatok = new List<adat>();
        static void Main(string[] args)
        {
            feladat_01();
            feladat_02();
            //feladat_03();
            //feladat_04();
            feladat_05();
            feladat_06();
            Console.ReadKey();
        }

        

        private static void feladat_06()
        {
            int osszperc = 0, time1 = 0, time2 = 1,id=0,index=0;
            bool tarsalgoban_volt = false;
            Console.WriteLine("6. feladat");
            Console.Write("Adja meg a személy azonosítóját: ");
            int bekert = int.Parse(Console.ReadLine());
            Console.WriteLine("7. feladat");
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].id == bekert && adatok[i].bennt)
                {
                    Console.Write($"{adatok[i].ora}:{adatok[i].perc}-");
                    time1 = adatok[i].ora*60+adatok[i].perc;
                    id++;
                    index = i;
                }
                if (adatok[i].id == bekert && !adatok[i].bennt)
                {
                    Console.Write($"{adatok[i].ora}:{adatok[i].perc}\n");
                    time2 = adatok[i].ora * 60 + adatok[i].perc;
                    osszperc += time2 - time1;
                }
            }
            if (id % 2 == 1)
            {
                tarsalgoban_volt = true;
                time2 = 15 * 60;
                osszperc += time2 - (adatok[index].ora * 60 + adatok[index].perc);
            }
            Console.WriteLine();
            Console.WriteLine("8. feladat");
            if (tarsalgoban_volt == true)
                Console.WriteLine($"A(z) {bekert} személy összesen {osszperc} percet volt bennt, a megfigyelés végén a társalgóban volt.");
            if (tarsalgoban_volt == false)
                Console.WriteLine($"A(z) {bekert} személy összesen {osszperc} percet volt bennt, a megfigyelés végén nem volt a társalgóban.");

        }

        private static void feladat_05()
        {
            Console.WriteLine("5. feladat");
            int ossz = 0;
            int max = 0;
            for(int i=0;i<adatok.Count;i++)
            {
                if(adatok[i].bennt)
                {
                    ossz++;
                    if (max < ossz)
                    {
                        max=ossz;
                        if (max == 12)
                            Console.WriteLine($"{adatok[i].ora}:{adatok[i].perc}-kor voltak a legtöbben a társalgóban, {max}-en");
                    }
                }   
                if (!adatok[i].bennt)
                {
                    ossz--;
                    
                }
            }
        }

        //private static void feladat_04()
        //{
        //    int[] szamlalo = null;
        //    //Console.WriteLine("4. feladat");
        //    for(int i=0;i<adatok.Count;i++)
        //    {
                
        //    }
        //    for(int i=0;i<adatok.Count;i++)
        //    {
                
        //    }
        //}

        //private static void feladat_03()
        //{
        //    int[] athaladasok = new int[2000];
        //    int db = 0;
        //    for(int i=0;i<adatok.Count;i++)
        //    {
        //        if(adatok[i].bennt || !adatok[i].bennt)
        //        {
        //            athaladasok[i] = db+1;
        //        }
        //    }
        //    for (int i = 0; i < adatok.Count; i++)
        //    {
        //        Console.WriteLine(athaladasok[i]);
        //    }
        //}

        private static void feladat_02()
        {
            Console.WriteLine("2. feladat");
            for (int i = 0; i < adatok.Count; i++)
            {
                if(adatok[i].bennt)
                {
                    Console.WriteLine($"Az első belépő: {adatok[i].id}");
                    break;
                }
            }
            for (int i = adatok.Count-1; i >= 0; i--)
            {
                if(!adatok[i].bennt)
                {
                    Console.WriteLine($"Az utolsó kilépő: {adatok[i].id}");
                    break;
                }
            }
        }

        private static void feladat_01()
        {
            
            StreamReader sr = new StreamReader("ajto.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(' ');
                adatok.Add(new adat(int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]), temp[3] == "be"));
            }
            
            
        }
    }
}
