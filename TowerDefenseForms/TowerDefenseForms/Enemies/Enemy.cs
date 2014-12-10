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
        private int hp, prize;
        private static int currentPath;
        private float armor, speed;
        private Point[] path;
        private PointF[] shape;
        private static PointF currentPos;
        public static PointF CurrentPos
        {
            get { return Enemy.currentPos; }
            set { Enemy.currentPos = value; }
        }
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
        public static int CurrentPath
        {
            get { return currentPath; }
            set { currentPath = value; }
        }
        #endregion
        public Enemy(float speed, int hp, float armor, Point[] path, int prize, PointF startPos, PointF[] shape, Color color)
            : base(startPos, shape, color)
        {
            this.hp = hp;
            this.speed = speed;
            this.prize = prize;
            this.armor = armor;
            this.path = path;
            this.shape = shape;
        }
        public void Move()
        {
            if(currentPos != path[currentPath])
            {
                if (currentPos.X <= path[currentPath].X)
                {
                    currentPos.X += speed;
                }
                if (currentPos.Y <= path[currentPath].Y)
                {
                    currentPos.Y += speed;
                }
                if (currentPos.Y >= path[currentPath].Y)
                {
                    currentPos.Y -= speed;
                }
                if (currentPos.X >= path[currentPath].Y)
                {
                    currentPos.X -= speed;
                }
            }
            else if (currentPos == path[currentPath])
            {
                currentPath++;
            }
        }
        public void Goal()
        {
            if(currentPos == path.Last())
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
    }
}
