using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SpeedyAir
{
    public class Flight
    {

        public Flight(int flightNumber, string origin, string destination, int day, int capacity)
        {
            this.FlightNumber = flightNumber;
            this.Origin = origin;
            this.Destination = destination;
            this.Day = day;
            this.Capacity = capacity;
        }
        public int FlightNumber { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }

        public int Day { get; set; }

        public int Capacity { get; set; }

        public List<string> orders = new List<string>();

        public override string ToString()
        {
            return $"flight: {this.FlightNumber}, departure: {this.Origin}, arrival: {this.Destination}, day: {this.Day}";
        }


    }
}