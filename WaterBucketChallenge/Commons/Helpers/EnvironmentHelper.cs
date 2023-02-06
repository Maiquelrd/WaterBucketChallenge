namespace WaterBucketChallenge.Commons.Helpers
{
    public class EnvironmentHelper
    {
        public static T GetEnv<T>(string name, T defaultValue)
        {
            string variableValue = Environment.GetEnvironmentVariable("name");

            if (string.IsNullOrEmpty(variableValue))
            {
                Console.WriteLine($"Enviroment variable {name} its not defined");
                return defaultValue;
            }

            return ObjectHelper.GetValue<T>(variableValue);
        }
    }
}
