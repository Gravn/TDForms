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
        Enemy(float speed, int hp, int armor, Point[] path, int prize, PointF startPos, PointF[] shape, Color color)
            : base(startPos, shape, color)
        {

        }
    }
}
