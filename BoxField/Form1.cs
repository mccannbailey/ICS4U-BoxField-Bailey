using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class Form1 : Form
    {
        string direction;
        int cx, cy, x, y, size;

        public Form1()
        {            
            InitializeComponent();
            cx = this.Width / 2; cy = this.Height / 2;
            x = cx; y = cy;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameScreen gs = new GameScreen();
            this.Controls.Add(gs);
            this.Refresh();           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
