namespace Utils
{
    public static class Input
    {
        public static T ReadAndValidateInput<T>(string prompt, Func<string, T>? parseMethod = null, Func<T, bool>? validateMethod = null)
        {
            T result;
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    string input = Console.ReadLine() ?? string.Empty;
                    result = parseMethod != null ? parseMethod(input) : (T)Convert.ChangeType(input, typeof(T));
                    if (validateMethod == null || validateMethod(result))
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a valid value.");
                }
            }
            return result;
        }
    }
    public static class EnumHelper
    {
        public static T Parse<T>(string value) where T : struct
        {
            Enum.TryParse(value, out T result);
            return result;
        }
    }
}