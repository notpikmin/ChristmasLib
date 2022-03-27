using System;
using System.IO;
using System.Linq;
using ChristmasLib.Asset;
using ChristmasLib.Utils;
using MelonLoader;

namespace ChristmasLib.StartMenu
{
    static internal class StartScreen
    {
        private static string _fileString = string.Join(Environment.NewLine
            , "[VersionText]"
            , "Style = \"Bold\""
            , "RichText = true"
            , "TextSize = 24"
            , "Scale = 1.0"
            , "LineSpacing = 1.0"
            , "TextColor = [ 255.0, 255.0, 255.0, 255.0, ]"
            , "Text = \" ChristmasLib v"+ MelonBuildInfo.Version+" Closed Beta\""
            , "Enabled = true"
            , "Position = [ 0, 16, ]"
            , "Size = [ 0, 0, ]"
            , "Anchor = \"MiddleCenter\""
            , "ScreenAnchor = \"MiddleCenter\"");


        public static void Start()
        {
            try
            {
                string path = Path.Combine(MelonUtils.UserDataDirectory, "MelonStartScreen/Themes/Default");
                if (!File.Exists(Path.Combine(path, "Logo.png")))
                {
                    DownloadHandler.DownloadFileSync("https://files.catbox.moe/pav8tr.png",
                        Path.Combine(path, "Logo.png"));
                }


                if (!File.ReadLines(Path.Combine(path, "VersionText.cfg"))
                        .Any(line => line.Contains(MelonBuildInfo.Version)))
                {
                    ConsoleUtils.Debug("Setting custom VersionText.cfg");
                    File.WriteAllText(Path.Combine(path, "VersionText.cfg"), _fileString);

                }
            }
            catch (Exception e)
            {
                ConsoleUtils.Error("Error customizing start screen: " + e.Message);
            }
        }
    }
}