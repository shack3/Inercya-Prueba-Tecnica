using System;
using System.Collections.Generic;
using System.IO;



namespace _3_Random
{
    class Program
    {
        static void Main(string[] args)
        {

            int N = 100000;
            HashSet<int> randomNumbers = new HashSet<int>();
            Random rand = new Random();
            string output;

            string pwd = System.IO.Directory.GetCurrentDirectory();
            pwd = Path.Combine(pwd, "numerosRandom.txt");


            while (randomNumbers.Count < N)
            {
                randomNumbers.Add(rand.Next(0, 2147483647));
            }


            output = string.Join("\n", randomNumbers);

            File.WriteAllText(pwd, output);

            Console.WriteLine("Archivo guardado en: " + pwd + "\n\nPulse una tecla para salir...");


            Console.ReadKey();
        }
    }
}
