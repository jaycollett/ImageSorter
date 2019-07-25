﻿using System;
using System.Collections.Generic;
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
    public partial class frmMain : Form
    {
        private List<string> unsortedImageFiles;
        private int imageListCurrentPos;
        private List<MemoryStream> imagesCache;

        public frmMain()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void FolderSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFolderSettings settingsForm = new frmFolderSettings();
            this.AddOwnedForm(settingsForm);
            settingsForm.Show();
        }

        private void BeginSortingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // update statusbar
            this.toolStripStatusLabel1.Text = "RUNNING";
            

            // validate the unsorted folder exist and there is at least one image in it
            if(!Directory.Exists(ConfigurationManager.AppSettings["UnsortedImagesPath"])){
                MessageBox.Show("It appears you have specified a unsorted image folder that does not exist.", "Unsorted Image Folder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.toolStripStatusLabel1.Text = "IDLE";
                this.toolStripStatusLabel2.Text = "";
                return;
            }

            // load images from the unsorted path
            this.toolStripStatusLabel2.Text = $"Loading images from {ConfigurationManager.AppSettings["UnsortedImagesPath"]}";
            LoadImages();

            if (unsortedImageFiles.Count<string>() <= 0)
            {
                MessageBox.Show("No supported images exist in the specified unsorted image folder.", "Unsorted Image Folder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.toolStripStatusLabel1.Text = "IDLE";
                this.toolStripStatusLabel2.Text = "";
                return;
            }

            this.btnSkip.Visible = true;
            this.beginSortingToolStripMenuItem.Enabled = false;
            // loop through all 10 sort folders and populate the paths and labels
            int t = 1;
            for (int i = 1; i <= 10; i++)
            {
               string buttonLabel = ConfigurationManager.AppSettings[$"SortFolderLabel{i}"];
               if (buttonLabel.Length > 0)
                {
                    Control sortButton = this.Controls["btnSort" + t.ToString()];
                    sortButton.Text = ConfigurationManager.AppSettings[$"SortFolderLabel{i}"];
                    sortButton.Visible = true;
                    t++;
                }
            }

            // load the first image to kick off the sorting...
            LoadNextImage();
        }

        private void LoadImages()
        {
            imagesCache = new List<MemoryStream>();

            imageListCurrentPos = 0;
            unsortedImageFiles = Directory.EnumerateFiles(ConfigurationManager.AppSettings["UnsortedImagesPath"], "*.*", SearchOption.AllDirectories)
             .Where(s => s.EndsWith(".jpg")
                     || s.EndsWith(".jpeg")
                     || s.EndsWith(".gif")
                     || s.EndsWith(".png")
                     || s.EndsWith(".bmp")
                     || s.EndsWith(".jfif")
             ).ToList();

            // now load the first x (specified by user) images into a memory stream list
            for(int t = 0; t < 10; t++)
            {
                imagesCache.Add(new MemoryStream(File.ReadAllBytes(unsortedImageFiles[t])));
                imageListCurrentPos++;
            }
        }

        private async Task<bool> LoadNextImage()
        {
            if (imageListCurrentPos >= unsortedImageFiles.Count)
            {
                this.pictureBox1.ImageLocation = "";
                this.toolStripStatusLabel2.Text = "";
                ///TODO: clean up this message
                MessageBox.Show("No more images to show...");
                this.toolStripStatusLabel1.Text = "IDLE";
                this.beginSortingToolStripMenuItem.Enabled = true;
                ///TODO: add logic to ask user if they want to refresh image list
                /// which will pick up new images and the skipped ones as well (as they'll be in the folder still)
            }
            else
            {
                // show image from cache
                ///TODO: load image from cache to picturebox
                ///

                // load next image from memory stream array
                this.toolStripStatusLabel2.Text = $"Loading image: {unsortedImageFiles[imageListCurrentPos]}";
                this.pictureBox1.Image = Image.FromStream(imagesCache.FirstOrDefault<MemoryStream>());
                imagesCache.RemoveAt(0);
                this.toolStripStatusLabel2.Text = $"Image loaded: {unsortedImageFiles[imageListCurrentPos]}";
                imageListCurrentPos++;

                await LoadCache();
            }
            return true;
        }

        private Task<bool> LoadCache()
        {
            while (imagesCache.Count < 10)
            {
                imagesCache.Add(new MemoryStream(File.ReadAllBytes(unsortedImageFiles[imageListCurrentPos])));
                imageListCurrentPos++;
                return Task.FromResult<bool>(true);
            }

            return Task.FromResult<bool>(false);
        }

        private void MoveImage(string frompath, string toPath)
        {
            try
            {
                this.toolStripStatusLabel2.Text = $"Moving image to {toPath}";

                File.Move(frompath, toPath);
            }catch(Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        private void MoveAndLoadNextImage(int sortedFolderNumber)
        {
            // update cursor to let user know we are trying to move or load next image (may be slow on some network shares/machines
            this.Cursor = Cursors.WaitCursor;
            this.btnSkip.Text = "....";
            this.btnSkip.Enabled = false;

            ///TODO: probably need to load these in memory as var and stop reading it over and over
            string newFullpath = ConfigurationManager.AppSettings[$"SortFolderPath{sortedFolderNumber}"] + "\\" + Path.GetFileName(this.pictureBox1.ImageLocation);
            MoveImage(this.pictureBox1.ImageLocation, newFullpath);
            LoadNextImage();
            this.Cursor = Cursors.Default;
            this.btnSkip.Enabled = true;
            this.btnSkip.Text = "Skip Image";

        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            // user want's to skip sorting this image, remove it from list and load next image
            LoadNextImage();
        }
        private void BtnSort1_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(1);
        }

        private void BtnSort2_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(2);
        }

        private void BtnSort3_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(3);
        }

        private void BtnSort4_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(4);
        }

        private void BtnSort5_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(5);
        }

        private void BtnSort6_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(6);
        }

        private void BtnSort7_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(7);
        }

        private void BtnSort8_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(8);
        }

        private void BtnSort9_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(9);
        }

        private void BtnSort10_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImage(10);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
