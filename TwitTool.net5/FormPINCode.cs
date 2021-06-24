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
    public partial class FormPINCode : Form
    {
        public FormPINCode()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Utils.pin = textBox1.Text;
            Close();
            return;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength >= 7)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
