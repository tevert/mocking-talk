using System;

namespace Mocking.Utils
{
    public class EmailUtils
    {
        public static bool SendEmail(string message)
        {
            Console.WriteLine($"I totally sent that email: {message}");
            return true;
        }
    }
}
