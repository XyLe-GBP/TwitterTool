
namespace TwitTool
{
    partial class FormAbout
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.linkLabel_CoreTweet = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel_TwitterTool = new System.Windows.Forms.LinkLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel_OpenCV = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel_OpenCVorg = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "TwitterTool for .NET 5 - A simple Twitter client application.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Copyright © 2021 - XyLe. All Rights Reserved.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "This application uses the CoreTweet library.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(106, 406);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(429, 15);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Twitter API - Real-time access to the global conversation, right at your fingerti" +
    "ps.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_TwitterAPI_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(170, 485);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(79, 15);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "XyLe\'s Github";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Github_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(311, 485);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(124, 15);
            this.linkLabel3.TabIndex = 5;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "XyLe\'s Official website";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Website_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TwitTool.Properties.Resources.csharp_logo;
            this.pictureBox1.Location = new System.Drawing.Point(60, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TwitTool.Properties.Resources.TwitterLogo;
            this.pictureBox2.Location = new System.Drawing.Point(14, 381);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TwitTool.Properties.Resources.CoreTweet_Logo;
            this.pictureBox3.Location = new System.Drawing.Point(60, 157);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(460, 526);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 9;
            this.button_OK.Text = "Done!";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // linkLabel_CoreTweet
            // 
            this.linkLabel_CoreTweet.AutoSize = true;
            this.linkLabel_CoreTweet.Location = new System.Drawing.Point(208, 181);
            this.linkLabel_CoreTweet.Name = "linkLabel_CoreTweet";
            this.linkLabel_CoreTweet.Size = new System.Drawing.Size(238, 15);
            this.linkLabel_CoreTweet.TabIndex = 10;
            this.linkLabel_CoreTweet.TabStop = true;
            this.linkLabel_CoreTweet.Text = "CoreTweet - The modern .NET Twitter library.";
            this.linkLabel_CoreTweet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_CoreTweet_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Copyright © 2013-2018 CoreTweet Development Team";
            // 
            // linkLabel_TwitterTool
            // 
            this.linkLabel_TwitterTool.AutoSize = true;
            this.linkLabel_TwitterTool.Location = new System.Drawing.Point(197, 68);
            this.linkLabel_TwitterTool.Name = "linkLabel_TwitterTool";
            this.linkLabel_TwitterTool.Size = new System.Drawing.Size(247, 15);
            this.linkLabel_TwitterTool.TabIndex = 12;
            this.linkLabel_TwitterTool.TabStop = true;
            this.linkLabel_TwitterTool.Text = "TwitterTool for .NET 5 - A simple Twitter client.";
            this.linkLabel_TwitterTool.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_TwitterTool_LinkClicked);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(62, 460);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 64);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox4_Paint);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TwitTool.Properties.Resources.opencv_logo;
            this.pictureBox5.Location = new System.Drawing.Point(60, 275);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 64);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "This application uses the OpenCVSharp library.";
            // 
            // linkLabel_OpenCV
            // 
            this.linkLabel_OpenCV.AutoSize = true;
            this.linkLabel_OpenCV.Location = new System.Drawing.Point(213, 311);
            this.linkLabel_OpenCV.Name = "linkLabel_OpenCV";
            this.linkLabel_OpenCV.Size = new System.Drawing.Size(225, 15);
            this.linkLabel_OpenCV.TabIndex = 16;
            this.linkLabel_OpenCV.TabStop = true;
            this.linkLabel_OpenCV.Text = "OpenCVSharp - OpenCV wrapper for .NET";
            this.linkLabel_OpenCV.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_OpenCV_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Copyright © 2021 , OpenCV team";
            // 
            // linkLabel_OpenCVorg
            // 
            this.linkLabel_OpenCVorg.AutoSize = true;
            this.linkLabel_OpenCVorg.Location = new System.Drawing.Point(143, 292);
            this.linkLabel_OpenCVorg.Name = "linkLabel_OpenCVorg";
            this.linkLabel_OpenCVorg.Size = new System.Drawing.Size(392, 15);
            this.linkLabel_OpenCVorg.TabIndex = 18;
            this.linkLabel_OpenCVorg.TabStop = true;
            this.linkLabel_OpenCVorg.Text = "OpenCV is a highly optimized library with focus on real-time applications.";
            this.linkLabel_OpenCVorg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_OpenCVorg_LinkClicked);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 561);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel_OpenCVorg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkLabel_OpenCV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.linkLabel_TwitterTool);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel_CoreTweet);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TwitterTool for .NET 5 の情報";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.LinkLabel linkLabel_CoreTweet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel_TwitterTool;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel_OpenCV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel_OpenCVorg;
    }
}