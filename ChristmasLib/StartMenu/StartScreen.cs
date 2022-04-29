using System;
using System.IO;
using System.Linq;
using System.Text;
using ChristmasLib.Asset;
using ChristmasLib.Utils;
using MelonLoader;

namespace ChristmasLib.StartMenu
{
    internal static class StartScreen
    {
        /*
        private static string _fileString1 = string.Join(Environment.NewLine
            , "[VersionText]"
            , "Style = \"Bold\""
            , "RichText = true"
            , "TextSize = 24"
            , "Scale = 1.0"
            , "LineSpacing = 1.0"
            , "TextColor = [ 255.0, 255.0, 255.0, 255.0, ]"
            , "Text = \" ChristmasLib v"+ MelonBuildInfo.Version+" Public\""
            , "Enabled = true"
            , "Position = [ 0, 16, ]"
            , "Size = [ 0, 0, ]"
            , "Anchor = \"MiddleCenter\""
            , "ScreenAnchor = \"MiddleCenter\"");
        */
        private static string _fileString = new StringBuilder(
            "[VersionText] \n"
            + "Style = \"Bold\" \n"
            + "RichText = true \n"
            + "TextSize = 24 \n"
            + "Scale = 1.0 \n"
            + "LineSpacing = 1.0 \n"
            + "TextColor = [ 255.0, 255.0, 255.0, 255.0, ] \n"
            + "Text = \" ChristmasLib v" + MelonBuildInfo.Version + " " +MelonBuildInfo.ReleaseVersion + " \" \n"
            + "Enabled = true \n"
            + "Position = [ 0, 16, ] \n"
            + "Size = [ 0, 0, ] \n"
            + "Anchor = \"MiddleCenter\" \n"
            + "ScreenAnchor = \"MiddleCenter\"").ToString();      
        
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

                //if any lines of the VersionText contain the current build return 
                //not the best method of checking
                if (File.ReadLines(Path.Combine(path, "VersionText.cfg"))
                    .Any(line => line.Contains(MelonBuildInfo.Version))) return;
                
                ConsoleUtils.Debug("Setting custom VersionText.cfg");
                File.WriteAllText(Path.Combine(path, "VersionText.cfg"), _fileString);
            }
            catch (Exception e)
            {
                ConsoleUtils.Error("Error customizing start screen: " + e.Message);
            }
        }
    }
}