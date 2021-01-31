

namespace Edea.Entities
{
    public class Order
    {
        public int OrderID        { get; set; }
        public string CompanyName { get; set; }
        public string CustomerID  { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity    { get; set; }
        public string ShipRegion  { get; set; }
        public float ShippingCost { get; set; }
    }
}
