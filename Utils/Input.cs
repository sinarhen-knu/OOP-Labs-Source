namespace Utils
{
    public static class Input
    {
        public static T ReadAndValidateInput<T>(string prompt, Func<string, T> parseMethod, Func<T, bool>? validateMethod = null)
        {
            T result;
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    result = parseMethod(Console.ReadLine() ?? string.Empty);
                    if (validateMethod == null || validateMethod(result))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid value.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a valid value.");
                }
            }
            return result;
        }
    }
}