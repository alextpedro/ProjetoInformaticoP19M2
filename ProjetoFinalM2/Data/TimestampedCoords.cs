using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalM2.Data
{
    public class TimestampedCoords
    {
        public DateTime Timestamp { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public TimestampedCoords(DateTime timestamp, double lat, double lon)
        {
            Timestamp = timestamp;
            Lat = lat;
            Lon = lon;
        }

        public override string ToString()
        {
            return $"{Timestamp} {Lat} {Lon}";
        }
    }
}
