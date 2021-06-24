
namespace TwitTool
{
    partial class FormSearch
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
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox_SearchKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_EnableUserSearch = new System.Windows.Forms.CheckBox();
            this.checkBox_EnableDateSearch = new System.Windows.Forms.CheckBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.button_Close = new System.Windows.Forms.Button();
            this.comboBox_GetCount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Search
            // 
            this.button_Search.Enabled = false;
            this.button_Search.Location = new System.Drawing.Point(12, 216);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(200, 23);
            this.button_Search.TabIndex = 0;
            this.button_Search.Text = "Search!";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.Button_Search_Click);
            // 
            // textBox_SearchKeyword
            // 
            this.textBox_SearchKeyword.Location = new System.Drawing.Point(12, 31);
            this.textBox_SearchKeyword.MaxLength = 140;
            this.textBox_SearchKeyword.Name = "textBox_SearchKeyword";
            this.textBox_SearchKeyword.Size = new System.Drawing.Size(459, 23);
            this.textBox_SearchKeyword.TabIndex = 1;
            this.textBox_SearchKeyword.TextChanged += new System.EventHandler(this.TextBox_SearchKeyword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "検索するキーワード：";
            // 
            // checkBox_EnableUserSearch
            // 
            this.checkBox_EnableUserSearch.AutoSize = true;
            this.checkBox_EnableUserSearch.Location = new System.Drawing.Point(12, 65);
            this.checkBox_EnableUserSearch.Name = "checkBox_EnableUserSearch";
            this.checkBox_EnableUserSearch.Size = new System.Drawing.Size(171, 19);
            this.checkBox_EnableUserSearch.TabIndex = 3;
            this.checkBox_EnableUserSearch.Text = "ユーザー指定検索を有効にする";
            this.checkBox_EnableUserSearch.UseVisualStyleBackColor = true;
            this.checkBox_EnableUserSearch.CheckedChanged += new System.EventHandler(this.CheckBox_EnableUserSearch_CheckedChanged);
            // 
            // checkBox_EnableDateSearch
            // 
            this.checkBox_EnableDateSearch.AutoSize = true;
            this.checkBox_EnableDateSearch.Location = new System.Drawing.Point(12, 114);
            this.checkBox_EnableDateSearch.Name = "checkBox_EnableDateSearch";
            this.checkBox_EnableDateSearch.Size = new System.Drawing.Size(159, 19);
            this.checkBox_EnableDateSearch.TabIndex = 4;
            this.checkBox_EnableDateSearch.Text = "期間指定検索を有効にする";
            this.checkBox_EnableDateSearch.UseVisualStyleBackColor = true;
            this.checkBox_EnableDateSearch.CheckedChanged += new System.EventHandler(this.CheckBox_EnableDateSearch_CheckedChanged);
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Enabled = false;
            this.textBox_UserName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_UserName.Location = new System.Drawing.Point(91, 84);
            this.textBox_UserName.MaxLength = 15;
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(380, 23);
            this.textBox_UserName.TabIndex = 5;
            this.textBox_UserName.TextChanged += new System.EventHandler(this.TextBox_UserName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "ユーザー名：＠";
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Enabled = false;
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(91, 135);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(169, 23);
            this.dateTimePicker_StartDate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "期間を指定：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "～";
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Enabled = false;
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(290, 135);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(181, 23);
            this.dateTimePicker_EndDate.TabIndex = 10;
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(266, 216);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(205, 23);
            this.button_Close.TabIndex = 11;
            this.button_Close.Text = "閉じる";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // comboBox_GetCount
            // 
            this.comboBox_GetCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_GetCount.FormattingEnabled = true;
            this.comboBox_GetCount.Items.AddRange(new object[] {
            "5",
            "15",
            "25",
            "50",
            "75",
            "100",
            "125",
            "150",
            "175",
            "200",
            "225",
            "250",
            "275",
            "300"});
            this.comboBox_GetCount.Location = new System.Drawing.Point(129, 164);
            this.comboBox_GetCount.Name = "comboBox_GetCount";
            this.comboBox_GetCount.Size = new System.Drawing.Size(83, 23);
            this.comboBox_GetCount.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "取得数 (上限300)：";
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 251);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_GetCount);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.checkBox_EnableDateSearch);
            this.Controls.Add(this.checkBox_EnableUserSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_SearchKeyword);
            this.Controls.Add(this.button_Search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ツイート検索";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.TextBox textBox_SearchKeyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_EnableUserSearch;
        private System.Windows.Forms.CheckBox checkBox_EnableDateSearch;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.ComboBox comboBox_GetCount;
        private System.Windows.Forms.Label label5;
    }
}