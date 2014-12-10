using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TowerDefenseForms
{
    class LaserTower:Tower
    {
        private int level;
        private float damage;
        private float range;
        private float rateOfFire;
        private float fireTimer;
        private int buyPrice;
        private int sellPrice;

        public LaserTower(int level, float damage, float range, float rateOfFire, int buyPrice, int sellPrice, PointF position, PointF[] shape, Color color):base(level,damage,range,rateOfFire,buyPrice,sellPrice, position, shape, color)
        {
            this.level = level;
            this.damage = damage;
            this.range = range;
            this.rateOfFire = rateOfFire;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            //find nearest mix these 2
            /*
            foreach (Enemy e in GameWorld.gameobjects)
            {
                float nearest = range;
                if (Math.Sqrt(e.position.X - position.X * e.position.X - position.X + e.position.Y - position.Y * e.position.Y - position.Y) <= nearest)
                {
                    nearest = (float)Math.Sqrt(e.position.X - position.X * e.position.X - position.X + e.position.Y - position.Y * e.position.Y - position.Y);
                }
                GameWorld.gameobjects.Add(new LaserEffect(this,e,2,3,position,shape,Color.Red));
            }
            */

            for (int i = 0; i < GameWorld.gameobjects.Count; i++)
            {
                if (GameWorld.gameobjects[i] is Enemy)
                {
                    float dx = GameWorld.gameobjects[i].position.X - position.X;
                    float dy = GameWorld.gameobjects[i].position.Y - position.Y;

                    if (Math.Sqrt(dx * dx + dy * dy) < range)
                    {
                        GameWorld.gameobjects.Add(new LaserEffect(this,GameWorld.gameobjects[i], 2, 3, position, shape, Color.Red));
                    }
                }
            }


        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
        }

        public override void Attack()
        {
            base.Attack();
            //Create LaserEffect
        }
    }
}
