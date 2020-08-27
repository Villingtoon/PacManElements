using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManElements
{
    class Enemy : PictureBox
    {
        public int Step { get; set; } = 2;
        public int HorizontalVelocity { get; set; } = 0;
        public int VerticalVelocity { get; set; } = 0;

        public Enemy()
        {
            InitializeEnemy();
        }

        private void InitializeEnemy()
        {
            this.BackColor = Color.Red;
            this.Size = new Size(40, 40);
            this.Tag = "Enemy";
        }
    }
}
