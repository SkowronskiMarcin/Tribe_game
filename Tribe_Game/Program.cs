using System;

namespace Tribe_Game
{
     
    class Program
    {
        static void Main(string[] args)
        {
            int Size_World = 50; 
            //Rozmiar świata
            int Percent_Forest = 30;
            //Procent powierzchni zajętej przez lasy
            int Density_Forest = 8;
            //Gęstość zalesienia w skali 0-10 
            
            World mainworld = new World(Size_World, Percent_Forest, Density_Forest);
            mainworld.Print_World(Size_World);           
        }       
    }
    class Cellule //Klasa komórki na planszy
    {
        public int xPos;
        public int yPos;
        public int type = 0;
        // 0 = łąka  / 1 = las  / 2 = woda
    }

    class World  // Klasa świat
    {
        
        public Cellule[,] board;  //Dane 

        public World(int Size_World,int Percent_Forest,int Density_Forest)   //Konstruktor
        {
            board = new Cellule[Size_World, Size_World];
            for (int i = 0; i < Size_World; i++)
            {
                for (int j = 0; j < Size_World; j++)
                {
                    board[i, j] = new Cellule();
                    board[i, j].xPos = i;
                    board[i, j].yPos = j;
                }
            }
            Generate_Forests(Size_World,Percent_Forest, Density_Forest);
        }

        public void Generate_Forests (int Size_World,int Percent_Forest,int Density_Forest)   //Funkcja generująca lasy
        {
            int Number_Forests = (Size_World * Size_World) * Percent_Forest/100/25;
            Console.WriteLine(Number_Forests);
            for (int i = 0; i < Number_Forests; i++)
            {
                int x = Random_Generator(Size_World);
                int y = Random_Generator(Size_World);
                board[x, y].type = 1;
                int Forest_Range = Random_Generator(6);
                for (int k = 0; k < Forest_Range*2; k++)
                {
                    for (int l = 0; l < Forest_Range * 2; l++)
                    {
                        if ((x-Forest_Range+k)>=0 && (x-Forest_Range+k)<Size_World && (y-Forest_Range+l)>=0 && (y-Forest_Range+l)<Size_World)
                        {
                            if (Random_Generator(10)<Density_Forest)
                            {
                                board[x - Forest_Range + k, y - Forest_Range + l].type = 1;
                            }
                            
                        }
                    }
                }
            }                                                                                                                               
        }

        public void Print_World(int Size_World)   // Funkcja drukująca świat w konsoli
        {
            for (int i = 0; i < Size_World; i++)
            {
                for (int j = 0; j < Size_World; j++)
                {
                    Console.Write("[" + board[i, j].type + "]");
                    //Console.Write("["+board[i, j].xPos+","+ board[i, j].yPos+"]");
                }
                Console.WriteLine();
            }
        }

        public int Random_Generator(int Compartment)  // Funkcja losująca liczbę pseudolosową
        {
            Random generator = new Random();
            int x = generator.Next(Compartment);
            return x;
        }
    }



    
}
