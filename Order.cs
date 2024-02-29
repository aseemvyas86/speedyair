/**
Purpose of this Order class
1. It loads the order from json file
2. Parse it and return the list of Order object using method "ParseOrders"
3. Order object has two field:
   OrderId
   Destination

*/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpeedyAir
{
    public class Order
    {
        public string? OrderId { get; set; }

        public string? Destination { get; set; }

        public List<Order> ParseOrders(string filepath)
        {
            List<Order> orderList = new List<Order>();
            string jsonString = File.ReadAllText(filepath);
            JObject? parsedJson = JsonConvert.DeserializeObject<JObject>(jsonString);
            if (parsedJson != null)
            {
                foreach (var order in parsedJson)
                {

                    orderList.Add(new Order
                    {
                        OrderId = order.Key,
                        Destination = order.Value["destination"]?.ToString()
                    });
                }
            }
            return orderList;
        }
    }
}