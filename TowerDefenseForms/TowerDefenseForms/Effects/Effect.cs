using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    abstract class Effect:GameObject
    {
        private GameObject origin, target;
        private float damage, lifeTime,timer;

        public Effect(GameObject origin,GameObject target, float damage, float lifeTime,PointF position,PointF[] shape,Color color):base(position,shape,color)
        {
            this.origin = origin;
            this.target = target;
            this.damage = damage;
            this.lifeTime = lifeTime;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            timer +=10f*deltaTime;        
            if (timer >= lifeTime)
            {
                Destroy(this);
            }

        }

        public override void Draw(Graphics dc)
        {
 	        base.Draw(dc);
        }
    }
}
