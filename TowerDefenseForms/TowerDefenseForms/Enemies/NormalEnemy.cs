using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseForms
{
    class NormalEnemy : Enemy
    {
        public NormalEnemy(float speed, float hp, float armor, Point[] path, int prize, PointF startPos, PointF[] shape, Color color)
            : base(speed, hp, armor, path, prize, startPos, shape, color)
        {

        }
        public override void Die()
        {
            base.Die();
        }
    }
}
