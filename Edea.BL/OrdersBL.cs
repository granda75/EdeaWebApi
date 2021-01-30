using Edea.DAL;
using Edea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Edea.BL
{
    public class OrdersBL : IOrdersBL
    {

        private IOrdersDal _dal;

        #region Constructor

        public OrdersBL(IOrdersDal dal)
        {
            _dal = dal;
        }

        #endregion

        public OrdersData GetOrdersData()
        {
            OrdersData data = new OrdersData();
            data.OrdersList = _dal.GetOrdersList();
            data.TotalOrders = data.OrdersList.Count;
            data.TotalShippingCost = data.OrdersList.Sum(l => l.Freight);
            data.AverageShippingCost = data.OrdersList.Average(l => l.Freight);

            return data;
        }
    }
}
