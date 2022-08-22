using System;

namespace Tribe_Game
{
     
    class Program
    {
        static void Main(string[] args)
        {
            int Size_World = 20; 
            //Rozmiar świata
            int Percent_Forest = 30;
            //Procent powierzchni zajętej przez lasy
            int Density_Forest = 8;
            //Gęstość zalesienia w skali 0-10 
            int Percent_Water =10;
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
            Generate_Forests(Size_World,Percent_Forest, Density_Forest);  //Generowanie lasów
            Generate_Waters(Size_World, Percent_Water); // Generowanie wody
        }

        public void Generate_Forests (int Size_World,int Percent_Forest,int Density_Forest)   //Funkcja generująca lasy
        {
            int Number_Forests = (Size_World * Size_World) * Percent_Forest/100/25;  //Ile powstanie lasów skupionych            
            for (int i = 0; i < Number_Forests; i++)
            {
                int x = Random_Generator(Size_World);
                int y = Random_Generator(Size_World);
                board[x, y].type = 1;
                int Forest_Range = Random_Generator(6);
                for (int k = 0; k < Forest_Range*2; k++)
                {
                    for (int l = 0; l < Forest_Range*2; l++)
                    {
                        if (Cellule_Check(x - Forest_Range + k, y - Forest_Range + l,Size_World) && (Random_Generator(10) < Density_Forest))
                        {
                            board[x - Forest_Range + k, y - Forest_Range + l].type = 1;
                        }                           
                    }
                }
            }                                                                                                                               
        }

        public void Generate_Waters(int Size_World, int Percent_Water) //Funkcja genegująca jeziora i rzeki
        {
            int Range_River = ((Size_World * Size_World) * Percent_Water/100)/Size_World; //Ilość obiektów wodnych
            Console.WriteLine(Range_River);
            for (int i = 0; i < Range_River; i++)
            {
                int x = Random_Generator(Size_World);
                int y = Random_Generator(Size_World);
                board[x, y].type = 2;
                int shot = Random_Generator(3);
                if (shot<1) //Generowanie jeziora
                {
                    int Lake = Random_Generator((Size_World/10)+1);
                    for (int k = 0; k < Lake*2; k++)
                    {
                        for (int l = 0; l < Lake*2; l++)
                        {
                            if (Cellule_Check(x - Lake + k, y - Lake + l, Size_World))
                            {
                                board[x - Lake + k, y - Lake + l].type = 2;
                            }
                        }
                    }
                }
                else // Generowanie rzeki 
                {
                    int Lake_Range = Size_World;  // Długość całej rzeki
                    int Points_intersection = Lake_Range/(Random_Generator(Size_World/4)+3);  // Ilość punktów złamania
                    int Range_bPoints = Lake_Range / (Points_intersection+1); // Długość pomiędzy punktami 
                    for (int m = 0; m < Points_intersection; m++)
                    {
                        int x_vector = Random_Generator(2) - 1;
                        int y_vector = Random_Generator(2) - 1;
                        for (int n = 0; n < Range_bPoints; n++)
                        {
                            if (Cellule_Check(x + x_vector, y + y_vector, Size_World))
                            {
                                board[x+x_vector,y+y_vector].type = 2;
                                x = x + x_vector;
                                y = y + y_vector;


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
        public bool Cellule_Check(int x,int y,int Size_World) //Funkcja sprawdzająca czy wybrana komórka nie leży poza światem
        {
            if(x >= 0 && x < Size_World)
            {
                if (y >= 0 && y < Size_World)
                {
                    return true;                   
                }               
            }
            return false;
        }
        public int Random_Generator(int Compartment)  // Funkcja losująca liczbę pseudolosową z podanego przedziału
        {
            Random generator = new Random();
            int x = generator.Next(Compartment);
            return x;
        }              
    }



    
}
