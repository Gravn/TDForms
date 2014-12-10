using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseForms
{
    class SpawningEnemy : Enemy
    {
        private int spawns, hp, prize;
        public SpawningEnemy(float speed, int hp, float armor, Point[] path, int prize, PointF startPos, PointF[] shape, Color color, int spawns)
            : base(speed, hp, armor, path, prize, startPos, shape, color)
        {
            this.hp = hp;
            this.prize = prize;
            this.spawns = spawns;
        }
        public override void Die()
        {
            List<Point> path = Path.ToList();
            for(int i = CurrentPath; i > 0; i--)
            {
                path.RemoveAt(i);
            }
            Point[] newpath = path.ToArray();
            //spawn 3 more weaker enemies
            for(int i = 0; i < spawns; i++)
            {
                GameWorld.gameobjects.Add(new NormalEnemy(10f,hp/spawns, 0f, newpath, prize/spawns, CurrentPos, this.shape, Color.Azure));
            }
            base.Die();
        }
    }
}
