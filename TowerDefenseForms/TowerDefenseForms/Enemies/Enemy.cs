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
        private int hp,prize;
        private float armor, speed;
        private Point[] path;
        private PointF[] shape;
        private Point currentPos; 
        Enemy(float speed, int hp, float armor, Point[] path, int prize, PointF startPos, PointF[] shape, Color color)
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
            for (int i = 0; i < 0; i++)
            {
                if(currentPos != path[i])
                {
                    if(currentPos.X != path[i].X)
                    {
                        currentPos.X += 1;
                    }
                    if (currentPos.Y != path[i].Y)
                    {
                        currentPos.Y += 1;
                    }
                }
            }
        }
        public void Goal()
        {
            if(currentPos == path.Last())
            {

            }
        }
        public void Die()
        {
            if(hp <= 0)
            {
                GameWorld.gameobjects.Remove(this);
            }
        }
    }
}
