using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitTool
{
    public partial class FormQuoteTweet : Form
    {
        public FormQuoteTweet()
        {
            InitializeComponent();
        }

        private void FormQuoteTweet_Load(object sender, EventArgs e)
        {
            try
            {
                label_QuoteTweet.Text = Utils.GetTweet(Utils.usrid[Utils.listindex]).Replace("\n", "\r\n");
                groupBox1.Text = Utils.usrscn[Utils.listindex] + " さんのツイート";
                pictureBox1.ImageLocation = Utils.profileimg;
                pictureBox2.ImageLocation = Utils.usricon[Utils.listindex];
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        private void Button_Quoted_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("内容が記入されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.TextLength >= 140)
            {
                MessageBox.Show("文字数制限を超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool rs = Utils.QuoteTweet(textBox1.Text, Utils.usrscn[Utils.listindex], Utils.usrid[Utils.listindex]);
                if (rs != false)
                {
                    MessageBox.Show("引用ツイートを行いました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                else
                {
                    Close();
                    return;
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                using GraphicsPath gp = new();
                gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
                Region rg = new(gp);
                pictureBox1.Region = rg;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                using GraphicsPath gp = new();
                gp.AddEllipse(0, 0, pictureBox2.Width - 3, pictureBox2.Height - 3);
                Region rg = new(gp);
                pictureBox2.Region = rg;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }
    }
}
