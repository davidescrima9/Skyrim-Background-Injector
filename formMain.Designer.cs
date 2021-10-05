namespace Skyrim_Background_Injector
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialogInputImageFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogOutputDdsFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.labelOutputDdsFolder = new CustomUI.Controls.CustomLabel();
            this.textBoxInputFolder = new CustomUI.Controls.CustomTextBox();
            this.labelInputFolder = new CustomUI.Controls.CustomLabel();
            this.buttonProcess = new CustomUI.Controls.CustomButton();
            this.textBoxOutputDdsFolder = new CustomUI.Controls.CustomTextBox();
            this.buttonBrowseInputImageFolder = new CustomUI.Controls.CustomButton();
            this.buttonBrowseOutputDdsFolder = new CustomUI.Controls.CustomButton();
            this.labelStatusDescription = new CustomUI.Controls.CustomLabel();
            this.progressBarProcess = new CustomUI.Controls.CustomProgressBar();
            this.buttonSettings = new CustomUI.Controls.CustomButton();
            this.groupBox1 = new CustomUI.Controls.CustomGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOutputDdsFolder
            // 
            this.labelOutputDdsFolder.AutoSize = true;
            this.labelOutputDdsFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelOutputDdsFolder.Location = new System.Drawing.Point(6, 45);
            this.labelOutputDdsFolder.Name = "labelOutputDdsFolder";
            this.labelOutputDdsFolder.Size = new System.Drawing.Size(124, 17);
            this.labelOutputDdsFolder.TabIndex = 4;
            this.labelOutputDdsFolder.Text = "Output DDS folder";
            // 
            // textBoxInputFolder
            // 
            this.textBoxInputFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textBoxInputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInputFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxInputFolder.Location = new System.Drawing.Point(106, 16);
            this.textBoxInputFolder.Name = "textBoxInputFolder";
            this.textBoxInputFolder.Size = new System.Drawing.Size(362, 22);
            this.textBoxInputFolder.TabIndex = 2;
            this.textBoxInputFolder.TextChanged += new System.EventHandler(this.textBoxInputFolder_TextChanged);
            // 
            // labelInputFolder
            // 
            this.labelInputFolder.AutoSize = true;
            this.labelInputFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelInputFolder.Location = new System.Drawing.Point(6, 19);
            this.labelInputFolder.Name = "labelInputFolder";
            this.labelInputFolder.Size = new System.Drawing.Size(79, 17);
            this.labelInputFolder.TabIndex = 1;
            this.labelInputFolder.Text = "Input folder";
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(425, 236);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Padding = new System.Windows.Forms.Padding(5);
            this.buttonProcess.Size = new System.Drawing.Size(93, 23);
            this.buttonProcess.TabIndex = 10;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // textBoxOutputDdsFolder
            // 
            this.textBoxOutputDdsFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textBoxOutputDdsFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOutputDdsFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxOutputDdsFolder.Location = new System.Drawing.Point(106, 42);
            this.textBoxOutputDdsFolder.Name = "textBoxOutputDdsFolder";
            this.textBoxOutputDdsFolder.Size = new System.Drawing.Size(362, 22);
            this.textBoxOutputDdsFolder.TabIndex = 5;
            this.textBoxOutputDdsFolder.TextChanged += new System.EventHandler(this.textBoxOutputDdsFolder_TextChanged);
            // 
            // buttonBrowseInputImageFolder
            // 
            this.buttonBrowseInputImageFolder.Location = new System.Drawing.Point(474, 16);
            this.buttonBrowseInputImageFolder.Name = "buttonBrowseInputImageFolder";
            this.buttonBrowseInputImageFolder.Padding = new System.Windows.Forms.Padding(5);
            this.buttonBrowseInputImageFolder.Size = new System.Drawing.Size(26, 20);
            this.buttonBrowseInputImageFolder.TabIndex = 3;
            this.buttonBrowseInputImageFolder.Text = "...";
            this.buttonBrowseInputImageFolder.Click += new System.EventHandler(this.buttonBrowseInputImageFolder_Click);
            // 
            // buttonBrowseOutputDdsFolder
            // 
            this.buttonBrowseOutputDdsFolder.Location = new System.Drawing.Point(474, 41);
            this.buttonBrowseOutputDdsFolder.Name = "buttonBrowseOutputDdsFolder";
            this.buttonBrowseOutputDdsFolder.Padding = new System.Windows.Forms.Padding(5);
            this.buttonBrowseOutputDdsFolder.Size = new System.Drawing.Size(26, 20);
            this.buttonBrowseOutputDdsFolder.TabIndex = 6;
            this.buttonBrowseOutputDdsFolder.Text = "...";
            this.buttonBrowseOutputDdsFolder.Click += new System.EventHandler(this.buttonBrowseOutputDdsFolder_Click);
            // 
            // labelStatusDescription
            // 
            this.labelStatusDescription.AutoSize = true;
            this.labelStatusDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelStatusDescription.Location = new System.Drawing.Point(12, 214);
            this.labelStatusDescription.Name = "labelStatusDescription";
            this.labelStatusDescription.Size = new System.Drawing.Size(119, 17);
            this.labelStatusDescription.TabIndex = 8;
            this.labelStatusDescription.Text = "Ready to process";
            // 
            // progressBarProcess
            // 
            this.progressBarProcess.CurrentValue = 0;
            this.progressBarProcess.Location = new System.Drawing.Point(12, 185);
            this.progressBarProcess.Maximum = 206;
            this.progressBarProcess.Name = "progressBarProcess";
            this.progressBarProcess.Size = new System.Drawing.Size(506, 23);
            this.progressBarProcess.TabIndex = 7;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(326, 236);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(5);
            this.buttonSettings.Size = new System.Drawing.Size(93, 23);
            this.buttonSettings.TabIndex = 9;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox1.Controls.Add(this.labelInputFolder);
            this.groupBox1.Controls.Add(this.textBoxInputFolder);
            this.groupBox1.Controls.Add(this.labelOutputDdsFolder);
            this.groupBox1.Controls.Add(this.textBoxOutputDdsFolder);
            this.groupBox1.Controls.Add(this.buttonBrowseOutputDdsFolder);
            this.groupBox1.Controls.Add(this.buttonBrowseInputImageFolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Skyrim_Background_Injector.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 100);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // formMain
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(530, 271);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.progressBarProcess);
            this.Controls.Add(this.labelStatusDescription);
            this.Controls.Add(this.buttonProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Text = "Skyrim Background Injector v0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogInputImageFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOutputDdsFolder;
        private CustomUI.Controls.CustomLabel labelOutputDdsFolder;
        private CustomUI.Controls.CustomTextBox textBoxInputFolder;
        private CustomUI.Controls.CustomLabel labelInputFolder;
        private CustomUI.Controls.CustomButton buttonProcess;
        private CustomUI.Controls.CustomTextBox textBoxOutputDdsFolder;
        private CustomUI.Controls.CustomButton buttonBrowseInputImageFolder;
        private CustomUI.Controls.CustomButton buttonBrowseOutputDdsFolder;
        private CustomUI.Controls.CustomLabel labelStatusDescription;
        private CustomUI.Controls.CustomProgressBar progressBarProcess;
        private CustomUI.Controls.CustomButton buttonSettings;
        private CustomUI.Controls.CustomGroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

