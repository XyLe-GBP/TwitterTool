using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitTool
{
    public partial class FormFFLists : Form
    {
        public FormFFLists()
        {
            InitializeComponent();
        }

        private uint flag = 0;

        private void FormFFLists_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            toolStripStatusLabel_AccountCounts.Text = "";
            comboBox1.SelectedIndex = 1;
        }

        private void Button_Search1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }
            string subitemstring1 = "フォローされていません";
            string subitemstring2 = "'following'";
            Utils.usrnamelists = Utils.GetFollowerLists(int.Parse(comboBox1.SelectedItem.ToString()));
            Utils.SplittingUserList();
            if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null && Utils.usrnameArray4 != null && Utils.usrnameArray5 != null)
            {
                Utils.notfriendsusrArray1 = Utils.GetNotFriendsLists(Utils.usrnameArray1);
                Utils.notfriendsusrArray2 = Utils.GetNotFriendsLists(Utils.usrnameArray2);
                Utils.notfriendsusrArray3 = Utils.GetNotFriendsLists(Utils.usrnameArray3);
                Utils.notfriendsusrArray4 = Utils.GetNotFriendsLists(Utils.usrnameArray4);
                Utils.notfriendsusrArray5 = Utils.GetNotFriendsLists(Utils.usrnameArray5);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.notfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray4.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray4[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray5.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray5[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローされていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null && Utils.usrnameArray4 != null)
            {
                Utils.notfriendsusrArray1 = Utils.GetNotFriendsLists(Utils.usrnameArray1);
                Utils.notfriendsusrArray2 = Utils.GetNotFriendsLists(Utils.usrnameArray2);
                Utils.notfriendsusrArray3 = Utils.GetNotFriendsLists(Utils.usrnameArray3);
                Utils.notfriendsusrArray4 = Utils.GetNotFriendsLists(Utils.usrnameArray4);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.notfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray4.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray4[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローされていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null)
            {
                Utils.notfriendsusrArray1 = Utils.GetNotFriendsLists(Utils.usrnameArray1);
                Utils.notfriendsusrArray2 = Utils.GetNotFriendsLists(Utils.usrnameArray2);
                Utils.notfriendsusrArray3 = Utils.GetNotFriendsLists(Utils.usrnameArray3);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.notfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローされていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null)
            {
                Utils.notfriendsusrArray1 = Utils.GetNotFriendsLists(Utils.usrnameArray1);
                Utils.notfriendsusrArray2 = Utils.GetNotFriendsLists(Utils.usrnameArray2);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.notfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                for (int i = 0; i < Utils.notfriendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローされていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null)
            {
                Utils.notfriendsusrArray1 = Utils.GetNotFriendsLists(Utils.usrnameArray1);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.notfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.notfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);

                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローされていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("フォローされていないアカウントは存在しません。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripStatusLabel_AccountCounts.Text = "フォローされていないアカウントは存在しません";
            }
            flag = 1;
        }

        private void Button_Search2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }
            string subitemstring1 = "フォローされています";
            string subitemstring2 = "'followed_by'";
            Utils.usrnamelists = Utils.GetFollowerLists(int.Parse(comboBox1.SelectedItem.ToString()));
            Utils.SplittingUserList();
            if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null && Utils.usrnameArray4 != null && Utils.usrnameArray5 != null)
            {
                Utils.friendsusrArray1 = Utils.GetFriendsLists(Utils.usrnameArray1);
                Utils.friendsusrArray2 = Utils.GetFriendsLists(Utils.usrnameArray2);
                Utils.friendsusrArray3 = Utils.GetFriendsLists(Utils.usrnameArray3);
                Utils.friendsusrArray4 = Utils.GetFriendsLists(Utils.usrnameArray4);
                Utils.friendsusrArray5 = Utils.GetFriendsLists(Utils.usrnameArray5);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.friendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray4.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray4[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray5.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray5[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローしていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null && Utils.usrnameArray4 != null)
            {
                Utils.friendsusrArray1 = Utils.GetFriendsLists(Utils.usrnameArray1);
                Utils.friendsusrArray2 = Utils.GetFriendsLists(Utils.usrnameArray2);
                Utils.friendsusrArray3 = Utils.GetFriendsLists(Utils.usrnameArray3);
                Utils.friendsusrArray4 = Utils.GetFriendsLists(Utils.usrnameArray4);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.friendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray4.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray4[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローしていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null)
            {
                Utils.friendsusrArray1 = Utils.GetFriendsLists(Utils.usrnameArray1);
                Utils.friendsusrArray2 = Utils.GetFriendsLists(Utils.usrnameArray2);
                Utils.friendsusrArray3 = Utils.GetFriendsLists(Utils.usrnameArray3);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.friendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローしていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null)
            {
                Utils.friendsusrArray1 = Utils.GetFriendsLists(Utils.usrnameArray1);
                Utils.friendsusrArray2 = Utils.GetFriendsLists(Utils.usrnameArray2);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.friendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.friendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローしていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null)
            {
                Utils.friendsusrArray1 = Utils.GetFriendsLists(Utils.usrnameArray1);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.friendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.friendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "フォローしていないアカウントの数：" + listView1.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("フォローしていないアカウントは存在しません。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripStatusLabel_AccountCounts.Text = "フォローしていないアカウントは存在しません";
            }
            flag = 2;
        }

        private void Button_Search3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }
            string subitemstring1 = "相互フォロー中です";
            string subitemstring2 = "'following', 'followed_by'";
            Utils.usrnamelists = Utils.GetFollowerLists(int.Parse(comboBox1.SelectedItem.ToString()));
            Utils.SplittingUserList();
            if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null && Utils.usrnameArray4 != null && Utils.usrnameArray5 != null)
            {
                Utils.mutualfriendsusrArray1 = Utils.GetMutualFriendsLists(Utils.usrnameArray1);
                Utils.mutualfriendsusrArray2 = Utils.GetMutualFriendsLists(Utils.usrnameArray2);
                Utils.mutualfriendsusrArray3 = Utils.GetMutualFriendsLists(Utils.usrnameArray3);
                Utils.mutualfriendsusrArray4 = Utils.GetMutualFriendsLists(Utils.usrnameArray4);
                Utils.mutualfriendsusrArray5 = Utils.GetMutualFriendsLists(Utils.usrnameArray5);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.mutualfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray4.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray4[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray5.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray5[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "相互フォロー中のアカウント数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null && Utils.usrnameArray4 != null)
            {
                Utils.mutualfriendsusrArray1 = Utils.GetMutualFriendsLists(Utils.usrnameArray1);
                Utils.mutualfriendsusrArray2 = Utils.GetMutualFriendsLists(Utils.usrnameArray2);
                Utils.mutualfriendsusrArray3 = Utils.GetMutualFriendsLists(Utils.usrnameArray3);
                Utils.mutualfriendsusrArray4 = Utils.GetMutualFriendsLists(Utils.usrnameArray4);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.mutualfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray4.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray4[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "相互フォロー中のアカウント数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null && Utils.usrnameArray3 != null)
            {
                Utils.mutualfriendsusrArray1 = Utils.GetMutualFriendsLists(Utils.usrnameArray1);
                Utils.mutualfriendsusrArray2 = Utils.GetMutualFriendsLists(Utils.usrnameArray2);
                Utils.mutualfriendsusrArray3 = Utils.GetMutualFriendsLists(Utils.usrnameArray3);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.mutualfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray3.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray3[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "相互フォロー中のアカウント数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null && Utils.usrnameArray2 != null)
            {
                Utils.mutualfriendsusrArray1 = Utils.GetMutualFriendsLists(Utils.usrnameArray1);
                Utils.mutualfriendsusrArray2 = Utils.GetMutualFriendsLists(Utils.usrnameArray2);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.mutualfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                for (int i = 0; i < Utils.mutualfriendsusrArray2.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray2[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "相互フォロー中のアカウント数：" + listView1.Items.Count.ToString();
            }
            else if (Utils.usrnameArray1 != null)
            {
                Utils.mutualfriendsusrArray1 = Utils.GetMutualFriendsLists(Utils.usrnameArray1);
                listView1.BeginUpdate();
                for (int i = 0; i < Utils.mutualfriendsusrArray1.Length; i++)
                {
                    ListViewItem lvi = new();
                    lvi.Text = Utils.mutualfriendsusrArray1[i];
                    lvi.SubItems.Add(subitemstring1);
                    lvi.SubItems.Add(subitemstring2);
                    listView1.Items.Add(lvi);
                }
                listView1.EndUpdate();
                toolStripStatusLabel_AccountCounts.Text = "相互フォロー中のアカウント数：" + listView1.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("相互フォロー中のアカウントは存在しません。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripStatusLabel_AccountCounts.Text = "相互フォロー中のアカウントは存在しません";
            }
            flag = 3;
        }

        private void Button_Follow_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;
                Utils.token.Friendships.Create(screen_name => listView1.SelectedItems[index].Text.Replace("@", ""));
                listView1.Items.Remove(listView1.SelectedItems[index]);
            }
        }

        private void Button_Unfollow_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;
                Utils.token.Friendships.Destroy(screen_name => listView1.SelectedItems[index].Text.Replace("@", ""));
                listView1.Items.Remove(listView1.SelectedItems[index]);
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                switch (flag)
                {
                    case 0:
                        button_Follow.Enabled = false;
                        button_Unfollow.Enabled = false;
                        break;
                    case 1:
                        button_Follow.Enabled = false;
                        button_Unfollow.Enabled = true;
                        break;
                    case 2:
                        button_Follow.Enabled = true;
                        button_Unfollow.Enabled = false;
                        break;
                    case 3:
                        button_Follow.Enabled = false;
                        button_Unfollow.Enabled = true;
                        break;
                    default:
                        button_Follow.Enabled = false;
                        button_Unfollow.Enabled = false;
                        break;
                }
            }
            else
            {
                button_Follow.Enabled = false;
                button_Unfollow.Enabled = false;
            }
        }

    }
}
