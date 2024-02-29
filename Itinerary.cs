/**
Purpose of this Itinerary Class:
----------------------------------------
1. It create flight itinerary for the given schedule generated by User
2. Method "FlightItinaries" goes each order in orderList and check whether flight is 
   scheduled for that order in that day
3. Logic behind the method "FlightItinaries"
   i. We have dictionary "trackFlights" 
      key --> destination 
      value --> Tuple<list of flight, variable to track which flight is field>
   ii. Foreach order in orderList--> 
   iii. Check "destination" from order exist in Dictionary
        key ---> destination not exist
        ----------------------------------
        > Search all flights from flightschedule
        > Add in tuple list of flights and set index to 0 because it is the first one
        > Add order to orderScheduled list
        ----------------------------------
        key  ---> destination exist in Dictionary
        > Retrive the value of particular key
        > Add the order of a current flight 
        > Fill upto capacity of the flight
        > Update the tuple with updated flight and increment index of tuple
        > Update the Dictonary 
        > Add order in orderScheduled list
    iv. Return the orderScheduled list


*/



namespace SpeedyAir
{

    public class Itinerary()
    {


        public List<string> FlightItinaries(List<Flight> schedule, List<Order> orderList)
        {

            Dictionary<string, Tuple<List<Flight>, int>> trackFlights = new Dictionary<string, Tuple<List<Flight>, int>>();
            List<string> orderScheduled = new List<string>();

            foreach (var order in orderList)
            {
                Tuple<List<Flight>, int> value;
                string destination = order.Destination;
                if (trackFlights.TryGetValue(destination, out value))
                {
                    List<Flight> listOfFlight = value.Item1;
                    if (value.Item2 <= listOfFlight.Count - 1)
                    {
                        Flight currentFlight = listOfFlight[value.Item2];

                        if (currentFlight.orders.Count < currentFlight.Capacity)
                        {
                            currentFlight.orders.Add(order.OrderId);
                            orderScheduled.Add(FlightItinariesTemplate(order.OrderId, currentFlight.FlightNumber, currentFlight.Origin, currentFlight.Destination, currentFlight.Day));
                        }
                        else
                        {
                            Tuple<List<Flight>, int> updatedFlight = Tuple.Create(listOfFlight, value.Item2 + 1);
                            trackFlights[destination] = updatedFlight;
                        }

                    }
                    else
                    {
                        orderScheduled.Add($"order: {order.OrderId}, flightNumber: not scheduled");
                    }
                }
                else
                {
                    List<Flight> flightsToDestination = schedule.FindAll(x => x.Destination == destination);
                    if (flightsToDestination.Count > 0)
                    {
                        Flight firstFlight = flightsToDestination[0];
                        firstFlight.orders.Add(order.OrderId);
                        orderScheduled.Add(FlightItinariesTemplate(order.OrderId, firstFlight.FlightNumber, firstFlight.Origin, firstFlight.Destination, firstFlight.Day));
                        Tuple<List<Flight>, int> trackFlightOrder = Tuple.Create(flightsToDestination, 0);
                        trackFlights.Add(destination, trackFlightOrder);
                    }
                    else
                    {
                        orderScheduled.Add($"order: {order.OrderId}, flightNumber: not scheduled");
                    }

                }
            }

            return orderScheduled;
        }

        private string FlightItinariesTemplate(string orderNumber, int flightNumber, string departure, string arrival, int day)
        {
            return $"order: {orderNumber}, flightNumber: {flightNumber}, departure: {departure}, arrival: {arrival}, day: {day}";
        }
    }


}