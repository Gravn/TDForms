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
            //position.X++;
            //shape[0].X++;
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
        }

        public override void Attack()
        {
            base.Attack();
            GameObject target = this;

            for (int i = 0; i < GameWorld.gameobjects.Count; i++)
            {
                if (GameWorld.gameobjects[i] is Enemy)
                {
                    //get nearest
                    float dx = GameWorld.gameobjects[i].position.X - position.X;
                    float dy = GameWorld.gameobjects[i].position.Y - position.Y;
                    float distance = (float)Math.Sqrt(dx * dx + dy * dy);
                    float nearest = range;
                    if (distance < nearest)
                    {
                        nearest = distance;
                        target = GameWorld.gameobjects[i];
                    }
                }
            }
            if(target != null)
            {
                GameWorld.gameobjects.Add(new LaserEffect(this, target, 5, 0.5f, position, new PointF[]{new PointF(0,0)}, Color.Red));
                fireTimer = 0;
            }
        }
    }
}
