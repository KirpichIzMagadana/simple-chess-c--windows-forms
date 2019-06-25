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
    public partial class mainmenu : Form
    {
        public mainmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            settings set = new settings();
            set.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void game_Click(object sender, EventArgs e)
        {
            game set = new game();
            set.Show();
            this.Visible = false;
        }
    }
}
