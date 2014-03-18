using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;

namespace IosIconMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<IconSize> sizes_;
        private string filepath_;
        private Bitmap sourceImage_;
        private string outputDir_;

        private void Form1_Load(object sender, EventArgs e)
        {
            sizes_ = new List<IconSize>();
            sizes_.Add(new IconSize("Icon.png", 57, 57));
            sizes_.Add(new IconSize("Icon@2x.png", 114, 114));
            sizes_.Add(new IconSize("Icon-72.png", 72, 72));
            sizes_.Add(new IconSize("Icon-72@2x.png", 144, 144));
            sizes_.Add(new IconSize("Icon-Small.png", 29, 29));
            sizes_.Add(new IconSize("Icon-Small@2x.png", 58, 58));
            sizes_.Add(new IconSize("Icon-Small-50.png", 50, 50));
            sizes_.Add(new IconSize("Icon-Small-50@2x.png", 100, 100));
            sizes_.Add(new IconSize("iTunesArtwark", 512, 512));
            sizes_.Add(new IconSize("iTunesArtwark@2x", 1024, 1024));

            outputDir_ = "output";
            DirectoryInfo dirInfo = new DirectoryInfo(outputDir_);
            if (!Directory.Exists(outputDir_))
            {
                Directory.CreateDirectory(outputDir_);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            System.Diagnostics.Debug.WriteLine(filenames[0]);

            filepath_ = filenames[0];
            sourceImage_ = new Bitmap(filepath_);

            Bitmap pictureImage = new Bitmap(sourceImage_, pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = pictureImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (IconSize size in sizes_)
            {
                using (Bitmap icon = new Bitmap(sourceImage_, size.Width, size.Height))
                {
                    //string iconpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../output", size.FileName);
                    string iconpath = Path.Combine(outputDir_, size.FileName);
                    icon.Save(iconpath, ImageFormat.Png);
                }
            }
        }
    }

    class IconSize
    {
        public string FileName;
        public int Width;
        public int Height;

        public IconSize(string filename, int width, int height)
        {
            FileName = filename;
            Width = width;
            Height = height;
        }
    }
}
