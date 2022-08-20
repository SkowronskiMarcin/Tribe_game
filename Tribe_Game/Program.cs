using System;

namespace Tribe_Game
{
     
    class Program
    {
        static void Main(string[] args)
        {
            int Size_World = 50; 
            //Rozmiar świata
            int Percent_Forest = 40;
            //Procent powierzchni zajętej przez lasy
            int Density_Forest = 9;
            //Gęstość zalesienia w skali 0-10 
            int Percent_Water = 5;
            //Procent powierzchni zajątej przez wode
            
            World mainworld = new World(Size_World, Percent_Forest, Density_Forest, Percent_Water);
            mainworld.Print_World(Size_World);           
        }       
    }
    class Cellule //Klasa komórki na planszy
    {
        public int xPos = 0;
        public int yPos = 0;
        public int type = 0;
        // 0 = łąka  / 1 = las  / 2 = woda
    }

    class World  // Klasa świat
    {
        
        public Cellule[,] board;  //Dane 

        public World(int Size_World,int Percent_Forest,int Density_Forest,int Percent_Water)   //Konstruktor
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
            Generate_Waters(Size_World, Percent_Water);
        }

        public void Generate_Forests (int Size_World,int Percent_Forest,int Density_Forest)   //Funkcja generująca lasy
        {
            int Number_Forests = (Size_World * Size_World) * Percent_Forest/100/25;            
            for (int i = 0; i < Number_Forests; i++)
            {
                int x = Random_Generator(Size_World);
                int y = Random_Generator(Size_World);
                board[x, y].type = 1;
                int Forest_Range = Random_Generator(6);
                for (int k = 0; k < Forest_Range*2; k++)
                {
                    for (int l = 0; l < Forest_Range *2; l++)
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

        public void Generate_Waters(int Size_World, int Percent_Water) //Funkcja genegująca jeziora i rzeki
        {
            int Range_River = (Size_World * Size_World) * Percent_Water / 50 ;           
            //int Size_Lake = Size_World / 10;
            Cellule Start = new Cellule();
            Start.xPos = Random_Generator(Size_World);
            Start.yPos = Random_Generator(Size_World);
            //Console.WriteLine("Współrzędne to [" + Start.xPos + "," + Start.yPos + "]");
            
            board[Start.xPos, Start.yPos].type = 2;

            for (int i = 0; i < Range_River; i++)
            {
                int x = Random_Generator(3) - 1;
                int y = Random_Generator(3) - 1;
                if ((Start.xPos + x) < (Size_World-1) && (Start.yPos + y) < (Size_World - 1))
                {
                    if ((Start.xPos + x) >= 0 && (Start.yPos + y) >= 0)
                    {
                        if (board[Start.xPos + x, Start.yPos + y].type != 2)
                        {
                            board[Start.xPos + x, Start.yPos + y].type = 2;
                            Start.xPos = Start.xPos + x;
                            Start.yPos = Start.yPos + y;
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

        public int Random_Generator(int Compartment)  // Funkcja losująca liczbę pseudolosową z podanego przedziału
        {
            Random generator = new Random();
            int x = generator.Next(Compartment);
            return x;
        }
    }



    
}
