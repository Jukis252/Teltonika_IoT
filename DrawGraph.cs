using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Teltonika
{
    public static class DrawGraph
    {
        public static void DrawGraphOfSpeed(Dictionary<int,int> Map) //output custom graph to screen in console
        {
            int a = 0;
            int b = 9;
            Console.WriteLine("------------Graph of speed data------------");
            for (int i = 0; i < Map.Count; i++)
            {
                if (Map[i] > 0 && Map[i] < 1000)
                {
                    Console.WriteLine(a+" - "+b+" "+" |                       "+Map[i]+" "+"hits");
                }
                else if (Map[i] > 1000 && Map[i] < 2000)
                {
                    Console.WriteLine(a+" - "+b+" "+" | |                    "+Map[i]+" "+"hits");
                }
                else if (Map[i] > 2000 && Map[i] < 3000)
                {
                    Console.WriteLine(a+" - "+b+" "+"   | | |                  "+Map[i]+" "+"hits");
                }
                else if (Map[i] > 3000 && Map[i] < 4000)
                {
                    Console.WriteLine(a+" - "+b+" "+"   | | | |                "+Map[i]+" "+"hits");
                }
                else if (Map[i] > 4000 && Map[i] < 5000)
                {
                    Console.WriteLine(a+" - "+b+" "+"| | | | | "+Map[i]+" "+"hits");
                }
                else if (Map[i] > 5000 && Map[i] < 6000)
                {
                    Console.WriteLine(a+" - "+b+" "+"   | | | | | |            "+Map[i]+" "+"hits");
                }
                else if (Map[i] > 6000 && Map[i] < 7000)
                {
                    Console.WriteLine(a+" - "+b+" "+"   | | | | | | |"+Map[i]+" "+"hits");
                }
                else if (Map[i] > 7000 && Map[i] < 8000)
                {
                    Console.WriteLine(a+" - "+b+" "+"   | | | | | | | |        "+Map[i]+" "+"hits");
                }
                else if (Map[i] > 8000 && Map[i] < 9000)
                {
                    Console.WriteLine(a+" - "+b+" "+"   | | | | | | | | |      "+Map[i]+" "+"hits");
                }
                else if (Map[i] > 9000 && Map[i] < 10000)
                {
                    Console.WriteLine(a+" - "+b+" "+"| | | | | | | | | |"+Map[i]+" "+"hits");
                }
                else if (Map[i] > 10000 && Map[i] < 11000)
                {
                    Console.WriteLine(a+" - "+b+" "+"     | | | | | | | | | | | "+Map[i]+" "+"hits");
                }
                a += 10;
                b += 10;
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(" ");
        }

        public static void DrawGraphOfSatelites(Dictionary<int, int> Map)//output custom graph to screen in console
        {
            int a=Map.Count;
            int b = 9000;
            char [,] freq = new char[10,a];
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < a; j++)
                {
                    if(Map[j] >= b)
                    {
                        freq[i,j]='*';
                    }
                    else
                    {
                        freq[i,j]=' ';
                    }
                }
                b-=1000;
            }
            Console.WriteLine("--------------------------------Satelites---------------------------");
            b=9000;
            for(int i = 0; i < 10; i++)
            {
                Console.Write(b+"    ");
                for(int j = 0; j < a; j++)
                {
                    Console.Write(freq[i,j]+"  ");
                }
                b-=1000;
                Console.WriteLine();
                if(i == 9)
                {
                    Console.WriteLine("     0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20");
                }
            }
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
