using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    class Tower : GameObject
    {
        public int level;
        public float damage;
        public float range;
        public float rateOfFire;
        public int buyPrice;
        public int sellPrice;

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
            //base.Update(deltaTime);
            for (int i = 0; i < shape.Length; i++)
            {
                newshape[i].X = shape[i].X + position.X;
                newshape[i].Y = shape[i].Y + position.Y;
            }
            //position.X += 0.001f * deltaTime;
        }

        public override void Draw(Graphics dc)
        {
            Pen p = new Pen(Brushes.Blue, 8);
            p.Color = color;
                dc.DrawPolygon(p,newshape);

        }

        

    }
}
