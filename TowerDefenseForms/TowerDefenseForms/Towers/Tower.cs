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
        private Button[] Buttons = new Button[4];

        public Tower(int level, float damage, float range, float rateOfFire, int buyPrice, int sellPrice, PointF position, PointF[] shape, Color color):base(position, shape, color)
        {
            this.level = level;
            this.damage = damage;
            this.range = range;
            this.rateOfFire = rateOfFire;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;

            Buttons[0] = new Button(63, 63, position,"", Color.Blue);
            GameWorld.gameobjects.Add(Buttons[0]);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            //Dette var et forsøg på på at lave funktionelle knapper til tårnene.
            /*
            if(Buttons[0].Clicked())
            {
                Buttons[1] = new Button(32, 32, new PointF(position.X+16, position.Y + 64),@"GUI\cancel.png", Color.Red);
                Buttons[2] = new Button(32, 32, new PointF(position.X +64, position.Y+16),@"GUI\upgrade.png", Color.Green);
                Buttons[3] = new Button(32, 32, new PointF(position.X+16, position.Y - 32),@"GUI\sell.png",Color.Yellow);
                for (int i = 0; i < Buttons.Length; i++)
                {
                    GameWorld.gameobjects.Add(Buttons[i]);
                }
                if (Buttons[1].Clicked())
                {
                    for (int i = 0; i < Buttons.Length; i++)
                    {
                        Buttons[i].Destroy(this);
                        Buttons = new Button[4];
                    }
                }
                if (Buttons[2].Clicked())
                {
                    Upgrade();
                }
                if (Buttons[3].Clicked())
                {
                    Sell();
                }      
            }
            */
            fireTimer += deltaTime;

            if(fireTimer > 1/rateOfFire)
            {
                Attack();
            }
        }

        //bliver aldrig kaldt, men skulle have været kaldt fra knapper.
        public virtual void Upgrade()
        {
            GameWorld.money -= buyPrice;
            //justér lvl, justér stats.
        }
        
        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
            Pen p = new Pen(Brushes.Blue);
            p.Color = color;
            dc.DrawPolygon(p,newshape);
            dc.FillPolygon(new SolidBrush(color),newshape);

        }

        //Tower Attack og dets subklasser angriber ikke fjender direkte, men instantierer effekter som kalder funktioner på de fjender de rammer.
        public virtual void Attack()
        {
            
        }

        //bliver aldrig kaldt, men skulle have været kaldt fra knapper.
        public virtual void Sell()
        {
            GameWorld.money += sellPrice;
            Destroy(this);
        }

        

    }
}
