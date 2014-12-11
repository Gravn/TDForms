using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseForms
{
    abstract class Enemy : GameObject
    {
        #region fields
        private int prize;
        private static int currentPath;
        private float armor, speed, hp;
        private Point[] path;
        private PointF[] shape,newshape;
        public Point[] Path
        {
            get { return path; }
            set { path = value; }
        }
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int CurrentPath
        {
            get { return currentPath; }
            set { currentPath = value; }
        }
        #endregion
        public Enemy(float speed, float hp, float armor, Point[] path, int prize, PointF startPos, PointF[] shape, Color color)
            : base(startPos, shape, color)
        {
            this.hp = hp;
            this.speed = speed;
            this.prize = prize;
            this.armor = armor;
            this.path = path;
            this.shape = shape;
            newshape = new PointF[shape.Length];
        }
        public override void Update(float deltaTime)
        {
            Die();
            Move();

            //gravn movement:
            for (int i = 0; i < shape.Length; i++)
            {
                newshape[i].X = shape[i].X + position.X;
                newshape[i].Y = -shape[i].Y + position.Y;
            }

            base.Update(deltaTime);
        }
        public void Move()
        {
            if (position != path[currentPath])
            {
                if (position.X <= path[currentPath].X)
                {
                    position.X += speed;
                }
                if (position.Y <= path[currentPath].Y)
                {
                    position.Y += speed;
                }
                if (position.Y >= path[currentPath].Y)
                {
                    position.Y -= speed;
                }
                if (position.X >= path[currentPath].Y)
                {
                    position.X -= speed;
                }
            }
            else if (position == path[currentPath])
            {
                currentPath++;
            }
        }
        public void Goal()
        {
            if (position == path.Last())
            {

                GameWorld.gameobjects.Remove(this);
            }
        }
        public virtual void Die()
        {
            if(hp <= 0)
            {
                GameWorld.gameobjects.Remove(this);
            }
        }
        public override void Draw(Graphics dc)
        {
            dc.FillPolygon(new SolidBrush(color),newshape);
            base.Draw(dc);
        }
        public void GetHit(float dmg)
        {
            hp -= dmg;
        }
    }
}
