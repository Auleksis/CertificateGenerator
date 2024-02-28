using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace CertficateGenerator
{
    public partial class Form1 : Form
    {
        public static PrivateFontCollection private_fonts;
        public static Font font;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            private_fonts = new PrivateFontCollection();
            using (MemoryStream fontStream = new MemoryStream(Properties.Resources.GaliverSans1))
            {
                // create an unsafe memory block for the font data
                System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                // create a buffer to read in to
                byte[] fontdata = new byte[fontStream.Length];
                // read the font data from the resource
                fontStream.Read(fontdata, 0, (int)fontStream.Length);
                // copy the bytes to the unsafe memory block
                Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                // pass the font to the font collection
                private_fonts.AddMemoryFont(data, (int)fontStream.Length);
                // free the unsafe memory
                Marshal.FreeCoTaskMem(data);

            }

            font = new Font(private_fonts.Families[0], 18);
        }

        private void wPattern_Click(object sender, EventArgs e)
        {
            WorkWithImages form = new WorkWithImages();

            form.ShowDialog(this);
        }

        private void openTemplate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();

            if(d.ShowDialog() == DialogResult.OK)
            {
                string dir = d.SelectedPath;
                string projectName = dir.Split('\\').Last();

                string imageFile = dir + "\\" + projectName + ".jpg";
                string dataFile = dir + "\\data.xml";

                if (File.Exists(dataFile) && File.Exists(imageFile))
                {
                    WorkWithImages form = new WorkWithImages(imageFile, dataFile, projectName);
                    form.Show(this);
                }
            }
        }

        private void gCertificates_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            d.Description = "Выберите шаблон (папку, в которой лежит xml файл проект)";

            if(d.ShowDialog() == DialogResult.OK)
            {
                string dir = d.SelectedPath;
                string projectName = dir.Split('\\').Last();

                string imageFile = dir + "\\" + projectName + ".jpg";
                string dataFile = dir + "\\data.xml";

                OpenFileDialog fd = new OpenFileDialog();
                fd.Title = "Выбирите xsls-файл с данными (если он есть) или нажмите кнопку отмена";

                if (fd.ShowDialog() == DialogResult.OK && File.Exists(dataFile) && File.Exists(imageFile))
                {
                    DataEditing form = new DataEditing(imageFile, dataFile, projectName, fd.FileName);
                    form.Show(this);
                }
                else
                {
                    DataEditing form = new DataEditing(imageFile, dataFile, projectName);
                    form.Show(this);
                }
            }
        }
    }
}
