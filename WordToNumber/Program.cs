using System;

namespace WordToNumber
{
    public static class Program
    {
        public static void Main()
        {
            var isRunning = true;
            do
            {
                Console.WriteLine("Enter sentence:");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "quit":
                    case "exit":
                        isRunning = false;
                        break;
                    case "help":
                        Console.WriteLine("Type quit or exit for termination.");
                        break;
                    default:
                        var translatedText = Converter.Translate(input);
                        Console.WriteLine(translatedText);
                        break;
                }
            } while (isRunning);

            Console.WriteLine("Bye!");
        }
    }
}