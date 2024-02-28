using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

using ImageProcessor;
using ImageProcessor.Imaging;

namespace CertficateGenerator
{
    public partial class WorkWithImages : Form
    {
        Image originalImage;
        Image originalImageCopy;
        public static Graphics g;
        

        int focusedAreaIndex;
        List<Area> areas;
        string areaName;

        Pen pen;
        Pen selected;
        Brush textBrush;

        bool isFocused;
        bool isResized;
        bool isEditingText;
        int deltaX, deltaY;

        bool load;
        string imageFile, dataFile, projectName;
        ImageFactory imageCopy;

        public WorkWithImages()
        {
            load = false;
            InitializeComponent();
        }

        public WorkWithImages(string imageFile, string dataFile, string projectName)
        {
            load = true;
            this.imageFile = imageFile;
            this.dataFile = dataFile;
            this.projectName = projectName;
            InitializeComponent();
        }

        private void WorkWithImages_Load(object sender, EventArgs e)
        {
            if (!load)
            {
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Выберете шаблон";
                openFileDialog1.Filter = "Image Files(*.JPG)|*.JPG|All files (*.*)|*.*";

                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    originalImage = Image.FromFile(openFileDialog1.FileName);
                    projectName = openFileDialog1.FileName.Split('\\').Last().Split('.')[0];
                }
                else
                {
                    this.Close();
                }
                //originalImage = GetResizedImage(originalImage);

                pictureBox1.Image = originalImage;

                originalImageCopy = originalImage;

                areaName = "Область ";
                areas = new List<Area>();
                areas.Add(new Area(100, 100, 400, 200, areaName + Convert.ToString(areas.Count + 1)));
                focusedAreaIndex = 0;

                areasList.Items.Add(areas[0].name);

                pen = new Pen(Color.CadetBlue, 3.0f);
                selected = new Pen(Color.Red, 3.0f);
                textBrush = new SolidBrush(Color.Black);

                isFocused = false;
                isResized = false;
                isEditingText = false;
            }
            else
            {
                originalImage = new Bitmap(Image.FromFile(imageFile));                
               
                pictureBox1.Image = originalImage;

                originalImageCopy = originalImage;

                focusedAreaIndex = 0;

                pen = new Pen(Color.CadetBlue, 3.0f);
                selected = new Pen(Color.Red, 3.0f);
                textBrush = new SolidBrush(Color.Black);

                using (var stream = File.OpenRead(dataFile))
                {
                    var serializer = new XmlSerializer(typeof(List<Area>));
                    areas = (List<Area>)serializer.Deserialize(stream);
                }

                foreach (Area a in areas)
                {
                    a.isSelected = false;
                    a.CreateFont();
                }

                foreach (Area a in areas)
                {
                    areasList.Items.Add(a.name);
                }

                isFocused = false;
                isResized = false;
                isEditingText = false;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }



