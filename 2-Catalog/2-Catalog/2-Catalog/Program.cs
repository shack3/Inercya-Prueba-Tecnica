﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace _2_Catalog
{
    class Program
    {
        static void Main(string[] args)
        {

            catalog catalogo = new catalog();
            List<category> categoriesList = new List<category>();
            List<product> productsList = new List<product>();
            

            string productspath = @"A:\Documents\0 - GIT\Inercya-Prueba-Tecnica\2-Catalog\Products.csv";
            string categoriespath = @"A:\Documents\0 - GIT\Inercya-Prueba-Tecnica\2-Catalog\Categories.csv";

            string[] productosString = LoadCSV(productspath);
            string[] categoriasString = LoadCSV(categoriespath);

            for(int i = 1; i<categoriasString.Length; i++)
            {
                string[] rawData = categoriasString[i].Split(';');
                category category = new category()
                {
                    ID = Int32.Parse(rawData[0]),
                    NAME = rawData[1],
                    DESCRIPTION = rawData[2]
                };

                categoriesList.Add(category);
            }

            for(int i=1; i<productosString.Length; i++)
            {
                string[] rawData = productosString[i].Split(';');
                product product = new product()
                {
                    ID = Int32.Parse(rawData[0]),
                    CATEGORY = Int32.Parse(rawData[1]),
                    NAME = rawData[2],
                    PRICE = float.Parse(rawData[3], System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
                };

                productsList.Add(product);
            }



            Console.ReadKey();
        }



        private static string[] LoadCSV(string filename)
        {
            // Direccion del CSV.
            string whole_file = System.IO.File.ReadAllText(filename);

            // Dividir en lineas.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            return lines;
        }
    }


    class catalog
    {
        public category[] CATEGORIES { get; set; }
    }

    class category
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }

        public product[] PRODUCTS { get; set; }
    }

    class product
    {
        public int ID { get; set; }
        public int CATEGORY { get; set; }
        public string NAME { get; set; }
        public float PRICE { get; set; }
    }
}