using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Geolocation;


namespace Teltonika
{
    public class Program // main class
    {
        List<DataJSON> listJson;
        List<DataCSV> listCSV;
        public string json;
        List<int> satelites = new List<int>();
        int[] ArrayOfSatelites = new int[21];
        int[] ArrayForSatelitesGraph = new int[21];
        List<int> speed = new List<int>();
        int[] ArrayOfSpeed = new int[200];
        int[] ArrayForSpeedSumGraph = new int [200];
        int[] ArrayOfSpeedSum = new int [19];
        List<double>Latitude = new List<double>();
        List<double> Longitude = new List<double>();
        List<DateTime>GpsTime = new List<DateTime>();
        List<int> Angle = new List<int>();
        List<int> Altitude = new List<int>();
        List<double>ListOfDistances = new List<double>();
        List<double> LatitudeStart = new List<double>();
        List <double> LongtitudeStart = new List<double>();
        List<double> LatitudeEnd = new List<double>();
        List<double> LongtitudeEnd= new List<double>();
        List<DateTime> GPSTimeStart= new List<DateTime>();
        List<DateTime> GPSTimeEnd= new List<DateTime>();
        List<double> ListOfSpeeds =new List<double>();
        long time;
        int index;
        double biggest;
        double RoadDivededByTime;


        private void GetDataJson() //function to get JSON data
        {
            StreamReader ReadJson = new StreamReader("2019-07.json");
            json = ReadJson.ReadToEnd();
        }
        private void DeserializeJsonData() // deserialiazation of Json data
        {
            listJson = JsonConvert.DeserializeObject<List<DataJSON>>(json);
        }
        private void ShowJsonData() // output to console of JSON data
        {
            foreach (var item in listJson)
            {
                Console.WriteLine(item.Latitude + " " + item.Longitude + " " + item.GpsTime + " " + item.Speed + " " + item.Angle + " " + item.Altitude + " " + item.Satellites);
            }
        }
        private void GetDataCSV() // obtaining CSV data
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using var reader = new StreamReader("2019-08.csv");
            using var csv = new CsvReader(reader, config);

            listCSV = csv.GetRecords<DataCSV>().ToList();
        }
        private void ShowDataCSV()// output to console of CSV data
        {
            foreach (var item in listCSV)
            {
                Console.WriteLine(item.Latitude + " " + item.Longitude + " " + item.GpsTime + " " + item.Speed + " " + item.Angle + " " + item.Altitude + " " + item.Satellites);
            }
        }
        private void SatelitesInsertToList() //putting all satelites from both files to one list
        {
            foreach (var item in listCSV)
            {
                satelites.Add(item.Satellites);
            }
            foreach (var item in listJson)
            {
                satelites.Add(item.Satellites);
            }
        }
        private void LongitudeInsertToList() //putting all longtitudes from both files to one list
        {
            foreach (var item in listCSV)
            {
                Longitude.Add(item.Longitude);
            }
            foreach (var item in listJson)
            {
                Longitude.Add(item.Longitude);
            }
        }
        private void GPSInsertToList() //putting all GPS from both files to one list
        {
            foreach (var item in listCSV)
            {
                GpsTime.Add(item.GpsTime);
            }
            foreach (var item in listJson)
            {
                GpsTime.Add(item.GpsTime);
            }
        }
        private void LatitudeInsertToList() //putting all latitudes from both files to one list
        {
            foreach (var item in listCSV)
            {
                Latitude.Add(item.Latitude);
            }
            foreach (var item in listJson)
            {
                Latitude.Add(item.Latitude);
            }
        }
        private void AngleInsertToList() //putting all angles from both files to one list
        {
            foreach (var item in listCSV)
            {
                Angle.Add(item.Angle);
            }
            foreach (var item in listJson)
            {
                Angle.Add(item.Angle);
            }
        }
        private void AltitudeInsertToList() //putting all altitudes from both files to one list
        {
            foreach (var item in listCSV)
            {
                Altitude.Add(item.Altitude);
            }
            foreach (var item in listJson)
            {
                Altitude.Add(item.Altitude);
            }
        }
        private void SpeedInsertToList() //putting all speeds from both files to one list
        {
            foreach (var item in listCSV)
            {
                speed.Add(item.Speed);
            }
            foreach (var item in listJson)
            {
                speed.Add(item.Speed);
            }
        }
        private void SatelitesValueSort() // sort satelites
        {
            satelites.Sort();
        }
        private void SpeedValueSort() // sort speed
        {
            speed.Sort();
        }
        private void SatelitesValueCount() // counting quantity of satelites
        {
            int a = 0;
            foreach(var item in satelites)
            {
               if(item==a)
                {
                    ArrayOfSatelites[a]++;
                }
               else
                {
                    a++;
                    ArrayOfSatelites[a]++;
                }
            }
        }
        private void SpeedValueCount() // counting quantity of speed values
        {
            int a = 10;
            int b = 0;
            foreach(var item in speed)
            {
                if (item == b && item!=item-a)
                {
                    ArrayOfSpeed[b]++;
                }
                else
                {
                    a=a+10;
                    b++;
                    ArrayOfSpeed[b]++;
                }
            }
        }
         private void GraphOfSpeed() // transefering from one array to other ( idea was to divide so it would be easier to draw a graph, but idea changed in the middle of development)
        {

            for (int i = 0; i < ArrayForSpeedSumGraph.Length; i++)
            {
                ArrayForSpeedSumGraph[i] = ArrayOfSpeed[i];;
            }
        }
        private void GraphOfSatelites() // transfering from one array to other and lowering the count for more comfortable numbers
        {

            for (int i = 0; i < ArrayOfSatelites.Length; i++)
            {
                ArrayForSatelitesGraph[i] = ArrayOfSatelites[i] / 100;
            }
        }

