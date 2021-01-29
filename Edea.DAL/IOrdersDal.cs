using Edea.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Edea.DAL
{
    public interface IOrdersDal
    {
        List<Order> GetOrdersList();
    }
}
