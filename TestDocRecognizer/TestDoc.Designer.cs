namespace TestDocRecognizer
{
    partial class TestDocFabri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestDocFabri));
            uploadButton = new Button();
            resultTextBox = new TextBox();
            analyzeButton = new Button();
            pictureBox = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(12, 12);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(75, 23);
            uploadButton.TabIndex = 0;
            uploadButton.Text = "Upload";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += UploadButton_Click;
            // 
            // resultTextBox
            // 
            resultTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resultTextBox.Location = new Point(944, 85);
            resultTextBox.Multiline = true;
            resultTextBox.Name = "resultTextBox";
            resultTextBox.ScrollBars = ScrollBars.Vertical;
            resultTextBox.Size = new Size(571, 741);
            resultTextBox.TabIndex = 2;
            // 
            // analyzeButton
            // 
            analyzeButton.Location = new Point(111, 12);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(75, 23);
            analyzeButton.TabIndex = 3;
            analyzeButton.Text = "Analyze";
            analyzeButton.UseVisualStyleBackColor = true;
            analyzeButton.Click += AnalyzeButton_Click;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(12, 89);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(665, 737);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(289, 62);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 4;
            label1.Text = "Anteprima";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(1195, 62);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 5;
            label2.Text = "Dati estratti";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(224, 283);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(220, 220);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(374, 13);
            textBox1.Name = "textBox1";
            textBox1.RightToLeft = RightToLeft.No;
            textBox1.Size = new Size(150, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "Domanda_1";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(699, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(279, 23);
            textBox2.TabIndex = 8;
            textBox2.Text = "https://formiscrizioni.cognitiveservices.azure.com/";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 16);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 9;
            label3.Text = "Modello utilizzato:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(556, 16);
            label4.Name = "label4";
            label4.Size = new Size(131, 15);
            label4.TabIndex = 10;
            label4.Text = "EndPoint Azure Service:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(984, 16);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 11;
            label5.Text = "Api Key:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1064, 13);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(218, 23);
            textBox3.TabIndex = 12;
            textBox3.Text = "9182d6cd106c49dcbecf162758e53861";
            // 
            // TestDocFabri
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1527, 838);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(uploadButton);
            Controls.Add(pictureBox);
            Controls.Add(resultTextBox);
            Controls.Add(analyzeButton);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TestDocFabri";
            Text = "Fabrizio's Magic";
            Load += TestDocFabri_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
    }
}