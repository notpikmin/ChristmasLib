using System;
using System.IO;
using ChristmasLib.Utils;
using Newtonsoft.Json;

namespace ChristmasLib.Config
{
    public class ChristmasConfig
    {
        public string Name;
        private const string ConfigPath = "Christmas/";
        public Type ObjectType;
        public Action OnUpdate;
        
        public ChristmasConfig(string name,Action onUpdate)
        {
            Name = name;
            if (onUpdate != null)
            {
                OnUpdate = onUpdate;
            }
            else
            {
               ConsoleUtils.Warning(name + " has no onUpdate action.");
            }
            
        }

        #region Loading

        public T Load<T>( T fileObject, bool writeFiles = false)
        {
            string path = ConfigPath + Name;
            ObjectType = fileObject.GetType();
            Init(fileObject);
            T file;
            try
            {
                string fileString = File.ReadAllText(path);
                file = JsonConvert.DeserializeObject<T>(fileString);
                if (writeFiles)
                {
                    string config = JsonConvert.SerializeObject(file, Formatting.Indented);
                    File.WriteAllText(path, config);
                }
            }
            catch
            {
                ConsoleUtils.Error("Failed to load config");
                file = default;
            }
            
            return file;
        }
  
        public void Init(object o)
        {
            if (!ConfigUtils.Configs.Contains(this))
            {
                ConfigUtils.Configs.Add(this);
            }
            Directory.CreateDirectory(ConfigPath);
            string path = ConfigPath + Name;
            if (File.Exists(path)) return;
            
            string config = JsonConvert.SerializeObject(o, Formatting.Indented);
            File.WriteAllText(path, config);

        }

        
        //static version needs a complete rewrite 
        public static T Load<T>( T fileObject, string name, bool writeFiles = false)
        {
            string path = ConfigPath + name;
         
            Init(fileObject,name);
            T file;
            try
            {
                string fileString = File.ReadAllText(path);
                file = JsonConvert.DeserializeObject<T>(fileString);
                if (writeFiles)
                {
                    string config = JsonConvert.SerializeObject(file, Formatting.Indented);
                    File.WriteAllText(path, config);
                }
            }
            catch
            {
                ConsoleUtils.Error("Failed to load config");
                file = default;
            }
            
            return file;
        }
        public static void Init(object o,string name)
        {
            
            Directory.CreateDirectory(ConfigPath);
            string path = ConfigPath + name;
            if (File.Exists(path)) return;
            string config = JsonConvert.SerializeObject(o, Formatting.Indented);
            File.WriteAllText(path, config);

        }

        #endregion
        
    }
}