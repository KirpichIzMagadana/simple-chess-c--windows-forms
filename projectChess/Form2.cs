using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectChess
{
    public partial class settings : Form
    {
        public static bool timer;
        public static int time;
        public settings()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            mainmenu menu = new mainmenu();
            menu.Show();
            this.Visible = false;
        }

        private void settings_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            settings.timer = false;
            textBox1.Visible = false;
            settings.time = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            settings.timer = true;
            textBox1.Visible = true;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            settings.time = int.Parse(textBox1.Text);
        }
    }
}
