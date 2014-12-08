using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TowerDefenseForms
{
    class GameWorld
    {
        private Graphics dc;
        private static List<GameObject> gameObjects;
        public static List<GameObject> gameobjects
        {
            get { return gameObjects; }
            set { gameObjects = value; }
        }

        public DateTime endTime;
        public static float deltaTime;

        private BufferedGraphics backBuffer;
        public PointF size;
        public Image[] images;
        public PointF[][] shapes;
        public float[][] stats;

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
            size = new PointF(displayRectangle.Width, displayRectangle.Height);
            SetupWorld();
        }

        public void SetupWorld()
        {
            gameObjects = new List<GameObject>();

            shapes[0] = new PointF[]
            {
                new PointF(0, 0), 
                new PointF(100, 0), 
                new PointF(100, 100), 
                new PointF(0, 100)
            };

            gameObjects.Add(new Tower(1,2,50,5,100,90,new PointF(250,250),shapes[0],Color.Blue));
        }

        public void GameLoop()
        {
            DateTime startTime = DateTime.Now;
            TimeSpan realDeltaTime = startTime - endTime;
            int milliseconds = realDeltaTime.Milliseconds > 0 ? realDeltaTime.Milliseconds : 1;
            deltaTime = 1 / (1000 / (float)milliseconds);
            endTime = DateTime.Now;
            Update();
            Draw();
        }

        private void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(deltaTime);
            }
        }

        private void Draw()
        {
            dc.Clear(Color.Black);
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(dc);
            }
            backBuffer.Render();
        }
    }
}
