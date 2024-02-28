
namespace CertficateGenerator
{
    partial class WorkWithImages
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fontSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.areasList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameEditor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textEditor = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.addArea = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.fontSize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.areasList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameEditor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textEditor);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.addArea);
            this.groupBox1.Location = new System.Drawing.Point(872, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 633);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Инструменты";
            // 
            // fontSize
            // 
            this.fontSize.Location = new System.Drawing.Point(6, 414);
            this.fontSize.Name = "fontSize";
            this.fontSize.Size = new System.Drawing.Size(374, 29);
            this.fontSize.TabIndex = 11;
            this.fontSize.Text = "18";
            this.fontSize.TextChanged += new System.EventHandler(this.fontSize_TextChanged);
            this.fontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fontSize_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Размер шрифта:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Все области:";
            // 
            // areasList
            // 
            this.areasList.FormattingEnabled = true;
            this.areasList.ItemHeight = 21;
            this.areasList.Location = new System.Drawing.Point(6, 290);
            this.areasList.Name = "areasList";
            this.areasList.Size = new System.Drawing.Size(368, 88);
            this.areasList.TabIndex = 7;
            this.areasList.SelectedIndexChanged += new System.EventHandler(this.areasList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Имя области:";
            // 
            // nameEditor
            // 
            this.nameEditor.Enabled = false;
            this.nameEditor.Location = new System.Drawing.Point(6, 171);
            this.nameEditor.Multiline = true;
            this.nameEditor.Name = "nameEditor";
            this.nameEditor.Size = new System.Drawing.Size(368, 92);
            this.nameEditor.TabIndex = 5;
            this.nameEditor.TextChanged += new System.EventHandler(this.nameEditor_TextChanged);
            this.nameEditor.Leave += new System.EventHandler(this.nameEditor_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Текст в области:";
            // 
            // textEditor
            // 
            this.textEditor.Enabled = false;
            this.textEditor.Location = new System.Drawing.Point(6, 49);
            this.textEditor.Multiline = true;
            this.textEditor.Name = "textEditor";
            this.textEditor.Size = new System.Drawing.Size(368, 92);
            this.textEditor.TabIndex = 3;
            this.textEditor.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(10, 580);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(364, 47);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addArea
            // 
            this.addArea.AutoEllipsis = true;
            this.addArea.Location = new System.Drawing.Point(10, 532);
            this.addArea.Name = "addArea";
            this.addArea.Size = new System.Drawing.Size(364, 42);
            this.addArea.TabIndex = 0;
            this.addArea.Text = "Добавить область";
            this.addArea.UseVisualStyleBackColor = true;
            this.addArea.Click += new System.EventHandler(this.addArea_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 637);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(848, 630);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // deleteButton
            // 
            this.deleteButton.AutoEllipsis = true;
            this.deleteButton.Location = new System.Drawing.Point(10, 484);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(364, 42);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Удалить область";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // WorkWithImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 690);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "WorkWithImages";
            this.Text = "Редактор";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkWithImages_FormClosed);
            this.Load += new System.EventHandler(this.WorkWithImages_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addArea;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameEditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox areasList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fontSize;
        private System.Windows.Forms.Button deleteButton;
    }
}