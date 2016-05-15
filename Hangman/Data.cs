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
            encDecr e = new encDecr();
            this.category = category;
            string path = "";
            if (category.Equals("Animals"))
            {
                string inp = @"../../Resources/animalsenc.txt";
                path = @"../../Resources/animals.txt";
                e.DecryptFile(inp, path);
            }
            else if (category.Equals("Capital cities"))
            {
                string inp = @"../../Resources/citiesenc.txt";
                path = @"../../Resources/cities.txt";
                e.DecryptFile(inp, path);
            }
            else if (category.Equals("FINKI"))
            {
                string inp = @"../../Resources/finkienc.txt";
                path = @"../../Resources/finki.txt";
                e.DecryptFile(inp, path);
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
                else if (category.Equals("Capital cities"))
                {
                    cities.Add(lines);
                }
                else if (category.Equals("FINKI"))
                {
                    finki.Add(lines);
                }

            }
            if (category.Equals("Animals"))
            {
                string inp = @"../../Resources/animals.txt";
                file.Close();
                File.Delete(inp);
            }
            else if (category.Equals("Capital cities"))
            {
                string inp = @"../../Resources/cities.txt";
                file.Close();
                File.Delete(inp);
            }
            else if (category.Equals("FINKI"))
            {
                string inp = @"../../Resources/finki.txt";
                file.Close();
                File.Delete(inp);
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
            else if (category.Equals("Capital cities"))
            {
                lista = cities;
            }
            else if (category.Equals("FINKI"))
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
