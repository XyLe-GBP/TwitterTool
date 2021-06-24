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
    public partial class FormTokenSettings : Form
    {
        public FormTokenSettings()
        {
            InitializeComponent();
        }

        private void FormTokenSettings_Load(object sender, EventArgs e)
        {
            var ini = new PrivateProfile.IniFile(@".\\settings.ini");
            string CK = ini.GetString("TOKENS", "CONSUMER_KEY", ""), CS = ini.GetString("TOKENS", "CONSUMER_SECRET", ""), AT = ini.GetString("TOKENS", "ACCESS_TOKEN", ""), AS = ini.GetString("TOKENS", "ACCESS_SECRET", ""), BT = ini.GetString("TOKENS", "BEARER_TOKEN", "");
            if (CK != "")
            {
                textBox_CK.Text = CK;
                label_CK_Status.Text = "OK!";
                label_CK_Status.ForeColor = Color.Green;
                if (CS != "")
                {
                    textBox_CS.Text = CS;
                    label_CS_Status.Text = "OK!";
                    label_CS_Status.ForeColor = Color.Green;
                    textBox_CS.Enabled = true;
                    if (AT != "")
                    {
                        textBox_AT.Text = AT;
                        label_AT_Status.Text = "OK!";
                        label_AT_Status.ForeColor = Color.Green;
                        textBox_AT.Enabled = true;
                        if (AS != "")
                        {
                            textBox_AS.Text = AS;
                            label_AS_Status.Text = "OK!";
                            label_AS_Status.ForeColor = Color.Green;
                            textBox_AS.Enabled = true;
                            textBox_BT.Enabled = true;
                            if (BT != "")
                            {
                                textBox_BT.Text = BT;
                                label_BT_Status.Text = "OK!";
                                label_BT_Status.ForeColor = Color.Green;
                                button_OK.Enabled = true;
                            }
                            else
                            {
                                textBox_BT.Text = null;
                                label_BT_Status.Text = null;
                                button_OK.Enabled = true;
                            }
                        }
                        else
                        {
                            textBox_CK.Text = null;
                            label_CK_Status.Text = null;
                            textBox_CS.Text = null;
                            label_CS_Status.Text = null;
                            textBox_CS.Enabled = false;
                            textBox_AT.Text = null;
                            label_AT_Status.Text = null;
                            textBox_AT.Enabled = false;
                            textBox_AS.Text = null;
                            label_AS_Status.Text = null;
                            textBox_AS.Enabled = false;
                            textBox_BT.Text = null;
                            label_BT_Status.Text = null;
                            textBox_BT.Enabled = false;
                            button_OK.Enabled = false;
                        }
                    }
                    else
                    {
                        textBox_CK.Text = null;
                        label_CK_Status.Text = null;
                        textBox_CS.Text = null;
                        label_CS_Status.Text = null;
                        textBox_CS.Enabled = false;
                        textBox_AT.Text = null;
                        label_AT_Status.Text = null;
                        textBox_AT.Enabled = false;
                        textBox_AS.Text = null;
                        label_AS_Status.Text = null;
                        textBox_AS.Enabled = false;
                        textBox_BT.Text = null;
                        label_BT_Status.Text = null;
                        textBox_BT.Enabled = false;
                        button_OK.Enabled = false;
                    }
                }
                else
                {
                    textBox_CK.Text = null;
                    label_CK_Status.Text = null;
                    textBox_CS.Text = null;
                    label_CS_Status.Text = null;
                    textBox_CS.Enabled = false;
                    textBox_AT.Text = null;
                    label_AT_Status.Text = null;
                    textBox_AT.Enabled = false;
                    textBox_AS.Text = null;
                    label_AS_Status.Text = null;
                    textBox_AS.Enabled = false;
                    textBox_BT.Text = null;
                    label_BT_Status.Text = null;
                    textBox_BT.Enabled = false;
                    button_OK.Enabled = false;
                }
            }
            else
            {
                textBox_CK.Text = null;
                label_CK_Status.Text = null;
                textBox_CS.Text = null;
                label_CS_Status.Text = null;
                textBox_CS.Enabled = false;
                textBox_AT.Text = null;
                label_AT_Status.Text = null;
                textBox_AT.Enabled = false;
                textBox_AS.Text = null;
                label_AS_Status.Text = null;
                textBox_AS.Enabled = false;
                textBox_BT.Text = null;
                label_BT_Status.Text = null;
                textBox_BT.Enabled = false;
                button_OK.Enabled = false;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            var ini = new PrivateProfile.IniFile(@".\\settings.ini");
            if (textBox_CK.TextLength == 25 && textBox_CS.TextLength == 50 && textBox_AT.TextLength == 50 && textBox_AS.TextLength == 45)
            {
                if (textBox_BT.TextLength != 0)
                {
                    if (textBox_BT.TextLength == 116)
                    {
                        ini.WriteString("TOKENS", "CONSUMER_KEY", textBox_CK.Text);
                        ini.WriteString("TOKENS", "CONSUMER_SECRET", textBox_CS.Text);
                        ini.WriteString("TOKENS", "ACCESS_TOKEN", textBox_AT.Text);
                        ini.WriteString("TOKENS", "ACCESS_SECRET", textBox_AS.Text);
                        ini.WriteString("TOKENS", "BEARER_TOKEN", textBox_BT.Text);
                        DialogResult dr = MessageBox.Show("トークン設定が更新されました。\n反映するにはアプリケーションを再起動する必要があります。\n再起動しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            Close();
                            Application.Restart();
                            return;
                        }
                        else
                        {
                            Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("BEARER_TOKENの値が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    ini.WriteString("TOKENS", "CONSUMER_KEY", textBox_CK.Text);
                    ini.WriteString("TOKENS", "CONSUMER_SECRET", textBox_CS.Text);
                    ini.WriteString("TOKENS", "ACCESS_TOKEN", textBox_AT.Text);
                    ini.WriteString("TOKENS", "ACCESS_SECRET", textBox_AS.Text);
                    ini.WriteString("TOKENS", "BEARER_TOKEN", "");
                    DialogResult dr = MessageBox.Show("トークン設定が更新されました。\n反映するにはアプリケーションを再起動する必要があります。\n再起動しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        Close();
                        Application.Restart();
                        return;
                    }
                    else
                    {
                        Close();
                        return;
                    }
                }
            }
            else
            {
                if (textBox_CK.TextLength == 25)
                {
                    if (textBox_CS.TextLength == 50)
                    {
                        if (textBox_AT.TextLength == 50)
                        {
                            if (textBox_AS.TextLength == 45)
                            {
                                Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("ACCESS_SECRETの値が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("ACCESS_TOKENの値が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("CONSUMER_SECRETの値が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("CONSUMER_KEYの値が不正です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void TextBox_CK_TextChanged(object sender, EventArgs e)
        {
            if (textBox_CK.TextLength == 25)
            {
                textBox_CS.Enabled = true;
                label_CK_Status.Text = "OK!";
                label_CK_Status.ForeColor = Color.Green;
            }
            else
            {
                textBox_CS.Enabled = false;
                label_CK_Status.Text = "NG!";
                label_CK_Status.ForeColor = Color.Red;
            }
        }

        private void TextBox_CS_TextChanged(object sender, EventArgs e)
        {
            if (textBox_CK.TextLength == 25 && textBox_CS.TextLength == 50)
            {
                textBox_AT.Enabled = true;
                label_CS_Status.Text = "OK!";
                label_CS_Status.ForeColor = Color.Green;
            }
            else
            {
                textBox_AT.Enabled = false;
                label_CS_Status.Text = "NG!";
                label_CS_Status.ForeColor = Color.Red;
            }
        }

        private void TextBox_AT_TextChanged(object sender, EventArgs e)
        {
            if (textBox_CK.TextLength == 25 && textBox_CS.TextLength == 50 && textBox_AT.TextLength == 50)
            {
                textBox_AS.Enabled = true;
                label_AT_Status.Text = "OK!";
                label_AT_Status.ForeColor = Color.Green;
            }
            else
            {
                textBox_AS.Enabled = false;
                label_AT_Status.Text = "NG!";
                label_AT_Status.ForeColor = Color.Red;
            }
        }

        private void TextBox_AS_TextChanged(object sender, EventArgs e)
        {
            if (textBox_CK.TextLength == 25 && textBox_CS.TextLength == 50 && textBox_AT.TextLength == 50 && textBox_AS.TextLength == 45 && textBox_BT.TextLength == 0)
            {
                textBox_BT.Enabled = true;
                button_OK.Enabled = true;
                label_AS_Status.Text = "OK!";
                label_AS_Status.ForeColor = Color.Green;
            }
            else
            {
                button_OK.Enabled = false;
                label_AS_Status.Text = "NG!";
                label_AS_Status.ForeColor = Color.Red;
            }
        }

        private void TextBox_BT_TextChanged(object sender, EventArgs e)
        {
            if (textBox_BT.TextLength == 116)
            {
                button_OK.Enabled = true;
                label_BT_Status.Text = "OK!";
                label_BT_Status.ForeColor = Color.Green;
            }
            else if (textBox_BT.TextLength == 0)
            {
                button_OK.Enabled = true;
                label_BT_Status.Text = "OK!";
                label_BT_Status.ForeColor = Color.Green;
            }
            else
            {
                button_OK.Enabled = false;
                label_BT_Status.Text = "NG!";
                label_BT_Status.ForeColor = Color.Red;
            }
        }
    }
}
