
namespace TwitTool
{
    partial class FormFFLists
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
            this.button_OK = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.button_Unfollow = new System.Windows.Forms.Button();
            this.button_Follow = new System.Windows.Forms.Button();
            this.button_Search1 = new System.Windows.Forms.Button();
            this.button_Search2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_Search3 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_AccountCounts = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(11, 487);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(461, 42);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "Done";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(460, 323);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "アカウント名";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ステータス";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "JSONレスポンス";
            this.columnHeader3.Width = 150;
            // 
            // button_Unfollow
            // 
            this.button_Unfollow.Enabled = false;
            this.button_Unfollow.Location = new System.Drawing.Point(247, 458);
            this.button_Unfollow.Name = "button_Unfollow";
            this.button_Unfollow.Size = new System.Drawing.Size(225, 23);
            this.button_Unfollow.TabIndex = 2;
            this.button_Unfollow.Text = "選択したアカウントのフォローを解除する";
            this.button_Unfollow.UseVisualStyleBackColor = true;
            this.button_Unfollow.Click += new System.EventHandler(this.Button_Unfollow_Click);
            // 
            // button_Follow
            // 
            this.button_Follow.Enabled = false;
            this.button_Follow.Location = new System.Drawing.Point(11, 458);
            this.button_Follow.Name = "button_Follow";
            this.button_Follow.Size = new System.Drawing.Size(225, 23);
            this.button_Follow.TabIndex = 3;
            this.button_Follow.Text = "選択したアカウントをフォローする";
            this.button_Follow.UseVisualStyleBackColor = true;
            this.button_Follow.Click += new System.EventHandler(this.Button_Follow_Click);
            // 
            // button_Search1
            // 
            this.button_Search1.Location = new System.Drawing.Point(12, 343);
            this.button_Search1.Name = "button_Search1";
            this.button_Search1.Size = new System.Drawing.Size(460, 23);
            this.button_Search1.TabIndex = 5;
            this.button_Search1.Text = "自分がフォローしているがフォローされていないアカウントを取得";
            this.button_Search1.UseVisualStyleBackColor = true;
            this.button_Search1.Click += new System.EventHandler(this.Button_Search1_Click);
            // 
            // button_Search2
            // 
            this.button_Search2.Location = new System.Drawing.Point(12, 372);
            this.button_Search2.Name = "button_Search2";
            this.button_Search2.Size = new System.Drawing.Size(460, 23);
            this.button_Search2.TabIndex = 6;
            this.button_Search2.Text = "フォローされているが自分がフォローしていないアカウントを取得";
            this.button_Search2.UseVisualStyleBackColor = true;
            this.button_Search2.Click += new System.EventHandler(this.Button_Search2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "取得数 (項目x2件)：";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "50",
            "100",
            "150"});
            this.comboBox1.Location = new System.Drawing.Point(122, 430);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 23);
            this.comboBox1.TabIndex = 8;
            // 
            // button_Search3
            // 
            this.button_Search3.Location = new System.Drawing.Point(12, 401);
            this.button_Search3.Name = "button_Search3";
            this.button_Search3.Size = new System.Drawing.Size(460, 23);
            this.button_Search3.TabIndex = 9;
            this.button_Search3.Text = "相互フォローしているアカウントを取得";
            this.button_Search3.UseVisualStyleBackColor = true;
            this.button_Search3.Click += new System.EventHandler(this.Button_Search3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_AccountCounts});
            this.statusStrip1.Location = new System.Drawing.Point(0, 537);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_AccountCounts
            // 
            this.toolStripStatusLabel_AccountCounts.Name = "toolStripStatusLabel_AccountCounts";
            this.toolStripStatusLabel_AccountCounts.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel_AccountCounts.Text = "AccountConts";
            // 
            // FormFFLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 559);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_Search3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Search2);
            this.Controls.Add(this.button_Search1);
            this.Controls.Add(this.button_Follow);
            this.Controls.Add(this.button_Unfollow);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormFFLists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "フォロー・フォロワーリスト";
            this.Load += new System.EventHandler(this.FormFFLists_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button_Unfollow;
        private System.Windows.Forms.Button button_Follow;
        private System.Windows.Forms.Button button_Search1;
        private System.Windows.Forms.Button button_Search2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_Search3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_AccountCounts;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}