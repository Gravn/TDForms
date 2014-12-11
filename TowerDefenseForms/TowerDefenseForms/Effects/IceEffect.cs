using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    class IceEffect : Effect
    {
        private GameObject origin, target;
        private float damage, lifeTime,slowFactor;
        private PointF[] shape,effectshape;

        public IceEffect(GameObject origin, GameObject target, float damage, float lifeTime, PointF position, PointF[] shape, Color color)
            : base(origin, target, damage, lifeTime, position, shape, color)
        {
            this.origin = origin;
            this.target = target;
            this.damage = damage;
            this.lifeTime = lifeTime;
            this.shape = target.shape;

            //width needs proper calc, otherwise too wide.
            if (target is Enemy)
            {
                (target as Enemy).GetHit(damage);
            }
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            for (int i = 0; i < shape.Length; i++)
            {
                effectshape[i].X = shape[i].X + position.X;
                effectshape[i].Y = shape[i].Y + position.Y;
            }


        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
            
            dc.FillPolygon(Brushes.AntiqueWhite,shape);
        }
    }
}