using System;
using System.Windows.Forms;

namespace Skyrim_Background_Injector
{
    public partial class formSettings : Form
    {
        private ConfigControl config;

        public formSettings(ConfigControl cc)
        {
            InitializeComponent();

            config = cc;
        }

        private void formSettings_Load(object sender, EventArgs e)
        {
            this.Icon = Skyrim_Background_Injector.Properties.Resources.icon_32x32;

            isInitialized = false;
            isConfigChanged = false;
            int maxValue = Environment.ProcessorCount;

            for (int i = 1; i < maxValue + 1; i++)
            {
                comboBoxMaxParallelWorkers.Items.Add(i.ToString());
            }

            comboBoxMaxParallelWorkers.SelectedIndex = Convert.ToInt32(config.ConfigDictionary["MaxParallelWorkers"]) - 1;
            checkBoxRandomizeInputImages.Checked = Convert.ToBoolean(config.ConfigDictionary["RandomizeInputImages"]);
            checkBoxSearchOnSubfolders.Checked = Convert.ToBoolean(config.ConfigDictionary["SearchOnSubfolders"]);

            isInitialized = true;
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            comboBoxMaxParallelWorkers.SelectedIndex = Environment.ProcessorCount - 1;

            checkBoxRandomizeInputImages.Checked = true;
            checkBoxSearchOnSubfolders.Checked = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean isInitialized;
        private Boolean isConfigChanged;
        
        private void comboBoxMaxParallelWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                isConfigChanged = true;
            }
        }

        private void checkBoxRandomizeInputImages_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                isConfigChanged = true;
            }
        }

        private void checkBoxSearchOnSubfolders_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                isConfigChanged = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (isInitialized && isConfigChanged)
            {
                config.ChangeConfig("MaxParallelWorkers", comboBoxMaxParallelWorkers.SelectedItem.ToString());
                config.ChangeConfig("RandomizeInputImages", checkBoxRandomizeInputImages.Checked.ToString().ToLower());
                config.ChangeConfig("SearchOnSubfolders", checkBoxSearchOnSubfolders.Checked.ToString().ToLower());
            }

            this.Close();
        }
    }
}
