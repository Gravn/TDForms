using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    class Button : GUIElement
    {
        private float width, height;
        private RectangleF rect;
        private bool hover,imgpass;
        private string imagePath;
        private Image img;

        public Button(float width, float height,PointF position, string imagePath, Color color)
            : base(width,height,position,imagePath, color)
        {
            this.width = width;
            this.height = height;
            this.imagePath = imagePath;
            this.rect = new RectangleF(position, new SizeF(width, height));
            try
            {
                img = Image.FromFile(imagePath);
            }
            catch 
            {
                imgpass = false;
            }
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void Draw(Graphics dc)
        {
            if(imgpass)
            {
                dc.DrawImage(img, position);
            }
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