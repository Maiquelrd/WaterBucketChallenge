using Microsoft.AspNetCore.Mvc;
using WaterBucketChallenge.Models;
using WaterBucketChallenge.Services;

namespace WaterBucketChallenge.Controllers
{
    [Route("api/waterBucket")]
    [ApiController]
    public class WaterBucketController : ControllerBase
    {
        private readonly IWaterBucketService _waterBucketService;

        public WaterBucketController(IWaterBucketService waterBucketService)
        {
            _waterBucketService = waterBucketService;
        }
        [HttpGet()]
        [Route("getSteps")]
        public List<Step> GetSteps(int x, int y, int z)
        {
            return _waterBucketService.GetSteps(x,y,z);
        }


        [HttpGet()]
        [Route("showSteps")]
        public string ShowSteps(int x, int y, int z)
        {
            return _waterBucketService.ShowSteps(x, y, z);
        }
    }
}
