using LapShop.Bl;
using LapShop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShop.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IItems oItem;
        public ItemsController(IItems iitem)
        {
            oItem=iitem;
        }
        // GET: api/<ItemsController>
        /// <summary>
        /// get all items from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse Get()
        {
            ApiResponse oApiResponse = new ApiResponse();
            oApiResponse.Data= oItem.GetAll();
            oApiResponse.Errors = null;
            oApiResponse.StatusCode = "200";
            return oApiResponse;
        }

        // GET api/<ItemsController>/5
        /// <summary>
        /// get item by id
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            ApiResponse oApiResponse = new ApiResponse();
            oApiResponse.Data = oItem.GetById(id);
            oApiResponse.Errors = null;
            oApiResponse.StatusCode = "200";
            return oApiResponse;
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    ApiResponse oApiResponse = new ApiResponse();
        //    oApiResponse.Data = oItem.GetById(id);
        //    oApiResponse.Errors = null;
        //    oApiResponse.StatusCode = "200";
        //    return Ok(new object() { });
        //}

        // GET api/<ItemsController>/5
        [HttpGet("GetByCategoryId/{categoryId}")]
        public ApiResponse GetByCategoryId(int categoryId)
        {
            ApiResponse oApiResponse = new ApiResponse();
            oApiResponse.Data = oItem.GetAllItemsData(categoryId);
            oApiResponse.Errors = null;
            oApiResponse.StatusCode = "200";
            return oApiResponse;
        }

        // POST api/<ItemsController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbItem item)
        {
            try
            {
                oItem.Save(item);
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = "done";
                oApiResponse.Errors = null;
                oApiResponse.StatusCode = "200";
                return oApiResponse;
            }
            catch(Exception ex)
            {
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = null;
                oApiResponse.Errors = ex.Message;
                oApiResponse.StatusCode = "502";
                return oApiResponse;
            }
        }

        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int id)
        {
            oItem.Dekete(id);
        }
    }
}
