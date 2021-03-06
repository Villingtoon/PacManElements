﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PacManElements
{
    class Food : PictureBox
    {
        private Random rand = new Random();
        public int Type { get; set; } = 1;

        public Food()
        {
            InitializeFood();
        }

        private void InitializeFood()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(25, 25);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Name = "Food";
            this.SetType(1);
        }

        public void SetType(int type)
        {
            this.Type = type;
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject("food_" + type.ToString());
        }
    }
}
