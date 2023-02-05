using Microsoft.AspNetCore.Mvc;
using WaterBucketChallenge.Models;
using WaterBucketChallenge.Services;

namespace WaterBucketChallenge.Controllers
{
    [Route("api/waterBucket")]
    [ApiController]
    public class WaterBucketController : ControllerBase
    {
        [HttpGet()]
        [Route("getSteps")]
        public List<Step> GetSteps(int x, int y, int z)
        {
            return new WaterBucketService().GetSteps(x,y,z);
        }


        [HttpGet()]
        [Route("showSteps")]
        public string ShowSteps(int x, int y, int z)
        {
            return new WaterBucketService().ShowSteps(x, y, z);
        }
    }
}
