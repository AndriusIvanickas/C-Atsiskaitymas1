using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kiekis = 0;
            int kiekis1 = 0;
            int kiekisbraukt = 0;
            int[,] pazymiai = { {10,0,8,8},
                                {10,10,10,10 },
                                {4,0,0, 3 },
                                {10,10,10,10 },
                                {9,0,9, 9 },
                                {8,8,8,8},
                                {5,0,0,3 } };
            double[] studentovidurkis = new double[pazymiai.GetLength(0)];
            double[] vidurkis = KiekivienoStudentoVidurkis(pazymiai);
            SpausdintiMasyva(pazymiai, studentovidurkis);
            Console.WriteLine();
            Console.Write("i egzamina bent viena karta neatvyko " + KiekNeatvyko(pazymiai, kiekis) + " studentas/ai");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("is viso nebuvo islaikyti " + kiekNeislaikyta(pazymiai, kiekis1) + " egzaminai");
            Console.WriteLine();
            KiekvienasNeislaike(pazymiai);
            Console.WriteLine();
            SpausdintiMasyva(pazymiai, vidurkis);
            double geriausias = GeriausiasVidurkis(vidurkis);
            SpausdintiGeriausius(geriausias);
            BendrasVidurkis(vidurkis);
            Console.WriteLine("Siuloma isbraukti " + SiulomaIsbraukti(vidurkis, kiekisbraukt) + " studentus");





            Console.ReadKey();

        }


        static void SpausdintiMatrica(int[,] pazymiai)
        {
            for (int i = 0; i < pazymiai.GetLength(0); i++)
            {
                for (int j = 0; j < pazymiai.GetLength(1); j++)
                {
                    Console.WriteLine(pazymiai[i, j]);
                }
            }
        }

        static void SpausdintiMasyva(int[,] pazymiai, double[] studentovidurkis)
        {
            Console.WriteLine("|----------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("| Nr. |        Egz1       |" + "      Egz2             |" + "     Egz3              |" + "        Egz4           |" + "Vidurkis|");

            Console.WriteLine("|----------------------------------------------------------------------------------------------------------|");
            for (int i = 0; i < pazymiai.GetLength(0); i++)
            {
                int vieta = 1 + i;
                Console.Write("| " + vieta);
                for (int j = 0; j < pazymiai.GetLength(1); j++)
                {
                    switch (pazymiai[i, j])
                    {
                        case 0:
                            Console.Write("       " + pazymiai[i, j] + "  " + Pazymys.neatvyko + "     |");

                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            Console.Write("       " + pazymiai[i, j] + "  " + Pazymys.nepatenkinama + "|");

                            break;
                        case 5:
                            Console.Write("       " + pazymiai[i, j] + "  " + Pazymys.silpnai + "      |");

                            break;
                        case 6:
                        case 7:
                            Console.Write("       " + pazymiai[i, j] + "  " + Pazymys.patenkinamai + "|");

                            break;
                        case 8:
                            Console.Write("       " + pazymiai[i, j] + "  " + Pazymys.gerai + "        |");
                            break;
                        case 9:
                            Console.Write("       " + pazymiai[i, j] + "  " + Pazymys.l_gerai + "      |");
                            break;
                        case 10:
                            Console.Write("       " + pazymiai[i, j] + "  " + Pazymys.Puikiai + "     |");
                            break;
                    }


                }


                Console.Write("   " + Math.Round(studentovidurkis[i], 2) + "    |");


                Console.WriteLine();

            }
            Console.WriteLine("|----------------------------------------------------------------------------------------------------------|");
        }

        static int KiekNeatvyko(int[,] pazymiai, int kiekis)
        {
            for (int i = 0; i < pazymiai.GetLength(0); i++)
            {

                for (int j = 0; j < pazymiai.GetLength(1); j++)
                {
                    if (pazymiai[i, j] == 0 & i != j)
                    {

                        kiekis++;
                        break;
                    }

                }

            }
            return kiekis;
        }
        static void KiekvienasNeislaike(int[,] pazymiai)
        {
            for (int i = 0; i < pazymiai.GetLength(0); i++)
            {
                int kiekis = 0;
                int vieta = 1 + i;
                for (int j = 0; j < pazymiai.GetLength(1); j++)
                {
                    if (pazymiai[i, j] > 0 && pazymiai[i, j] < 5)
                    {


                        kiekis++;
                    }



                }

                Console.WriteLine(vieta + " studentas neislaike " + kiekis + " egzaminu");

            }

        }
        static int kiekNeislaikyta(int[,] pazymiai, int kiekis1)
        {
            for (int i = 0; i < pazymiai.GetLength(1); i++)
            {


                for (int j = 0; j < pazymiai.GetLength(0); j++)
                {
                    if (pazymiai[j, i] > 0 && pazymiai[j, i] < 5)
                    {


                        kiekis1++;
                    }



                }

            }
            return kiekis1;
        }
        static double[] KiekivienoStudentoVidurkis(int[,] pazymiai)
        {
            double[] vidurkisMasyvas = new double[pazymiai.GetLength(0)];
            double vidurkis;
            for (int i = 0; i < pazymiai.GetLength(0); i++)
            {

                double suma = 0;
                double kiekis5 = 0;
                for (int j = 0; j < pazymiai.GetLength(1); j++)
                {
                    if (pazymiai[i, j] == 0)
                    {

                    }
                    else
                    {
                        suma = suma + pazymiai[i, j];
                        kiekis5++;
                    }
                }
                vidurkis = (double)suma / kiekis5;
                vidurkisMasyvas[i] = vidurkis;

            }
            return vidurkisMasyvas;
        }
        static double GeriausiasVidurkis(double[] vidurkis)
        {

            double max = vidurkis.Max();
            return max;
        }
        static void SpausdintiGeriausius(double geriausias)
        {
            Console.WriteLine("Geriausi studentai");
            Console.WriteLine("|--------------------------|");
            Console.WriteLine("| Geriausi stud. | Vidurkis|");
            Console.WriteLine("|--------------------------|");
            Console.WriteLine("|       " + 1 + "        |    " + geriausias + "   |");
            Console.WriteLine("|--------------------------|");
        }
        static void BendrasVidurkis(double[] vidurkis)
        {
            double suma = 0;
            Console.Write("Bendras grupes vidurkis: ");
            for (int i = 0; i < vidurkis.Length; i++)
            {
                suma += vidurkis[i];
            }
            suma = suma / vidurkis.Length;
            Console.WriteLine(Math.Round(suma, 2));
        }

        static int SiulomaIsbraukti(double[] vidurkis, int kiekisbraukt)
        {
            for (int i = 0; i < vidurkis.GetLength(0); i++)
            {

                if (vidurkis[i] <= 4)
                {
                    kiekisbraukt++;
                }



            }
            return kiekisbraukt;
        }
        enum Pazymys
        {
            Puikiai,
            l_gerai,
            gerai,
            vidutiniskai,
            patenkinamai,
            silpnai,
            nepatenkinama,
            neatvyko

        }
    }
}

