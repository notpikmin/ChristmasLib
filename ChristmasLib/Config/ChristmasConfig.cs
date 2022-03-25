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

        public T Load<T>( T fileObject)
        {
            string path = _configPath + Name;
            ObjectType = fileObject.GetType();
;           Init(fileObject);
            T file;
            try
            {
                string fileString = File.ReadAllText(path);
                file = JsonConvert.DeserializeObject<T>(fileString);
            }
            catch
            {
                ConsoleUtils.Error("Failed to load config");
                file = default;
            }
            
            return file;
        }
  
        public void Init(Object o)
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

        
        //static version needs a complete rewrite 
        public static T Load<T>( T fileObject, string name)
        {
            string path = _configPath + name;
         
            Init(fileObject,name);
            T file;
            try
            {
                string fileString = File.ReadAllText(path);
                file = JsonConvert.DeserializeObject<T>(fileString);
            }
            catch
            {
                ConsoleUtils.Error("Failed to load config");
                file = default;
            }
            
            return file;
        }
        public static void Init(Object o,string name)
        {
            
            Directory.CreateDirectory(_configPath);
            string path = _configPath + name;
            if (!File.Exists(path))
            {
                string config = JsonConvert.SerializeObject(o, Formatting.Indented);
                File.WriteAllText(path, config);
            }
          
        }

        #endregion
        
    }
}