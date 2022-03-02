using System.IO;
using ChristmasLib.Utils;
using Newtonsoft.Json;

namespace ChristmasLib.Config
{
    public class ChristmasConfig
    {
        public string Name;
        public ChristmasConfig(string name)
        {
            Name = name;
        }

        public T Load<T>(string fileName, T fileObject)
        {
            string path = _configPath + fileName;

            Init(fileName, fileObject);
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

        private static string _configPath = "Christmas/";

        public void Init(string fileName, System.Object o)
        {
            
            Directory.CreateDirectory(_configPath);
            string path = _configPath + fileName;
            if (!File.Exists(path))
            {
                string config =   JsonConvert.SerializeObject(o, Formatting.Indented);
                File.WriteAllText(path, config);
            }
          
        }


        public void FileSystemWatcher()
        {
             var watcher = new FileSystemWatcher(_configPath);
             watcher.NotifyFilter = NotifyFilters.Attributes
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.FileName
                                    | NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Security
                                    | NotifyFilters.Size;

             watcher.Changed += OnChanged;
             watcher.Error += OnError;

             watcher.Filter = "*.json";
             watcher.IncludeSubdirectories = false;
             watcher.EnableRaisingEvents = true;

        }
        
        private  void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            ConsoleUtils.Debug($"Changed: {e.FullPath}");
        }

        private  void OnError(object sender, ErrorEventArgs e)
        {
            ConsoleUtils.Error(e.GetException().Message);
        }

    }
}