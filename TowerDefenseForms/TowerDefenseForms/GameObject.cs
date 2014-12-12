using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    abstract class GameObject
    {
        public PointF position;
        public PointF[] shape,newshape;
        public Color color;

        //Constructor for Gameobjects der bruger shapes.
        public GameObject(PointF position, PointF[] shape, Color color)
        {
            this.position = position;
            this.color = color;
            this.shape = shape;

            //Dette gør at objektet nu kan tegnes i dets position, og stadig beholde dets form
            newshape = new PointF[shape.Length];
            for (int i = 0; i < shape.Length; i++)
            {
                newshape[i].X = shape[i].X + position.X;
                newshape[i].Y = shape[i].Y + position.Y;
            }
        }

        //Constructor for objekter der benytter imagePath istedet for Shapes.
        public GameObject(PointF position, string imagePath, Color color)
        {
            this.position = position;
            this.color = color;
        }

        public virtual void Update(float deltaTime)
        {
            
        }

        //Alle objekter som kalder base.Draw får også skrevet dets koordinator på sig. Primært til debug/tests
        public virtual void Draw(Graphics dc)
        {
            dc.DrawString(position.X + ":" + position.Y, new Font("Arial",8f,FontStyle.Regular), Brushes.White, new PointF(position.X+12,position.Y+28));
        }

        //Fjerner objektet fra listen defineret og gennemgået i GameWorld.
        public void Destroy(GameObject go)
        {
            GameWorld.gameobjects.Remove(go);
        }
    }
}
