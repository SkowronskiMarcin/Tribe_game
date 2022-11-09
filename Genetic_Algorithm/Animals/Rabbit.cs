using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm.Animals
{
    class Rabbit
    {
        public int age = 0; 
        // Startowy wiek = 0
        public int sex { get; set; }  // 0-1
        // 0 = woman
        // 1 = man
        public int max_age { get; set; } // 5-10 
        public int max_energy { get; set; } // 10-20

        public int speed { get; set; } // 0-10
        public int color { get; set; } // 0-4
        // 0 - bonus do polany+1
        // 1 - bonus do lasu +1
        // 2 - brak bonusu
        // 3 - bonus polana + 0,5
        // 4 - bonus las + 0,5

        public int characteristic { get; set; } // 0-3
        // 0 - Łasuch
        // 1 - lovelas
        // 2 - podróżnik
        // 3 - wodnik

        public Rabbit born_start_Rabbit(Rabbit t) //Urodzenie startowego królika bez rodziców
        {           
            Random generator = new Random();
            t.sex = generator.Next(2); //Losowanie puci
            t.max_age = generator.Next(5) + 5;
            t.max_energy = generator.Next(11) + 10;
            t.speed = generator.Next(11);
            t.color = generator.Next(5);
            t.characteristic = generator.Next(4);
            return t;
        }
        public string convert_color_tostring(Rabbit rabbit)
        {
            string[] kolory_królików = {"bonus_polana_+1","bonus_las+1","brak_bonusu", "bonus_polana_+0,5", "bonus_polana_ + 0,5"};
            return kolory_królików[rabbit.color];
        }

        public string convert_charakter_tostring(Rabbit rabbit)
        {
            string[] charaktery_królików = { "Łasuc", "lovelas", "podróżnik", "wodnik"};
            return charaktery_królików[rabbit.characteristic];
        }

        public string convert_sex_tostring(Rabbit rabbit)
        {
            string[] płcie_królików = {"man","woman"};
            if (rabbit.sex==1)
            {
                return płcie_królików[0];
            }
            else
            {
                return płcie_królików[1];
            }
        }

        public void show_info_about_Rabbit(Rabbit rabbit)
        {
            Console.WriteLine(
                "Królik: wiek: "+rabbit.age+
                " max_wiek: "+rabbit.max_age+
                " płeć "+convert_sex_tostring(rabbit)+
                " maksymalna energia "+rabbit.max_energy+
                " Szybkosc: "+rabbit.speed+
                " Kolor: "+convert_color_tostring(rabbit)+
                " Charakter: " + convert_color_tostring(rabbit)+"");
        }
    }
}
