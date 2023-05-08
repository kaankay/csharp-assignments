using System;

namespace UbungsblattVier
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Übung.1-2-3:");
            Console.WriteLine("Bitte geben Sie eine binäre Zahl ein:");
            string first = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie eine weitere binäre Zahl ein:");
            string second = Console.ReadLine();

            string ergebnisAddieren = binaryAdd(first, second);
            string ergebnisMultiplikation = binaryMult(first, second);

            Console.WriteLine("Die Summe der binären Zahlen: " + ergebnisAddieren);
            Console.WriteLine("Die Summe im Dezimalzahlsystem : " + parseBinaryAndDecimal(ergebnisAddieren));
            Console.WriteLine("Die Summe der Multiplikation im Binärzahlsystem :" + ergebnisMultiplikation);
            Console.WriteLine("Die Summe der Multiplikation im Dezimalzahlsystem :" + parseBinaryAndDecimal(ergebnisMultiplikation));


            Console.WriteLine("Übung.4-5-6:");
            Console.WriteLine("Wie viele Zeilen wollen Sie in der Matrix haben?");
            int userInput1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Wie viele Spalten wollen Sie in der Matrix haben?");
            int userInput2 = int.Parse(Console.ReadLine());

            double[,] matrix = createMatrix(userInput1, userInput2); //Übung.4 > diese Funktion stellt eine Matrix her.

            fillRandom(ref matrix); // Übung.5 > diese Funktion füllt die ganze Matrix mit Zahlen als random aus.

            printMatrix(matrix); // Übung.6 > diese Funktion zeigt die Matrix in der Console.


        }
        static string binaryAdd(string first, string second)
        {
            int zahllaenge = Math.Max(first.Length, second.Length); // die längste Zahlt wird bestimmt.
            first = first.PadLeft(zahllaenge, '0'); //  Die übliche Ziffern werden mit '0' gefüllt.
            second = second.PadLeft(zahllaenge, '0'); // Die übliche Ziffern werden mit '0' gefüllt.

            int rest = 0;
            string summe = "";

            for (int i = zahllaenge - 1; i >= 0; i--)   // "111"    i=3-1; i>=0; i--  
            {
                int ersteZahl = int.Parse(first[i].ToString()); //"1"
                int zweiteZahl = int.Parse(second[i].ToString()); //"1"

                summe = ((ersteZahl + zweiteZahl + rest) % 2) + summe; //"0"
                rest = (ersteZahl + zweiteZahl + rest) / 2; // 1
            }

            if (rest != 0)
            {
                summe = rest + summe;
            }


            return summe;
        }
        static string parseBinaryAndDecimal(string binary)
        {
            double result = 0;
            int power = 0;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                result = (int.Parse(binary[i].ToString()) * Math.Pow(2, power)) + result; // quadrieren
                power++;    // quadrieren nimmt zu.
            }

            return result.ToString();

        }
        static string binaryMult(string first, string second)
        {
            string ergebnis = "0";
            int Null = 0;
            for (int i = second.Length - 1; i >= 0; i--)
            {
                int multiplikator = int.Parse(second[i].ToString());

                string zwischenErgebnis = "";
                for (int k = first.Length - 1; k >= 0; k--)
                {
                    int multiplikand = int.Parse(first[k].ToString());
                    zwischenErgebnis = (multiplikator * multiplikand) + zwischenErgebnis;
                }

                zwischenErgebnis = zwischenErgebnis + new String('0', Null);
                ergebnis = binaryAdd(ergebnis, zwischenErgebnis);

                Null++;
            }

            return ergebnis;

        }


        static double[,] createMatrix(int lines, int columns)
        {
            double[,] ergebnis = new double[lines, columns];

            return ergebnis;

        }
        static void fillRandom(ref double[,] matrix, int lowerRange = -10, int maxRange = 10)
        {
            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    int zufaelligeZahl = random.Next(lowerRange, maxRange);

                    matrix[i, k] = zufaelligeZahl;

                }

            }

        }
        static void printMatrix(double[,] mustafasMatrix)
        {
            for (int i = 0; i < mustafasMatrix.GetLength(0); i++)
            {

                for (int k = 0; k < mustafasMatrix.GetLength(1); k++)
                {
                    Console.Write(mustafasMatrix[i, k].ToString().PadLeft(5));

                }

                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------");
        }


        static void Übung_7()
        {
            Console.WriteLine("Übung.7:");
            Console.WriteLine("Wie viele Zeilen wollen Sie in der Matrix haben?");
            int userInput1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Wie viele Spalten wollen Sie in der Matrix haben?");
            int userInput2 = int.Parse(Console.ReadLine());


            double[,] determinantematrix = createMatrix(userInput1, userInput2);

            fillRandom(ref determinantematrix);



            if (isQuadratical(determinantematrix))
            {
                Console.WriteLine("Diese Matrix ist eine quadratische Matrix!");

                double ergebnisDeterminante = calculateDet(determinantematrix);

                printMatrix(determinantematrix);

                Console.WriteLine("Das Ergebnis der Determinantenberechnung der Matrix= " + ergebnisDeterminante);

                // printMatrix(otherMatrix(determinantematrix, 2, 3));

            }
            else
            {
                Console.WriteLine("Diese Matrix ist keine quadratische Matrix, deshalb kann die Determinante leider nicht berechnet werden. ");
            }

        }
        static bool isQuadratical(double[,] quadratisch)
        {
            if (quadratisch.GetLength(0) == quadratisch.GetLength(1))
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        static double calculateDet(double[,] m)
        {

            if (m.GetLength(0) == 2 && m.GetLength(1) == 2)
            {
                return (m[0, 0] * m[1, 1]) - (m[1, 0] * m[0, 1]);

            }
            else if (m.GetLength(0) == 3 && m.GetLength(1) == 3)
            {

                return ((m[0, 0] * m[1, 1] * m[2, 2]) +
                           (m[0, 1] * m[1, 2] * m[2, 0]) +
                           (m[0, 2] * m[1, 0] * m[2, 1]))
                               -
                         ((m[2, 0] * m[1, 1] * m[0, 2]) +
                           (m[2, 1] * m[1, 2] * m[0, 0]) +
                           (m[2, 2] * m[1, 0] * m[0, 1]));
            }
            else
            {
                double ergebnis = 0;
                for (int k = 0; k < m.GetLength(0); k++)
                {

                    ergebnis += m[0, k] * Math.Pow(-1, k) * calculateDet(otherMatrix(m, 0, k));

                }

                return ergebnis;
            }

        }
        static double[,] otherMatrix(double[,] m, int zeile, int spalte)
        {
            int neudimension = (m.GetLength(0) - 1);

            double[,] neuMatrix = createMatrix(neudimension, neudimension);

            for (int i = 0; i < neuMatrix.GetLength(0); i++)
            {
                int satir = (i >= zeile) ? i + 1 : i;

                for (int k = 0; k < neuMatrix.GetLength(1); k++)
                {
                    int sutun = (k >= spalte) ? k + 1 : k;

                    neuMatrix[i, k] = m[satir, sutun];
                }

            }

            return neuMatrix;

        }


        static void Übung_8()
        {
            Console.WriteLine("Bitte geben Sie erste Matrix ein.(z.B. zahl , zahl)");
            string Text = Console.ReadLine(); // "5,3"
            string[] veriDizisi = Text.Split(','); // [5 , 3]

            int userInput1 = int.Parse(veriDizisi[0]);
            int userInput2 = int.Parse(veriDizisi[1]);

            Console.WriteLine("Bitte geben Sie zweite Matrix ein.(z.B. zahl , zahl)");
            string Text2 = Console.ReadLine(); // "5,3"
            string[] veriDizisi2 = Text2.Split(','); // [5 , 3]

            int userInput3 = int.Parse(veriDizisi2[0]);
            int userInput4 = int.Parse(veriDizisi2[1]);

            //int userInput1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("Wie viele Spalten wollen Sie in der Matrix haben?");
            //int userInput2 = int.Parse(Console.ReadLine());

            //double[,]ersteMatrix = createMatrix(userInput1, userInput2);
            //double[,] zweiteMatrix = createMatrix(userInput1, userInput2);

            double[,] ersteMatrix = createMatrix(userInput1, userInput2);
            double[,] zweiteMatrix = createMatrix(userInput3, userInput4);

            fillRandom(ref ersteMatrix);
            fillRandom(ref zweiteMatrix);

            bool addierbar = sindMatrixenAddierbar(ersteMatrix, zweiteMatrix);

            if (addierbar)
            {
                double[,] summe = addMatrix(ersteMatrix, zweiteMatrix);
                Console.WriteLine("Erste Matrix: ");
                printMatrix(ersteMatrix);
                Console.WriteLine("Zweite Matrix: ");
                printMatrix(zweiteMatrix);
                Console.WriteLine("Die Summe von Matrixen: ");
                printMatrix(summe);

            }
            else
            {
                Console.WriteLine("Diese zweien Matrixen sind nicht addierbar!!");
            }

            Console.WriteLine("<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>");

            if (sindMatrixenMultiplierbar(ersteMatrix, zweiteMatrix))
            {
                double[,] summe_mult = multMatrix(ersteMatrix, zweiteMatrix);
                Console.WriteLine("Erste Matrix: ");
                printMatrix(ersteMatrix);
                Console.WriteLine("Zweite Matrix: ");
                printMatrix(zweiteMatrix);
                Console.WriteLine("Die Multiplikation von Matrixen: ");
                printMatrix(summe_mult);

            }
            else
            {
                Console.WriteLine("Diese zweien Matrixen sind nicht multiplierbar!!");
            }


        }
        static bool sindMatrixenAddierbar(double[,] m, double[,] n)
        {

            if (m.GetLength(0) != n.GetLength(0) || m.GetLength(1) != n.GetLength(1))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        static double[,] addMatrix(double[,] m, double[,] n)
        {

            double[,] summeDerMatrixen = createMatrix(m.GetLength(0), m.GetLength(1));


            for (int i = 0; i < m.GetLength(0); i++)
            {

                for (int k = 0; k < n.GetLength(1); k++)
                {
                    summeDerMatrixen[i, k] = m[i, k] + n[i, k];

                }

            }

            return summeDerMatrixen;

        }
        static bool sindMatrixenMultiplierbar(double[,] m, double[,] n)
        {

            // return (m.GetLength(1) != n.GetLength(0)) ? false : true;

            if (m.GetLength(1) != n.GetLength(0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        static double[,] multMatrix(double[,] a, double[,] b)
        {


            double[,] c = createMatrix(a.GetLength(0), b.GetLength(1));


            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {

                    double zwischenSumme = 0;

                    for (int s = 0; s < a.GetLength(1); s++)
                    {
                        zwischenSumme += a[i, s] * b[s, j];
                    }

                    c[i, j] = zwischenSumme;

                }
            }

            return c;
        }


        static void Übung_9()
        {

            Console.WriteLine("Bitte geben Sie eine Dezimalzahl zwischen 0-10.000.000 ein:");
            double zahl = double.Parse(Console.ReadLine());
            string zahlwort = generateNumeral(zahl);
            Console.WriteLine("Ihre Zahl in Wörtern: " + zahlwort);

        }
        static string generateNumeral(double number)
        {
            string[] zahlen1 = new string[] { "","ein", "zwei", "drei", "vier", "fünf",
                                        "sechs", "sieben", "acht", "neun", "zehn","elf",
                                        "zwölf", "dreizehn","vierzehn","fünfzehn","sechszehn",
                                        "siebzehn","achtzehn","neunzehn" };

            string[] zahlen2 = new string[] { "", "", "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig", "achtzig", "neunzig" };

            string[] zahlen3 = new string[] { "", "", "tausend", "million", };

            string zahlwort = number.ToString(); // "159"  "1234"
            double teilunginDrei = Math.Ceiling(zahlwort.Length / 3.0);
            zahlwort = zahlwort.PadLeft(Convert.ToInt32((teilunginDrei) * 3), '0');

            //Console.WriteLine(teilunginDrei);
            //Console.WriteLine( Math.Ceiling(teilunginDrei) );
            //Console.WriteLine(zahlwort);

            string ihreZahl = "";
            for (int i = 0; (i * 3) < zahlwort.Length; i++)
            {
                string kolon = zahlwort.Substring(i * 3, 3); // 0-3, 3-3
                Console.WriteLine(kolon);

                if (kolon[0] != '0') // "7xx"  "0xx"
                {
                    ihreZahl += zahlen1[Convert.ToInt32(kolon[0].ToString())] + "hundert";
                }

                int sonikibasamak = int.Parse(kolon.Substring(1, 2));
                if (sonikibasamak < 20)
                {
                    if (sonikibasamak == 1)
                    {
                        ihreZahl += "eins";
                    }
                    else
                    {
                        ihreZahl += zahlen1[sonikibasamak];
                    }

                }
                else
                {
                    if (kolon[2] != '0') // "153"einhundert'dreiund'fünfzig   "150"einhundertfünfzig
                    {
                        ihreZahl += zahlen1[Convert.ToInt32(kolon[2].ToString())] + "und";
                    }

                    ihreZahl += zahlen2[Convert.ToInt32(kolon[1].ToString())];
                }


                if (kolon != "000")
                {
                    ihreZahl += zahlen3[(Convert.ToInt32(teilunginDrei)) - i];
                }

            }

            return ihreZahl;


        }
    }
}
