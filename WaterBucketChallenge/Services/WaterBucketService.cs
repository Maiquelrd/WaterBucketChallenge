using WaterBucketChallenge.Commons.Structs;
using WaterBucketChallenge.Commons.Validators;
using WaterBucketChallenge.Models;

namespace WaterBucketChallenge.Services
{
    public class WaterBucketService : IWaterBucketService
    {
        private readonly IWaterBucketValditator _waterBucketValditator;
        public WaterBucketService(IWaterBucketValditator waterBucketValditator)
        {
            _waterBucketValditator = waterBucketValditator;
        }
        public virtual string ShowSteps(int x, int y, int z)
        {
            List<Step> solution = GetSteps(x, y, z);
            IEnumerable<string> stepsDescription = solution.Select(x => x.Description);

            return String.Join("\n", stepsDescription);
        }

        public virtual List<Step> GetSteps(int x, int y, int z)
        {

            if (!_waterBucketValditator.Validate(x, y, z))
                return new List<Step>();

            Bucket bucketX = new Bucket("X", 0, x);
            Bucket bucketY = new Bucket("Y", 0, y);

            List<Step> solution1 = Pour(bucketY, bucketX, z);
            List<Step> solution2 = Pour(bucketX, bucketY, z);

            return solution1.Count < solution2.Count ? solution1 : solution2;

        }

        public virtual List<Step> Pour(Bucket fromBucket, Bucket toBucket,int desired)
        {
            List<Step> steps = new List<Step>();

            Fill(fromBucket, steps);
           
            while (fromBucket.Value != desired && toBucket.Value != desired)
            {
                int transferValue = Math.Min(fromBucket.Value, toBucket.Cap - toBucket.Value);

                Transfer(fromBucket, toBucket, transferValue, steps);

                if (fromBucket.Value == desired || toBucket.Value == desired)
                    break;

                if (fromBucket.Value == 0) Fill(fromBucket, steps);

                if (toBucket.Value == toBucket.Cap) Dump(toBucket, steps);
                
            }
            fromBucket.Value = 0;
            toBucket.Value = 0;
            return steps;
        }

        public virtual void Fill(Bucket bucket, List<Step> steps)
        {
            bucket.Value = bucket.Cap;
            steps.Add(new Step(steps.Count + 1, StepAction.Fill, bucket.Cap, bucket));
        }

        public virtual void Dump(Bucket bucket, List<Step> steps)
        {
            int currentVal = bucket.Value;
            bucket.Value = 0;
            steps.Add(new Step(steps.Count + 1, StepAction.Dump, currentVal, bucket));
        }

        public virtual void Transfer(Bucket fromBucket, Bucket toBucket, int value, List<Step> steps)
        {
            toBucket.Value += value;
            fromBucket.Value -= value;

            steps.Add(new Step(steps.Count + 1, StepAction.Transfer, value, fromBucket, toBucket));
        }
    }
}
