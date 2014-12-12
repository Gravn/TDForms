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
            
            //width, som er en unik variabel for LaserEffect, er for at indikere til spilleren hvor meget effekten skader.
            //Jo mere laseren skader, jo bredere er laseren når den bliver tegnet.
            width = damage;

            
            if (target is Enemy)
            {
                (target as Enemy).GetHit(damage); //Her kaldes Enemy klassens GetHit funktion. Det var planlagt at forskellige fjender reagerede forskelligt på skade.
            }
        }

        public override void Update(float deltaTime)
        {
 	        base.Update(deltaTime);
        }

        public override void Draw(Graphics dc)
        {
 	        //base.Draw(dc);
            //Der tegnes en laser/linje imellem origin(for det meste et tårn) og target(for det meste en fjende), der korrigeres position så der skydes fra og rammes ca i midten istedet for øverste højre hjørne.
            dc.DrawLine(new Pen(new SolidBrush(color), width),new PointF(origin.position.X+32,origin.position.Y+32), new PointF(target.position.X+32,target.position.Y+32));
        }
    }
}