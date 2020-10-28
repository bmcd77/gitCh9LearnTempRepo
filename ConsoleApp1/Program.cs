using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                var i = 0;
                foreach (var a in args)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("arg" + (++i).ToString() + " " + a);
                }
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("    H e l l o   W o r l d!   "); Console.WriteLine();
            Console.ResetColor();

            string user = "bmcd77";
            string repo = "gitCh9LearnTempRepo";
            Uri projectUri = new Uri($"https://github.com/{user}/{repo}");

            Console.WriteLine($"This is a test of Github SCM from a Rob Green channel 9 video for {projectUri}");
                        
        }
    }
}
