using System;
using System.Collections.Generic;
using System.Text;

namespace Teltonika
{
    public class Distance
    {
        public double ListOfDistances {get;set;}
        public double  LatitudeStart {get;set;}
        public double  LongtitudeStart{get;set; }
        public double  LatitudeEnd {get;set; }
        public double  LongtitudeEnd{get;set;}
        public DateTime GPSTimeStart{get;set;}
        public DateTime GPSTimeEnd{get;set;}
        public Distance(double listofdistances,double latitudestart, double longtitudestart, double latitudeend,double longtitudeend, DateTime gpstimestart, DateTime gpstimeend)
        {
            ListOfDistances = listofdistances;
            LatitudeStart = latitudestart;
            LongtitudeStart = longtitudestart;
            LatitudeEnd = latitudeend;
            LongtitudeEnd = longtitudeend;
            GPSTimeStart=gpstimestart;
            GPSTimeEnd=gpstimeend;

        }

    }
}
