using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalM2.Data
{
    internal class Vehicle
    {
        public int Id { get; set; }
        public List<TimestampedCoords> TimestampedCoords { get; set; }

        public Vehicle(int id) {
            Id = id;
            TimestampedCoords = new List<TimestampedCoords>();
        }
    }
}
