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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            pictureBox4.ImageLocation = "https://avatars.githubusercontent.com/u/59692068?v=4";
        }

        private void LinkLabel_TwitterAPI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://developer.twitter.com/en/products/twitter-api");
            return;
        }

        private void LinkLabel_TwitterTool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://github.com/XyLe-GBP/TwitterTool");
            return;
        }

        private void LinkLabel_CoreTweet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://github.com/CoreTweet");
            return;
        }

        private void LinkLabel_OpenCVorg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://opencv.org/");
            return;
        }

        private void LinkLabel_OpenCV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://github.com/shimat/opencvsharp");
            return;
        }

        private void LinkLabel_Github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://github.com/XyLe-GBP");
            return;
        }

        private void LinkLabel_Website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://xyle-official.com");
            return;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void PictureBox4_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                using GraphicsPath gp = new();
                gp.AddEllipse(0, 0, pictureBox4.Width - 3, pictureBox4.Height - 3);
                Region rg = new(gp);
                pictureBox4.Region = rg;
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
