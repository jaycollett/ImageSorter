using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSorter
{
    public partial class frmFolderSettings : Form
    {
        public frmFolderSettings()
        {
            InitializeComponent();
        }

        private void BtnBrowseUnsortedPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                txtUnsortedImagesPath.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                // make sure the unsorted folder exists already
                if (!Directory.Exists(txtUnsortedImagesPath.Text))
                {
                    MessageBox.Show("The directory specified for the unsorted images does not appear to exist, please make sure the folder exists and contains your unsorted images.", "Unsorted Directory Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    AddOrUpdateAppSettings("UnsortedImagesPath", txtUnsortedImagesPath.Text);
                }

                // quick hack to validate all the input for the 10 sort folders...
                for (int i = 1; i <= 10; i++)
                {
                    Control sortedFolderLabel = this.Controls["txtSortFolderLabel" + i.ToString()];
                    Control sortedFolderPath = this.Controls["txtSortFolderPath" + i.ToString()];

                    if(sortedFolderLabel.Text.Length<=0 && sortedFolderPath.Text.Length > 0)
                    {
                        MessageBox.Show($"Please provide a label for sort folder #{i}", $"Input error with sort folder #{i} label", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    }else if (sortedFolderLabel.Text.Length > 0 && sortedFolderPath.Text.Length <= 0)
                    {
                        MessageBox.Show($"Please provide a path for sort folder #{i}", $"Input error with sort folder #{i} path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        // looks like the user provide some valid input, let's save it out to the app config file
                        AddOrUpdateAppSettings($"SortFolderLabel{i}", sortedFolderLabel.Text);
                        AddOrUpdateAppSettings($"SortFolderPath{i}", sortedFolderPath.Text);
                    }
                }
                this.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "ERROR", MessageBoxButtons.OK);
            }
        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void FrmFolderSettings_Load(object sender, EventArgs e)
        {
            // load unsorted folder path from settings
            this.txtUnsortedImagesPath.Text = ConfigurationManager.AppSettings["UnsortedImagesPath"];

            // loop through all 10 sort folders and populate the paths and labels
            for (int i = 1; i <= 10; i++)
            {
                Control sortedFolderLabel = this.Controls["txtSortFolderLabel" + i.ToString()];
                Control sortedFolderPath = this.Controls["txtSortFolderPath" + i.ToString()];

                sortedFolderLabel.Text = ConfigurationManager.AppSettings[$"SortFolderLabel{i}"];
                sortedFolderPath.Text = ConfigurationManager.AppSettings[$"SortFolderPath{i}"];
            }
        }

        private void BtnSortFolder1Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath1.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath2.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath3.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath4.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath5.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath6.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath7.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath8.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath9.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void BtnSortFolderPath10_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSortFolderPath10.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
    }
}
