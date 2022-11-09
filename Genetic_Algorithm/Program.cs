using Genetic_Algorithm.Animals;
using System.Collections;
using System.Collections.Generic;

namespace Generetic_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczebność populacji");
            string abundance = Console.ReadLine();
            int abundance_int = Int32.Parse(abundance);
            List < Rabbit > population = new List<Rabbit>();
            for (int i = 0; i < abundance_int; i++)
            {
                Rabbit t = new Rabbit();
                population.Add(t.born_start_Rabbit(t));
            }
            Console.WriteLine("Pomyślnie utworzyłeś populację królików liczącą: " + abundance_int + " sztuk");
            bool ping = true;
            while (ping == true)
            {
                Console.WriteLine("Dostępne komendy: Wyswietl, NextCykl, Reset, Koniec");
                string command = Console.ReadLine();                           
                switch (command)
                {                   
                    case "Wyswietl":
                        for (int i = 0; i < population.Count; i++)
                        {
                            Console.Write(+i+1+" ");
                            population[i].show_info_about_Rabbit(population[i]);                           
                        }
                        break;
                    case "NextCykl":
                        break;
                    case "Reset":
                        break;
                    case "Koniec":
                        ping = false;
                        break;
                }


            }

        }
    }
}