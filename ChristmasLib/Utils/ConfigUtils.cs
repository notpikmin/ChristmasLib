using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristmasLib.Utils;
namespace ChristmasLib.Utils
{
    public static class ConfigUtils
    {


        public static T Load<T>(string path, T FileObject)
        {
            Init(path, FileObject);
            T file = default(T);
            try
            {
                string fstring = File.ReadAllText(path);
                file = JsonConvert.DeserializeObject<T>(fstring);
            }
            catch
            {
                ConsoleUtils.Error("Failed to load config");
                file = default(T);
            }
            
            return file;
        }

        public static void Init(string path, Object o)
        {
            if (!File.Exists(path))
            {
                string config =   JsonConvert.SerializeObject(o, Formatting.Indented);
                File.WriteAllText(path, config);
            }
          
        }

    }
}
