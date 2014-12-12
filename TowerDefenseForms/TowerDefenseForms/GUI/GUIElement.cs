using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    class GUIElement:GameObject
    {
        private float width,height;
        private RectangleF rect;
        private bool hover;
        private string imagePath;

        public GUIElement(float width, float height,PointF position,string imagePath, Color color)
            : base(position,imagePath, color)
        {
            this.width = width;
            this.height = height;
            this.imagePath = imagePath;
            rect = new RectangleF(position,new SizeF(width,height));
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if (Cursor.Position.X >= position.X && Cursor.Position.X < position.X + width && Cursor.Position.Y >= position.Y && Cursor.Position.Y <= position.Y + height)
            {
                hover = true;
            }
            else
            {
                hover = false;
            }
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
            
            if (hover)
            {
                dc.DrawRectangle(Pens.Blue, new Rectangle((int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Height));
            }
            else
            {
                dc.DrawRectangle(Pens.White, new Rectangle((int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Height));
            }
        }
    }
}
