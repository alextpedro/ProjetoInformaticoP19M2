namespace ProjetoFinalM2.Data
{
    public class Vehicle
    {
        public int Id { get; set; }
        public List<TimestampedCoords> TimestampedCoords { get; set; }

        public Vehicle(int id)
        {
            Id = id;
            TimestampedCoords = new List<TimestampedCoords>();
        }

        public override string ToString()
        {
            return $"Vehicle ID: {Id} with {TimestampedCoords.Count} coords.";
        }
    }
}
