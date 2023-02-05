using WaterBucketChallenge.Models;

namespace WaterBucketChallenge.Services
{
    public class WaterBucketService
    {
        public string GetSteps(int n, int m, int d)
        {
            List<Step> solution = minSteps(m, n, d);
            string test = "Minimum number of " +
                               "steps required is " +
                               solution.Count;
            Console.WriteLine(solution);
            return test;
        }

        public int gcd(int a, int b)
        {
            if (b == 0)
                return a;

            return gcd(b, a % b);
        }

        public List<Step> pour(Bucket fromBucket, Bucket toBucket,int d)
        {
            List<Step> steps = new List<Step>();
            fromBucket.Value = 0;
            toBucket.Value = 0;

            Fill(fromBucket, steps);
           
            while (fromBucket.Value != d && toBucket.Value != d)
            {
                int transferValue = Math.Min(fromBucket.Value, toBucket.Cap - toBucket.Value);

                Transfer(fromBucket, toBucket, transferValue, steps);

                if (fromBucket.Value == d || toBucket.Value == d)
                    break;

                if (fromBucket.Value == 0)
                {
                    Fill(fromBucket, steps);
                }

                if (toBucket.Value == toBucket.Cap)
                {
                    Dump(toBucket, steps);
                }
            }
            return steps;
        }

        public List<Step> minSteps(int m, int n, int d)
        {
            if (m > n)
            {
                int t = m;
                m = n;
                n = t;
            }

            if (d > n)
                return new List<Step>();

            if ((d % gcd(n, m)) != 0)
                return new List<Step>();

            Bucket bucketM = new Bucket("m", 0, m);
            Bucket bucketN = new Bucket("n", 0, n);

            List<Step> solution1 = pour(bucketN, bucketM, d);
            List<Step> solution2 = pour(bucketM, bucketN, d);

            return solution1.Count < solution2.Count ? solution1: solution2;

        }

        public void Fill(Bucket bucket, List<Step> steps)
        {
            bucket.Value = bucket.Cap;
            steps.Add(new Step(steps.Count + 1, "Fill", bucket));
        }

        public void Dump(Bucket bucket, List<Step> steps)
        {
            bucket.Value = 0;
            steps.Add(new Step(steps.Count + 1, "Dump", bucket));
        }

        public void Transfer(Bucket fromBucket, Bucket toBucket, int value, List<Step> steps)
        {
            toBucket.Value += value;
            fromBucket.Value -= value;

            steps.Add(new Step(steps.Count + 1, "Transfer", fromBucket, toBucket));
        }
    }
}
