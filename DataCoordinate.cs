using System;
using System.Collections.Generic;
using System.Text;

namespace Teltonika
{
    public class DataCoordinate
    {
        public int Satelite{get; set;}
        public int Speed {get;set;}
        public double Latitude {get;set;}
        public double Longtitude {get;set;}
        public DateTime GPSTime {get;set;}
        public int Angle {get;set;}
        public int Altitude {get;set;}
        public DataCoordinate(int satelite, int speed, double latitude, double longtitude, DateTime gpsTime, int angle, int altitude)
        {
            Satelite=satelite;
            Speed=speed;
            Latitude=latitude;
            Longtitude=longtitude;
            GPSTime=gpsTime;
            Angle=angle;
            Altitude=altitude;            
        }
    }
    
}
