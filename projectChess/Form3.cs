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
    public partial class game : Form
    {
        public static bool select = false, go=false;
        public static PictureBox copy = new PictureBox();
        public static PictureBox copy2 = new PictureBox();
        public static string color1, color2;
        public static int min1 = settings.time, min2 = settings.time, sec1 = 0, sec2 = 0, x1, y1, x2, y2, hod = 1, square1, square2; // hod(1)- white, hod(2) - black   square1/square2-выбранные хлетки  
        public static int[,] table;
        //   public static PictureBox RW = new PictureBox();
        //   public static PictureBox RB = new PictureBox();
        //   public static PictureBox QW = new PictureBox();
        //  public static PictureBox QB = new PictureBox();
        //   public static PictureBox pW = new PictureBox();
        // public static PictureBox pB = new PictureBox();
        // public static PictureBox NW = new PictureBox();
        //  public static PictureBox NB = new PictureBox();
        // public static PictureBox KW = new PictureBox();
        // public static PictureBox KB = new PictureBox();
        //public static PictureBox BB = new PictureBox();
        //public static PictureBox BW = new PictureBox();

        public game()
        {
            InitializeComponent();
        }

        private void game_Load(object sender, EventArgs e)
        {
            table = new int[8, 8]
            {
                {02, 03, 04, 05, 06, 04, 03, 02},
                {01, 01, 01, 01, 01, 01, 01, 01},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {00, 00, 00, 00, 00, 00, 00, 00},
                {11, 11, 11, 11, 11, 11, 11, 11},
                {12, 13, 14, 15, 16, 14, 13, 12},
            };

            if (settings.timer)
            {
                label1.Visible = true;
                label2.Visible = true;
                label1.Text = settings.time.ToString() + ":00";
                label2.Text = settings.time.ToString() + ":00";
                button1.Visible = true;
                button2.Visible = true;
                button2.Enabled = false;
                button2.BackColor = Color.Gray;
                timer1.Enabled = true;
                timer2.Enabled = false;
                timer1.Interval = 1000;
                timer2.Interval = 1000;

            }

        }
       static void win()
        {
            if(square2 == 16)
            {
                MessageBox.Show(
                      "Черные победили!",
                      "Черные победили!",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                Application.Exit();
            }
            if (square2 == 06)
            {
                MessageBox.Show(
                       "Белые победили!",
                       "Белые победили!",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);
                Application.Exit();
            }
        }
        static void img(int sq)
        {
            if (sq / 10 == 1)
            {
                if (sq % 10 == 1)
                {
                    copy.BackgroundImage = Properties.Resources.pW2;
                }
                else if(sq % 10 == 2)
                {
                    copy.BackgroundImage = Properties.Resources.RW;
                }
                else if (sq % 10 == 3)
                {
                    copy.BackgroundImage = Properties.Resources.NW1;
                }
                else if (sq % 10 == 4)
                {
                    copy.BackgroundImage = Properties.Resources.BW1;
                }
                else if (sq % 10 == 5)
                {
                    copy.BackgroundImage = Properties.Resources.QW2;
                }
                else if (sq % 10 == 6)
                {
                    copy.BackgroundImage = Properties.Resources.KW;
                }
            }
            else
            {
                if (sq % 10 == 1)
                {
                    copy.BackgroundImage = Properties.Resources.pB;
                }
                else if (sq % 10 == 2)
                {
                    copy.BackgroundImage = Properties.Resources.RB;
                }
                else if (sq % 10 == 3)
                {
                    copy.BackgroundImage = Properties.Resources.NB;
                }
                else if (sq % 10 == 4)
                {
                    copy.BackgroundImage = Properties.Resources.BB;
                }
                else if (sq % 10 == 5)
                {
                    copy.BackgroundImage = Properties.Resources.QB1;
                }
                else if (sq % 10 == 6)
                {
                    copy.BackgroundImage = Properties.Resources.KB;
                }
            }
        }
        static void piece(int sq, int x1, int y1, int x2, int y2)
        {
            if(x1 == x2 && y1 == y2){
                go = true;
            }
           else if (sq % 10 == 1)
            {
               
                 pawn(sq, x1, y1, x2, y2);
            }
            else if (sq % 10 == 2)
            {
                rook(x1, y1, x2, y2);
            }
            else if (sq % 10 == 3)
            {
                knight(x1, y1, x2, y2);
            }
            else if (sq % 10 == 4)
            {
                bishop(x1, y1, x2, y2);
            }
            else if (sq % 10 == 5)
            {
                queen(x1, y1, x2, y2);
            }
            else if (sq % 10 == 6)
            {
                king(x1, y1, x2, y2);
            }
        }
        static void pawn(int sq, int x1, int y1, int x2, int y2)
        {
            if(sq/10 == 1)
            {
                if (y1 == y2 && x1 == x2)
                {
                    go = true;
                }
                else if((y1 == y2) && (x1 == 7 && x2 == 5) && square2 == 0 )
                {
                    go = true;
                }
                else if ((y1 == y2) && (x2 == x1-1) && square2 == 0)
                {
                    go = true;
               }
                else if ((x2 == x1-1 && (y2 == y1 - 1 || y2 == y1+1)) && square2 != 00)
                {
                  go = true;
                }
                else
                {
                    go = false;
                }
            }
            else
            {
                if (y1 == y2 && x1 == x2)
                {
                    go = true;
                }
                else if ((y1 == y2) && (x1 == 2 && x2 == 4) && square2 == 0)
                {
                    go = true;
                }
                else if ((y1 == y2) && (x2 == x1 + 1) && square2 == 0)
                {
                    go = true;
                }
                else if ((x2 == x1 + 1 && (y2 == y1 + 1 || y2 == y1 - 1)) && square2 != 00)
                {
                    go = true;
                }
            
                else
                {
                    go = false;
                }
            }
        }
        static void rook(int x1, int y1, int x2, int y2)
        {
            if(x1 == x2 || y1 == y2)
            {
                go = true;
            }
            else
            {
                go = false;
            }
        }
        static void king(int x1, int y1, int x2, int y2)
        {
            if(Math.Abs(x1-x2) <= 1 && Math.Abs(y1-y2) <= 1)
            {
                go = true;
            }
            else
            {
                go = false;
            }
        }
        static void knight(int x1, int y1, int x2, int y2)
        {
            int dx = Math.Abs(x1 - x2);
            int dy = Math.Abs(y1 - y2);
            if ((dx == 1 && dy == 2) || (dx == 2 && dy == 1)){
                go = true;
            }
            else
            {
                go = false;
            }
        }
        static void bishop(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
            {
                go = true;
            }
            else
            {
                go = false;
            }
        }
        static void queen(int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2) || x1 == x2 || y1 == y2)
            {
                go = true;
            }
            else
            {
                go = false;
            }
        }
        static void color(int sq)
        {
            if (sq == square1)
            {
                if (square1 / 10 == 1)
                {
                    color1 = "W";

                }
                else if (square1 == 00)
                {
                    color1 = "null";
                }
                else
                {
                    color1 = "B";
                }
            }
            else
            {
                if (square2 / 10 == 1)
                {
                    color2 = "W";
                }
                else if(square2 == 00)
                {
                    color2 = "null";
                }
                else
                {
                    color2 = "B";
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = true;
            button2.BackColor = Color.Black;
            button1.BackColor = Color.Gray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button1.BackColor = Color.Black;
            button2.BackColor = Color.Gray;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec1 == 0)
            {
                if (min1 == 0)
                {
                    MessageBox.Show(
                       "Черные победили!",
                       "Черные победили!",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);
                    Application.Exit();

                }
                else
                {
                    min1--;
                    sec1 = 59;
                    label1.Text = min1.ToString() + ":" + sec1.ToString();
                }
            }
            else
            {
                sec1--;
                label1.Text = min1.ToString() + ":" + sec1.ToString();

            }

        }




        private void p11_Click(object sender, EventArgs e)
        {

            if (select)
            {
            if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
            else chey_hod.Text = "Ходят - белые"; 
                copy2 = p11;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p11.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p11;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p11.BackgroundImage = null;

            }
        }

        private void p21_Click(object sender, EventArgs e)
        {
            if (select)
            {

                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p21;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p21.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p21;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p21.BackgroundImage = null;

            }
        }

        private void p31_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p31;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p31.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p31;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p31.BackgroundImage = null;

            }
        }

        private void p41_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p41;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p41.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p41;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p41.BackgroundImage = null;

            }
        }

        private void p51_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p51;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p51.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p51;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p51.BackgroundImage = null;

            }
        }

        private void p61_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые"; ;

                copy2 = p61;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p61.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p61;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p61.BackgroundImage = null;

            }
        }

        private void p71_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p71;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p71.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p71;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p71.BackgroundImage = null;

            }
        }

        private void p_81_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p_81;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p_81.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p_81;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p_81.BackgroundImage = null;

            }
        }

        private void p12_Click(object sender, EventArgs e)
        {
            if (select)
            {
                
            if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
            else chey_hod.Text = "Ходят - белые";
                copy2 = p12;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p12.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p12;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p12.BackgroundImage = null;

            }
        }

        private void p22_Click(object sender, EventArgs e)
        {
            if (select)
            {

                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p22;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p22.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                   copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p22;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p22.BackgroundImage = null;

            }
        }

        private void p32_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p32;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p32.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p32;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p32.BackgroundImage = null;

            }
        }

        private void p42_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p42;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p42.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p42;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p42.BackgroundImage = null;

            }
        }

        private void p52_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p52;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p52.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p52;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p52.BackgroundImage = null;

            }
        }

        private void p62_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p62;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p62.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p62;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p62.BackgroundImage = null;

            }
        }

        private void p72_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p72;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p72.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p72;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p72.BackgroundImage = null;

            }
        }

        private void p82_Click_1(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p82;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p82.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p82;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p82.BackgroundImage = null;

            }
        }

        private void p83_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p83;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p83.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p83;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p83.BackgroundImage = null;

            }
        }

        private void p73_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p73;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p73.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p73;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p73.BackgroundImage = null;

            }
        }

        private void p63_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p63;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p63.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p63;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p63.BackgroundImage = null;

            }
        }

        private void p84_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p84;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p84.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p84;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p84.BackgroundImage = null;

            }
        }

        private void p85_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p85;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p85.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p85;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p85.BackgroundImage = null;

            }
        }

        private void p86_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p86;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p86.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p86;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p86.BackgroundImage = null;

            }
        }

        private void p87_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p87;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p87.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p87;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p87.BackgroundImage = null;

            }
        }

        private void p88_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p88;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p88.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p88;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p88.BackgroundImage = null;

            }
        }

        private void p74_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p74;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p74.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p74;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p74.BackgroundImage = null;

            }
        }

        private void p75_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p75;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p75.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p75;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p75.BackgroundImage = null;

            }
        }

        private void p76_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p76;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p76.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p76;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p71.BackgroundImage = null;

            }
        }

        private void p66_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p66;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p66.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p66;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p66.BackgroundImage = null;

            }
        }

        private void p77_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p77;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p77.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p77;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p77.BackgroundImage = null;

            }
        }

        private void p78_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p78;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p78.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p78;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p78.BackgroundImage = null;

            }
        }

        private void p64_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p64;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p64.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p64;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p64.BackgroundImage = null;

            }
        }

        private void p65_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p65;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p65.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p65;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p65.BackgroundImage = null;

            }
        }

        private void p67_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p67;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p67.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p67;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p67.BackgroundImage = null;

            }
        }

        private void p68_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p68;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p68.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p68;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p68.BackgroundImage = null;

            }
        }

        private void p43_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p43;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p43.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p43;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p43.BackgroundImage = null;

            }
        }

        private void p53_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p53;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p53.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p53;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p53.BackgroundImage = null;

            }
        }

        private void p54_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p54;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p54.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p54;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p54.BackgroundImage = null;

            }
        }

        private void p55_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p55;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p55.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p55;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p55.BackgroundImage = null;

            }
        }

        private void p56_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p56;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p56.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p56;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p56.BackgroundImage = null;

            }
        }

        private void p57_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p57;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p57.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p57;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p57.BackgroundImage = null;

            }
        }

        private void p58_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p58;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p58.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p58;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p58.BackgroundImage = null;

            }
        }

        private void p44_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p44;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p44.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p44;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p44.BackgroundImage = null;

            }
        }

        private void p45_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p45;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p45.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p45;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p45.BackgroundImage = null;

            }
        }

        private void p46_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p46;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p46.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p46;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p46.BackgroundImage = null;

            }
        }

        private void p47_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p47;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p47.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p47;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p47.BackgroundImage = null;

            }
        }

        private void p48_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p48;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p48.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p48;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p48.BackgroundImage = null;

            }
        }

        private void p33_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p33;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p33.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p33;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p33.BackgroundImage = null;

            }
        }

        private void p34_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p34;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p34.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p34;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p34.BackgroundImage = null;

            }
            // if (select)
            //  {
            //   if (copy.BackgroundImage == null)
            //   {
            //        select = false;
            //        selected.BackgroundImage = null;
            //    }
            //     else
            //     {
            //         p34.BackgroundImage = copy.BackgroundImage;
            //          select = false;
            //          selected.BackgroundImage = null;
            //      }
            // }
            //   else
            //  {
            //      select = true;
            //      copy.BackgroundImage = p34.BackgroundImage;
            //       selected.BackgroundImage = p34.BackgroundImage;
            //       p34.BackgroundImage = null;
            //  }
        }

        private void p35_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p35;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p35.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p35;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p35.BackgroundImage = null;

            }
        }

        private void p36_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p36;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p36.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p36;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p36.BackgroundImage = null;

            }
        }

        private void p37_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p37;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p37.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p37;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p37.BackgroundImage = null;

            }
        }

        private void p38_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";

                copy2 = p38;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p38.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p38;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p38.BackgroundImage = null;

            }
        }

        private void p23_Click(object sender, EventArgs e)
        {
           

                if (select)
                {

                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                    copy2 = p23;
                    x2 = copy2.Top / 70;
                    y2 = copy2.Left / 70;
                    square2 = table[x2 - 1, y2 - 1];
                    color(square2);
                    piece(square1, x1, y1, x2, y2);
                    if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                    {
                        img(square1);
                        table[x2 - 1, y2 - 1] = square1;
                        p23.BackgroundImage = copy.BackgroundImage;
                        select = false;
                        selected.BackgroundImage = null;
                       copy.BackgroundImage = null;
                        hod++;
                        win();
                    }
                }
                else
                {
                    copy = p23;
                    x1 = copy.Top / 70;
                    y1 = copy.Left / 70;
                    square1 = table[x1 - 1, y1 - 1];
                    color(square1);
                    table[x1 - 1, y1 - 1] = 00;
                    selected.BackgroundImage = copy.BackgroundImage;
                    select = true;
                    p23.BackgroundImage = null;

                }
            }
    

        private void p24_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p24;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p24.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p24;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p24.BackgroundImage = null;

            }
        }

        private void p25_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p25;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p25.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p25;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p25.BackgroundImage = null;

            }
        }

        private void p26_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p26;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p26.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p26;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p26.BackgroundImage = null;

            }
        }

        private void p27_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p27;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p27.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p27;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p27.BackgroundImage = null;

            }
        }

        private void p28_Click(object sender, EventArgs e)
        {
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p28;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p28.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p28;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p28.BackgroundImage = null;

            }
        }

        private void p13_Click(object sender, EventArgs e)
        {
            if (select)
            {
            if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
            else chey_hod.Text = "Ходят - белые";
                copy2 = p13;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p13.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    hod++;
                  copy.BackgroundImage = null;
                    win();
                }
            }
            else
            {
                copy = p13;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p13.BackgroundImage = null;

            }
        }

        private void p14_Click(object sender, EventArgs e)
        {
            if (select)
            {

            if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
            else chey_hod.Text = "Ходят - белые";
                copy2 = p14;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p14.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                  copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p14;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p14.BackgroundImage = null;

            }
        }

        private void p15_Click(object sender, EventArgs e)
        {
            if (select)
            {

            if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
            else chey_hod.Text = "Ходят - белые";
                copy2 = p15;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p15.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p15;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p15.BackgroundImage = null;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (sec2 == 0)
            {
                if (min2 == 0)
                {
                    MessageBox.Show(
                       "Белые победили!",
                       "Белые победили!",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);
                    Application.Exit();

                }
                else
                {
                    min2--;
                    sec2 = 59;
                    label1.Text = min2.ToString() + ":" + sec2.ToString();
                }
            }
            else
            {
                sec2--;
                label2.Text = min2.ToString() + ":" + sec2.ToString();

            }
        }

        private void p16_Click(object sender, EventArgs e)
        {
            if (select)
            {

            if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
            else chey_hod.Text = "Ходят - белые";
                copy2 = p16;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p16.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p16;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p16.BackgroundImage = null;

            }
        }

        private void p17_Click(object sender, EventArgs e)
        {
            if (select)
            {

            if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
            else chey_hod.Text = "Ходят - белые";
                copy2 = p17;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod%2 ==  1) || (color1 == "B" && hod%2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p17.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                   copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p17;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p17.BackgroundImage = null;

            }
        }

        private void p18_Click(object sender, EventArgs e)
        {
            
            if (select)
            {
                if (hod % 2 == 1) chey_hod.Text = "Ходят - черные";
                else chey_hod.Text = "Ходят - белые";
                copy2 = p18;
                x2 = copy2.Top / 70;
                y2 = copy2.Left / 70;
                square2 = table[x2 - 1, y2 - 1];
                color(square2);
                piece(square1, x1, y1, x2, y2);
                if (color1 != color2 && go == true && ((color1 == "W" && hod % 2 == 1) || (color1 == "B" && hod % 2 == 0)))
                {
                    img(square1);
                    table[x2 - 1, y2 - 1] = square1;
                    p18.BackgroundImage = copy.BackgroundImage;
                    select = false;
                    selected.BackgroundImage = null;
                    copy.BackgroundImage = null;
                    hod++;
                    win();
                }
            }
            else
            {
                copy = p18;
                x1 = copy.Top / 70;
                y1 = copy.Left / 70;
                square1 = table[x1 - 1, y1 - 1];
                color(square1);
                table[x1 - 1, y1 - 1] = 00;
                selected.BackgroundImage = copy.BackgroundImage;
                select = true;
                p18.BackgroundImage = null;

            }
        }
    }
}

