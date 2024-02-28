
namespace CertficateGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.wPattern = new System.Windows.Forms.Button();
            this.gCertificates = new System.Windows.Forms.Button();
            this.openTemplate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wPattern
            // 
            this.wPattern.Location = new System.Drawing.Point(210, 67);
            this.wPattern.Name = "wPattern";
            this.wPattern.Size = new System.Drawing.Size(313, 116);
            this.wPattern.TabIndex = 0;
            this.wPattern.Text = "Создать шаблон";
            this.wPattern.UseVisualStyleBackColor = true;
            this.wPattern.Click += new System.EventHandler(this.wPattern_Click);
            // 
            // gCertificates
            // 
            this.gCertificates.Location = new System.Drawing.Point(210, 355);
            this.gCertificates.Name = "gCertificates";
            this.gCertificates.Size = new System.Drawing.Size(313, 116);
            this.gCertificates.TabIndex = 1;
            this.gCertificates.Text = "Генерация сертификатов";
            this.gCertificates.UseVisualStyleBackColor = true;
            this.gCertificates.Click += new System.EventHandler(this.gCertificates_Click);
            // 
            // openTemplate
            // 
            this.openTemplate.Location = new System.Drawing.Point(206, 206);
            this.openTemplate.Name = "openTemplate";
            this.openTemplate.Size = new System.Drawing.Size(313, 116);
            this.openTemplate.TabIndex = 2;
            this.openTemplate.Text = "Открыть шаблон";
            this.openTemplate.UseVisualStyleBackColor = true;
            this.openTemplate.Click += new System.EventHandler(this.openTemplate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 528);
            this.Controls.Add(this.openTemplate);
            this.Controls.Add(this.gCertificates);
            this.Controls.Add(this.wPattern);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button wPattern;
        private System.Windows.Forms.Button gCertificates;
        private System.Windows.Forms.Button openTemplate;
    }
}

