using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterBucketChallenge.Services;

namespace WaterBucketChallenge.Controllers
{
    [Route("api/waterBucket")]
    [ApiController]
    public class WaterBucketController : ControllerBase
    {
        [HttpGet(Name = "test")]
        public string Get(int m, int n, int d)
        {
            return new WaterBucketService().GetSteps(m,n,d);
        }
    }
}
