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
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace CertficateGenerator
{
    public partial class DataEditing : Form
    {
        List<Area> areas;
        Image image;

        string imageFile, templateFile, projectName, dataFile;

        public DataEditing(string imageFile, string templateFile, string projectName, string dataFile)
        {
            this.imageFile = imageFile;
            this.templateFile = templateFile;
            this.projectName = projectName;
            this.dataFile = dataFile;
            InitializeComponent();            
        }

        public DataEditing(string imageFile, string templateFile, string projectName)
        {
            this.imageFile = imageFile;
            this.templateFile = templateFile;
            this.projectName = projectName;            
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            d.Description = "Выбирите папку для сохранения";

            string dir = "";
            if(d.ShowDialog() == DialogResult.OK)
            {
                dir = d.SelectedPath;
                string text;
                string imName;                

                using (Brush brush = new SolidBrush(Color.Black))
                {
                    for (int i = 0; i < grid.Rows.Count-1; i++)
                    {
                        using (Image im = new Bitmap(image))
                        {
                            using (Graphics g = Graphics.FromImage(im))
                            {
                                for (int j = 0; j < grid.Columns.Count; j++)
                                {
                                    text = grid[j, i].Value.ToString();
                                    g.DrawString(text, areas[j].font, brush, areas[j].rectangle, Area.sf);
                                }
                            }
                            imName = grid[0, i].Value.ToString();
                            im.Save(dir + "\\" + imName + ".jpg");
                            im.Dispose();
                        }
                    }
                }
            }        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataEditing_Load(object sender, EventArgs e)
        {

            image = Image.FromFile(imageFile);
            using (var stream = File.OpenRead(templateFile))
            {
                var serializer = new XmlSerializer(typeof(List<Area>));
                areas = (List<Area>)serializer.Deserialize(stream);
            }

            //List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
            int width = grid.Width / areas.Count;
            foreach (Area a in areas)
            {
                a.CreateFont();
                DataGridViewColumn t = new DataGridViewColumn();
                t.HeaderText = a.name;
                t.CellTemplate = new DataGridViewTextBoxCell();
                t.Width = width;
                grid.Columns.Add(t);
            }

            if (dataFile != null && !dataFile.Equals(""))
            {
                Excel.Application app = new Excel.Application();

                Excel.Workbook workbook = app.Workbooks.Open(
                    dataFile,
                    Type.Missing, true, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing
                );

                Excel.Worksheet sheet = workbook.Worksheets[1];

                /* int columnIndex = 2;
                 for (int rowIndex = 2; rowIndex < 106; rowIndex++)
                 {
                     string data = sheet.Cells[rowIndex, columnIndex].Value;
                     if (!data.Equals("") && data.Count(f => f == '(') == 0)
                     {
                         grid.Rows.Add(data);
                     }
                 }*/

                int columnIndex = 1;
                int rowIndex = 2;
                string data;


                data = sheet.Cells[rowIndex, columnIndex].Value;
                while(data != null)
                {
                    do
                    {
                        data = Convert.ToString(sheet.Cells[rowIndex, columnIndex++].Value);
                    } while (data != null);


                    columnIndex-=2;
                    Array dataArray = sheet.Range[sheet.Cells[rowIndex, 1], sheet.Cells[rowIndex, columnIndex]].Cells.Value;
                    grid.Rows.Add(ConvertToStringArray(dataArray));


                    rowIndex++;
                    columnIndex = 1;


                    data = sheet.Cells[rowIndex, columnIndex++].Value;
                }
            }
        }

        string[] ConvertToStringArray(System.Array values)
        {

            // create a new string array
            string[] theArray = new string[values.Length];

            // loop through the 2-D System.Array and populate the 1-D String Array
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(1, i) == null)
                    theArray[i - 1] = "";
                else
                    theArray[i - 1] = (string)values.GetValue(1, i).ToString();
            }

            return theArray;
        }
    }
}
