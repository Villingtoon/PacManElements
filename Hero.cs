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
        public string Direction { get; set; } = "right";
        private Timer animationTimer = null;
        private int frameCounter = 1;

        public Hero()
        {
            InitializeHero();
            InitializeAnimationTimer();
        }

        private void InitializeAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 200;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            Animate();
        }

        private void Animate()
        {
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject("pacman_right_1");
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
