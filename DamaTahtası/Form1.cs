using System;
using System.Drawing;
using System.Windows.Forms;

namespace DamaTahtası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateButtons();

        }

        private void GenerateButtons()
        {
            Button[,] buttons = new Button[8, 8];
            int top = 0;
            int left = 0;

            //satırın en büyük değeri
            for (int i = 0; i < buttons.GetUpperBound(0); i++)
            {
                //sütunun en büyük değeri
                for (int j = 0; j < buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 50;
                    buttons[i, j].Height = 50;
                    buttons[i, j].Top = top;
                    buttons[i, j].Left = left;
                    left = left + 50;

                    //dama renkleri
                    if ((i + j) % 2 == 0)
                    {
                        buttons[i, j].BackColor = Color.Black;
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.White;
                    }

                    //ekranda yazdır
                    this.Controls.Add(buttons[i, j]);

                }
                //her seferinde tepeden bir butonun yüksekliği kadar mesafe
                top += 50;
                //her seferinde yenden soldan başla
                left = 0;
            }


        }



    }
}
