namespace so2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Legszennyezes> legszennyezesek = new();
            using var sr = new StreamReader(
                path: @"..\..\..\src\SO2.txt",
                encoding: System.Text.Encoding.UTF8
                );

            while ( !sr.EndOfStream )
            {
                legszennyezesek.Add(new Legszennyezes(sr.ReadLine()));
            }

            foreach (var item in legszennyezesek)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n3.feladat");
            harmas(legszennyezesek);

            Console.WriteLine("\n4.feladat");
            Console.WriteLine(negyes(legszennyezesek));

            Console.WriteLine("\n5.feladat");
            Console.WriteLine(db(legszennyezesek));

            Console.WriteLine("\n6.feladat");
            Console.WriteLine(atlag(legszennyezesek));

            Console.WriteLine("\n7.feladat");
            hetes(legszennyezesek);
        }

        static void harmas(List<Legszennyezes> szenny)
        {
            using (var sw = new StreamWriter(
                path: @"..\..\..\src\harmas.txt"
                ))
            {
                for (int i = 0;  i < szenny.Count;  i++)
                {
                    for (int j = 0; j < szenny[i].Ora.Count; j++)
                    {
                        if (250 < szenny[i].Ora[j])
                        {
                            sw.WriteLine($"március {i+1}");
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("kész");
        }

        static string negyes(List<Legszennyezes> szenny)
        {
            int max = 0;
            int nap = 0;
            int ora = 0;
            foreach (var item in szenny)
            {
                for(int i = 0;i < item.Ora.Count; i++)
                {
                    if (max < item.Ora[i])
                    {
                        max = item.Ora[i];
                    }
                }
            }


            for (int i = 0; i < szenny.Count; i++)
            {
                if (szenny[i].Ora.Contains(max) && nap == 0)
                {
                    nap = i+1;
                    
                    for (int j = 0; j < szenny[i].Ora.Count; j++)
                    {
                        if (max == szenny[i].Ora[j])
                        {
                            ora = j+1;
                        }
                    }
                }
            }


            return $"nap: {nap}, óra: {ora}";
        }

        static int db(List<Legszennyezes> szenny)
        {
            int db = 0;
            foreach (var item in szenny)
            {
                for (int i = 0; i < item.Ora.Count; i++)
                {
                    if (item.Ora[i] < 100)
                    {
                        db++;
                    }
                }
            }
            return db ;
        }

        static double atlag(List<Legszennyezes> szenny)
        {
            double atlag = 0;
            foreach (var item in szenny)
            {
                atlag += item.Ora.Sum();
            }

            return Math.Round(atlag / (30*24), 4);
        }


        static void hetes(List<Legszennyezes> szenny)
        {
            int nap = 0;
            int szam = 0;
            bool vmi = false;
            for (int i = 0; i < szenny.Count; i++)
            {
                szam = szenny[i].Ora.Max();
                if (szam < 60)
                {
                    nap = i;
                    vmi = true;
                    break;
                }
                szam = 0;
            }

            if (vmi == true)
            {
                Console.WriteLine($"{nap +1}. napon 60 alatt volt ment");
            }
            else
            {
                Console.WriteLine("nincs ilyen");
            }

        }

    }
}
