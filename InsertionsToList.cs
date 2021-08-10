using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Teltonika
{
    public static class InsertionsToList
    {
        public static List<DataCoordinate> AllInsertToList(List<DataJSON> listJson,List<DataCSV> listCSV) //putting all satelites from both files to one list
        {
            List<DataCoordinate> result = new List<DataCoordinate>();
            foreach (var item in listCSV)
            {
                result.Add(new DataCoordinate(item.Satellites,item.Speed,item.Latitude,item.Longitude,item.GpsTime,item.Angle,item.Altitude));
            }
            foreach (var item in listJson)
            {
                result.Add(new DataCoordinate(item.Satellites,item.Speed,item.Latitude,item.Longitude,item.GpsTime,item.Angle,item.Altitude));
            }
            return result;
        }

        public static List<DataJSON> GetJsonData() // deserialiazation of Json data
        {
            StreamReader ReadJson = new StreamReader("2019-07.json");
            string json = ReadJson.ReadToEnd();
            List<DataJSON> listJson = JsonConvert.DeserializeObject<List<DataJSON>>(json);
            return listJson;
        }
        public static List<DataCSV> GetDataCSV() // obtaining CSV data
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using var reader = new StreamReader("2019-08.csv");
            using var csv = new CsvReader(reader, config);

            List<DataCSV> listCSV = csv.GetRecords<DataCSV>().ToList();
            return listCSV;
        }
        public static void ShowJsonData(List<DataJSON> listJson) // output to console of JSON data
        {
            foreach (var item in listJson)
            {
                Console.WriteLine(item.Latitude + " " + item.Longitude + " " + item.GpsTime + " " + item.Speed + " " + item.Angle + " " + item.Altitude + " " + item.Satellites);
            }
        }
        public static void ShowDataCSV(List<DataCSV> listCSV)// output to console of CSV data
        {
            foreach (var item in listCSV)
            {
                Console.WriteLine(item.Latitude + " " + item.Longitude + " " + item.GpsTime + " " + item.Speed + " " + item.Angle + " " + item.Altitude + " " + item.Satellites);
            }
        }
        public static void ShowAllValues(List<DataCoordinate> result)
        {
            foreach(var item in result)
            {
                Console.WriteLine(item.Satelite+" "+item.Speed+" "+item.Latitude+" "+item.Longtitude+" "+item.GPSTime+" "+item.Angle+" "+item.Altitude);
            }
        }
    }
}
