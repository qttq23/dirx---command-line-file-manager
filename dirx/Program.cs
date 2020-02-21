using System;
using System.IO;

using System.Json;

namespace dirx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // config file
            Config.Init();
            string startFolder = Config.json["startFolder"];

            // show list
            Console.WriteLine($"files and folders at {startFolder}:");
            var list = FileDirInfo.List(startFolder);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }


    }
}