        private void ShowAllSatelites() //output all satelites
        {
            for (int i = 0; i <ArrayForSatelitesGraph.Length; i++)
            {
                Console.Write(i+" "+ArrayForSatelitesGraph[i]);
                Console.WriteLine();
            }
        }
        private void CountSpeed() // count  speed quantity in different range
        {
            int sum=0;
            int a=10;
            int b=0;
            for(int i = 0; i < ArrayForSpeedSumGraph.Length; i++)
            {
                if (i == a)
                {
                    ArrayOfSpeedSum[b]=sum;
                    b++;
                    a=a+10;
                }
                else
                {
                    sum=sum+ArrayForSpeedSumGraph[i];
                }
            }
        }
        private void DrawGraphOfSpeed() //output custom graph to screen in console
        {
            int a = 0;
            int b = 9;
            Console.WriteLine("-------Graph of speed data------");
            for (int i = 0; i < ArrayOfSpeedSum.Length; i++)
            {
                Console.Write(a+" - "+b);
                if (i==0)
                {
                    Console.Write("    ");
                }
                else if (i>=1 && i<10)
                {
                    Console.Write("  ");
                }
                if(ArrayOfSpeedSum[i]>10000 && ArrayOfSpeedSum[i]<20000)
                {
                    Console.Write(" |           ");
                }
                else if(ArrayOfSpeedSum[i]>20000 && ArrayOfSpeedSum[i] < 30000)
                {
                    Console.Write(" |   |       ");
                }
                else if(ArrayOfSpeedSum[i]>30000 && ArrayOfSpeedSum[i] < 40000)
                {
                    Console.Write(" |   |  |    ");
                }
                else if(ArrayOfSpeedSum[i]>40000 && ArrayOfSpeedSum[i] < 50000)
                {
                    Console.Write(" |   |  |  | ");
                }
                Console.WriteLine(ArrayOfSpeedSum[i]+" hits");
                a+=10;
                b+=10;
            }
            Console.WriteLine("---Count of same speed x10000---");
            Console.WriteLine(" ");
        }

