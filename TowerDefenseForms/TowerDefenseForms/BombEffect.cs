using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    class BombEffect : Effect
    {
        private GameObject origin, target;
        private float damage, lifeTime, timer,bombRadius;

        public BombEffect(GameObject origin,GameObject target, float damage,float bombRadius, float lifeTime,PointF position,PointF[] shape,Color color):base(origin,target,damage,lifeTime,position,shape,color)
        {
            this.origin = origin;
            this.target = target;
            this.damage = damage;
            this.lifeTime = lifeTime;
            this.bombRadius = bombRadius;
            //width needs proper calc, otherwise too wide.
        }

        public override void Update(float deltaTime)
        {
            timer += deltaTime;
            if (timer >= lifeTime)
            {
                Destroy(this);
            }

            for (int i = 0; i < GameWorld.gameobjects.Count;i++ )
            {
                if (GameWorld.gameobjects[i] is Enemy)
                {
                    float dx = (GameWorld.gameobjects[i] as Enemy).position.X - position.X;
                    float dy = (GameWorld.gameobjects[i] as Enemy).position.Y - position.Y;
                    float distance = (float)Math.Sqrt(dx * dx + dy * dy);
                    if (distance <= bombRadius)
                    {
                        GameWorld.gameobjects.Add(new LaserEffect(this, GameWorld.gameobjects[i], 20, 0.1f, position, new PointF[] { new PointF(0, 0) }, Color.Red));
                    }
                }
            }
            base.Update(deltaTime);
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
            Pen p = new Pen(new SolidBrush(color),2);
            dc.DrawEllipse(p,new RectangleF(target.position.X-32,target.position.Y-32,128,128));
        }
    }
}
