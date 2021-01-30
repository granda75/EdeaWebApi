using System;
using System.Collections.Generic;
using System.Text;

namespace Edea.Entities
{
    public class OrdersData
    {
        public List<Order> OrdersList { get; set; }
        public int TotalOrders { get; set; }
        public double TotalShippingCost { get; set; }

        public double AverageShippingCost { get; set; }
    }
}
