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
        private int spawns, prize;
        private float hp;
        public SpawningEnemy(float speed, float hp, float armor, Point[] path, int prize, PointF startPos, PointF[] shape, int spawns)
            : base(speed, hp, armor, path, prize, startPos, shape, Color.Blue)
        {
            this.hp = hp;
            this.prize = prize;
            this.spawns = spawns;
        }
        public override void Die()
        {
            //Give the spawned enemies a proper path to follow
            List<Point> path = Path.ToList();
            for(int i = CurrentPath; i > 0; i--)
            {
                path.RemoveAt(i);
            }
            Point[] newpath = path.ToArray();
            //spawn weaker enemies
            for(int i = 0; i < spawns; i++)
            {
                GameWorld.gameobjects.Add(new NormalEnemy(2,hp/spawns, 0f, newpath, prize/spawns, position,shape, Color.Red));
            }
            base.Die();
        }
    }
}
