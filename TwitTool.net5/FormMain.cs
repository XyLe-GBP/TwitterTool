using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using CoreTweet;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TwitTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FreeConsole();

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text = "TwitterTool for .NET 5 ( build: 2021.07.02-Beta )";
            var ini = new PrivateProfile.IniFile(@".\\settings.ini");
            if (!File.Exists(@".\\settings.ini"))
            {
                ini.WriteString("TOKENS", "CONSUMER_KEY", "");
                ini.WriteString("TOKENS", "CONSUMER_SECRET", "");
                ini.WriteString("TOKENS", "ACCESS_TOKEN", "");
                ini.WriteString("TOKENS", "ACCESS_SECRET", "");
                ini.WriteString("TOKENS", "BEARER_TOKEN", "");
                ini.WriteString("ACCOUNT_1", "NAME", "");
                ini.WriteString("ACCOUNT_1", "ID", "");
                ini.WriteString("ACCOUNT_1", "ACCESS_TOKEN", "");
                ini.WriteString("ACCOUNT_1", "ACCESS_SECRET", "");
                ini.WriteString("ACCOUNT_2", "NAME", "");
                ini.WriteString("ACCOUNT_2", "ID", "");
                ini.WriteString("ACCOUNT_2", "ACCESS_TOKEN", "");
                ini.WriteString("ACCOUNT_2", "ACCESS_SECRET", "");
                ini.WriteString("ACCOUNT_3", "NAME", "");
                ini.WriteString("ACCOUNT_3", "ID", "");
                ini.WriteString("ACCOUNT_3", "ACCESS_TOKEN", "");
                ini.WriteString("ACCOUNT_3", "ACCESS_SECRET", "");
                ini.WriteString("ACCOUNT_4", "NAME", "");
                ini.WriteString("ACCOUNT_4", "ID", "");
                ini.WriteString("ACCOUNT_4", "ACCESS_TOKEN", "");
                ini.WriteString("ACCOUNT_4", "ACCESS_SECRET", "");
                ini.WriteString("ACCOUNT_5", "NAME", "");
                ini.WriteString("ACCOUNT_5", "ID", "");
                ini.WriteString("ACCOUNT_5", "ACCESS_TOKEN", "");
                ini.WriteString("ACCOUNT_5", "ACCESS_SECRET", "");
                ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "");
            }
            string ca = ini.GetString("OTHERS", "CURRENT_ACCOUNT");
            string user, id, at, ats;
            if (ca != "")
            {
                try
                {
                    switch (ca)
                    {
                        case "0":
                            user = ini.GetString("ACCOUNT_1", "NAME", "");
                            id = ini.GetString("ACCOUNT_1", "ID", "");
                            at = ini.GetString("ACCOUNT_1", "ACCESS_TOKEN", "");
                            ats = ini.GetString("ACCOUNT_1", "ACCESS_SECRET", "");
                            if (at != "" && ats != "" && user != "" && id != "")
                            {
                                if (Utils.TokensCheck() != true)
                                {
                                    MessageBox.Show("TwitterAPI アプリケーションのトークンが設定されていません。\n'設定→トークン設定' から設定を行ってください。", "トークン未設定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    toolStripStatusLabel2.Text = "トークンが設定されていないため、ユーザー名を取得できません";
                                    return;
                                }
                                Utils.token = Utils.TokenCreate(Utils.API_KEY, Utils.API_SECRET, at, ats, long.Parse(id), user);
                                if (Utils.SetProfileImg() != true)
                                {
                                    throw new Exception("ユーザーアイコン取得に失敗しました。");
                                }
                                else
                                {
                                    toolStripStatusLabel2.Text = "@" + user;
                                    comboBox1.SelectedIndex = 1;
                                }
                                return;
                            }
                            else
                            {
                                MessageBox.Show("アカウント情報の取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                toolStripStatusLabel2.Text = "アカウント情報の取得に失敗しました";
                                return;
                            }
                        case "1":
                            user = ini.GetString("ACCOUNT_2", "NAME");
                            id = ini.GetString("ACCOUNT_2", "ID");
                            at = ini.GetString("ACCOUNT_2", "ACCESS_TOKEN");
                            ats = ini.GetString("ACCOUNT_2", "ACCESS_SECRET");
                            if (at != "" && ats != "" && user != "" && id != "")
                            {
                                if (Utils.TokensCheck() != true)
                                {
                                    MessageBox.Show("TwitterAPI アプリケーションのトークンが設定されていません。\n'設定→トークン設定' から設定を行ってください。", "トークン未設定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    toolStripStatusLabel2.Text = "トークンが設定されていないため、ユーザー名を取得できません";
                                    return;
                                }
                                Utils.token = Utils.TokenCreate(Utils.API_KEY, Utils.API_SECRET, at, ats, long.Parse(id), user);
                                if (Utils.SetProfileImg() != true)
                                {
                                    throw new Exception("ユーザーアイコン取得に失敗しました。");
                                }
                                else
                                {
                                    toolStripStatusLabel2.Text = "@" + user;
                                    comboBox1.SelectedIndex = 1;
                                }
                                return;
                            }
                            else
                            {
                                MessageBox.Show("アカウント情報の取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                toolStripStatusLabel2.Text = "アカウント情報の取得に失敗しました";
                                return;
                            }
                        case "2":
                            user = ini.GetString("ACCOUNT_3", "NAME");
                            id = ini.GetString("ACCOUNT_3", "ID");
                            at = ini.GetString("ACCOUNT_3", "ACCESS_TOKEN");
                            ats = ini.GetString("ACCOUNT_3", "ACCESS_SECRET");
                            if (at != "" && ats != "" && user != "" && id != "")
                            {
                                if (Utils.TokensCheck() != true)
                                {
                                    MessageBox.Show("TwitterAPI アプリケーションのトークンが設定されていません。\n'設定→トークン設定' から設定を行ってください。", "トークン未設定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    toolStripStatusLabel2.Text = "トークンが設定されていないため、ユーザー名を取得できません";
                                    return;
                                }
                                Utils.token = Utils.TokenCreate(Utils.API_KEY, Utils.API_SECRET, at, ats, long.Parse(id), user);
                                if (Utils.SetProfileImg() != true)
                                {
                                    throw new Exception("ユーザーアイコン取得に失敗しました。");
                                }
                                else
                                {
                                    toolStripStatusLabel2.Text = "@" + user;
                                    comboBox1.SelectedIndex = 1;
                                }
                                return;
                            }
                            else
                            {
                                MessageBox.Show("アカウント情報の取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                toolStripStatusLabel2.Text = "アカウント情報の取得に失敗しました";
                                return;
                            }
                        case "3":
                            user = ini.GetString("ACCOUNT_4", "NAME");
                            id = ini.GetString("ACCOUNT_4", "ID");
                            at = ini.GetString("ACCOUNT_4", "ACCESS_TOKEN");
                            ats = ini.GetString("ACCOUNT_4", "ACCESS_SECRET");
                            if (at != "" && ats != "" && user != "" && id != "")
                            {
                                if (Utils.TokensCheck() != true)
                                {
                                    MessageBox.Show("TwitterAPI アプリケーションのトークンが設定されていません。\n'設定→トークン設定' から設定を行ってください。", "トークン未設定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    toolStripStatusLabel2.Text = "トークンが設定されていないため、ユーザー名を取得できません";
                                    return;
                                }
                                Utils.token = Utils.TokenCreate(Utils.API_KEY, Utils.API_SECRET, at, ats, long.Parse(id), user);
                                if (Utils.SetProfileImg() != true)
                                {
                                    throw new Exception("ユーザーアイコン取得に失敗しました。");
                                }
                                else
                                {
                                    toolStripStatusLabel2.Text = "@" + user;
                                    comboBox1.SelectedIndex = 1;
                                }
                                return;
                            }
                            else
                            {
                                MessageBox.Show("アカウント情報の取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                toolStripStatusLabel2.Text = "アカウント情報の取得に失敗しました";
                                return;
                            }
                        case "4":
                            user = ini.GetString("ACCOUNT_5", "NAME");
                            id = ini.GetString("ACCOUNT_5", "ID");
                            at = ini.GetString("ACCOUNT_5", "ACCESS_TOKEN");
                            ats = ini.GetString("ACCOUNT_5", "ACCESS_SECRET");
                            if (at != "" && ats != "" && user != "" && id != "")
                            {
                                if (Utils.TokensCheck() != true)
                                {
                                    MessageBox.Show("TwitterAPI アプリケーションのトークンが設定されていません。\n'設定→トークン設定' から設定を行ってください。", "トークン未設定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    toolStripStatusLabel2.Text = "トークンが設定されていないため、ユーザー名を取得できません";
                                    return;
                                }
                                Utils.token = Utils.TokenCreate(Utils.API_KEY, Utils.API_SECRET, at, ats, long.Parse(id), user);
                                if (Utils.SetProfileImg() != true)
                                {
                                    throw new Exception("ユーザーアイコン取得に失敗しました。");
                                }
                                else
                                {
                                    toolStripStatusLabel2.Text = "@" + user;
                                    comboBox1.SelectedIndex = 1;
                                }
                                return;
                            }
                            else
                            {
                                MessageBox.Show("アカウント情報の取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                toolStripStatusLabel2.Text = "アカウント情報の取得に失敗しました";
                                return;
                            }
                        default:
                            if (Utils.TokensCheck() != true)
                            {
                                MessageBox.Show("TwitterAPI アプリケーションのトークンが設定されていません。\n'設定→トークン設定' から設定を行ってください。", "トークン未設定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            toolStripStatusLabel2.Text = "アカウントがありません";
                            return;
                    }
                }
                catch (TwitterException ex)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                catch (WebException ex)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                catch (TimeoutException ex)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
            }
            else
            {
                if (Utils.TokensCheck() != true)
                {
                    MessageBox.Show("TwitterAPI アプリケーションのトークンが設定されていません。\n'設定→トークン設定' から設定を行ってください。", "トークン未設定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                toolStripStatusLabel2.Text = "アカウントがありません";
                return;
            }
        }

        private void ToolStripMenuItem_Accounts_Click(object sender, EventArgs e)
        {
            var formAccount = new FormAccount();
            formAccount.ShowDialog();
            formAccount.Dispose();
            var ini = new PrivateProfile.IniFile(@".\\settings.ini");
            string ca = ini.GetString("OTHERS", "CURRENT_ACCOUNT");
            if (ca != "")
            {
                switch (ca)
                {
                    case "0":
                        toolStripStatusLabel2.Text = "@" + ini.GetString("ACCOUNT_1", "NAME");
                        return;
                    case "1":
                        toolStripStatusLabel2.Text = "@" + ini.GetString("ACCOUNT_2", "NAME");
                        return;
                    case "2":
                        toolStripStatusLabel2.Text = "@" + ini.GetString("ACCOUNT_3", "NAME");
                        return;
                    case "3":
                        toolStripStatusLabel2.Text = "@" + ini.GetString("ACCOUNT_4", "NAME");
                        return;
                    case "4":
                        toolStripStatusLabel2.Text = "@" + ini.GetString("ACCOUNT_5", "NAME");
                        return;
                    default:
                        MessageBox.Show("アカウント情報の取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel2.Text = "アカウント情報の取得に失敗しました";
                        return;
                }
            }
            else
            {
                MessageBox.Show("アカウント情報の取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel2.Text = "アカウント情報の取得に失敗しました";
                return;
            }
        }

        private void ToolStripMenuItem_Tokens_Click(object sender, EventArgs e)
        {
            var formTokenSettings = new FormTokenSettings();
            formTokenSettings.ShowDialog();
            formTokenSettings.Dispose();
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            var formAbout = new FormAbout();
            formAbout.ShowDialog();
            formAbout.Dispose();
        }

        private void ToolStripMenuItem_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string netversion;
                WebClient wc = new();

                Stream st = wc.OpenRead("https://raw.githubusercontent.com/XyLe-GBP/TwitterTool/master/VERSIONINFO");
                StreamReader sr = new(st);
                netversion = sr.ReadToEnd();

                sr.Close();
                st.Close();

                FileVersionInfo ver = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);

                switch (ver.FileVersion.ToString().CompareTo(netversion[8..]))
                {
                    case -1:
                        DialogResult dr = MessageBox.Show(this, "最新バージョン：" + netversion[8..] + "\n現在のバージョン：" + ver.FileVersion + "\nアプリケーションのアップデートが可能です。サイトを開きますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            Utils.OpenURI("https://github.com/XyLe-GBP/TwitterTool");
                            return;
                        }
                        else
                        {
                            return;
                        }
                    case 0:
                        MessageBox.Show(this, "最新バージョン：" + netversion[8..] + "\n現在のバージョン：" + ver.FileVersion + "\nアプリケーションは最新です。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        throw new Exception(netversion[8..].ToString() + " < " + ver.FileVersion.ToString());
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Button_GetUserTimeline_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                listBox1.ClearSelected();
                listBox1.Items.Clear();
                var home = Utils.token.Statuses.UserTimeline(count => comboBox1.SelectedItem);
                foreach (var status in home)
                {
                    textBox1.AppendText(status.Text.Replace("\n", "\r\n") + "\r\n\r\n" + status.CreatedAt.LocalDateTime + "[" + status.User.Name + "] ( @" + status.User.ScreenName + " )" + Environment.NewLine + "------------------------" + Environment.NewLine + Environment.NewLine);
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Button_GetHomeTimeline_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                listBox1.ClearSelected();
                listBox1.Items.Clear();
                Utils.GetStatuses(int.Parse(comboBox1.SelectedItem.ToString()));

                var home = Utils.stat;
                foreach (var status in home)
                {
                    textBox1.AppendText(status.Text.Replace("\n", "\r\n") + "\r\n\r\n" + status.CreatedAt.LocalDateTime + " [" + status.User.Name + "] ( @" + status.User.ScreenName + " )" + Environment.NewLine + "------------------------" + Environment.NewLine + Environment.NewLine);
                    listBox1.Items.Add(status.Text);
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "予期せぬエラーが発生しました。\r\n\r\n" + ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Button_IsFavorite_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            uint rs = Utils.FavoriteTweet(Utils.usrid[index]);
            switch (rs)
            {
                case 0:
                    MessageBox.Show("ツイートのいいねに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 1:
                    listBox1.Items[index] = "[いいね済み] " + listBox1.Items[index].ToString();
                    MessageBox.Show("いいねしました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 2:
                    listBox1.Items[index] = "[いいね取り消し済み] " + listBox1.Items[index].ToString();
                    MessageBox.Show("いいねを取り消しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                default:
                    MessageBox.Show("ツイートのいいねに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }

        private void Button_IsRetweet_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            uint rs = Utils.Retweet(Utils.usrid[index]);
            switch (rs)
            {
                case 0:
                    MessageBox.Show("ツイートのリツイートに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 1:
                    listBox1.Items[index] = "[リツイート済み] " + listBox1.Items[index].ToString();
                    MessageBox.Show("リツイートしました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                case 2:
                    listBox1.Items[index] = "[リツイート取り消し済み] " + listBox1.Items[index].ToString();
                    MessageBox.Show("リツイート取り消しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                default:
                    MessageBox.Show("ツイートのリツイートに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }

        private void Button_IsQuoted_Click(object sender, EventArgs e)
        {
            Utils.listindex = listBox1.SelectedIndex;
            var formQuoteTweet = new FormQuoteTweet();
            formQuoteTweet.ShowDialog();
            formQuoteTweet.Dispose();
        }

        private void Button_Tweet_Click(object sender, EventArgs e)
        {
            var formTweet = new FormTweet();
            formTweet.ShowDialog();
            formTweet.Dispose();
        }

        private void Button_Reply_Click(object sender, EventArgs e)
        {
            Utils.listindex = listBox1.SelectedIndex;
            var formReply = new FormReply();
            formReply.ShowDialog();
            formReply.Dispose();
            return;
        }

        private void Button_Profile_Click(object sender, EventArgs e)
        {
            Utils.listindex = listBox1.SelectedIndex;
            var formProfile = new FormProfile();
            formProfile.ShowDialog();
            formProfile.Dispose();
            return;
        }

        private void Button_Search_Click(object sender, EventArgs e)
        {
            var formSearch = new FormSearch();
            formSearch.ShowDialog();
            formSearch.Dispose();
            listBox1.ClearSelected();
            textBox1.Clear();
            listBox1.Items.Clear();
            var home = Utils.SearchStatus;
            if (home != null)
            {
                foreach (var status in home)
                {
                    textBox1.AppendText(status.Text.Replace("\n", "\r\n") + "\r\n\r\n" + status.CreatedAt.LocalDateTime + " [" + status.User.Name + "] ( @" + status.User.ScreenName + " )" + Environment.NewLine + "------------------------" + Environment.NewLine + Environment.NewLine);
                    listBox1.Items.Add(status.Text);
                }
                return;
            }
            else
            {
                return;
            }
        }

        private void Button_TweetDetails_Click(object sender, EventArgs e)
        {
            Utils.listindex = listBox1.SelectedIndex;
            var formTweetDetails = new FormTweetDetails();
            formTweetDetails.ShowDialog();
            formTweetDetails.Dispose();
            return;
        }

        private void Button_Others_Click(object sender, EventArgs e)
        {
            long[] id = Utils.GetFavoritters(1407253505765638147);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button11.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button11.Enabled = false;
            }
        }

        private void FF_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFFLists = new FormFFLists();
            formFFLists.ShowDialog();
            formFFLists.Dispose();
        }

        private void AllBlock_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSearch = new FormSearch();
            formSearch.ShowDialog();
            formSearch.Dispose();
            var home = Utils.SearchStatus;
            if (home != null)
            {
                AllocConsole();
                foreach (var status in home)
                {
                    Utils.token.Blocks.Create(screen_name => status.User.ScreenName);
                    Console.WriteLine("User: @" + status.User.ScreenName + "( " + status.User.Name + " ) is blocked.");
                }
                System.Threading.Thread.Sleep(1000);
                FreeConsole();
                MessageBox.Show("特定キーワードが含まれているアカウントのブロックが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                return;
            }
        }
    }
}
