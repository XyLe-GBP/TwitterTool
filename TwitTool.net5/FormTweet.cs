using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitTool
{
    public partial class FormTweet : Form
    {
        public FormTweet()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Utils.token == null)
            {
                MessageBox.Show("トークンが取得されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("内容が記入されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.TextLength >= 140)
            {
                MessageBox.Show("ツイートの文字数制限を超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Utils.TextOnlyTweet(textBox1.Text);

                MessageBox.Show("ツイートを送信しました", "ツイート完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (Utils.token == null)
            {
                MessageBox.Show("トークンが取得されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (textBox1.TextLength >= 140)
            {
                MessageBox.Show("ツイートの文字数制限を超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool response = Utils.ImageTweet(textBox1.Text, Utils.GetTweetImageFileInfos());
                if (response == true)
                {
                    MessageBox.Show("ツイートを送信しました。", "ツイート完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ツイートに失敗しました。", "ツイート失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Utils.token == null)
            {
                MessageBox.Show("トークンが取得されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (textBox1.TextLength >= 140)
            {
                MessageBox.Show("ツイートの文字数制限を超えています。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool response = Utils.VideoTweet(textBox1.Text, Utils.GetTweetVideoFileInfo());
                if (response == true)
                {
                    MessageBox.Show("ツイートを送信しました。", "ツイート完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                else
                {
                    MessageBox.Show("ツイートに失敗しました。", "ツイート失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void FormTweet_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = Utils.profileimg;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using GraphicsPath gp = new();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new(gp);
            pictureBox1.Region = rg;
        }

    }
}
