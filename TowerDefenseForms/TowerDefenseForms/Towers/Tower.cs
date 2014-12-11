using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    abstract class Tower : GameObject
    {
        private int level;
        private float damage;
        private float range;
        private float rateOfFire;
        private float fireTimer;
        private int buyPrice;
        private int sellPrice;

        public Tower(int level, float damage, float range, float rateOfFire, int buyPrice, int sellPrice, PointF position, PointF[] shape, Color color):base(position, shape, color)
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
            fireTimer += deltaTime;

            if(fireTimer >= 1/rateOfFire)
            {
                Attack();
            }
        }

        public virtual void Upgrade()
        {
            GameWorld.money -= buyPrice;
        }
        
        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
            Pen p = new Pen(Brushes.Blue);
            p.Color = color;
            dc.DrawPolygon(p,newshape);
            dc.FillPolygon(new SolidBrush(color),newshape);

        }

        public virtual void Attack()
        {
            
        }

        public virtual void Sell()
        {
            GameWorld.money += sellPrice;
            Destroy(this);
        }

        

    }
}
