using Microsoft.Win32;

namespace BSPIntegrator.src
{
    internal class Utilities
    {

        /// <summary>
        ///   Gets the path to the steam installation.
        /// </summary>
        /// <returns>
        ///   Path of the Steam's installation, or null if doesn't exists.
        /// </returns>
        public static string? GetSteamPath()
        {
            string path;
            if (Environment.Is64BitProcess)
            {
                path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam";
            }
            else
            {
                path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam";
            }
            return (string?)Registry.GetValue(path, "InstallPath", null);
        }

        /// <summary>
        ///  Gets the path to the Garry's Mod installation.
        /// </summary>
        /// <returns>
        ///   Path of the Garry's Mod's installation, or null if doesn't exists.
        /// </returns>
        public static string? GetGarrysModPath()
        {
            string? steamPath = GetSteamPath();
            if (steamPath == null)
            {
                return null;
            }
            // Check if the path is valid.
            string garrysModPath = steamPath + @"\steamapps\common\GarrysMod\";
            if (!Directory.Exists(garrysModPath))
            {
                return null;
            }
            return garrysModPath;
        }


    }
}
