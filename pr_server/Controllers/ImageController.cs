using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pr_Model.Models;

namespace pr_server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public List<ImageModel> GetImages()
        {
            List<ImageModel>list = new List<ImageModel>()
            {
                new ImageModel(){ImageUrl="/images/banners/Banner_01.png",CourseUrl="https://tw.yahoo.com/"},
                new ImageModel(){ImageUrl="/images/banners/Banner_02.png",CourseUrl="https://tw.yahoo.com/"},
                new ImageModel(){ImageUrl="/images/banners/Banner_03.png",CourseUrl="https://tw.yahoo.com/"},
            };
            return list;
        }
    }
}
