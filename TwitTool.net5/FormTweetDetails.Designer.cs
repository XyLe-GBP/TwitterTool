
namespace TwitTool
{
    partial class FormTweetDetails
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label_TweetText = new System.Windows.Forms.Label();
            this.button_IsFavorite = new System.Windows.Forms.Button();
            this.pictureBox_Icon = new System.Windows.Forms.PictureBox();
            this.button_IsRetweet = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.label_ScreenName = new System.Windows.Forms.Label();
            this.backgroundWorker_Video = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_VideoAudio = new System.ComponentModel.BackgroundWorker();
            this.button_IsQuote = new System.Windows.Forms.Button();
            this.label_FavoritedCounts = new System.Windows.Forms.Label();
            this.label_RetweetedCounts = new System.Windows.Forms.Label();
            this.label_QuotedCounts = new System.Windows.Forms.Label();
            this.linkLabel_Client = new System.Windows.Forms.LinkLabel();
            this.groupBox_Quote = new System.Windows.Forms.GroupBox();
            this.label_QuoteScreenName = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label_QuoteTweetText = new System.Windows.Forms.Label();
            this.label_QuoteName = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icon)).BeginInit();
            this.groupBox_Quote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(330, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 165);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(13, 184);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(300, 165);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(330, 184);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(300, 165);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // label_TweetText
            // 
            this.label_TweetText.Location = new System.Drawing.Point(12, 408);
            this.label_TweetText.Name = "label_TweetText";
            this.label_TweetText.Size = new System.Drawing.Size(618, 136);
            this.label_TweetText.TabIndex = 4;
            this.label_TweetText.Text = "TweetText";
            // 
            // button_IsFavorite
            // 
            this.button_IsFavorite.Location = new System.Drawing.Point(12, 687);
            this.button_IsFavorite.Name = "button_IsFavorite";
            this.button_IsFavorite.Size = new System.Drawing.Size(159, 23);
            this.button_IsFavorite.TabIndex = 5;
            this.button_IsFavorite.Text = "このツイートにいいねする";
            this.button_IsFavorite.UseVisualStyleBackColor = true;
            this.button_IsFavorite.Click += new System.EventHandler(this.Button_IsFavorite_Click);
            // 
            // pictureBox_Icon
            // 
            this.pictureBox_Icon.Location = new System.Drawing.Point(12, 355);
            this.pictureBox_Icon.Name = "pictureBox_Icon";
            this.pictureBox_Icon.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Icon.TabIndex = 6;
            this.pictureBox_Icon.TabStop = false;
            this.pictureBox_Icon.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Icon_Paint);
            // 
            // button_IsRetweet
            // 
            this.button_IsRetweet.Location = new System.Drawing.Point(177, 687);
            this.button_IsRetweet.Name = "button_IsRetweet";
            this.button_IsRetweet.Size = new System.Drawing.Size(164, 23);
            this.button_IsRetweet.TabIndex = 7;
            this.button_IsRetweet.Text = "このツイートをリツイートする";
            this.button_IsRetweet.UseVisualStyleBackColor = true;
            this.button_IsRetweet.Click += new System.EventHandler(this.Button_IsRetweet_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(555, 687);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 8;
            this.button_OK.Text = "Done!";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // label_ScreenName
            // 
            this.label_ScreenName.AutoSize = true;
            this.label_ScreenName.Location = new System.Drawing.Point(68, 390);
            this.label_ScreenName.Name = "label_ScreenName";
            this.label_ScreenName.Size = new System.Drawing.Size(73, 15);
            this.label_ScreenName.TabIndex = 9;
            this.label_ScreenName.Text = "ScreenName";
            // 
            // backgroundWorker_Video
            // 
            this.backgroundWorker_Video.WorkerReportsProgress = true;
            this.backgroundWorker_Video.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_Video_DoWork);
            this.backgroundWorker_Video.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_Video_ProgressChanged);
            // 
            // backgroundWorker_VideoAudio
            // 
            this.backgroundWorker_VideoAudio.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_VideoAudio_DoWork);
            // 
            // button_IsQuote
            // 
            this.button_IsQuote.Location = new System.Drawing.Point(348, 687);
            this.button_IsQuote.Name = "button_IsQuote";
            this.button_IsQuote.Size = new System.Drawing.Size(201, 23);
            this.button_IsQuote.TabIndex = 10;
            this.button_IsQuote.Text = "このツイートを引用リツイートする";
            this.button_IsQuote.UseVisualStyleBackColor = true;
            this.button_IsQuote.Click += new System.EventHandler(this.Button_IsQuote_Click);
            // 
            // label_FavoritedCounts
            // 
            this.label_FavoritedCounts.AutoSize = true;
            this.label_FavoritedCounts.Location = new System.Drawing.Point(13, 717);
            this.label_FavoritedCounts.Name = "label_FavoritedCounts";
            this.label_FavoritedCounts.Size = new System.Drawing.Size(87, 15);
            this.label_FavoritedCounts.TabIndex = 11;
            this.label_FavoritedCounts.Text = "FavoritedCount";
            // 
            // label_RetweetedCounts
            // 
            this.label_RetweetedCounts.AutoSize = true;
            this.label_RetweetedCounts.Location = new System.Drawing.Point(177, 717);
            this.label_RetweetedCounts.Name = "label_RetweetedCounts";
            this.label_RetweetedCounts.Size = new System.Drawing.Size(94, 15);
            this.label_RetweetedCounts.TabIndex = 12;
            this.label_RetweetedCounts.Text = "RetweetedCount";
            // 
            // label_QuotedCounts
            // 
            this.label_QuotedCounts.AutoSize = true;
            this.label_QuotedCounts.Location = new System.Drawing.Point(348, 717);
            this.label_QuotedCounts.Name = "label_QuotedCounts";
            this.label_QuotedCounts.Size = new System.Drawing.Size(79, 15);
            this.label_QuotedCounts.TabIndex = 13;
            this.label_QuotedCounts.Text = "QuotedCount";
            // 
            // linkLabel_Client
            // 
            this.linkLabel_Client.AutoSize = true;
            this.linkLabel_Client.Location = new System.Drawing.Point(12, 669);
            this.linkLabel_Client.Name = "linkLabel_Client";
            this.linkLabel_Client.Size = new System.Drawing.Size(58, 15);
            this.linkLabel_Client.TabIndex = 14;
            this.linkLabel_Client.TabStop = true;
            this.linkLabel_Client.Text = "ClientText";
            this.linkLabel_Client.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Client_LinkClicked);
            // 
            // groupBox_Quote
            // 
            this.groupBox_Quote.Controls.Add(this.label_QuoteName);
            this.groupBox_Quote.Controls.Add(this.label_QuoteScreenName);
            this.groupBox_Quote.Controls.Add(this.pictureBox5);
            this.groupBox_Quote.Controls.Add(this.label_QuoteTweetText);
            this.groupBox_Quote.Location = new System.Drawing.Point(13, 547);
            this.groupBox_Quote.Name = "groupBox_Quote";
            this.groupBox_Quote.Size = new System.Drawing.Size(617, 119);
            this.groupBox_Quote.TabIndex = 15;
            this.groupBox_Quote.TabStop = false;
            this.groupBox_Quote.Text = "QuoteGroupBox";
            // 
            // label_QuoteScreenName
            // 
            this.label_QuoteScreenName.AutoSize = true;
            this.label_QuoteScreenName.Location = new System.Drawing.Point(42, 37);
            this.label_QuoteScreenName.Name = "label_QuoteScreenName";
            this.label_QuoteScreenName.Size = new System.Drawing.Size(106, 15);
            this.label_QuoteScreenName.TabIndex = 2;
            this.label_QuoteScreenName.Text = "QuoteScreenName";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(7, 23);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // label_QuoteTweetText
            // 
            this.label_QuoteTweetText.Location = new System.Drawing.Point(7, 53);
            this.label_QuoteTweetText.Name = "label_QuoteTweetText";
            this.label_QuoteTweetText.Size = new System.Drawing.Size(604, 63);
            this.label_QuoteTweetText.TabIndex = 0;
            this.label_QuoteTweetText.Text = "QuoteTweetText";
            // 
            // label_QuoteName
            // 
            this.label_QuoteName.AutoSize = true;
            this.label_QuoteName.Location = new System.Drawing.Point(42, 22);
            this.label_QuoteName.Name = "label_QuoteName";
            this.label_QuoteName.Size = new System.Drawing.Size(71, 15);
            this.label_QuoteName.TabIndex = 3;
            this.label_QuoteName.Text = "QuoteName";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(68, 375);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(38, 15);
            this.label_Name.TabIndex = 16;
            this.label_Name.Text = "Name";
            // 
            // FormTweetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 741);
            this.ControlBox = false;
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.groupBox_Quote);
            this.Controls.Add(this.linkLabel_Client);
            this.Controls.Add(this.label_QuotedCounts);
            this.Controls.Add(this.label_RetweetedCounts);
            this.Controls.Add(this.label_FavoritedCounts);
            this.Controls.Add(this.button_IsQuote);
            this.Controls.Add(this.label_ScreenName);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_IsRetweet);
            this.Controls.Add(this.pictureBox_Icon);
            this.Controls.Add(this.button_IsFavorite);
            this.Controls.Add(this.label_TweetText);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTweetDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ツイート詳細";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTweetDetails_FormClosed);
            this.Load += new System.EventHandler(this.FormTweetDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Icon)).EndInit();
            this.groupBox_Quote.ResumeLayout(false);
            this.groupBox_Quote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label_TweetText;
        private System.Windows.Forms.Button button_IsFavorite;
        private System.Windows.Forms.PictureBox pictureBox_Icon;
        private System.Windows.Forms.Button button_IsRetweet;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Label label_ScreenName;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Video;
        private System.ComponentModel.BackgroundWorker backgroundWorker_VideoAudio;
        private System.Windows.Forms.Button button_IsQuote;
        private System.Windows.Forms.Label label_FavoritedCounts;
        private System.Windows.Forms.Label label_RetweetedCounts;
        private System.Windows.Forms.Label label_QuotedCounts;
        private System.Windows.Forms.LinkLabel linkLabel_Client;
        private System.Windows.Forms.GroupBox groupBox_Quote;
        private System.Windows.Forms.Label label_QuoteScreenName;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label_QuoteTweetText;
        private System.Windows.Forms.Label label_QuoteName;
        private System.Windows.Forms.Label label_Name;
    }
}