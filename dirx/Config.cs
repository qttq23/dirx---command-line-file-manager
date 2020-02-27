using System;
using System.IO;

using System.Json;

namespace dirx
{
    public class Config
    {
        public static JsonValue json;
        public static string filename = "config.json";

        public static void Init(){
            Init(filename);
        }

        public static void Init(string configFileName){

            string jsonString = File.ReadAllText(configFileName);
            json = JsonValue.Parse(jsonString);
        } 

    }
}
