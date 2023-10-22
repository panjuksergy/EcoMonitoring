using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SparkSwim.GoodsService.ShortenerService
{
    public class DefaultShortener : IShortener
    {
        public string GenerateShortUrlHash()
        {
            var symbols = "abcdefghijklmnopqrstuvwxyz".ToList();
            var random = new Random();
            var result = new List<char>();

            string defaultWay = "https://localhost:5001";

            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(symbols.Count);
                result.Add(symbols[index]);
                symbols.RemoveAt(index);
            }
            
            // using var file = File.OpenText("Properties/launchSettings.json");
            // using var reader = new JsonTextReader(file);
            // var jObject = JObject.Load(reader);
            //
            // var profiles = jObject.GetValue("profiles");
            // var yourProfile = profiles.SelectToken("SparkSwim.GoodsService");
            //
            // if (yourProfile != null)
            // {
            //     var applicationUrl = yourProfile.SelectToken("applicationUrl")?.Value<string>();
            //     defaultWay = applicationUrl;
            // }
            //
            
            return defaultWay+$"/sl/{String.Join("", result)}";
        }
    }
}