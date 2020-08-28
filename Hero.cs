using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManElements
{
    class Hero : PictureBox
    {
        public int Step { get; set; } = 4;
        public int HorizontalVelocity { get; set; } = 0;
        public int VerticalVelocity { get; set; } = 0;

        public Hero()
        {
            InitializeHero();
        }

        private void InitializeHero()
        {
            this.BackColor = Color.Yellow;
            this.Size = new Size(35, 35);
            this.Location = new Point(200, 200);
            this.Name = "PacMan";
        }
    }
}
