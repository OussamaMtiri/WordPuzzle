using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WordPuzzle;

namespace WordPuzzleTests
{
    public class Tools
    {
        public static IOptions<MySettings> GetAppSettingOptions()
        {
            string appsettingsJson = File.ReadAllText($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\appsettingsTest.json");
            var mySetting = JsonSerializer.Deserialize<MySettings>(appsettingsJson);
            return Options.Create(mySetting);
        }
    }
}
