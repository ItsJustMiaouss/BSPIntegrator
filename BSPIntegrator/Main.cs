using BSPIntegrator.src;
using System.Diagnostics;

namespace BSPIntegrator
{
    public partial class Main : Form
    {
        public string? BSPZipPath = Utilities.GetGarrysModPath() + @"\bin\bspzip.exe";
        public string? inputBSPPath, inputBSPFileName, outputBSPPath, contentFolderPath;
        public string bspIntegratorOutput = Path.GetTempPath() + @"\BSPIntegrator_output.txt";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Check if Steam and Garry's Mod are installed.
            if (Utilities.GetSteamPath() == null || Utilities.GetGarrysModPath() == null)
            {
                MessageBox.Show("Steam or Garry's Mod not found. Please install them before using this program.", "Error");
                Environment.Exit(0);
            }

            // Check if bspzip.exe exists.
            if (!File.Exists(BSPZipPath))
            {
                MessageBox.Show("bspzip.exe cannot be found. Please install Garry's Mod (WITHOUT USING A BETA VERSION) before using this program.", "Error");
                Environment.Exit(0);
            }
        }

        private async void SearchAllFiles(string directory)
        {
            if (outputBSPPath == "") { return; }

            string[] filesEntry = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            List<string> lines = new List<string>();

            foreach (string absolutePath in filesEntry)
            {
                string relativePath = absolutePath.Substring(directory.Length + 1); // +1 to remove the first "\"
                // dataGridView1.Rows.Add(absolutePath, relativePath);

                // BSPZip require to have a relative path and an absolute path.
                lines.Add(relativePath);
                lines.Add(absolutePath);
            }

            await File.WriteAllLinesAsync(bspIntegratorOutput, lines.ToArray());

            MessageBox.Show("Finished!");

            ExecuteBSPZIP();
        }

        private void ExecuteBSPZIP()
        {
            if (bspIntegratorOutput == null || !File.Exists(BSPZipPath))
            {
                return;
            }

            string command = "-addlist " + inputBSPPath + " " + bspIntegratorOutput + " " + outputBSPPath;
            MessageBox.Show("BSPZip will execute this command:\n'" + command + "'");

            Process bspZIPProcess = new Process();
            bspZIPProcess.StartInfo.FileName = BSPZipPath;
            bspZIPProcess.StartInfo.Arguments = command;
            bspZIPProcess.Exited += BspZIPProcess_Exited;
            bspZIPProcess.Start();
        }

        private void BspZIPProcess_Exited(object? sender, EventArgs e)
        {
            MessageBox.Show("Okay!");
        }

        private void inputBSPButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Binary Space Partition|*.bsp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inputBSPTextbox.Text = ofd.FileName;
                inputBSPPath = ofd.FileName;
                inputBSPFileName = ofd.SafeFileName;
            }
        }

        private void outputBSPButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = "bsp";
            sfd.Filter = "Binary Space Partition|*.bsp";
            sfd.FileName = inputBSPFileName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                outputBSPTextbox.Text = sfd.FileName;
                outputBSPPath = sfd.FileName;
            }
        }

        private void contentFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fwd = new FolderBrowserDialog();

            if (fwd.ShowDialog() == DialogResult.OK)
            {
                contentFolderTextbox.Text = fwd.SelectedPath;
                contentFolderPath = fwd.SelectedPath;
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            if (contentFolderPath == null)
            {
                MessageBox.Show("Please select a content folder.", "Error");
                return;
            }

            // dataGridView1.Rows.Clear();
            SearchAllFiles(contentFolderPath);



            /*MessageBox.Show(bspZIPPath);
            Process.Start("cmd.exe", @"/c pause");*/
        }
    }
}
