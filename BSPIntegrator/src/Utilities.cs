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
        ///  Gets the path to BSPZip from the Garry's Mod folder.
        /// </summary>
        /// <returns>
        ///   Path of the BSPZip, or null if doesn't exists.
        /// </returns>
        public static string? GetBspZipPath()
        {
            string? bspZipPath = Properties.Settings.Default.bspZipPath;
            if (ValidateBspZipPath(bspZipPath)) return bspZipPath;

            string? gmodPath = GetSteamPath() + @"\steamapps\common\GarrysMod";

            bspZipPath = gmodPath + @"\bin\bspzip.exe";
            if (ValidateBspZipPath(bspZipPath))
            {
                Properties.Settings.Default.bspZipPath = bspZipPath;
                Properties.Settings.Default.gmodPath = gmodPath;
                Properties.Settings.Default.Save();
                return bspZipPath;
            };

            gmodPath = PromptForGmodPath();
            bspZipPath = gmodPath + @"\bin\bspzip.exe";
            if (ValidateBspZipPath(bspZipPath))
            {
                Properties.Settings.Default.bspZipPath = bspZipPath;
                Properties.Settings.Default.gmodPath = gmodPath;
                Properties.Settings.Default.Save();
                return bspZipPath;
            };

            MessageBox.Show("bspzip.exe cannot be found.", "Error");
            Environment.Exit(0);
            return null;
        }

        private static string? PromptForGmodPath()
        {
            MessageBox.Show(@"bspzip.exe cannot be found. Please select the Garry's Mod path (...\steamapps\common\GarrysMod).", "Error");

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }

            Environment.Exit(0);
            return null;
        }

        public static bool ValidateBspZipPath(string path)
        {
            return File.Exists(path) && path.Contains("GarrysMod");
        }

    }
}
