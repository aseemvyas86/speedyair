namespace SpeedyAir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("User Story 1");
            Console.WriteLine("------------------");
            // User story 1

            Schedule schedule = new Schedule();
            // Default departure is YUL
            // Set all flight destination for day 1
            schedule.SetDestinationsForDay(["YYZ", "YYC", "YVR"]);
            // Set all flight destination for day 1
            schedule.SetDestinationsForDay(["YYZ", "YYE", "YVR"]);
            List<Flight> flightSchedules = schedule.GetScheduleForAllDays();
            foreach (var flightSchedule in flightSchedules)
            {
                // Print flight schedule
                Console.WriteLine(flightSchedule);
            }
            Console.WriteLine("<-------------------------------------------------------------------------->");
            Console.WriteLine("<-------------------------------------------------------------------------->");
            Console.WriteLine("------------------");
            Console.WriteLine("User Story 2");
            Console.WriteLine("------------------");
            //User story 2

            List<Order> orderList = new Order().ParseOrders(Constants.FilePath);

            Itinerary itinerary = new Itinerary();
            List<string> allOrderScheduled = itinerary.FlightItinaries(flightSchedules, orderList);
            foreach (var orderScheduled in allOrderScheduled)
            {
                Console.WriteLine(orderScheduled);
            }

        }
    }
}