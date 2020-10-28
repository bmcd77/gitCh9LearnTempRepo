using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string user = "bmcd77";
            string repo = "gitCh9LearnTempRepo";
            Uri projectUri = new Uri($"https://github.com/{user}/{repo}");

            Console.WriteLine($"This is a test of Github SCM from a Rob Green channel 9 video for {projectUri}");
        }
    }
}
