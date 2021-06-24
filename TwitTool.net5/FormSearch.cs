using CoreTweet;
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
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            comboBox_GetCount.SelectedIndex = 2;
            dateTimePicker_StartDate.Format = DateTimePickerFormat.Custom;
            dateTimePicker_StartDate.CustomFormat = "yyyy-MM-dd";
            dateTimePicker_EndDate.Format = DateTimePickerFormat.Custom;
            dateTimePicker_EndDate.CustomFormat = "yyyy-MM-dd";
        }

        private void CheckBox_EnableUserSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_EnableUserSearch.Checked != false)
            {
                textBox_UserName.Enabled = true;
                button_Search.Enabled = false;
                return;
            }
            else
            {
                textBox_UserName.Enabled = false;
                textBox_UserName.Text = null;
                return;
            }
        }

        private void CheckBox_EnableDateSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_EnableDateSearch.Checked != false)
            {
                dateTimePicker_StartDate.Enabled = true;
                dateTimePicker_EndDate.Enabled = true;
                return;
            }
            else
            {
                dateTimePicker_StartDate.Enabled = false;
                dateTimePicker_EndDate.Enabled = false;
                return;
            }
        }

        private void Button_Search_Click(object sender, EventArgs e)
        {
            if (textBox_SearchKeyword.TextLength != 0)
            {
                switch (checkBox_EnableUserSearch.Checked)
                {
                    case true:
                        switch (checkBox_EnableDateSearch.Checked)
                        {
                            case true:
                                if (textBox_UserName.TextLength >= 4)
                                {
                                    Utils.SearchStatus = Utils.SearchTweets(int.Parse(comboBox_GetCount.SelectedItem.ToString()), textBox_SearchKeyword.Text, textBox_UserName.Text, dateTimePicker_StartDate.Text, dateTimePicker_EndDate.Text);

                                    Utils.GetStatusesForSearched(int.Parse(comboBox_GetCount.SelectedItem.ToString()));
                                    
                                    if (Utils.SearchStatus.Length != 0)
                                    {
                                        MessageBox.Show(string.Format("{0} 件のツイートを検索しました。", Utils.SearchStatus.Length), "検索完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Close();
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("ツイート検索に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Close();
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ユーザーIDが短すぎます。\nIDは4文字以上かつ、15文字以下で指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            case false:
                                if (textBox_UserName.TextLength >= 4)
                                {
                                    Utils.SearchStatus = Utils.SearchTweets(int.Parse(comboBox_GetCount.SelectedItem.ToString()), textBox_SearchKeyword.Text, textBox_UserName.Text);

                                    Utils.GetStatusesForSearched(int.Parse(comboBox_GetCount.SelectedItem.ToString()));

                                    if (Utils.SearchStatus.Length != 0)
                                    {
                                        MessageBox.Show(string.Format("{0} 件のツイートを検索しました。", Utils.SearchStatus.Length), "検索完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Close();
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("ツイート検索に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Close();
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ユーザーIDが短すぎます。\nIDは4文字以上かつ、15文字以下で指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                        }
                    case false:
                        Utils.SearchStatus = Utils.SearchTweets(int.Parse(comboBox_GetCount.SelectedItem.ToString()), textBox_SearchKeyword.Text);

                        Utils.GetStatusesForSearched(int.Parse(comboBox_GetCount.SelectedItem.ToString()));

                        if (Utils.SearchStatus.Length != 0)
                        {
                            MessageBox.Show(string.Format("{0} 件のツイートを検索しました。", Utils.SearchStatus.Length), "検索完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("ツイート検索に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                            return;
                        }
                }
            }
            else
            {
                MessageBox.Show("検索キーワードが入力されていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void TextBox_SearchKeyword_TextChanged(object sender, EventArgs e)
        {
            if (textBox_SearchKeyword.TextLength != 0)
            {
                switch (checkBox_EnableUserSearch.Checked)
                {
                    case true:
                        if (textBox_UserName.TextLength != 0)
                        {
                            button_Search.Enabled = true;
                            return;
                        }
                        else
                        {
                            button_Search.Enabled = false;
                            return;
                        }
                    case false:
                        button_Search.Enabled = true;
                        return;
                }
            }
            else
            {
                button_Search.Enabled = false;
                return;
            }
        }

        private void TextBox_UserName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_UserName.TextLength != 0)
            {
                if (textBox_SearchKeyword.TextLength != 0)
                {
                    button_Search.Enabled = true;
                    return;
                }
                else
                {
                    button_Search.Enabled = false;
                    return;
                }
            }
            else
            {
                button_Search.Enabled = false;
                return;
            }
        }
    }
}
