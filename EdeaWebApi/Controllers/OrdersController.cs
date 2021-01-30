using Edea.BL;
using Edea.DAL;
using Edea.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdeaWebApi.Controllers
{


    //[EnableCors("AllowOrigin")]
    //[EnableCors("OrdersPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Fields

        private readonly ILogger<OrdersController> _logger;
        public IConfiguration _configuration { get; set; }

        //public IOrdersDal _dal;
        public IOrdersBL _bl;

        #endregion

        #region Constructor

        public OrdersController(ILogger<OrdersController> logger, IConfiguration configuration, IOrdersBL ordersBl)
        {
            _logger = logger;
            _configuration = configuration;
            _bl = ordersBl;
        }

        #endregion

        #region Public methods

        //[HttpGet]
        //public List<Order> Get(int first, int rows)
        //{
        //    return _dal.GetOrdersList();
        //}

        [HttpGet]
        public OrdersData Get()
        {
            return _bl.GetOrdersData();
        }

        #endregion
    }
}
