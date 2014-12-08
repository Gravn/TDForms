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
        public PointF[] shape;
        public Color color;

        public GameObject(PointF position,PointF[] shape,Color color)
        {
            this.position = position;
            this.shape = shape;
            this.color = color;
        }

        public virtual void Update(float deltaTime)
        {

        }

        public virtual void Draw(Graphics dc)
        { 
            
        }

        public void Destroy(GameObject go)
        {
            GameWorld.gameobjects.Remove(go);
        }
    }
}
