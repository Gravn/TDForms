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
        //Internt brugte variabler
        private int spawns, prize;
        private float hp; 
        public SpawningEnemy(float speed, float hp, float armor, Point[] path, int prize, PointF startPos, PointF[] shape, int spawns, Color color) //Til instantiering af dette objekt
            : base(speed, hp, armor, path, prize, startPos, shape, color)
        {
            this.hp = hp;
            this.prize = prize;
            this.spawns = spawns;
        }
        public override void Die() //Bliver kaldt når denne fjende rammer 0 liv
        {
            //Giver de nye fjender som laves den rigtige sti at følge
            List<Point> path = Path.ToList(); //Laver stien om til en liste hvor enkelte punkter kan fjernes
            if (CurrentPath > 0) //Æmdre kun i stien hvis der er nogen ændringer
            {
                for (int i = CurrentPath; i >= 0; i--) //Fjerner punkter i stien de nye fjender skal følge
                {
                    path.RemoveAt(i);
                }
            }
            Point[] newpath = path.ToArray(); //Laver listen om til et array igen med de rigtige punkter
            for(int i = 0; i < spawns; i++) //Laver nye fjender på positionen denne SpawningEnemy døde
            {
                GameWorld.gameobjects.Add(new NormalEnemy(2, hp/spawns, 0f, newpath, prize/spawns, position,shape, Color.Red)); //Instantierer de nye fjender i objekt listen
            }
            base.Die(); //Kalder Enemy klassens Die som fjerner dette objekt fra objekt listen
        }
    }
}
