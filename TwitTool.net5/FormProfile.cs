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
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            try
            {
                var user = Utils.token.Friendships.Lookup(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                if (user.Json.Contains("followed_by") && !user.Json.Contains("following"))
                {
                    label6.Text = "フォローされています";
                    label6.ForeColor = Color.Green;
                    button1.Text = "このアカウントをフォローする";
                }
                else if (user.Json.Contains("following") && !user.Json.Contains("followed_by"))
                {
                    label6.Text = "フォローしています";
                    label6.ForeColor = Color.Red;
                    button1.Text = "このアカウントのフォローを解除する";
                }
                else if (user.Json.Contains("following") && user.Json.Contains("followed_by"))
                {
                    label6.Text = "相互フォローしています";
                    label6.ForeColor = Color.Blue;
                    button1.Text = "このアカウントのフォローを解除する";
                }
                else if (!user.Json.Contains("following") && !user.Json.Contains("followed_by"))
                {
                    label6.Text = "";
                    button1.Text = "このアカウントをフォローする";
                }
                else
                {
                    label6.Text = "";
                    button1.Text = "このアカウントをフォローする";
                }
                if (user.Json.Contains("muting"))
                {
                    button2.Text = "このアカウントのミュートを解除する";
                }
                else
                {
                    button2.Text = "このアカウントをミュートする";
                }
                if (user.Json.Contains("blocking"))
                {
                    button4.Text = "このアカウントのブロックを解除する";
                }
                else
                {
                    button4.Text = "このアカウントをブロックする";
                }
                label1.Text = Utils.usrname[Utils.listindex];
                label2.Text = Utils.usrscn[Utils.listindex];
                label3.Text = Utils.usrbio[Utils.listindex];
                label4.Text = Utils.usrfollows[Utils.listindex].ToString() + " フォロー中";
                label5.Text = Utils.usrfollowers[Utils.listindex].ToString() + " フォロワー";
                pictureBox1.ImageLocation = Utils.usricon[Utils.listindex];
                pictureBox2.ImageLocation = Utils.usrheader[Utils.listindex];
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
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

        private void Button1_Click(object sender, EventArgs e)
        {
            var user = Utils.token.Friendships.Lookup(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
            if (user.Json.Contains("followed_by") && !user.Json.Contains("following"))
            {
                DialogResult confirm = MessageBox.Show("このアカウントをフォローしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    Utils.token.Friendships.Create(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                    label6.Text = "相互フォローしています";
                    label6.ForeColor = Color.Blue;
                    button1.Text = "このアカウントのフォローを解除する";
                    return;
                }
                else
                {
                    return;
                }
            }
            else if (user.Json.Contains("following") && !user.Json.Contains("followed_by"))
            {
                DialogResult confirm = MessageBox.Show("このアカウントのフォローを解除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    Utils.token.Friendships.Destroy(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                    label6.Text = "";
                    button1.Text = "このアカウントをフォローする";
                    return;
                }
                else
                {
                    return;
                }
            }
            else if (user.Json.Contains("following") && user.Json.Contains("followed_by"))
            {
                DialogResult confirm = MessageBox.Show("このアカウントのフォローを解除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    Utils.token.Friendships.Destroy(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                    label6.Text = "フォローされています";
                    label6.ForeColor = Color.Green;
                    button1.Text = "このアカウントをフォローする";
                    return;
                }
                else
                {
                    return;
                }
            }
            else if (!user.Json.Contains("following") && !user.Json.Contains("followed_by"))
            {
                DialogResult confirm = MessageBox.Show("このアカウントをフォローしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    Utils.token.Friendships.Create(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                    label6.Text = "フォローしています";
                    label6.ForeColor = Color.Red;
                    button1.Text = "このアカウントのフォローを解除する";
                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                label6.Text = "";
                button1.Text = "このアカウントをフォローする";
                return;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var user = Utils.token.Friendships.Lookup(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
            if (user.Json.Contains("muting"))
            {
                Utils.token.Mutes.Users.Destroy(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                button4.Text = "このアカウントをミュートする";
                return;
            }
            else
            {
                Utils.token.Mutes.Users.Create(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                button4.Text = "このアカウントのミュートを解除する";
                return;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var user = Utils.token.Friendships.Lookup(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
            if (user.Json.Contains("blocking"))
            {
                Utils.token.Blocks.Destroy(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                button4.Text = "このアカウントをブロックする";
                return;
            }
            else
            {
                Utils.token.Blocks.Create(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""));
                button4.Text = "このアカウントのブロックを解除する";
                return;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Utils.token.Friendships.Update(screen_name => Utils.usrscn[Utils.listindex].Replace("@", ""), retweets => false);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }
    }
}
