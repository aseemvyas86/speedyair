/**
Purpose of this class "Schedule"
1. This class store days and its relevant flight of that day
2. User can set flights of destinations by using metthod "SetDestinationsForDay"
Example:
   schedule.SetDestinationsForDay(["YYZ", "YYC", "YVR"]);
   schedule.SetDestinationsForDay(["YYZ", "YYE", "YVR"]);
It will set the schedule like  this:
  flight: 1, departure: YUL, arrival: YYZ, day: 1
  flight: 2, departure: YUL, arrival: YYC, day: 1
  flight: 3, departure: YUL, arrival: YVR, day: 1
  flight: 4, departure: YUL, arrival: YYZ, day: 2
  flight: 5, departure: YUL, arrival: YYE, day: 2
  flight: 6, departure: YUL, arrival: YVR, day: 2

3. User can again reset all the days schedule by using method  "Reset"
4. User can set departure city by default it is set to "YUL"
*/

namespace SpeedyAir
{
   public class Schedule
   {
      List<string[]> days;
      string departure;

      public Schedule()
      {
         days = new List<string[]>();
         departure = "YUL";

      }




      public void SetDestinationsForDay(string[] listOfDestination)
      {
         days.Add(listOfDestination);
      }

      public void SetDeparture(string departureCity)
      {
         departure = departureCity;
      }

      public void Reset()
      {
         days.Clear();
      }

      public List<Flight> GetScheduleForAllDays()
      {
         List<Flight> flightDetails = new List<Flight>();
         int flightCount = 1;
         for (int i = 0; i < days.Count; i++)
         {
            string[] destinations = days[i];
            for (int j = 0; j < destinations.Length; j++)
            {

               flightDetails.Add(new Flight(flightCount, departure, destinations[j], i + 1, Constants.Capacity));
               flightCount++;

            }
         }
         return flightDetails;
      }

   }
}