        private void DrawGraphOfSatelites()//output custom graph to screen in console
        {
            Console.WriteLine("---Graph of sattelites data---");
            for (int i = 0; i < ArrayForSatelitesGraph.Length; i++)
            {
                if (ArrayForSatelitesGraph[i]>=0 && ArrayForSatelitesGraph[i]<1)
                {
                    Console.WriteLine(i+" ");
                }
                else if (ArrayForSatelitesGraph[i]>1 && ArrayForSatelitesGraph[i]<20 && i<10)
                {
                    Console.WriteLine(i+"    *");
                }
                else if (ArrayForSatelitesGraph[i]>1 && ArrayForSatelitesGraph[i]<20)
                {
                    Console.WriteLine(i+"   *");
                }
                else if (ArrayForSatelitesGraph[i] > 0 && ArrayForSatelitesGraph[i] <= 20 && i<10)
                {
                    Console.WriteLine(i + "    *   *");
                }
                else if (ArrayForSatelitesGraph[i] > 0 && ArrayForSatelitesGraph[i] <= 20)
                {
                    Console.WriteLine(i + "   *   *");
                }
                else if (ArrayForSatelitesGraph[i] > 20 && ArrayForSatelitesGraph[i] <= 40)
                {
                    Console.WriteLine(i + "   *   *   *");
                }
                else if (ArrayForSatelitesGraph[i] > 40 && ArrayForSatelitesGraph[i] <= 60)
                {
                    Console.WriteLine(i + "   *   *   *   *");
                }
                else if (ArrayForSatelitesGraph[i] > 60 && ArrayForSatelitesGraph[i] <= 80)
                {
                    Console.WriteLine(i + "   *   *   *   *   *");
                }
            }
            Console.WriteLine("    20  40  60  80  100  ");
            Console.WriteLine("---Count of satelites x100---");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

        }
        private void Distance() // count the quantity of distances that go further than 100km
        {
            for(int i = 1; i < Longitude.Count; i++) // doesn't matter if its longtitude or latitude, the count is same for both
            {
                for(int j = 0; j < 1000; j++) // made here j < 1000 for working principals, cause to be correct you should count to Longtitude.Count or Latitude.Count, but then the number are too big and it takes a lot of time.
                {
                    double distance = GeoCalculator.GetDistance(Latitude[i-1],Longitude[i-1],Latitude[j],Longitude[j]); // calculates in miles
                    //Console.WriteLine(distance);
                    if(distance >= 62) //100 km is about 62 miles
                    {
                        ListOfDistances.Add(distance);
                        LatitudeStart.Add(Latitude[i - 1]);
                        LongtitudeStart.Add( Longitude[i - 1]);
                        LatitudeEnd.Add(Latitude[j]);
                        LongtitudeEnd.Add(Longitude [j]);
                        GPSTimeStart.Add(GpsTime[j]);
                        GPSTimeEnd.Add(GpsTime[i]);
                        //Console.WriteLine("works");
                    }
                    else
                    {
                        //Console.WriteLine("doesnt work");
                    }
                }
            }
        }
        private void FastestRoad() // counting all possible speeds when distance is over 100km
        {
            if (ListOfDistances.Count != 0)
            {
                for (int i = 0; i < ListOfDistances.Count; i++)
                {
                    time = (GPSTimeStart[i].Ticks - GPSTimeEnd[i].Ticks);
                    time = (long)TimeSpan.FromTicks(time).TotalHours;
                    Console.WriteLine(time + " " + ListOfDistances[i]);
                    if (time > 0)
                    {
                        RoadDivededByTime = (ListOfDistances[i]) / time;
                    }
                    //Console.WriteLine(RoadDivededByTime);
                    if (RoadDivededByTime > 0)
                    {
                        ListOfSpeeds.Add(RoadDivededByTime);
                    }
                    else
                    { }

                }
            }
            else
            { }


        }
        private void FindFastestRoad()  // finding the biggest speed in list
        {
            if(ListOfDistances.Count != 0)
            {
                biggest = 0;
                biggest = ListOfSpeeds.Max();
                index = ListOfSpeeds.IndexOf(biggest);
            }
            else
            {

            }
            
        }
        private void OutputFastestRoad() //output to console with all necesary information
        {
            if(ListOfDistances.Count != 0)
            {
                Console.WriteLine("Fastest road section of at least 100km was driven with these coordinates:");
                Console.WriteLine("Start position "+LatitudeStart[index]+"; "+LongtitudeStart[index]);
                Console.WriteLine("Start Gps time "+GPSTimeStart[index]);
                Console.WriteLine("End position "+LatitudeEnd[index]+"; "+LongtitudeEnd[index]);
                Console.WriteLine("End Gps time "+GPSTimeEnd[index]);
                Console.WriteLine("Average speed "+biggest+ " km/h");
            }
            else
            {
                Console.WriteLine("No distances were found");
            }

        }
        static void Main(string[] args) // main to turn on necesasy functions
        {
            Program program = new Program();
            program.GetDataJson();
            program.DeserializeJsonData();
            //program.ShowJsonData();
            program.GetDataCSV();
            //program.ShowDataCSV();
            program.SatelitesInsertToList();
            program.SatelitesValueSort();
            program.SatelitesValueCount();
            program.GraphOfSatelites();
            //program.ShowAllSatelites();
            program.DrawGraphOfSatelites();
            program.SpeedInsertToList();
            program.SpeedValueSort();
            program.SpeedValueCount();
            program.GraphOfSpeed();
            program.CountSpeed();
            program.DrawGraphOfSpeed();
            program.LatitudeInsertToList();
            program.LongitudeInsertToList();
            program.AltitudeInsertToList();
            program.AngleInsertToList();;
            program.GPSInsertToList();
            program.Distance();
            program.FastestRoad();
            program.FindFastestRoad();
            program.OutputFastestRoad();



        }
    }
}