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


namespace Teltonika
{
    public class Program // main class
    {
        List<DataCoordinate> dataCoordinate = new List<DataCoordinate>();
        static List<DataJSON> listJson;
        static List<DataCSV> listCSV;
        static List<DataCoordinate> AllValues;
        List<Distance> distances = new List<Distance>();
        static List<Distance> Count;
        static List<double> FastestRoad;
        static int FindFastestRoad;
        static Dictionary<int,int> SpeedValues;
        static Dictionary<int,int> SpeedValuesGrouped;
        static Dictionary<int,int> SatelitesValue;
        /* Perkelk visus variables i main() vidu, kad nereiketu kurtis Program objekto (Program program = new Program())
         * InsertionsToList yra pavyzdziai kaip perkelti funkcijas is Program klases i kitas
         * main() yra kreipiniai i kitas klases, kur gali pamatyti klasiu priskyrima is funkciju
         * Kiek imanoma, visus siuos arrays ir listus perkelk i objektus ir naudok List<Object>, kreipiniai i visus prop Obj.Property
         * Nepamirsk kituose klasese naudoti static kituose klasese, kad galetum kreiptis i tuos metodus!
         */

        private void InsertData()
        {
            foreach (var item in listCSV)
            {
                dataCoordinate.Add(new DataCoordinate(item.Satellites,item.Speed,item.Latitude,item.Longitude,item.GpsTime,item.Angle,item.Altitude));
            }
            foreach (var item in listJson)
            {
                dataCoordinate.Add(new DataCoordinate(item.Satellites,item.Speed,item.Latitude,item.Longitude,item.GpsTime,item.Angle,item.Altitude));
            }
        }
        static void Main(string[] args) // main to turn on necesasy functions
        {
            Program program = new Program();
            listJson = InsertionsToList.GetJsonData();
            listCSV = InsertionsToList.GetDataCSV();
            AllValues = InsertionsToList.AllInsertToList(listJson,listCSV);
            program.InsertData();
            SpeedValues = Values.SpeedValueCount(AllValues);
            SpeedValuesGrouped = Values.SpeedValueCountGrouped(SpeedValues);
            SatelitesValue = Values.SatelitesValueCount(AllValues);
            DrawGraph.DrawGraphOfSpeed(SpeedValuesGrouped);
            DrawGraph.DrawGraphOfSatelites(SatelitesValue);
            //Values.OutputSatelites(SatelitesValue);
            //Values.OutputSpeed(SpeedValues);
            //InsertionsToList.ShowDataCSV(listCSV);
            //InsertionsToList.ShowJsonData(listJson);
            //InsertionsToList.ShowAllValues(AllValues);
            Count = DistanceCount.Count(AllValues);
            FastestRoad = DistanceCount.FastestRoad(Count);
            FindFastestRoad = DistanceCount.FindFastestRoad(FastestRoad, Count);
            DistanceCount.OutputFastestRoad(Count, FindFastestRoad, FastestRoad);


        }
    }
}