using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CertficateGenerator
{
    [Serializable]
    public class Area
    {
        [XmlIgnore] public static Pen pen = new Pen(Color.CadetBlue, 3.0f);
        [XmlIgnore] public static Pen selected = new Pen(Color.Red, 3.0f);
        [XmlIgnore] public static Brush textBrush = new SolidBrush(Color.Black);

        
        [XmlIgnore] public Font font;

        public int fontSize;

        public Rectangle rectangle;
        public string text;
        public string name;

        public static StringFormat sf;

        public bool isSelected;

        static Area()
        {
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

        public Area(int x, int y, int width, int height, string name)
        {
            rectangle = new Rectangle(x, y, width, height);            
            text = "Двойной клик для редактирования";
            this.name = name;
            isSelected = false;
            fontSize = 18;
            font = new Font(Form1.private_fonts.Families[0], fontSize);            
        }

        public Area()
        {
            rectangle = new Rectangle();
            text = "";
            this.name = "";
            isSelected = false;
            fontSize = 18;            
        }

        public void SetFontSize(int size)
        {
            fontSize = size;
            font = new Font(Form1.private_fonts.Families[0], size);
        }

        public void CreateFont()
        {
            font = new Font(Form1.private_fonts.Families[0], fontSize);
        }

        public void Draw(Graphics g)
        {
            if (isSelected)
                g.DrawRectangle(selected, rectangle);              
            else
                g.DrawRectangle(pen, rectangle);
            g.DrawString(text, font, textBrush, rectangle, sf);
        }     
    }
}
