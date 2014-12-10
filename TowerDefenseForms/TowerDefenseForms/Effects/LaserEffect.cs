using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    class LaserEffect:Effect
    {
        private GameObject origin, target;
        private float damage, lifeTime,width;

        public LaserEffect(GameObject origin,GameObject target, float damage, float lifeTime,PointF position,PointF[] shape,Color color):base(origin,target,damage,lifeTime,position,shape,color)
        {
            this.origin = origin;
            this.target = target;
            this.damage = damage;
            this.lifeTime = lifeTime;
            //width needs proper calc, otherwise too wide.
            width = damage;
        }

        public override void Update(float deltaTime)
        {
 	        base.Update(deltaTime);

            if (target is Enemy)
            {
                (target as Enemy).Die();
            }
        }

        public override void Draw(Graphics dc)
        {
 	        base.Draw(dc);
            dc.DrawLine(new Pen(Brushes.Green, width), origin.position, target.position);
        }
    }
}