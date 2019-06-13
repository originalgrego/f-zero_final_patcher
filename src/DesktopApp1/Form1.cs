using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DesktopApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void patch_Click(object sender, EventArgs e) {
            if (checkFZeroFile(fzeroFileText.Text) && checkGP2File(gp2FileText.Text)) {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                String directory = Directory.GetCurrentDirectory();
                cmd.StandardInput.WriteLine("copy " + fzeroFileText.Text + " " + directory + "\\F-Zero.sfc");
                cmd.StandardInput.WriteLine("copy " + gp2FileText.Text + " " + directory + "\\F-Zero_GP2.sfc");

                Process process = Process.Start("apply_patch.bat");
                process.WaitForExit();

                cmd.StandardInput.WriteLine("del " + getFolder(fzeroFileText.Text) + "F-Zero_Final.sfc");
                cmd.StandardInput.WriteLine("copy F-Zero_Final.sfc " + getFolder(fzeroFileText.Text) + "F-Zero_Final.sfc");
                cmd.StandardInput.WriteLine("del F-Zero_Final.sfc");
                cmd.StandardInput.Close();

                String result = cmd.StandardOutput.ReadToEnd();

                cmd.StandardOutput.Close();
                cmd.WaitForExit();

                MessageBox.Show("F-Zero Final patching was successful, created file:\n" + getFolder(fzeroFileText.Text) + "\\F-Zero_Final.sfc", "Success", MessageBoxButtons.OK);
            }
        }

        private void fzeroSelect_Click(object sender, EventArgs e) {
            String file = showOpenFileDialog("Select F-Zero File", "F-Zero USA File (*.sfc)|*.sfc");
            if (checkFZeroFile(file)) {
                fzeroFileText.Text = file;
            }
        }

        private bool checkFZeroFile(String file) {
            if (String.IsNullOrEmpty(file)) {
                showError("No F-Zero USA file chosen.");
                return false;
            }

            String crcString = getFileCRC(file);
            if (!crcString.Trim().Equals("0xAA0E31DE (524,288)")) {
                showError("Invalid F-Zero USA rom, must have CRC 0xAA0E31DE and a length of 524,288 bytes.\n\nThe chosen ROM:\n" + file + "\nhad CRC and length:\n" + crcString);
                return false;
            }
            return true;
        }

        private void gp2Select_Click(object sender, EventArgs e) {
            String file = showOpenFileDialog("Select F-Zero GP2 File", "F-Zero GP2 File (*.sfc)|*.sfc");
            if (checkGP2File(file)) {
                gp2FileText.Text = file;
            }
        }

        private bool checkGP2File(String file) {
            if (String.IsNullOrEmpty(file)) {
                showError("No F-Zero GP2 file chosen.");
                return false;
            }

            String crcString = getFileCRC(file);
            if (!crcString.Trim().Equals("0xC4808858 (1,048,576)")) {
                showError("Invalid F-Zero GP2 rom, must have CRC 0xC4808858 and a length of 1,048,576 bytes.\n\nThe chosen ROM:\n" + file + "\nhad CRC and length:\n" + crcString);
                return false;
            }
            return true;
        }

        public String getFileCRC(String file) {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("cd " + Directory.GetCurrentDirectory());
            cmd.StandardInput.WriteLine("crc32.exe " + file);
            cmd.StandardInput.Flush();

            String result = "";
            while (!result.Contains("crc32.exe")){
                result = cmd.StandardOutput.ReadLine();
            }
            result = cmd.StandardOutput.ReadLine();

            cmd.StandardInput.Close();
            cmd.StandardOutput.Close();
            cmd.WaitForExit();

            return result;
        }

        public static String showOpenFileDialog(String title, String fileType) {
            using (OpenFileDialog openDialog = new OpenFileDialog()) {
                openDialog.Title = title;
                openDialog.Filter = fileType;

                if (openDialog.ShowDialog() == DialogResult.OK) {
                    return openDialog.FileName;
                }
                return null;
            }
        }

        public static void showError(String message) {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static String getFolder(String fileName) {
            return fileName.Substring(0, fileName.LastIndexOf("\\") + 1);
        }
    }
}
