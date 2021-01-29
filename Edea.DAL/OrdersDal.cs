using Edea.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Edea.DAL
{
    public class OrdersDal : IOrdersDal
    {
        #region Fields

        private string _conString;

        #endregion

        #region Constructors

        public OrdersDal(string conString)
        {
            _conString = conString;
        }

        #endregion

        #region Public methods

        //public List<Order> GetProductsList(int page, int rowsOnPage)
        public List<Order> GetOrdersList()
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(_conString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("[dbo].[GetOrders]", connection);
                //cmd.Parameters.Add(new SqlParameter("@pageNumber", page));
                //cmd.Parameters.Add(new SqlParameter("@rowsOfPage", rowsOnPage));
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                List<Order> ordersList = ds.Tables[0].ToIEnumerable<Order>().ToList();
                return ordersList;
            }
        }

        #endregion

    }
}
