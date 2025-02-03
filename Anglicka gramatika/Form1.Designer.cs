using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnglickaGramatika
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblSentenceCount;
        private TextBox textBoxSentence;
        private TextBox textBoxAnswer;
        private Label lblResult;
        private Label lblUserAnswer;
        private Button btnStartTest;
        private Button btnStopTest;
        private Button btnShowStatistics;
        private Button btnShowDatabase;
        private Button btnImportData;
        private Button btnExportData;
        private PictureBox pictureBoxFooter;
        private Label lblAuthor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblSentenceCount = new Label();
            this.textBoxSentence = new TextBox();
            this.textBoxAnswer = new TextBox();
            this.lblResult = new Label();
            this.lblUserAnswer = new Label();
            this.btnStartTest = new Button();
            this.btnStopTest = new Button();
            this.btnShowStatistics = new Button();
            this.btnShowDatabase = new Button();
            this.btnImportData = new Button();
            this.btnExportData = new Button();
            this.pictureBoxFooter = new PictureBox();
            this.lblAuthor = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFooter)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            this.lblTitle.Location = new Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(1900, 60);
            this.lblTitle.Text = "Anglická gramatika a časy";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.Font = new Font("Segoe UI", 18F);
            this.lblSubtitle.Location = new Point(10, 80);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new Size(1900, 40);
            this.lblSubtitle.Text = "Poď sa otestovať 🙂";
            this.lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblSentenceCount
            this.lblSentenceCount.Font = new Font("Segoe UI", 16F);
            this.lblSentenceCount.Location = new Point(10, 130);
            this.lblSentenceCount.Name = "lblSentenceCount";
            this.lblSentenceCount.Size = new Size(1900, 30);
            this.lblSentenceCount.Text = "Naimportovaná databáza: Žiadna";
            this.lblSentenceCount.TextAlign = ContentAlignment.MiddleCenter;

            // textBoxSentence
            this.textBoxSentence.Font = new Font("Segoe UI", 18F);
            this.textBoxSentence.Location = new Point(605, 200);
            this.textBoxSentence.ReadOnly = true;
            this.textBoxSentence.Size = new Size(752, 39);

            // textBoxAnswer
            this.textBoxAnswer.Font = new Font("Segoe UI", 18F);
            this.textBoxAnswer.Location = new Point(605, 260);
            this.textBoxAnswer.Size = new Size(752, 39);
            this.textBoxAnswer.KeyDown += new KeyEventHandler(this.TextBoxAnswer_KeyDown);

            // lblResult
            this.lblResult.Font = new Font("Segoe UI", 18F);
            this.lblResult.Location = new Point(760, 320);
            this.lblResult.Size = new Size(400, 40);
            this.lblResult.TextAlign = ContentAlignment.MiddleCenter;

            // lblUserAnswer
            this.lblUserAnswer.Font = new Font("Segoe UI", 14F);
            this.lblUserAnswer.Location = new Point(760, 360);
            this.lblUserAnswer.Size = new Size(400, 40);
            this.lblUserAnswer.TextAlign = ContentAlignment.MiddleCenter;

            // btnStartTest
            this.btnStartTest.BackColor = Color.LightGreen;
            this.btnStartTest.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnStartTest.Location = new Point(500, 420);
            this.btnStartTest.Size = new Size(200, 60);
            this.btnStartTest.Text = "Spusti test";
            this.btnStartTest.UseVisualStyleBackColor = false;
            this.btnStartTest.Click += new EventHandler(this.BtnStartTest_Click);

            // btnStopTest
            this.btnStopTest.BackColor = Color.LightCoral;
            this.btnStopTest.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnStopTest.Location = new Point(750, 420);
            this.btnStopTest.Size = new Size(200, 60);
            this.btnStopTest.Text = "Zastav test";
            this.btnStopTest.UseVisualStyleBackColor = false;
            this.btnStopTest.Click += new EventHandler(this.BtnStopTest_Click);

            // btnShowStatistics
            this.btnShowStatistics.BackColor = Color.LightYellow;
            this.btnShowStatistics.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnShowStatistics.Location = new Point(1000, 420);
            this.btnShowStatistics.Size = new Size(200, 60);
            this.btnShowStatistics.Text = "Štatistika";
            this.btnShowStatistics.UseVisualStyleBackColor = false;
            this.btnShowStatistics.Click += new EventHandler(this.BtnShowStatistics_Click);

            // btnShowDatabase
            this.btnShowDatabase.BackColor = Color.LightBlue;
            this.btnShowDatabase.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnShowDatabase.Location = new Point(1250, 420);
            this.btnShowDatabase.Size = new Size(200, 60);
            this.btnShowDatabase.Text = "Gramatické vzory";
            this.btnShowDatabase.UseVisualStyleBackColor = false;
            this.btnShowDatabase.Click += new EventHandler(this.BtnShowDatabase_Click);

            // btnImportData
            this.btnImportData.BackColor = Color.LightGray;
            this.btnImportData.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnImportData.Location = new Point(750, 500);
            this.btnImportData.Size = new Size(200, 60);
            this.btnImportData.Text = "Importovať dáta";
            this.btnImportData.UseVisualStyleBackColor = false;
            this.btnImportData.Click += new EventHandler(this.BtnImportData_Click);

            // btnExportData
            this.btnExportData.BackColor = Color.LightGray;
            this.btnExportData.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.btnExportData.Location = new Point(1000, 500);
            this.btnExportData.Size = new Size(200, 60);
            this.btnExportData.Text = "Exportovať dáta";
            this.btnExportData.UseVisualStyleBackColor = false;
            this.btnExportData.Click += new EventHandler(this.BtnExportData_Click);

            // pictureBoxFooter
            this.pictureBoxFooter.Image = ((Image)(resources.GetObject("pictureBoxFooter.Image")));
            this.pictureBoxFooter.Location = new Point(860, 831);
            this.pictureBoxFooter.Size = new Size(200, 100);
            this.pictureBoxFooter.SizeMode = PictureBoxSizeMode.StretchImage;

            // lblAuthor
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new Font("Segoe UI", 14F);
            this.lblAuthor.Location = new Point(855, 934);
            this.lblAuthor.Text = "Created by Peter Obala";

            // Form1
            this.ClientSize = new Size(1920, 1061);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblSentenceCount);
            this.Controls.Add(this.textBoxSentence);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblUserAnswer);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.btnStopTest);
            this.Controls.Add(this.btnShowStatistics);
            this.Controls.Add(this.btnShowDatabase);
            this.Controls.Add(this.btnImportData);
            this.Controls.Add(this.btnExportData);
            this.Controls.Add(this.pictureBoxFooter);
            this.Controls.Add(this.lblAuthor);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFooter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
