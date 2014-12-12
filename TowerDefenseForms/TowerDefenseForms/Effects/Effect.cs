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

        //Constructor for Effect. Bliver kaldt fra diverse Tower objekter.
        public Effect(GameObject origin,GameObject target, float damage, float lifeTime,PointF position,PointF[] shape,Color color):base(position,shape,color)
        {
            this.origin = origin;
            this.target = target;
            this.damage = damage;
            this.lifeTime = lifeTime;
        }

        //Alle effekter benytter lifeTime, så det er med i denne superklasse.
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            timer +=10f*deltaTime;        
            if (timer >= lifeTime)
            {
                Destroy(this);
            }

        }

        //Effekter benytter ikke GameObject's draw, da koordinat visning ikke er brugbart for effekterne.
        public override void Draw(Graphics dc)
        {
 	        //base.Draw(dc);
        }
    }
}
