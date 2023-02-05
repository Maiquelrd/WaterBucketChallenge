namespace WaterBucketChallenge.Models
{
    public class Step
    {
        public int Number { get; set; }
        public string Action { get; set; }
        public Bucket AffedtedBucket { get; set; }
        public Bucket? ToBucket { get; set; }
        public string? Description { get; set; }


        public Step(int number, string action, Bucket affectedBucket, Bucket? toBucket = null)
        {
            this.Number = number;
            this.Action = action;
            this.AffedtedBucket = affectedBucket;
            this.ToBucket = toBucket;
        }
    }
}
