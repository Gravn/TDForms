using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    class Button : GameObject
    {
        private float width, height;
        private RectangleF rect;
        private bool hover;

        public Button(float width, float height, PointF position, PointF[] shape, Color color)
            : base(position, shape, color)
        {
            this.width = width;
            this.height = height;
            this.rect = new RectangleF(position, new SizeF(width, height));
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
        }

        public bool Clicked()
        {
            if (Cursor.Position.X >= position.X && Cursor.Position.X < position.X + width && Cursor.Position.Y >= position.Y && Cursor.Position.Y <= position.Y + height && Control.MouseButtons == MouseButtons.Left)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}