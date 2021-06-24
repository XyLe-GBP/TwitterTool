using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreTweet;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TwitTool
{
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Utils.API_KEY == "" || Utils.API_SECRET == "")
            {
                MessageBox.Show("TwitterAPI アプリケーションのトークンが設定されていません。\n'設定→トークン設定' から設定を行ってください。", "トークン未設定", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Utils.token = Utils.TwitterOAuth(Utils.API_KEY, Utils.API_SECRET);
            if (Utils.token == null)
            {
                MessageBox.Show("トークンの取得に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var ini = new PrivateProfile.IniFile(@".\\settings.ini");
                string user1, user2, user3, user4, user5;
                user1 = ini.GetString("ACCOUNT_1", "NAME");
                user2 = ini.GetString("ACCOUNT_2", "NAME");
                user3 = ini.GetString("ACCOUNT_3", "NAME");
                user4 = ini.GetString("ACCOUNT_4", "NAME");
                user5 = ini.GetString("ACCOUNT_5", "NAME");
                if (user1 == "" && user2 == "" && user3 == "" && user4 == "" && user5 == "")
                {
                    string[] screen = { "@" + Utils.token.ScreenName, Utils.token.UserId.ToString() };
                    listView1.Items.Add(new ListViewItem(screen));
                    ini.WriteString("ACCOUNT_1", "NAME", Utils.token.ScreenName);
                    ini.WriteString("ACCOUNT_1", "ID", Utils.token.UserId.ToString());
                    ini.WriteString("ACCOUNT_1", "ACCESS_TOKEN", Utils.token.AccessToken);
                    ini.WriteString("ACCOUNT_1", "ACCESS_SECRET", Utils.token.AccessTokenSecret);
                    ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "0");
                    MessageBox.Show("アカウントの追加が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                else if (user1 != "" && user2 == "" && user3 == "" && user4 == "" && user5 == "")
                {
                    string[] screen = { "@" + Utils.token.ScreenName, Utils.token.UserId.ToString() };
                    listView1.Items.Add(new ListViewItem(screen));
                    ini.WriteString("ACCOUNT_2", "NAME", Utils.token.ScreenName);
                    ini.WriteString("ACCOUNT_2", "ID", Utils.token.UserId.ToString());
                    ini.WriteString("ACCOUNT_2", "ACCESS_TOKEN", Utils.token.AccessToken);
                    ini.WriteString("ACCOUNT_2", "ACCESS_SECRET", Utils.token.AccessTokenSecret);
                    ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "1");
                    MessageBox.Show("アカウントの追加が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                else if (user1 != "" && user2 != "" && user3 == "" && user4 == "" && user5 == "")
                {
                    string[] screen = { "@" + Utils.token.ScreenName, Utils.token.UserId.ToString() };
                    listView1.Items.Add(new ListViewItem(screen));
                    ini.WriteString("ACCOUNT_3", "NAME", Utils.token.ScreenName);
                    ini.WriteString("ACCOUNT_3", "ID", Utils.token.UserId.ToString());
                    ini.WriteString("ACCOUNT_3", "ACCESS_TOKEN", Utils.token.AccessToken);
                    ini.WriteString("ACCOUNT_3", "ACCESS_SECRET", Utils.token.AccessTokenSecret);
                    ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "2");
                    MessageBox.Show("アカウントの追加が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                else if (user1 != "" && user2 != "" && user3 != "" && user4 == "" && user5 == "")
                {
                    string[] screen = { "@" + Utils.token.ScreenName, Utils.token.UserId.ToString() };
                    listView1.Items.Add(new ListViewItem(screen));
                    ini.WriteString("ACCOUNT_4", "NAME", Utils.token.ScreenName);
                    ini.WriteString("ACCOUNT_4", "ID", Utils.token.UserId.ToString());
                    ini.WriteString("ACCOUNT_4", "ACCESS_TOKEN", Utils.token.AccessToken);
                    ini.WriteString("ACCOUNT_4", "ACCESS_SECRET", Utils.token.AccessTokenSecret);
                    ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "3");
                    MessageBox.Show("アカウントの追加が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                else if (user1 != "" && user2 != "" && user3 != "" && user4 != "" && user5 == "")
                {
                    string[] screen = { "@" + Utils.token.ScreenName, Utils.token.UserId.ToString() };
                    listView1.Items.Add(new ListViewItem(screen));
                    ini.WriteString("ACCOUNT_5", "NAME", Utils.token.ScreenName);
                    ini.WriteString("ACCOUNT_5", "ID", Utils.token.UserId.ToString());
                    ini.WriteString("ACCOUNT_5", "ACCESS_TOKEN", Utils.token.AccessToken);
                    ini.WriteString("ACCOUNT_5", "ACCESS_SECRET", Utils.token.AccessTokenSecret);
                    ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "4");
                    MessageBox.Show("アカウントの追加が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
                else if (user1 != "" && user2 != "" && user3 != "" && user4 != "" && user5 != "")
                {
                    MessageBox.Show("アカウントを5件以上追加することはできません。\n不要なアカウントを削除してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                }
                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            var ini = new PrivateProfile.IniFile(@".\\settings.ini");
            string user1, user2, user3, user4, user5, uid1, uid2, uid3, uid4, uid5;
            user1 = ini.GetString("ACCOUNT_1", "NAME");
            user2 = ini.GetString("ACCOUNT_2", "NAME");
            user3 = ini.GetString("ACCOUNT_3", "NAME");
            user4 = ini.GetString("ACCOUNT_4", "NAME");
            user5 = ini.GetString("ACCOUNT_5", "NAME");
            uid1 = ini.GetString("ACCOUNT_1", "ID");
            uid2 = ini.GetString("ACCOUNT_2", "ID");
            uid3 = ini.GetString("ACCOUNT_3", "ID");
            uid4 = ini.GetString("ACCOUNT_4", "ID");
            uid5 = ini.GetString("ACCOUNT_5", "ID");
            if (user1 == "" && user2 == "" && user3 == "" && user4 == "" && user5 == "")
            {
                return;
            }
            else if(user1 != "" && user2 == "" && user3 == "" && user4 == "" && user5 == "")
            {
                string[] screen = { "@" + user1, uid1.ToString() };
                listView1.Items.Add(new ListViewItem(screen));
                return;
            }
            else if (user1 != "" && user2 != "" && user3 == "" && user4 == "" && user5 == "")
            {
                string[] screen1 = { "@" + user1, uid1.ToString() };
                listView1.Items.Add(new ListViewItem(screen1));
                string[] screen2 = { "@" + user2, uid2.ToString() };
                listView1.Items.Add(new ListViewItem(screen2));
                return;
            }
            else if (user1 != "" && user2 != "" && user3 != "" && user4 == "" && user5 == "")
            {
                string[] screen1 = { "@" + user1, uid1.ToString() };
                listView1.Items.Add(new ListViewItem(screen1));
                string[] screen2 = { "@" + user2, uid2.ToString() };
                listView1.Items.Add(new ListViewItem(screen2));
                string[] screen3 = { "@" + user3, uid3.ToString() };
                listView1.Items.Add(new ListViewItem(screen3));
                return;
            }
            else if (user1 != "" && user2 != "" && user3 != "" && user4 != "" && user5 == "")
            {
                string[] screen1 = { "@" + user1, uid1.ToString() };
                listView1.Items.Add(new ListViewItem(screen1));
                string[] screen2 = { "@" + user2, uid2.ToString() };
                listView1.Items.Add(new ListViewItem(screen2));
                string[] screen3 = { "@" + user3, uid3.ToString() };
                listView1.Items.Add(new ListViewItem(screen3));
                string[] screen4 = { "@" + user4, uid4.ToString() };
                listView1.Items.Add(new ListViewItem(screen4));
                return;
            }
            else if (user1 != "" && user2 != "" && user3 != "" && user4 != "" && user5 != "")
            {
                string[] screen1 = { "@" + user1, uid1.ToString() };
                listView1.Items.Add(new ListViewItem(screen1));
                string[] screen2 = { "@" + user2, uid2.ToString() };
                listView1.Items.Add(new ListViewItem(screen2));
                string[] screen3 = { "@" + user3, uid3.ToString() };
                listView1.Items.Add(new ListViewItem(screen3));
                string[] screen4 = { "@" + user4, uid4.ToString() };
                listView1.Items.Add(new ListViewItem(screen4));
                string[] screen5 = { "@" + user5, uid5.ToString() };
                listView1.Items.Add(new ListViewItem(screen5));
                return;
            }
            else
            {
                return;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var ini = new PrivateProfile.IniFile(@".\\settings.ini");
            string ca = ini.GetString("OTHERS", "CURRENT_ACCOUNT");
            if (ca != "")
            {
                switch (ca)
                {
                    case "0":
                        Close();
                        return;
                    case "1":
                        Close();
                        return;
                    case "2":
                        Close();
                        return;
                    case "3":
                        Close();
                        return;
                    case "4":
                        Close();
                        return;
                    default:
                        MessageBox.Show("ツールで使用するアカウントが設定されていません。\nリストからアカウントを選択し '現在のアカウントに設定' ボタンをクリックしてください。", "アカウント設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
            }
            else
            {
                MessageBox.Show("ツールで使用するアカウントが設定されていません。\nリストからアカウントを選択し '現在のアカウントに設定' ボタンをクリックしてください。", "アカウント設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("現在選択されているアカウントを削除してもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    var ini = new PrivateProfile.IniFile(@".\\settings.ini");
                    int index = listView1.SelectedItems[0].Index;
                    switch (index)
                    {
                        case 0:
                            ini.WriteString("ACCOUNT_1", "NAME", ini.GetString("ACCOUNT_2", "NAME"));
                            ini.WriteString("ACCOUNT_1", "ID", ini.GetString("ACCOUNT_2", "ID"));
                            ini.WriteString("ACCOUNT_1", "ACCESS_TOKEN", ini.GetString("ACCOUNT_2", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_1", "ACCESS_SECRET", ini.GetString("ACCOUNT_2", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_2", "NAME", ini.GetString("ACCOUNT_3", "NAME"));
                            ini.WriteString("ACCOUNT_2", "ID", ini.GetString("ACCOUNT_3", "ID"));
                            ini.WriteString("ACCOUNT_2", "ACCESS_TOKEN", ini.GetString("ACCOUNT_3", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_2", "ACCESS_SECRET", ini.GetString("ACCOUNT_3", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_3", "NAME", ini.GetString("ACCOUNT_4", "NAME"));
                            ini.WriteString("ACCOUNT_3", "ID", ini.GetString("ACCOUNT_4", "ID"));
                            ini.WriteString("ACCOUNT_3", "ACCESS_TOKEN", ini.GetString("ACCOUNT_4", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_3", "ACCESS_SECRET", ini.GetString("ACCOUNT_4", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_4", "NAME", ini.GetString("ACCOUNT_5", "NAME"));
                            ini.WriteString("ACCOUNT_4", "ID", ini.GetString("ACCOUNT_5", "ID"));
                            ini.WriteString("ACCOUNT_4", "ACCESS_TOKEN", ini.GetString("ACCOUNT_5", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_4", "ACCESS_SECRET", ini.GetString("ACCOUNT_5", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_5", "NAME", "");
                            ini.WriteString("ACCOUNT_5", "ID", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_TOKEN", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_SECRET", "");
                            listView1.Items.Remove(listView1.SelectedItems[0]);
                            break;
                        case 1:
                            ini.WriteString("ACCOUNT_2", "NAME", ini.GetString("ACCOUNT_3", "NAME"));
                            ini.WriteString("ACCOUNT_2", "ID", ini.GetString("ACCOUNT_3", "ID"));
                            ini.WriteString("ACCOUNT_2", "ACCESS_TOKEN", ini.GetString("ACCOUNT_3", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_2", "ACCESS_SECRET", ini.GetString("ACCOUNT_3", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_3", "NAME", ini.GetString("ACCOUNT_4", "NAME"));
                            ini.WriteString("ACCOUNT_3", "ID", ini.GetString("ACCOUNT_4", "ID"));
                            ini.WriteString("ACCOUNT_3", "ACCESS_TOKEN", ini.GetString("ACCOUNT_4", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_3", "ACCESS_SECRET", ini.GetString("ACCOUNT_4", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_4", "NAME", ini.GetString("ACCOUNT_5", "NAME"));
                            ini.WriteString("ACCOUNT_4", "ID", ini.GetString("ACCOUNT_5", "ID"));
                            ini.WriteString("ACCOUNT_4", "ACCESS_TOKEN", ini.GetString("ACCOUNT_5", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_4", "ACCESS_SECRET", ini.GetString("ACCOUNT_5", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_5", "NAME", "");
                            ini.WriteString("ACCOUNT_5", "ID", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_TOKEN", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_SECRET", "");
                            listView1.Items.Remove(listView1.SelectedItems[1]);
                            break;
                        case 2:
                            ini.WriteString("ACCOUNT_3", "NAME", ini.GetString("ACCOUNT_4", "NAME"));
                            ini.WriteString("ACCOUNT_3", "ID", ini.GetString("ACCOUNT_4", "ID"));
                            ini.WriteString("ACCOUNT_3", "ACCESS_TOKEN", ini.GetString("ACCOUNT_4", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_3", "ACCESS_SECRET", ini.GetString("ACCOUNT_4", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_4", "NAME", ini.GetString("ACCOUNT_5", "NAME"));
                            ini.WriteString("ACCOUNT_4", "ID", ini.GetString("ACCOUNT_5", "ID"));
                            ini.WriteString("ACCOUNT_4", "ACCESS_TOKEN", ini.GetString("ACCOUNT_5", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_4", "ACCESS_SECRET", ini.GetString("ACCOUNT_5", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_5", "NAME", "");
                            ini.WriteString("ACCOUNT_5", "ID", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_TOKEN", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_SECRET", "");
                            listView1.Items.Remove(listView1.SelectedItems[2]);
                            break;
                        case 3:
                            ini.WriteString("ACCOUNT_4", "NAME", ini.GetString("ACCOUNT_5", "NAME"));
                            ini.WriteString("ACCOUNT_4", "ID", ini.GetString("ACCOUNT_5", "ID"));
                            ini.WriteString("ACCOUNT_4", "ACCESS_TOKEN", ini.GetString("ACCOUNT_5", "ACCESS_TOKEN"));
                            ini.WriteString("ACCOUNT_4", "ACCESS_SECRET", ini.GetString("ACCOUNT_5", "ACCESS_SECRET"));
                            ini.WriteString("ACCOUNT_5", "NAME", "");
                            ini.WriteString("ACCOUNT_5", "ID", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_TOKEN", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_SECRET", "");
                            listView1.Items.Remove(listView1.SelectedItems[3]);
                            break;
                        case 4:
                            ini.WriteString("ACCOUNT_5", "NAME", "");
                            ini.WriteString("ACCOUNT_5", "ID", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_TOKEN", "");
                            ini.WriteString("ACCOUNT_5", "ACCESS_SECRET", "");
                            listView1.Items.Remove(listView1.SelectedItems[4]);
                            break;
                        default:
                            break;
                    }
                    MessageBox.Show(string.Format("アカウント {0} の削除が完了しました。", index + 1), "アカウント削除完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var ini = new PrivateProfile.IniFile(@".\\settings.ini");
                int index = listView1.SelectedItems[0].Index;
                switch (index)
                {
                    case 0:
                        ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "0");
                        break;
                    case 1:
                        ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "1");
                        break;
                    case 2:
                        ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "2");
                        break;
                    case 3:
                        ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "3");
                        break;
                    case 4:
                        ini.WriteString("OTHERS", "CURRENT_ACCOUNT", "4");
                        break;
                    default:
                        break;
                }
                MessageBox.Show(string.Format("アカウント {0} を現在のアカウントに設定しました。", index + 1), "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("アカウントが変更されました。\n反映を行うため、アプリケーションを再起動します。", "アプリケーション再起動", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Application.Restart();
                return;
            }
            else
            {

            }
        }
    }
}
