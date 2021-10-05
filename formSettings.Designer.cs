namespace Skyrim_Background_Injector
{
    partial class formSettings
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
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxSearchOnSubfolders = new System.Windows.Forms.CheckBox();
            this.checkBoxRandomizeInputImages = new System.Windows.Forms.CheckBox();
            this.comboBoxMaxParallelWorkers = new System.Windows.Forms.ComboBox();
            this.labelMaxParallelWorkers = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxSearchOnSubfolders);
            this.groupBoxSettings.Controls.Add(this.checkBoxRandomizeInputImages);
            this.groupBoxSettings.Controls.Add(this.comboBoxMaxParallelWorkers);
            this.groupBoxSettings.Controls.Add(this.labelMaxParallelWorkers);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(314, 95);
            this.groupBoxSettings.TabIndex = 0;
            this.groupBoxSettings.TabStop = false;
            // 
            // checkBoxSearchOnSubfolders
            // 
            this.checkBoxSearchOnSubfolders.AutoSize = true;
            this.checkBoxSearchOnSubfolders.Checked = true;
            this.checkBoxSearchOnSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSearchOnSubfolders.Location = new System.Drawing.Point(9, 69);
            this.checkBoxSearchOnSubfolders.Name = "checkBoxSearchOnSubfolders";
            this.checkBoxSearchOnSubfolders.Size = new System.Drawing.Size(200, 17);
            this.checkBoxSearchOnSubfolders.TabIndex = 4;
            this.checkBoxSearchOnSubfolders.Text = "Allow image search on subdirectories";
            this.checkBoxSearchOnSubfolders.UseVisualStyleBackColor = true;
            this.checkBoxSearchOnSubfolders.CheckedChanged += new System.EventHandler(this.checkBoxSearchOnSubfolders_CheckedChanged);
            // 
            // checkBoxRandomizeInputImages
            // 
            this.checkBoxRandomizeInputImages.AutoSize = true;
            this.checkBoxRandomizeInputImages.Checked = true;
            this.checkBoxRandomizeInputImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRandomizeInputImages.Location = new System.Drawing.Point(9, 46);
            this.checkBoxRandomizeInputImages.Name = "checkBoxRandomizeInputImages";
            this.checkBoxRandomizeInputImages.Size = new System.Drawing.Size(141, 17);
            this.checkBoxRandomizeInputImages.TabIndex = 3;
            this.checkBoxRandomizeInputImages.Text = "Randomize input images";
            this.checkBoxRandomizeInputImages.UseVisualStyleBackColor = true;
            this.checkBoxRandomizeInputImages.CheckedChanged += new System.EventHandler(this.checkBoxRandomizeInputImages_CheckedChanged);
            // 
            // comboBoxMaxParallelWorkers
            // 
            this.comboBoxMaxParallelWorkers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaxParallelWorkers.FormattingEnabled = true;
            this.comboBoxMaxParallelWorkers.Location = new System.Drawing.Point(125, 19);
            this.comboBoxMaxParallelWorkers.Name = "comboBoxMaxParallelWorkers";
            this.comboBoxMaxParallelWorkers.Size = new System.Drawing.Size(179, 21);
            this.comboBoxMaxParallelWorkers.TabIndex = 2;
            this.comboBoxMaxParallelWorkers.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaxParallelWorkers_SelectedIndexChanged);
            // 
            // labelMaxParallelWorkers
            // 
            this.labelMaxParallelWorkers.AutoSize = true;
            this.labelMaxParallelWorkers.Location = new System.Drawing.Point(6, 22);
            this.labelMaxParallelWorkers.Name = "labelMaxParallelWorkers";
            this.labelMaxParallelWorkers.Size = new System.Drawing.Size(107, 13);
            this.labelMaxParallelWorkers.TabIndex = 1;
            this.labelMaxParallelWorkers.Text = "Max Parallel Workers";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(245, 113);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(81, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(158, 113);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(12, 113);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(81, 23);
            this.buttonDefault.TabIndex = 5;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 148);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.formSettings_Load);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.CheckBox checkBoxRandomizeInputImages;
        private System.Windows.Forms.ComboBox comboBoxMaxParallelWorkers;
        private System.Windows.Forms.Label labelMaxParallelWorkers;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.CheckBox checkBoxSearchOnSubfolders;
    }
}