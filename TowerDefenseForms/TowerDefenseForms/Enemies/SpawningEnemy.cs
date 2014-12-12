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
        //Til instantiering af dette objekt
        public SpawningEnemy(float speed, float hp, float armor, Point[] path, int prize, PointF startPos, PointF[] shape, int spawns, Color color) 
            : base(speed, hp, armor, path, prize, startPos, shape, color)
        {
            this.hp = hp;
            this.prize = prize;
            this.spawns = spawns;
        }
        public override void Die() //Bliver kaldt når denne fjende rammer 0 liv, giver de nye fjender som laves den rigtige sti at følge
        {
            //Laver stien om til en liste hvor enkelte punkter kan fjernes
            List<Point> path = Path.ToList(); 
            //Æmdre kun i stien hvis der er nogen ændringer
            if (CurrentPath > 0) 
            {
                //Fjerner punkter i stien de nye fjender skal følge
                for (int i = CurrentPath; i >= 0; i--) 
                {
                    path.RemoveAt(i);
                }
            }
            //Laver listen om til et array igen med de rigtige punkter
            Point[] newpath = path.ToArray();
            //Laver nye fjender på positionen denne SpawningEnemy døde
            for(int i = 0; i < spawns; i++) 
            {
                //Instantierer de nye fjender i objekt listen, læg mærke til at hver nye fjende er svagere end denne fjende proportionelt til antallet af nye fjender
                GameWorld.gameobjects.Add(new NormalEnemy(2, hp/spawns, 0f, newpath, prize/spawns, position,shape, Color.Red)); 
            }
            //Kalder Enemy klassens Die som fjerner dette objekt fra objekt listen
            base.Die();
        }
    }
}
