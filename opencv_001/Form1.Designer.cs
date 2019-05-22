namespace opencv_001
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.log_1 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.log_2 = new System.Windows.Forms.TextBox();
            this.targetWidthVal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.targetWidth = new System.Windows.Forms.Label();
            this.targetHeight = new System.Windows.Forms.Label();
            this.targetHeightVal = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.yVal = new System.Windows.Forms.TextBox();
            this.xVal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.threshMaxVal = new System.Windows.Forms.TextBox();
            this.thresh = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(662, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(640, 480);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(16, 542);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(640, 480);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "1.FromCameraSource";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(658, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "2.GrayScal ( From. number 1 )";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(12, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "4.FindRect";
            // 
            // log_1
            // 
            this.log_1.Location = new System.Drawing.Point(662, 561);
            this.log_1.Multiline = true;
            this.log_1.Name = "log_1";
            this.log_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log_1.Size = new System.Drawing.Size(640, 194);
            this.log_1.TabIndex = 19;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(1311, 31);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(640, 480);
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1307, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 31;
            this.label5.Text = "3.윤곽선";
            // 
            // log_2
            // 
            this.log_2.Location = new System.Drawing.Point(662, 828);
            this.log_2.Multiline = true;
            this.log_2.Name = "log_2";
            this.log_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log_2.Size = new System.Drawing.Size(640, 194);
            this.log_2.TabIndex = 32;
            // 
            // targetWidthVal
            // 
            this.targetWidthVal.Location = new System.Drawing.Point(124, 134);
            this.targetWidthVal.Name = "targetWidthVal";
            this.targetWidthVal.Size = new System.Drawing.Size(100, 29);
            this.targetWidthVal.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(662, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "4.FindRect";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(662, 806);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 19);
            this.label6.TabIndex = 35;
            this.label6.Text = "4.FindRect";
            // 
            // targetWidth
            // 
            this.targetWidth.AutoSize = true;
            this.targetWidth.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.targetWidth.Location = new System.Drawing.Point(21, 137);
            this.targetWidth.Name = "targetWidth";
            this.targetWidth.Size = new System.Drawing.Size(78, 19);
            this.targetWidth.TabIndex = 36;
            this.targetWidth.Text = "Width : ";
            // 
            // targetHeight
            // 
            this.targetHeight.AutoSize = true;
            this.targetHeight.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.targetHeight.Location = new System.Drawing.Point(21, 183);
            this.targetHeight.Name = "targetHeight";
            this.targetHeight.Size = new System.Drawing.Size(85, 19);
            this.targetHeight.TabIndex = 38;
            this.targetHeight.Text = "Height : ";
            // 
            // targetHeightVal
            // 
            this.targetHeightVal.Location = new System.Drawing.Point(124, 180);
            this.targetHeightVal.Name = "targetHeightVal";
            this.targetHeightVal.Size = new System.Drawing.Size(100, 29);
            this.targetHeightVal.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(534, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 39;
            this.button1.Text = "적용";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.threshMaxVal);
            this.groupBox1.Controls.Add(this.thresh);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.yVal);
            this.groupBox1.Controls.Add(this.xVal);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.targetWidth);
            this.groupBox1.Controls.Add(this.targetHeight);
            this.groupBox1.Controls.Add(this.targetHeightVal);
            this.groupBox1.Controls.Add(this.targetWidthVal);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(1311, 542);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 480);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "설정";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(21, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 19);
            this.label7.TabIndex = 41;
            this.label7.Text = "X : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(21, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 19);
            this.label8.TabIndex = 43;
            this.label8.Text = "Y : ";
            // 
            // yVal
            // 
            this.yVal.Location = new System.Drawing.Point(124, 89);
            this.yVal.Name = "yVal";
            this.yVal.Size = new System.Drawing.Size(100, 29);
            this.yVal.TabIndex = 42;
            // 
            // xVal
            // 
            this.xVal.Location = new System.Drawing.Point(124, 44);
            this.xVal.Name = "xVal";
            this.xVal.Size = new System.Drawing.Size(100, 29);
            this.xVal.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(21, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 19);
            this.label9.TabIndex = 45;
            this.label9.Text = "thresh :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(21, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 19);
            this.label10.TabIndex = 47;
            this.label10.Text = "maxval : ";
            // 
            // threshMaxVal
            // 
            this.threshMaxVal.Location = new System.Drawing.Point(124, 273);
            this.threshMaxVal.Name = "threshMaxVal";
            this.threshMaxVal.Size = new System.Drawing.Size(100, 29);
            this.threshMaxVal.TabIndex = 46;
            // 
            // thresh
            // 
            this.thresh.Location = new System.Drawing.Point(124, 227);
            this.thresh.Name = "thresh";
            this.thresh.Size = new System.Drawing.Size(100, 29);
            this.thresh.TabIndex = 44;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1963, 1315);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.log_2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.log_1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox log_1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox log_2;
        private System.Windows.Forms.TextBox targetWidthVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label targetWidth;
        private System.Windows.Forms.Label targetHeight;
        private System.Windows.Forms.TextBox targetHeightVal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox yVal;
        private System.Windows.Forms.TextBox xVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox threshMaxVal;
        private System.Windows.Forms.TextBox thresh;
    }
}

