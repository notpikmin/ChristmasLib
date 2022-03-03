using System;
using System.IO;
using ChristmasLib.Utils;
using Newtonsoft.Json;

namespace ChristmasLib.Config
{
    public class ChristmasConfig
    {
        public string Name;
        private static string _configPath = "Christmas/";
        public Type ObjectType;
        public Action OnUpdate;
        
        public ChristmasConfig(string name,object configObject,Action onUpdate=null)
        {
            Name = name;
            if (onUpdate != null)
            {
                OnUpdate = onUpdate;
            }
            else
            {
                OnUpdate = () =>
                {
                    Load(configObject);
                };
            }
            
        }

        public T Load<T>( T fileObject)
        {
            string path = _configPath + Name;
            ObjectType = fileObject.GetType();
;           Init(fileObject);
            T file;
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


        public void Init(System.Object o)
        {
            if (!ConfigUtils.Configs.Contains(this))
            {
                ConfigUtils.Configs.Add(this);
            }
            Directory.CreateDirectory(_configPath);
            string path = _configPath + Name;
            if (!File.Exists(path))
            {
                string config = JsonConvert.SerializeObject(o, Formatting.Indented);
                File.WriteAllText(path, config);
            }
          
        }



    }
}