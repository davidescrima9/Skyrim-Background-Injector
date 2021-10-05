using CustomUI.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Skyrim_Background_Injector
{
    public partial class formMain : CustomForm
    {
        ConfigControl config = new ConfigControl();
        
        public formMain()
        {
            InitializeComponent();
        }
        
        private void initializeFolder(string outputDdsFolder)
        {
            Directory.CreateDirectory(outputDdsFolder);
        }

        private void enableForm()
        {
            buttonProcess.Enabled = true;
            textBoxInputFolder.Enabled = true;
            textBoxOutputDdsFolder.Enabled = true;
            buttonBrowseInputImageFolder.Enabled = true;
            buttonBrowseOutputDdsFolder.Enabled = true;
            buttonSettings.Enabled = true;
        }

        private void disableForm()
        {
            buttonProcess.Enabled = false;
            textBoxInputFolder.Enabled = false;
            textBoxOutputDdsFolder.Enabled = false;
            buttonBrowseInputImageFolder.Enabled = false;
            buttonBrowseOutputDdsFolder.Enabled = false;
            buttonSettings.Enabled = false;
        }

        private async void buttonProcess_Click(object sender, EventArgs e)
        {
            // Disable process button
            disableForm();

            progressBarProcess.CurrentValue = 0;

            // Start watch to measure function time
            Stopwatch sw = Stopwatch.StartNew();


            // Max Threads Count
            Boolean isMaxParallelWorkersValid = System.Text.RegularExpressions.Regex.Match(config.ConfigDictionary["MaxParallelWorkers"], @"^[1-9][0-9]{0,2}$").Success;

            if (!isMaxParallelWorkersValid)
            {
                MessageBox.Show("[PROC-01] MaxThreadsCount value not valid!\nPlease use a non-negative Integer value.\nMin value: 1\nMax value: 999", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateStatus("Error");
                enableForm();
                return;
            }

            int maxParallelWorkers = Convert.ToInt32(config.ConfigDictionary["MaxParallelWorkers"]);


            // Folders
            String inputImageFolder = config.ConfigDictionary["InputImageFolder"];
            String outputDdsFolder = config.ConfigDictionary["OutputDDSFolder"];

            if (!IsValidPath(inputImageFolder))
            {
                MessageBox.Show($"[PROC-02] Input image folder not valid!\nNote: relative paths are not accepted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateStatus("Error");
                enableForm();
                return;
            }

            if (!IsValidPath(outputDdsFolder))
            {
                MessageBox.Show($"[PROC-03] Output DDS folder not valid!\nNote: relative paths are not accepted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateStatus("Error");
                enableForm();
                return;
            }


            // Initialize folders
            updateStatus("Initializing Output Folder...");
            progressBarProcess.CurrentValue += 1;
            initializeFolder(outputDdsFolder);
            initializeFolder($@"{outputDdsFolder}\LoadScreen by mAttii");
            initializeFolder($@"{outputDdsFolder}\objects");


            // Validating images
            // Features:
            //  - .jpg, .jpeg, .png, .bmp files
            //  - width >= 1920
            //  - height >= 1080
            //  - scrumble list
            updateStatus("Validating input images...");
            progressBarProcess.CurrentValue += 1;

            Random randomizer = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());

            List<String> inputFiles = new List<String>();

            SearchOption searchOption = Convert.ToBoolean(config.ConfigDictionary["SearchOnSubfolders"]) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            Boolean randomizeInput = Convert.ToBoolean(config.ConfigDictionary["RandomizeInputImages"]);

            await Task.Factory.StartNew(() =>
                inputFiles = Directory.GetFiles(inputImageFolder, "*.*", searchOption).Where(x =>
                {
                    return x.EndsWith(".png") || x.EndsWith(".jpg") || x.EndsWith(".jpeg") || x.EndsWith(".bmp");
                }).Where(x =>
                {
                    Size imageSize = ImageControl.GetImageSize(x);

                    return (imageSize.Width >= 1920 && imageSize.Height >= 1080);

                }).ToList()
            );

            if (randomizeInput)
            {
                inputFiles = inputFiles.OrderBy(x => randomizer.Next()).ToList();
            }

            if (inputFiles.Count < 201)
            {
                MessageBox.Show($"[PROC-04] You need at least 201 images to start the process!\nValid images processed: {inputFiles.Count}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateStatus("Error");
                enableForm();
                return;
            }

            // Preparing workers
            updateStatus("Preparing Workers...");
            progressBarProcess.CurrentValue += 1;

            List<WorkerModel> workersInfoList = new List<WorkerModel>(201);

            for (int i = 1; i < 201; i++)
            {
                workersInfoList.Add(new WorkerModel(inputFiles[i], $@"{outputDdsFolder}\LoadScreen by mAttii\LoadScreen_{i}.dds"));
            }

            workersInfoList.Add(new WorkerModel(inputFiles[0], $@"{outputDdsFolder}\objects\MAINMENUWALLPAPER.dds"));


            // Starting workers
            updateStatus("Processing Workers...");
            progressBarProcess.CurrentValue += 1;

            using (ImageControl ic = new ImageControl())
            {
                await Task.Factory.StartNew(() =>
                   Parallel.For(0, workersInfoList.Count, new ParallelOptions { MaxDegreeOfParallelism = maxParallelWorkers }, (i) =>
                   {
                       ic.ProcessImageToDds(workersInfoList[i].InputImagePath, workersInfoList[i].OutputDdsFolder);

                       MethodInvoker mi = new MethodInvoker(() => progressBarProcess.CurrentValue += 1);
                       if (progressBarProcess.InvokeRequired)
                       {
                           progressBarProcess.Invoke(mi);
                       }
                       else
                       {
                           mi.Invoke();
                       }
                   })
               );
            }

            // Done
            sw.Stop();
            var timeElapsedSeconds = sw.ElapsedMilliseconds / 1000;

            updateStatus($"Done in {timeElapsedSeconds}s");
            progressBarProcess.CurrentValue += 1;
            enableForm();
        }

        private bool IsValidPath(string path, bool allowRelativePaths = false)
        {
            bool isValid;

            try
            {
                string fullPath = Path.GetFullPath(path);

                if (allowRelativePaths)
                {
                    isValid = Path.IsPathRooted(path);
                }
                else
                {
                    string root = Path.GetPathRoot(path);
                    isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }

        private void updateStatus(String status)
        {
            labelStatusDescription.Text = status;
            Application.DoEvents();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            this.Icon = Skyrim_Background_Injector.Properties.Resources.icon_32x32;

            config.BeginInitialize();

            config.LoadConfig();

            textBoxInputFolder.Text = config.ConfigDictionary["InputImageFolder"];
            textBoxOutputDdsFolder.Text = config.ConfigDictionary["OutputDDSFolder"];

            config.EndInitialize();
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.SaveConfig();
        }

        private void textBoxInputFolder_TextChanged(object sender, EventArgs e)
        {
            if (config.IsInitialized)
            {
                config.ChangeConfig("InputImageFolder", textBoxInputFolder.Text);
            }
        }

        private void textBoxOutputDdsFolder_TextChanged(object sender, EventArgs e)
        {
            if (config.IsInitialized)
            {
                config.ChangeConfig("OutputDDSFolder", textBoxOutputDdsFolder.Text);
            }
        }

        private void buttonBrowseInputImageFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialogInputImageFolder.SelectedPath = config.ConfigDictionary["InputImageFolder"];

            if (folderBrowserDialogInputImageFolder.ShowDialog() == DialogResult.OK)
            {
                textBoxInputFolder.Text = folderBrowserDialogInputImageFolder.SelectedPath;
            }
        }

        private void buttonBrowseOutputDdsFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialogOutputDdsFolder.SelectedPath = config.ConfigDictionary["OutputDDSFolder"];

            if (folderBrowserDialogOutputDdsFolder.ShowDialog() == DialogResult.OK)
            {
                textBoxOutputDdsFolder.Text = folderBrowserDialogOutputDdsFolder.SelectedPath;
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            formSettings fs = new formSettings(config);
            fs.ShowDialog();
        }
    }
}
