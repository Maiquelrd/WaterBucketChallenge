using WaterBucketChallenge.Commons.Exceptions;
using WaterBucketChallenge.Commons.Helpers;

namespace WaterBucketChallenge.Commons.Validators
{
    public class WaterBucketValditator
    {
        public static bool Validate(int x, int y, int z)
        {
            if (!ValuesArePositives(x,y,z)) 
                throw new ValidationException("Values most be positives");
            if (!ValuesAreSafe(x, y, z))
                throw new ValidationException("Values should be smaller");
            if (!ZIsLower(x, y, z)) 
                throw new ValidationException("Z value should not be greater than Y and X");
            if (!IsDivisible(x, y, z)) 
                throw new ValidationException("The Greatest Common Divisor of X and Y should be able to divide Z");

            return true;
        }
        public static bool ValuesArePositives(int x, int y, int z)
        {
            return (x >= 0 && y >= 0 && z >= 0);
        }

        public static bool ValuesAreSafe(int x, int y, int z)
        {
            int maxLenght = EnvironmentHelper.GetEnv<int>("MAX_NUMBER", 1000);
            return (x <= maxLenght && y <= maxLenght && z <= maxLenght);
        }

        public static bool ZIsLower(int x, int y, int z)
        {
            return z < Math.Max(x, y);
        }

        public static bool IsDivisible(int x, int y, int z)
        {
            return ((z % NumberHelper.greatestCommonDivisor(y, x)) == 0);
        }

       
    }
}
