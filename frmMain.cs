﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace ImageSorter
{
    public partial class frmMain : Form
    {
        private List<string> unsortedImageFiles;
        private int precacheCurrentPostionOnImageList;
        private List<ImageCacheObject> imageCacheObjectList;

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

        private async void BeginSortingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // update statusbar
            this.toolStripStatusLabel1.Text = "RUNNING";
            

            // validate the unsorted folder exist and there is at least one image in it
            if(!System.IO.Directory.Exists(ConfigurationManager.AppSettings["UnsortedImagesPath"])){
                MessageBox.Show("It appears you have specified a unsorted image folder that does not exist.", "Unsorted Image Folder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.toolStripStatusLabel1.Text = "IDLE";
                this.toolStripStatusLabel2.Text = "";
                return;
            }

            // load images from the unsorted path
            this.toolStripStatusLabel2.Text = $"Loading images from {ConfigurationManager.AppSettings["UnsortedImagesPath"]}";

            imageCacheObjectList = new List<ImageCacheObject>();
            LoadImageList();

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

        private void LoadImageList()
        {
            precacheCurrentPostionOnImageList = 0;
            unsortedImageFiles = System.IO.Directory.EnumerateFiles(ConfigurationManager.AppSettings["UnsortedImagesPath"], "*.*", SearchOption.AllDirectories)
             .Where(s => s.EndsWith(".jpg")
                     || s.EndsWith(".jpeg")
                     || s.EndsWith(".gif")
                     || s.EndsWith(".png")
                     || s.EndsWith(".bmp")
                     || s.EndsWith(".jfif")
             ).ToList();

            PopulateImagePrecache();
        }

        private void PopulateImagePrecache()
        {
            if (precacheCurrentPostionOnImageList < unsortedImageFiles.Count)
            {
                // now load the first x (specified by user) images into a memory stream list
                while(imageCacheObjectList.Count <= 10)
                {
                    ImageCacheObject tmp = new ImageCacheObject
                    {
                        imageMemoryStream = new MemoryStream(File.ReadAllBytes(unsortedImageFiles[precacheCurrentPostionOnImageList])),
                        imagePath = unsortedImageFiles[precacheCurrentPostionOnImageList],
                        metaDataDirectories = ImageMetadataReader.ReadMetadata(unsortedImageFiles[precacheCurrentPostionOnImageList])
                    };

                    imageCacheObjectList.Add(tmp);
                    precacheCurrentPostionOnImageList++;
                }
            }
        }

      
        private void LoadNextImage()
        {
            if (imageCacheObjectList.Count <=0)
            {
                
                this.pictureBox1.Image = null;
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
                // load next image from memory stream array
                try
                {
                    this.pictureBox1.Image = Image.FromStream(imageCacheObjectList.FirstOrDefault().imageMemoryStream);
                    this.toolStripStatusLabel2.Text = $"{imageCacheObjectList.FirstOrDefault().imagePath}";
                    var exifMetaData = imageCacheObjectList.FirstOrDefault().metaDataDirectories.OfType<ExifIfd0Directory>().FirstOrDefault();
                    this.lblDateTimeTaken.Text = exifMetaData?.GetDescription(ExifDirectoryBase.TagDateTime);
                    
                    imageCacheObjectList.RemoveAt(0);
                }
                catch(Exception e)
                {
                    //sometimes we have bad images or images that the viewer can't handle, ignore them
                    ///TODO: skip bad images and rename them so the user knows they are bad/can't be viewed
                    ///

                    // remove this object form our list and recursively try again...
                    imageCacheObjectList.RemoveAt(0);
                    LoadNextImage();

                }

                if (imageCacheObjectList.Count <= 5)
                    PopulateImagePrecache(); 
            }
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

        private void MoveAndLoadNextImageAsync(int sortedFolderNumber)
        {
            // update cursor to let user know we are trying to move or load next image (may be slow on some network shares/machines
            this.Cursor = Cursors.WaitCursor;
            this.btnSkip.Text = "....";
            this.btnSkip.Enabled = false;

            ///TODO: probably need to load these in memory as var and stop reading it over and over
            string newFullpath = ConfigurationManager.AppSettings[$"SortFolderPath{sortedFolderNumber}"] + "\\" + Path.GetFileName(this.toolStripStatusLabel2.Text);
            MoveImage(this.toolStripStatusLabel2.Text, newFullpath);
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
            MoveAndLoadNextImageAsync(1);
        }

        private void BtnSort2_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(2);
        }

        private void BtnSort3_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(3);
        }

        private void BtnSort4_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(4);
        }

        private void BtnSort5_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(5);
        }

        private void BtnSort6_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(6);
        }

        private void BtnSort7_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(7);
        }

        private void BtnSort8_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(8);
        }

        private void BtnSort9_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(9);
        }

        private void BtnSort10_Click(object sender, EventArgs e)
        {
            MoveAndLoadNextImageAsync(10);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }

    public class ImageCacheObject
    {
        public MemoryStream imageMemoryStream { get; set; }
        public string imagePath { get; set; }
        public IEnumerable<MetadataExtractor.Directory> metaDataDirectories {get;set;}

    }
}
