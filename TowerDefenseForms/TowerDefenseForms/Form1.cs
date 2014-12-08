using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    public partial class Form1 : Form
    {
        private Graphics dc;
        private GameWorld gameWorld;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dc = CreateGraphics();
            gameWorld = new GameWorld(dc, DisplayRectangle);
        }

        private void ticker_Tick(object sender, EventArgs e)
        {
            gameWorld.GameLoop();
        }
    }
}