        private Image GetResizedImage(Image image)
        {
            Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            Bitmap nImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            nImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using(Graphics graphics = Graphics.FromImage(nImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using(ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }                
            }

            return nImage;
        }

        private Rectangle GetRectangleArea(Point p1, Point p2)
        {
            int x1 = Math.Min(p1.X, p2.X);
            int x2 = Math.Max(p1.X, p2.X);
            int y1 = Math.Min(p1.Y, p2.Y);
            int y2 = Math.Max(p1.Y, p2.Y);

            return new Rectangle(x1, y1, x2-x1, y2-y1);
        }        


        private void DrawExapmple()
        {
            pictureBox1.Invalidate();
            String text = "Иван Иванович Иванов";

            Image image = pictureBox1.Image;
            g = Graphics.FromImage(image);            


            using(g = Graphics.FromImage(image))
            {
                //using(Brush textBrush = new SolidBrush(Color.Black))
                //{
                //    g.DrawString(text, font, textBrush, mousep1);
                //}                                
            }            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {            
            g = e.Graphics;                      
            foreach (Area a in areas)
            {
                a.Draw(g);
            }         
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();

            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                string dir = browserDialog.SelectedPath + "\\" + projectName;
                Directory.CreateDirectory(dir);
                using (var stream = File.Create(dir + "\\data.xml"))
                {
                    var serializer = new XmlSerializer(typeof(List<Area>));
                    serializer.Serialize(stream, areas);                    
                }

                if (!File.Exists(imageFile))
                {
                    originalImage.Save(dir + "\\" + projectName + ".jpg");
                }

                MessageBox.Show("Проект успешно сохранён");
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                textEditor.Enabled = false;
                nameEditor.Enabled = false;
                fontSize.Enabled = false;
                areasList.SelectedIndex = -1;                
                foreach(Area a in areas)
                {
                    a.isSelected = false;
                }                
                for(int i = 0; i < areas.Count; i++)
                {
                    if (areas[i].rectangle.Contains(e.Location))
                    {
                        focusedAreaIndex = i;
                        areas[i].isSelected = true;
                        areasList.SelectedIndex = i;

                        deltaX = e.X - areas[i].rectangle.X;
                        deltaY = e.Y - areas[i].rectangle.Y;

                        isFocused = true;

                        textEditor.Enabled = true;
                        textEditor.Text = areas[focusedAreaIndex].text;
                        nameEditor.Enabled = true;
                        nameEditor.Text = areas[focusedAreaIndex].name;
                        fontSize.Enabled = true;
                        fontSize.Text = Convert.ToString(areas[focusedAreaIndex].fontSize);
                        //pictureBox1.Invalidate();
                        break;
                    }
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                foreach (Area a in areas)
                {
                    a.isSelected = false;
                }
                for (int i = 0; i < areas.Count; i++)
                {
                    if (areas[i].rectangle.Contains(e.Location))
                    {
                        focusedAreaIndex = i;
                        areas[i].isSelected = true;
                        isResized = true;
                        break;
                    }
                }
            }
            /*else if(e.Button == MouseButtons.Middle)
            {
                foreach (Area a in areas)
                {
                    a.isSelected = false;                    
                }
                for (int i = 0; i < areas.Count; i++)
                {
                    if (areas[i].rectangle.Contains(e.Location))
                    {
                        areas.RemoveAt(i);
                        //pictureBox1.Invalidate();
                        break;
                    }
                }
            }*/
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isFocused = false;
            isResized = false;
            //areas[focusedAreaIndex].isMoved = false;
            //pictureBox1.Invalidate();
        }

        private void addArea_Click(object sender, EventArgs e)
        {
            areas.Add(new Area(100, 100, 400, 200, areaName + Convert.ToString(areas.Count + 1)));
            areasList.Items.Add(areas.Last().name);

            pictureBox1.Invalidate();
        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            areas[focusedAreaIndex].text = textEditor.Text;
            pictureBox1.Invalidate();
        }

        private void nameEditor_TextChanged(object sender, EventArgs e)
        {            
            areas[focusedAreaIndex].name = nameEditor.Text;
        }

        private void WorkWithImages_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(originalImage != null)
                originalImage.Dispose();
            if(g != null)
                g.Dispose();
            GC.Collect();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void fontSize_TextChanged(object sender, EventArgs e)
        {
            if (!fontSize.Text.Equals("") && fontSize.Text[0] != '0') { 
                areas[focusedAreaIndex].SetFontSize(int.Parse(fontSize.Text));
                pictureBox1.Invalidate();
            }
        }

        private void fontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (areasList.Items.Count > 0)
            {
                areas.RemoveAt(focusedAreaIndex);
                areasList.Items.RemoveAt(focusedAreaIndex);
                focusedAreaIndex = 0;
                pictureBox1.Invalidate();
            }
        }

        private void areasList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (areasList.SelectedIndex != -1)
            {
                foreach (Area a in areas)
                {
                    a.isSelected = false;
                }

                int index = areasList.SelectedIndex;
                focusedAreaIndex = index;
                areas[index].isSelected = true;

                textEditor.Enabled = true;
                textEditor.Text = areas[index].text;
                nameEditor.Enabled = true;
                nameEditor.Text = areas[index].name;
                fontSize.Enabled = true;
                fontSize.Text = Convert.ToString(areas[focusedAreaIndex].fontSize);

                pictureBox1.Invalidate();
            }
        }

        private void nameEditor_Leave(object sender, EventArgs e)
        {
            areasList.Items.Clear();
            foreach(Area a in areas)
            {
                areasList.Items.Add(a.name);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isFocused)
            {
                //areas[focusedAreaIndex].isMoved = true;
                Rectangle r = areas[focusedAreaIndex].rectangle;                
                r.X = e.X - deltaX;
                r.Y = e.Y - deltaY;
                areas[focusedAreaIndex].rectangle = r;
                pictureBox1.Invalidate();
            }            
            else if (isResized)
            {
                Rectangle r = areas[focusedAreaIndex].rectangle;
                r.Width = e.X - r.X;
                r.Height = e.Y - r.Y;
                areas[focusedAreaIndex].rectangle = r;
                pictureBox1.Invalidate();
            }
        }
    }
}
