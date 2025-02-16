using LapShopPr.Bl;
using LapShopPr.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShopPr.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IItem oitem;
        public ItemsController(IItem item)
        {
            oitem = item;
        }
        // GET: api/<ItemsController>
        [HttpGet]
        public ApiResponse Get()
        {
            ApiResponse OpiResponse = new ApiResponse();
            OpiResponse.Data = oitem.GetAllItemData(null);
            OpiResponse.Error = null;
            OpiResponse.StatusCode = "200";
            return OpiResponse;
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public ApiResponse GetItemById(int id)
        {
            ApiResponse OpiResponse = new ApiResponse();
            OpiResponse.Data = oitem.GetById(id);
            OpiResponse.Error = null;
            OpiResponse.StatusCode = "200";
            return OpiResponse;
        }

        [HttpGet("GetCategoryById/{CategoryId}")]

        public ApiResponse GetCategoryById(int CategoryId)
        {

            ApiResponse OpiResponse = new ApiResponse();
            OpiResponse.Data = oitem.GetAllItemData(CategoryId);
            OpiResponse.Error = null;
            OpiResponse.StatusCode = "200";
            return OpiResponse;
          
        }

        // POST api/<ItemsController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbItem item)
        {
            try {

                oitem.Save(item);

                ApiResponse OpiResponse = new ApiResponse();
                OpiResponse.Data = "Done";
                OpiResponse.Error = null;
                OpiResponse.StatusCode = "200";
                return OpiResponse;

            }
            catch (Exception ex)
            {
                ApiResponse OpiResponse = new ApiResponse();
                OpiResponse.Data = null;
                OpiResponse.Error = ex.Message;
                OpiResponse.StatusCode = "502";
                return OpiResponse;

            }
            

        }




        // DELETE api/<ItemsController>/5
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int  id)
        {
            oitem.Delete(id);

        }
    }
}
