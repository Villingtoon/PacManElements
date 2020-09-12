using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManElements
{
    public partial class Game : Form
    {
        private int initialEnemyCount = 1;

        private Random rand = new Random();
        private Level level = new Level();
        private Hero hero = new Hero();
        private Food food = new Food();
        private Timer mainTimer = null;
        private List<Enemy> enemies = new List<Enemy>();
        private Timer enemySpawnTimer = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
            InitializeEnemySpawnTimer();
        }

        private void InitializeGame()
        {
            //adjust game form size
            this.Size = new Size(500, 500);
            AddLevel();
            AddHero();
            AddEnemies(3);
            AddFood();
            //add key down event handler
            this.KeyDown += Game_KeyDown;

        }

        private void AddFood()
        {
            this.Controls.Add(food);
            food.Location = new Point(rand.Next(100, 200), rand.Next(100, 200));
            food.Parent = level;
            food.BringToFront();
        }

        private void AddLevel()
        {
            //adding level to the game
            this.Controls.Add(level);
        }

        private void AddHero()
        {
            //adding hero to the game
            this.Controls.Add(hero);
            hero.BringToFront();
            hero.Parent = level;
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Interval = 20;
            mainTimer.Start();
        }
        private void InitializeEnemySpawnTimer()
        {
            enemySpawnTimer = new Timer();
            enemySpawnTimer.Tick += enemySpawnTimer_Tick;
            enemySpawnTimer.Interval = 5000;
            enemySpawnTimer.Start();
        }

        private void enemySpawnTimer_Tick(object sender, EventArgs e)
        {
            AddEnemies(1);
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            MoveHero();
            MoveEnemies();
            HeroBorderCollision();
            HeroFoodColission();
            EnemyBorderCollision();
            HeroEnemyColission();
        }

        private void MoveHero()
        {
            hero.Left += hero.HorizontalVelocity;
            hero.Top += hero.VerticalVelocity;
        }

        private void MoveEnemies()
        {
            foreach(var enemy in enemies)
            {
                enemy.Left += enemy.HorizontalVelocity;
                enemy.Top += enemy.VerticalVelocity;
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    hero.HorizontalVelocity = 0;
                    hero.VerticalVelocity = -hero.Step;
                    hero.Direction = "up";
                    break;
                case Keys.S:
                    hero.HorizontalVelocity = 0;
                    hero.VerticalVelocity = hero.Step;
                    hero.Direction = "down";
                    break;
                case Keys.A:
                    hero.HorizontalVelocity = -hero.Step;
                    hero.VerticalVelocity = 0;
                    hero.Direction = "left";
                    break;
                case Keys.D:
                    hero.HorizontalVelocity = hero.Step;
                    hero.VerticalVelocity = 0;
                    hero.Direction = "right";
                    break;
                case Keys.F:
                    hero.HorizontalVelocity = 0;
                    hero.VerticalVelocity = 0;
                    break;
            }
            SetRandomEnemyDirection();
        }

        private void HeroBorderCollision()
        {
            if(hero.Left > level.Left + level.Width)
            {
                hero.Left = level.Left - hero.Width;
            }
            if (hero.Left + hero.Width < level.Left)
            {
                hero.Left = level.Left + level.Width;
            }
            if (hero.Top > level.Top + level.Height)
            {
                hero.Top = level.Top - hero.Height;
            }
            if (hero.Top + hero.Height < level.Top)
            {
                hero.Top = level.Top + level.Height;
            }
        }

        private void EnemyBorderCollision()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.Top < level.Top) //From "up" to "down"
                {
                    enemy.SetRandomDirection(2);
                }
                if (enemy.Top > level.Height - enemy.Width) //From "down" to "up"
                {
                    enemy.SetRandomDirection(4);
                }
                if (enemy.Left < level.Left) //From "left" to "right"
                {
                    enemy.SetRandomDirection(1);
                }
                if (enemy.Left > level.Width - enemy.Width) //From "right" to "left"
                {
                    enemy.SetRandomDirection(3);
                }
            }
        }

        private void HeroEnemyColission()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.Bounds.IntersectsWith(hero.Bounds))
                {
                    GameOver();
                }
            }
        }

        private void HeroFoodColission()
        {
            if (food.Bounds.IntersectsWith(hero.Bounds))
            {
                food.Location = new Point(rand.Next(100, 200), rand.Next(100, 200));
                food.SetType(rand.Next(1, 5));
                hero.Step++;
            }
        }

        private void AddEnemies(int enemyCount)
        {
            Enemy enemy;
            for(int i = 0; i < enemyCount; i++)
            {
                enemy = new Enemy();
                enemy.Location = new Point(rand.Next(100, 400), rand.Next(100, 400));
                enemy.SetRandomDirection(rand.Next(1, 5));
                enemies.Add(enemy);
                this.Controls.Add(enemy);
                enemy.Parent = level;
                enemy.BringToFront();
            }
        }

        private void SetRandomEnemyDirection()
        {
            foreach(var enemy in enemies)
            {
                enemy.SetRandomDirection(rand.Next(1, 5));
            }
        }

        private void GameOver()
        {
            mainTimer.Stop();
            
            labelGameOver.Parent = level;
            labelGameOver.BackColor = Color.Transparent;
            labelGameOver.Visible = true;
            labelGameOver.BringToFront();
        }
    }
}
