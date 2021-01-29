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
    [EnableCors("OrdersPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Fields

        private readonly ILogger<OrdersController> _logger;
        public IConfiguration _configuration { get; set; }

        public IOrdersDal _dal;

        #endregion

        #region Constructor

        public OrdersController(ILogger<OrdersController> logger, IConfiguration configuration, IOrdersDal ordersDal)
        {
            _logger = logger;
            _configuration = configuration;
            _dal = ordersDal;
        }

        #endregion

        #region Public methods

        [EnableCors("OrdersPolicy")]
        [HttpGet]
        public List<Order> Get()
        {
            return _dal.GetOrdersList();
        }

        #endregion
    }
}
