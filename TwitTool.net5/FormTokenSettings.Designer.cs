
namespace TwitTool
{
    partial class FormTokenSettings
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_CK = new System.Windows.Forms.TextBox();
            this.textBox_CS = new System.Windows.Forms.TextBox();
            this.textBox_AT = new System.Windows.Forms.TextBox();
            this.textBox_AS = new System.Windows.Forms.TextBox();
            this.textBox_BT = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_CK_Status = new System.Windows.Forms.Label();
            this.label_CS_Status = new System.Windows.Forms.Label();
            this.label_AT_Status = new System.Windows.Forms.Label();
            this.label_AS_Status = new System.Windows.Forms.Label();
            this.label_BT_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONSUMER_KEY:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "CONSUMER_SECRET:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "ACCESS_TOKEN:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "ACCESS_SECRET:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "ツイートに使用するTwitterAPI アプリケーションのトークンを設定してください。";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(12, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(265, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "※設定を行わないとほとんどの機能は利用できません。";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "BEARER_TOKEN (Optional):";
            // 
            // textBox_CK
            // 
            this.textBox_CK.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_CK.Location = new System.Drawing.Point(168, 47);
            this.textBox_CK.MaxLength = 25;
            this.textBox_CK.Name = "textBox_CK";
            this.textBox_CK.Size = new System.Drawing.Size(362, 23);
            this.textBox_CK.TabIndex = 7;
            this.textBox_CK.TextChanged += new System.EventHandler(this.TextBox_CK_TextChanged);
            // 
            // textBox_CS
            // 
            this.textBox_CS.Enabled = false;
            this.textBox_CS.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_CS.Location = new System.Drawing.Point(168, 74);
            this.textBox_CS.MaxLength = 50;
            this.textBox_CS.Name = "textBox_CS";
            this.textBox_CS.Size = new System.Drawing.Size(362, 23);
            this.textBox_CS.TabIndex = 8;
            this.textBox_CS.TextChanged += new System.EventHandler(this.TextBox_CS_TextChanged);
            // 
            // textBox_AT
            // 
            this.textBox_AT.Enabled = false;
            this.textBox_AT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_AT.Location = new System.Drawing.Point(168, 101);
            this.textBox_AT.MaxLength = 50;
            this.textBox_AT.Name = "textBox_AT";
            this.textBox_AT.Size = new System.Drawing.Size(362, 23);
            this.textBox_AT.TabIndex = 9;
            this.textBox_AT.TextChanged += new System.EventHandler(this.TextBox_AT_TextChanged);
            // 
            // textBox_AS
            // 
            this.textBox_AS.Enabled = false;
            this.textBox_AS.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_AS.Location = new System.Drawing.Point(168, 129);
            this.textBox_AS.MaxLength = 45;
            this.textBox_AS.Name = "textBox_AS";
            this.textBox_AS.Size = new System.Drawing.Size(362, 23);
            this.textBox_AS.TabIndex = 10;
            this.textBox_AS.TextChanged += new System.EventHandler(this.TextBox_AS_TextChanged);
            // 
            // textBox_BT
            // 
            this.textBox_BT.Enabled = false;
            this.textBox_BT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_BT.Location = new System.Drawing.Point(168, 157);
            this.textBox_BT.MaxLength = 116;
            this.textBox_BT.Name = "textBox_BT";
            this.textBox_BT.Size = new System.Drawing.Size(362, 23);
            this.textBox_BT.TabIndex = 11;
            this.textBox_BT.TextChanged += new System.EventHandler(this.TextBox_BT_TextChanged);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(455, 202);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 12;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(374, 202);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 13;
            this.button_Cancel.Text = "キャンセル";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // label_CK_Status
            // 
            this.label_CK_Status.AutoSize = true;
            this.label_CK_Status.Location = new System.Drawing.Point(534, 50);
            this.label_CK_Status.Name = "label_CK_Status";
            this.label_CK_Status.Size = new System.Drawing.Size(39, 15);
            this.label_CK_Status.TabIndex = 14;
            this.label_CK_Status.Text = "Status";
            // 
            // label_CS_Status
            // 
            this.label_CS_Status.AutoSize = true;
            this.label_CS_Status.Location = new System.Drawing.Point(534, 77);
            this.label_CS_Status.Name = "label_CS_Status";
            this.label_CS_Status.Size = new System.Drawing.Size(39, 15);
            this.label_CS_Status.TabIndex = 15;
            this.label_CS_Status.Text = "Status";
            // 
            // label_AT_Status
            // 
            this.label_AT_Status.AutoSize = true;
            this.label_AT_Status.Location = new System.Drawing.Point(534, 104);
            this.label_AT_Status.Name = "label_AT_Status";
            this.label_AT_Status.Size = new System.Drawing.Size(39, 15);
            this.label_AT_Status.TabIndex = 16;
            this.label_AT_Status.Text = "Status";
            // 
            // label_AS_Status
            // 
            this.label_AS_Status.AutoSize = true;
            this.label_AS_Status.Location = new System.Drawing.Point(534, 132);
            this.label_AS_Status.Name = "label_AS_Status";
            this.label_AS_Status.Size = new System.Drawing.Size(39, 15);
            this.label_AS_Status.TabIndex = 17;
            this.label_AS_Status.Text = "Status";
            // 
            // label_BT_Status
            // 
            this.label_BT_Status.AutoSize = true;
            this.label_BT_Status.Location = new System.Drawing.Point(534, 160);
            this.label_BT_Status.Name = "label_BT_Status";
            this.label_BT_Status.Size = new System.Drawing.Size(39, 15);
            this.label_BT_Status.TabIndex = 18;
            this.label_BT_Status.Text = "Status";
            // 
            // FormTokenSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 237);
            this.ControlBox = false;
            this.Controls.Add(this.label_BT_Status);
            this.Controls.Add(this.label_AS_Status);
            this.Controls.Add(this.label_AT_Status);
            this.Controls.Add(this.label_CS_Status);
            this.Controls.Add(this.label_CK_Status);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_BT);
            this.Controls.Add(this.textBox_AS);
            this.Controls.Add(this.textBox_AT);
            this.Controls.Add(this.textBox_CS);
            this.Controls.Add(this.textBox_CK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTokenSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "トークン設定";
            this.Load += new System.EventHandler(this.FormTokenSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_CK;
        private System.Windows.Forms.TextBox textBox_CS;
        private System.Windows.Forms.TextBox textBox_AT;
        private System.Windows.Forms.TextBox textBox_AS;
        private System.Windows.Forms.TextBox textBox_BT;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_CK_Status;
        private System.Windows.Forms.Label label_CS_Status;
        private System.Windows.Forms.Label label_AT_Status;
        private System.Windows.Forms.Label label_AS_Status;
        private System.Windows.Forms.Label label_BT_Status;
    }
}