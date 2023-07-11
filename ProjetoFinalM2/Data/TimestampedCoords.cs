namespace ProjetoFinalM2.Data
{
    public class TimestampedCoords
    {
        public DateTime Timestamp { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Bearing { get; set; }

        public TimestampedCoords(DateTime timestamp, double lat, double lon, double bearing)
        {
            Timestamp = timestamp;
            Lat = lat;
            Lon = lon;
            Bearing = bearing;
        }

        public override string ToString()
        {
            return $"{Timestamp} {Lat} {Lon} {Bearing}";
        }
    }
}
