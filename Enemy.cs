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

        public Enemy()
        {
            InitializeEnemy();
            //SetRandomDirection();
        }

        private void InitializeEnemy()
        {
            this.BackColor = Color.Red;
            this.Size = new Size(30, 30);
            this.Tag = "Enemy";
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
                    break;
                case 2:
                    HorizontalVelocity = 0;
                    VerticalVelocity = Step;
                    break;
                case 3:
                    HorizontalVelocity = -Step;
                    VerticalVelocity = 0;
                    break;
                case 4:
                    HorizontalVelocity = 0;
                    VerticalVelocity = -Step;
                    break;
            }
        }
    }
}
