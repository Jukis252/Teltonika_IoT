using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Teltonika
{
    public static class Values
    {
        public static Dictionary<int, int> SatelitesValueCount(List<DataCoordinate> dataCoordinate) // counting quantity of satelites
        {
            int a = 0;
            dataCoordinate.OrderBy(x => x.Satelite); // Sorting before assiging values
            Dictionary<int, int> Map = new Dictionary<int, int>();
            foreach (var item in dataCoordinate)
            {
                if (Map.ContainsKey(item.Satelite))
                {
                    Map[item.Satelite]++;
                }
                else
                {
                    Map.Add(a, item.Satelite);
                    a++;
                }
            }
            return Map;
        }
        public static Dictionary<int,int> SpeedValueCountGrouped(Dictionary<int,int> Map)
        {
            int a=10;
            int b=0;
            int c=0;
            Dictionary<int, int> Values = new Dictionary<int, int>();
            for(int i = 0; i < Map.Count; i++)
            {
                if (i < a)
                {
                    b+=Map[i];
                }
                else
                {
                    Values.Add(c,b);
                    a+=10;
                    b=0;
                    c++;
                }
                if (i == Map.Count - 1)
                {
                    Values.Add(c,b);
                }
            }
            return Values;
        }
        public static Dictionary<int, int> SpeedValueCount(List<DataCoordinate> dataCoordinate)
        {
            int a=0;
            dataCoordinate.OrderBy(x => x.Speed);
            Dictionary<int,int> Map = new Dictionary<int, int>();
            foreach(var item in dataCoordinate)
            {
                if (Map.ContainsKey(item.Speed))
                {
                    Map[item.Speed]++;
                }
                else
                {
                    Map.Add(a,item.Speed);
                    a++;
                }
            }
            return Map;
        }
        public static void OutputSatelites(Dictionary<int, int> FreqMapSatelites)
        {
            FreqMapSatelites.OrderBy(x => x.Value);
            foreach(var pair in FreqMapSatelites)
            {
                int key = pair.Key;
                int value = pair.Value;
                Console.WriteLine(key + " " + value);
            }
        }
        public static void OutputSpeed(Dictionary<int, int> FreqMapSpeed)
        {
            foreach(var pair in FreqMapSpeed)
            {
                int key = pair.Key;
                int value = pair.Value;
                Console.WriteLine(key + " " + value);
            }
        }
    }
}
