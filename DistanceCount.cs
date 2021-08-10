using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geolocation;

namespace Teltonika
{
    public static class DistanceCount
    {
        public static List<Distance> Count(List<DataCoordinate> dataCoordinate) // count the quantity of distances that go further than 100km
        {
            List<Distance> AllData = new List<Distance>();
            double distance = 0;
            for (int i = 1; i < dataCoordinate.Count; i++) // doesn't matter if its longtitude or latitude, the count is same for both
            {
                for (int j = 0; j < dataCoordinate.Count; j++) // made here j < 1000 for working principals, cause to be correct you should count to Longtitude.Count or Latitude.Count, but then the number are too big and it takes a lot of time.
                {
                    distance = GeoCalculator.GetDistance(dataCoordinate[i - 1].Latitude, dataCoordinate[i - 1].Longtitude, dataCoordinate[j].Latitude, dataCoordinate[j].Longtitude); // calculates in miles
                    distance=distance*1.609344; //conversion to kilometers
                    if (distance >= 100)
                    {
                        AllData.Add(new Distance(distance,dataCoordinate[i-1].Latitude, dataCoordinate[i - 1].Longtitude, dataCoordinate[j].Latitude, dataCoordinate[j].Longtitude,dataCoordinate[i-1].GPSTime,dataCoordinate[j].GPSTime));
                        //Console.WriteLine("works");
                    }
                    else
                    {
                        //Console.WriteLine("doesnt work");
                    }
                }
            }
            return AllData;
        }
        public static List<double> FastestRoad(List<Distance> Count) // counting all possible speeds when distance is over 100km
        {
            List<double> speeds = new List<double>();
            long time;
            double RoadDivededByTime = 0;
            if (Count.Count != 0)
            {
                for (int i = 0; i < Count.Count; i++)
                {
                    time = (Count[i].GPSTimeEnd.Ticks - Count[i].GPSTimeStart.Ticks);
                    time = (long)TimeSpan.FromTicks(time).TotalHours;
                    //Console.WriteLine(time + " " + Count[i].ListOfDistances);
                    if (time > 0)
                    {
                        RoadDivededByTime = (Count[i].ListOfDistances) / time;
                    }
                    //Console.WriteLine(RoadDivededByTime);
                    if (RoadDivededByTime > 0)
                    {
                        speeds.Add(RoadDivededByTime);
                    }
                    else
                    { }

                }
            }
            else
            { }
            return speeds;

        }
        public static int FindFastestRoad(List<double> speeds, List<Distance> count)  // finding the biggest speed in list
        {
            double biggest;
            int index=0;
            if (count.Count != 0)
            {
                biggest = speeds.Max();
                index = speeds.IndexOf(biggest);
            }
            else
            {

            }
            return index;

        }
        public static void OutputFastestRoad(List<Distance> count, int FindFastestRoad, List<double>FastestRoad) //output to console with all necesary information
        {
            List<double> speeds =FastestRoad;
            int index = FindFastestRoad;
            if (count.Count != 0)
            {
                Console.WriteLine("Fastest road section of at least 100km was driven with these coordinates:");
                Console.WriteLine("Start position " + count[index].LatitudeStart + "; " + count[index].LongtitudeStart);
                Console.WriteLine("Start Gps time " + count[index].GPSTimeStart);
                Console.WriteLine("End position " + count[index].LatitudeEnd + "; " + count[index].LongtitudeEnd);
                Console.WriteLine("End Gps time " + count[index].GPSTimeEnd);
                Console.WriteLine("Average speed " + speeds.Max() + " km/h");
            }
            else
            {
                Console.WriteLine("No distances were found");
            }

        }
    }
}
