
using System.IO;
using ChristmasLib.Asset;
using MelonLoader;

namespace ChristmasLib.StartMenu
{
    static internal class StartScreen
    {
        public static void Start()
        {
            string path = Path.Combine(MelonUtils.UserDataDirectory, "MelonStartScreen/Themes/Default");
            if (!File.Exists(Path.Combine(path,"Logo.png")))
            {
                DownloadHandler.DownloadFileSync("https://files.catbox.moe/pav8tr.png",Path.Combine(path,"Logo.png"));
            }
          
        }
    }
}
