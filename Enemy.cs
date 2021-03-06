﻿using System;
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
        private Random rand = new Random();

        public int Step { get; set; } = 2;
        public int HorizontalVelocity { get; set; } = 0;
        public int VerticalVelocity { get; set; } = 0;
        public string Direction { get; set; } = "right";
        private Timer animationTimer = null;
        private int frameCounter = 1;

        public Enemy()
        {
            InitializeEnemy();
            InitializeAnimationTimer();
            //SetRandomDirection();
        }

        private void InitializeEnemy()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(30, 30);
            this.Tag = "Enemy";
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
            string imageName = "enemy_" + this.Direction + "_" + frameCounter.ToString();
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            frameCounter++;
            if (frameCounter > 2)
            {
                frameCounter = 1;
            }
        }

        /// <summary>
        /// Sets movement direction of the enemy
        /// </summary>
        /// <param name="directionCode">1-East, 2-South, 3-West, 4-North</param>
        public void SetRandomDirection(int directionCode)
        {
            //int directionCode = rand.Next(1, 5);
            switch (directionCode)
            {
                case 1:
                    HorizontalVelocity = Step;
                    VerticalVelocity = 0;
                    this.Direction = "right";
                    break;
                case 2:
                    HorizontalVelocity = 0;
                    VerticalVelocity = Step;
                    this.Direction = "down";
                    break;
                case 3:
                    HorizontalVelocity = -Step;
                    VerticalVelocity = 0;
                    this.Direction = "left";
                    break;
                case 4:
                    HorizontalVelocity = 0;
                    VerticalVelocity = -Step;
                    this.Direction = "up";
                    break;
            }
        }
    }
}
