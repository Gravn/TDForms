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
        #region Fields
        private int prize;
        private int currentPath;
        private float armor, speed, hp;
        private Point[] path;
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
            newshape = new PointF[shape.Length];
        }
        public override void Update(float deltaTime) //Loopet for alt fjenderne gør
        {
            if (hp <= 0)
            {
                Die();
            }
            Move();
            //Definerer fjendernes form som spillet kører og den løbende bevæger sig
            for (int i = 0; i < shape.Length; i++)
            {
                newshape[i].X = shape[i].X + position.X;
                newshape[i].Y = shape[i].Y + position.Y;
            }

            base.Update(deltaTime);
        }
        public void Move() //Bevæger alle fjenderne efter en sti defineret i arrayet "path"
        {
            if (this.position != path[currentPath]) //Hvis fjenden ikke er på stiens næste punkt bevæger den sig derhen, "position" er et punkt nedarvet af GameObject
            {
                if (this.position.X < path[currentPath].X)
                {
                    this.position.X += speed;
                }
                if (this.position.Y < path[currentPath].Y)
                {
                    this.position.Y += speed;
                }
                if (this.position.Y > path[currentPath].Y)
                {
                    this.position.Y -= speed;
                }
                if (this.position.X > path[currentPath].Y)
                {
                    this.position.X -= speed;
                }
            }
            else
            {
                this.currentPath++; //Når det næste punkt er nået øges denne variabel som definerer hvilket punkt fjenden er nået til.
            }
        }
        public void Goal() //Kaldes som fjenden når det sidste punkt dør den og spilleren mister et liv
        {
            if (position == path.Last())
            {
                //Lost HP
                GameWorld.gameobjects.Remove(this);
            }
        }
        public virtual void Die() //Kaldes når fjenden er på 0 eller mindre hp
        {
            GameWorld.gameobjects.Remove(this);
        }
        public override void Draw(Graphics dc) //Tegner fjenderne som fyldte polygoner defineret i Update
        {
            dc.FillPolygon(new SolidBrush(color),newshape);
            base.Draw(dc);
        }
        public void GetHit(float dmg) //Kaldes når en fjende bliver ramt
        {
            hp -= dmg;
        }
    }
}
