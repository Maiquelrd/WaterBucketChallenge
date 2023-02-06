namespace WaterBucketChallenge.Commons.Validators
{
    public interface IWaterBucketValditator
    {
        public bool Validate(int x, int y, int z);

        public bool ValuesArePositives(int x, int y, int z);

        public bool ValuesAreSafe(int x, int y, int z);

        public bool ZIsLower(int x, int y, int z);

        public bool IsDivisible(int x, int y, int z);
    }
}