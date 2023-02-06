using WaterBucketChallenge.Models;

namespace WaterBucketChallenge.Services
{
    public interface IWaterBucketService
    {
        string ShowSteps(int x, int y, int z);

        List<Step> GetSteps(int x, int y, int z);

        List<Step> Pour(Bucket fromBucket, Bucket toBucket, int desired);

        void Fill(Bucket bucket, List<Step> steps);

        void Dump(Bucket bucket, List<Step> steps);

        void Transfer(Bucket fromBucket, Bucket toBucket, int value, List<Step> steps);

    }
}