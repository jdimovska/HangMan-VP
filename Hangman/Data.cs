using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Data
    {
        List<String> cities = new List<String>();
        List<String> finki = new List<String>();
        List<String> animals = new List<String>();
        string category;

        public Data(string category)
        {
            this.category = category;
            string path = "";
            if (category.Equals("Animals"))
            {
                path = @"../../Resources/animals.txt";
            }
            else if (category.Equals("Capital"))
            {
                path = @"../../Resources/cities.txt";
            }
            else if (category.Equals("Finki"))
            {
                path = @"../../Resources/finki.txt";
            }

            StreamReader file;
            string lines;
            file = new StreamReader(path);
            while ((lines = file.ReadLine()) != null)
            {
                if (category.Equals("Animals"))
                {
                    animals.Add(lines);
                }
                else if (category.Equals("Capital"))
                {
                    cities.Add(lines);
                }
                else if (category.Equals("Finki"))
                {
                    finki.Add(lines);
                }

            }
        }
        public string getWord(int value)
        {
            List<String> lista = new List<String>();
            List<String> pom = new List<String>();
            if (category.Equals("Animals"))
            {
                lista = animals;

            }
            else if (category.Equals("Capital"))
            {
                lista = cities;
            }
            else if (category.Equals("Finki"))
            {
                lista = finki;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Length == value)
                {
                    pom.Add(lista[i]);
                }
            }

            Random rand = new Random();
            int num = rand.Next(0, pom.Count);
            return pom[num];
        }



    }
}
