using System;

namespace Nibble
{
    class Program
    {
        class nibbles
        {
            private int[] bit = new int[4];
            bool fehler = false;

            private void res()
            {
                int i; for (i = 0; i <= 3; i++)
                    bit[i] = 0;
            }
            private bool check()
            {
                int i; for (i = 0; i <= 3; i++)
                    if (bit[i] != 1 && bit[i] != 0)
                        return false;
                return true;
            }
            private int nibtoint()
            {
                int i, erg = 0, p = 8;
                for (i = 0; i <= 3; i++)
                {
                    erg = erg + bit[i] * p; p /= 2;
                }
                return erg;
            }
            public nibbles()
            {
                for (int i = 0; i <= 3; i++)
                    bit[i] = 0;
            }
            public nibbles(string s)
            {
                for (int i = 0; i <= 3; i++)
                {
                    bit[i] = s[i] - 48;
                    if (check() == false)
                    {
                        Console.WriteLine("Fehler");
                        res();
                    }
                }
            }
            public nibbles(int a)
            {
                int i, p = 8;
                res();
                if (a <= 15 && a >= 0)
                {
                    for (i = 0; i <= 3; i++)
                    {
                        if (a >= p)
                        { bit[i] = 1; a = a - p; }
                        p = p / 2;
                    }
                }
            }

            public nibbles(char c)

            {
                int a = 0;
                if (c == 'F' || c == 'f')
                    a = 15;
                if (c == 'E' || c == 'e')
                    a = 14;
                if (c == 'D' || c == 'd')
                    a = 13;
                if (c == 'C' || c == 'c')
                    a = 12;
                if (c == 'B' || c == 'b')
                    a = 11;
                if (c == 'A' || c == 'a')
                    a = 10;

                int i, p = 8;
                res();
                if (a <= 15 && a >= 0)
                {
                    for (i = 0; i <= 3; i++)
                    {
                        if (a >= p)
                        { bit[i] = 1; a = a - p; }
                        p = p / 2;
                    }
                }
            }
            public void ausgabe()
            {
                if (fehler == true)
                {
                    Console.WriteLine("Es ist ein Fehler aufgetreten. ");
                }
                else
                {
                    Console.WriteLine("Der Nibble hat den Wert" + bit[0] + bit[1] + bit[2] + bit[3]);
                }
            }


            public static nibbles operator +(nibbles b1, nibbles b2)
            {
                int hilf, i, t = 8;
                nibbles erg = new nibbles();
                hilf = b1.nibtoint() + b2.nibtoint();
                if (hilf > 15) hilf -= 16; for (i = 0; i <= 3; i++)
                {
                    if (hilf >= t)
                    {
                        erg.bit[i] = 1;
                        hilf = hilf - t;
                    }
                    t = t / 2;
                }
                return erg;
            }

            public static bool operator <(nibbles t1, nibbles t2)
            {
                if (t1.nibtoint() < t2.nibtoint()) return true;
                return false;
            }
            public static bool operator <=(nibbles t1, nibbles t2)
            {
                if (t1.nibtoint() <= t2.nibtoint()) return true;
                return false;
            }

            public static bool operator >(nibbles t1, nibbles t2)
            {
                if (t1.nibtoint() > t2.nibtoint()) return true;
                return false;
            }

            public static bool operator >=(nibbles t1, nibbles t2)
            {
                if (t1.nibtoint() >= t2.nibtoint()) return true;
                return false;
            }

            public static nibbles operator &(nibbles b1, nibbles b2)
            {
                nibbles erg = new nibbles();
                for (int i = 0; i <= 3; i++)
                    erg.bit[i] = b1.bit[i] & b2.bit[i];
                return erg;
            }
            public static nibbles operator >>(nibbles t1, int a)
            {
                int speicher;
                for (int x = 0; x < a; x++)
                {
                    speicher = t1.bit[0];
                    for (int i = 0; i <= 2; i++)
                        t1.bit[i] = t1.bit[i + 1];
                    t1.bit[3] = speicher;
                }
                return t1;
            }
            public static nibbles operator ++(nibbles b1)
            {
                nibbles bit1 = new nibbles();
                int a = b1.nibtoint() + 1, p = 8;


                if (a > 15) a -= 16;
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        if (a >= p)
                        { bit1.bit[i] = 1; a = a - p; }
                        p = p / 2;
                    }
                }

                return (bit1);
            }

        }
        static void Main(string[] args)
        {
            nibbles n1 = new nibbles();
            n1.ausgabe();
            nibbles n2 = new nibbles("0101");
            n2.ausgabe();
            nibbles n3 = new nibbles("0120");
            n3.ausgabe();
            nibbles n4 = new nibbles(13);
            n4.ausgabe();
            nibbles n5 = new nibbles('d');
            n5.ausgabe();
            nibbles n6 = new nibbles("0010");
            (n2 + n6).ausgabe();
            if (n2 > n6) Console.WriteLine("n2 ist größer n6");
            if (n2 < n6) Console.WriteLine("n2 ist kleiner n6");
            (++n2).ausgabe();
            (n2++).ausgabe();
            n2.ausgabe();
            nibbles n7 = new nibbles("1010");
            nibbles n8 = new nibbles("0111");
            n1 = n7 & n8;
            n1.ausgabe();
            (n1 >> 2).ausgabe();
        }
    }
}
