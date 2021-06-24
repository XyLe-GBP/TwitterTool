using CoreTweet;
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
using OpenCvSharp;
using OpenCvSharp.Extensions;
using NAudio.Wave;
using System.Diagnostics;
using System.IO;

namespace TwitTool
{
    public partial class FormTweetDetails : Form
    {
        private VideoCapture vcap;
        private Mat mat;

        public FormTweetDetails()
        {
            InitializeComponent();
        }

        private bool Mainimageflag = false;

        private void FormTweetDetails_Load(object sender, EventArgs e)
        {
            try
            {
                int favorited = Utils.GetTweetFavoritedCount(Utils.usrid[Utils.listindex]), retweeted = Utils.GetTweetRetweetedCount(Utils.usrid[Utils.listindex]);
                label_TweetText.Text = Utils.GetTweet(Utils.usrid[Utils.listindex]).Replace("\n", "\r\n");
                label_Name.Text = Utils.usrname[Utils.listindex];
                label_ScreenName.Text = Utils.usrscn[Utils.listindex] + " さんのツイート";
                linkLabel_Client.Text = "via " + Utils.GetTweetedSources(Utils.usrid[Utils.listindex]);
                label_QuotedCounts.Text = "";
                if (favorited != -1)
                {
                    label_FavoritedCounts.Text = favorited.ToString() + " 件のいいね";
                }
                else
                {
                    label_FavoritedCounts.Text = "いいねはまだありません";
                }
                if (retweeted != -1)
                {
                    label_RetweetedCounts.Text = retweeted.ToString() + " 件のリツイート";
                }
                else
                {
                    label_RetweetedCounts.Text = "リツイートはまだありません";
                }
                if (label_TweetText.Text.Contains("https://t.co/"))
                {
                    System.Net.WebClient wc = new();
                    string[] imgs = null;
                    long netspeed = Utils.ShowInterfaceSpeedAndQueue() / 1024;
                    if (netspeed < 1280)
                    {
                        imgs = Utils.GetTweetEntities(Utils.usrid[Utils.listindex], 0);
                    }
                    else if (netspeed > 1280 && netspeed < 20000)
                    {
                        imgs = Utils.GetTweetEntities(Utils.usrid[Utils.listindex], 1);
                    }
                    else if (netspeed > 20000)
                    {
                        imgs = Utils.GetTweetEntities(Utils.usrid[Utils.listindex], 2);
                    }
                    else
                    {
                        imgs = Utils.GetTweetEntities(Utils.usrid[Utils.listindex], 0);
                    }
                    
                    if (imgs != null)
                    {
                        if (imgs[0].Contains("/"))
                        {
                            Mainimageflag = true;
                        }
                        else
                        {
                            Mainimageflag = false;
                        }
                        switch (imgs.Length)
                        {
                            case 1:
                                if (imgs[0].Contains(".mp4"))
                                {
                                    wc.DownloadFile(imgs[0], @".\\TweetVideo.mp4");
                                    wc.Dispose();
                                    vcap = new VideoCapture(@".\\TweetVideo.mp4");
                                    backgroundWorker_Video.RunWorkerAsync();
                                    //backgroundWorker_VideoAudio.RunWorkerAsync();
                                    pictureBox1.Size = new System.Drawing.Size(616, 336);
                                    label_TweetText.Size = new System.Drawing.Size(618, 261);
                                    groupBox_Quote.Visible = false;
                                    label_QuoteName.Visible = false;
                                    label_QuoteScreenName.Visible = false;
                                    label_QuoteTweetText.Visible = false;
                                    pictureBox2.Visible = false;
                                    pictureBox3.Visible = false;
                                    pictureBox4.Visible = false;
                                    pictureBox5.Visible = false;
                                    break;
                                }
                                else if (Utils.entitiesid != null)
                                {
                                    label_TweetText.Size = new System.Drawing.Size(618,136);
                                    groupBox_Quote.Text = Utils.usrscn[Utils.listindex] + " Quoted tweet for " + Utils.GetTweetUserScreenName(long.Parse(Utils.entitiesid.Replace("id=", "")));
                                    label_QuoteName.Text = Utils.GetTweetUserName(long.Parse(Utils.entitiesid.Replace("id=", "")));
                                    label_QuoteScreenName.Text = Utils.GetTweetUserScreenName(long.Parse(Utils.entitiesid.Replace("id=", "")));
                                    label_QuoteTweetText.Text = Utils.GetTweet(long.Parse(Utils.entitiesid.Replace("id=", "")));
                                    pictureBox5.ImageLocation = Utils.GetTweetUserIcon(long.Parse(Utils.entitiesid.Replace("id=", "")));
                                    groupBox_Quote.Visible = true;
                                    label_QuoteName.Visible = true;
                                    label_QuoteScreenName.Visible = true;
                                    label_QuoteTweetText.Visible = true;
                                    pictureBox5.Visible = true;

                                    string[] quotedimgs = Utils.GetTweetEntities(long.Parse(Utils.entitiesid.Replace("id=", "")));
                                    if (quotedimgs != null && Mainimageflag != true)
                                    {
                                        switch (quotedimgs.Length)
                                        {
                                            case 1:
                                                if (quotedimgs[0].Contains(".mp4"))
                                                {
                                                    wc.DownloadFile(quotedimgs[0], @".\\TweetVideo.mp4");
                                                    wc.Dispose();
                                                    vcap = new VideoCapture(@".\\TweetVideo.mp4");
                                                    backgroundWorker_Video.RunWorkerAsync();
                                                    //backgroundWorker_VideoAudio.RunWorkerAsync();
                                                    pictureBox1.Size = new System.Drawing.Size(616, 336);
                                                    pictureBox2.Visible = false;
                                                    pictureBox3.Visible = false;
                                                    pictureBox4.Visible = false;
                                                    break;
                                                }
                                                else if (Utils.entitiesid != null)
                                                {
                                                    // looped
                                                    break;
                                                }
                                                else
                                                {
                                                    pictureBox1.ImageLocation = quotedimgs[0];
                                                    pictureBox1.Size = new System.Drawing.Size(616, 336);
                                                    pictureBox2.Visible = false;
                                                    pictureBox3.Visible = false;
                                                    pictureBox4.Visible = false;
                                                    break;
                                                }
                                            case 2:
                                                pictureBox1.ImageLocation = quotedimgs[0];
                                                pictureBox2.ImageLocation = quotedimgs[1];
                                                pictureBox1.Size = new System.Drawing.Size(300, 336);
                                                pictureBox2.Size = new System.Drawing.Size(300, 336);
                                                pictureBox3.Visible = false;
                                                pictureBox4.Visible = false;
                                                break;
                                            case 3:
                                                pictureBox1.ImageLocation = quotedimgs[0];
                                                pictureBox2.ImageLocation = quotedimgs[1];
                                                pictureBox3.ImageLocation = quotedimgs[2];
                                                pictureBox3.Size = new System.Drawing.Size(616, 165);
                                                pictureBox4.Visible = false;
                                                break;
                                            case 4:
                                                pictureBox1.ImageLocation = quotedimgs[0];
                                                pictureBox2.ImageLocation = quotedimgs[1];
                                                pictureBox3.ImageLocation = quotedimgs[2];
                                                pictureBox4.ImageLocation = quotedimgs[3];
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        if (Mainimageflag != true)
                                        {
                                            pictureBox1.Visible = false;
                                            pictureBox2.Visible = false;
                                            pictureBox3.Visible = false;
                                            pictureBox4.Visible = false;
                                            break;
                                        }
                                        else
                                        {
                                            pictureBox1.ImageLocation = imgs[0];
                                            pictureBox1.Size = new System.Drawing.Size(616, 336);
                                            pictureBox2.Visible = false;
                                            pictureBox3.Visible = false;
                                            pictureBox4.Visible = false;
                                            break;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    groupBox_Quote.Visible = false;
                                    label_TweetText.Size = new System.Drawing.Size(618, 261);
                                    label_QuoteName.Visible = false;
                                    label_QuoteScreenName.Visible = false;
                                    label_QuoteTweetText.Visible = false;

                                    pictureBox1.ImageLocation = imgs[0];
                                    pictureBox1.Size = new System.Drawing.Size(616, 336);
                                    pictureBox2.Visible = false;
                                    pictureBox3.Visible = false;
                                    pictureBox4.Visible = false;
                                    pictureBox5.Visible = false;
                                    break;
                                }
                            case 2:
                                groupBox_Quote.Visible = false;
                                label_TweetText.Size = new System.Drawing.Size(618, 261);
                                label_QuoteName.Visible = false;
                                label_QuoteScreenName.Visible = false;
                                label_QuoteTweetText.Visible = false;

                                pictureBox1.ImageLocation = imgs[0];
                                pictureBox2.ImageLocation = imgs[1];
                                pictureBox1.Size = new System.Drawing.Size(300, 336);
                                pictureBox2.Size = new System.Drawing.Size(300, 336);
                                pictureBox3.Visible = false;
                                pictureBox4.Visible = false;
                                pictureBox5.Visible = false;
                                break;
                            case 3:
                                groupBox_Quote.Visible = false;
                                label_TweetText.Size = new System.Drawing.Size(618, 261);
                                label_QuoteName.Visible = false;
                                label_QuoteScreenName.Visible = false;
                                label_QuoteTweetText.Visible = false;

                                pictureBox1.ImageLocation = imgs[0];
                                pictureBox2.ImageLocation = imgs[1];
                                pictureBox3.ImageLocation = imgs[2];
                                pictureBox3.Size = new System.Drawing.Size(616, 165);
                                pictureBox4.Visible = false;
                                pictureBox5.Visible = false;
                                break;
                            case 4:
                                groupBox_Quote.Visible = false;
                                label_TweetText.Size = new System.Drawing.Size(618, 261);
                                label_QuoteName.Visible = false;
                                label_QuoteScreenName.Visible = false;
                                label_QuoteTweetText.Visible = false;

                                pictureBox1.ImageLocation = imgs[0];
                                pictureBox2.ImageLocation = imgs[1];
                                pictureBox3.ImageLocation = imgs[2];
                                pictureBox4.ImageLocation = imgs[3];
                                pictureBox5.Visible = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    groupBox_Quote.Visible = false;
                    label_TweetText.Size = new System.Drawing.Size(618, 261);
                    label_QuoteName.Visible = false;
                    label_QuoteScreenName.Visible = false;
                    label_QuoteTweetText.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                }
                
                pictureBox_Icon.ImageLocation = Utils.usricon[Utils.listindex];

                Status status = Utils.token.Statuses.Show(id => Utils.usrid[Utils.listindex]);

                if ((bool)status.IsFavorited == false)
                {
                    button_IsFavorite.Text = "このツイートにいいねする";
                }
                else
                {
                    label_FavoritedCounts.ForeColor = Color.Red;
                    button_IsFavorite.Text = "このツイートへのいいねを取り消す";
                }
                if ((bool)status.IsRetweeted == false)
                {
                    button_IsRetweet.Text = "このツイートをリツイートする";
                }
                else
                {
                    label_RetweetedCounts.ForeColor = Color.Green;
                    button_IsRetweet.Text = "このツイートへのリツイートを取り消す";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        private void Button_IsFavorite_Click(object sender, EventArgs e)
        {
            uint rs = Utils.FavoriteTweet(Utils.usrid[Utils.listindex]);
            switch (rs)
            {
                case 0:
                    MessageBox.Show("ツイートのいいねに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 1:
                    MessageBox.Show("いいねしました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label_FavoritedCounts.ForeColor = Color.Red;
                    button_IsFavorite.Text = "このツイートへのいいねを取り消す";
                    return;
                case 2:
                    MessageBox.Show("いいねを取り消しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label_FavoritedCounts.ForeColor = Color.Black;
                    button_IsFavorite.Text = "このツイートにいいねする";
                    return;
                default:
                    MessageBox.Show("ツイートのいいねに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }

        private void Button_IsRetweet_Click(object sender, EventArgs e)
        {
            uint rs = Utils.Retweet(Utils.usrid[Utils.listindex]);
            switch (rs)
            {
                case 0:
                    MessageBox.Show("ツイートのリツイートに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 1:
                    MessageBox.Show("リツイートしました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label_RetweetedCounts.ForeColor = Color.Green;
                    button_IsRetweet.Text = "このツイートへのリツイートを取り消す";
                    return;
                case 2:
                    MessageBox.Show("リツイート取り消しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label_RetweetedCounts.ForeColor = Color.Black;
                    button_IsRetweet.Text = "このツイートをリツイートする";
                    return;
                default:
                    MessageBox.Show("ツイートのリツイートに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }

        private void Button_IsQuote_Click(object sender, EventArgs e)
        {
            var formQuoteTweet = new FormQuoteTweet();
            formQuoteTweet.ShowDialog();
            formQuoteTweet.Dispose();
            Close();
        }

        private void LinkLabel_Client_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURI("https://help.twitter.com/using-twitter/how-to-tweet#source-labels");
            return;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void PictureBox_Icon_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                using GraphicsPath gp = new();
                gp.AddEllipse(0, 0, pictureBox_Icon.Width - 3, pictureBox_Icon.Height - 3);
                Region rg = new(gp);
                pictureBox_Icon.Region = rg;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        private void BackgroundWorker_Video_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;
            
            while (vcap.IsOpened())
            {
                mat = new Mat();

                if (vcap.Read(mat))
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();//Memory release
                    }

                    if (mat.IsContinuous())
                    {
                        bw.ReportProgress(0, BitmapConverter.ToBitmap(mat));
                    }
                    else
                    {
                        break;
                    }
                    //Application.DoEvents(); // 非推奨
                }
                else
                {
                    break;
                }
                int interval = (int)(895 / vcap.Fps);
                System.Threading.Thread.Sleep(interval);
                mat.Dispose();//Memory release
            }

            vcap.Dispose();//Memory release
        }

        private void BackgroundWorker_Video_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pictureBox1.Image = (Bitmap)e.UserState;
        }

        private void BackgroundWorker_VideoAudio_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = (BackgroundWorker)sender;

            using var player = new WaveOut();
            using var reader = new MediaFoundationReader(@".\TweetVideo.mp4");
            player.Init(WaveFormatConversionStream.CreatePcmStream(reader));
            player.Play();

            FormClosed += (cs, ce) => player.Stop();
            while (reader.CurrentTime < reader.TotalTime && player.PlaybackState != PlaybackState.Stopped)
            {
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
        }

        private void FormTweetDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundWorker_Video.Dispose();
            backgroundWorker_VideoAudio.Dispose();
            if (vcap != null)
            {
                vcap.Dispose();
            }
            if (Utils.entitiesid != null)
            {
                Utils.entitiesid = null;
            }

            if (File.Exists(@".\TweetVideo.mp4"))
            {
                File.Delete(@".\TweetVideo.mp4");
                return;
            }
            else
            {
                return;
            }
        }

    }
}
