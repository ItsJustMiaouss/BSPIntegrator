using BSPIntegrator.src;
using System.Diagnostics;

namespace BSPIntegrator
{
    public partial class Main : Form
    {
        public string? inputBSPPath, inputBSPFileName, outputBSPPath, contentFolderPath;
        public string bspIntegratorOutput = Path.GetTempPath() + @"\BSPIntegrator_output.txt";

        public Main()
        {
            InitializeComponent();
        }

        private async void SearchAllFiles(string directory)
        {
            if (outputBSPPath == "") { return; }

            string[] filesEntry = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            List<string> lines = new List<string>();

            foreach (string absolutePath in filesEntry)
            {
                string relativePath = absolutePath.Substring(directory.Length + 1); // +1 to remove the first "\"

                // BSPZip require to have a relative path and an absolute path.
                lines.Add(relativePath);
                lines.Add(absolutePath);
            }

            await File.WriteAllLinesAsync(bspIntegratorOutput, lines.ToArray());

            await ExecuteBSPZIP();

            MessageBox.Show("Finished!");
        }

        private async Task ExecuteBSPZIP()
        {
            string? bspZipPath = Utilities.GetBspZipPath();

            if (bspIntegratorOutput == null || !File.Exists(bspZipPath))
            {
                return;
            }

            string command = "-addlist " + inputBSPPath + " " + bspIntegratorOutput + " " + outputBSPPath;
            MessageBox.Show("bspzip.exe will execute this command:\n'bspzip.exe " + command + "'");

            Process bspZIPProcess = new Process();
            bspZIPProcess.StartInfo.FileName = bspZipPath;
            bspZIPProcess.StartInfo.Arguments = command;
            bspZIPProcess.Start();
            await bspZIPProcess.WaitForExitAsync().ConfigureAwait(false);
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
            sfd.FileName = string.IsNullOrEmpty(inputBSPFileName) ? "output.bsp" : inputBSPFileName.Replace(".bsp", "_o.bsp");

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
            if (inputBSPFileName == null)
            {
                MessageBox.Show("Please select an input BSP file.", "Error");
                return;
            }

            if (contentFolderPath == null)
            {
                MessageBox.Show("Please select a content folder.", "Error");
                return;
            }

            if (outputBSPPath == null)
            {
                MessageBox.Show("Please select an output BSP file.", "Error");
                return;
            }

            SearchAllFiles(contentFolderPath);
        }
    }
}
