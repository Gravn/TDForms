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
        public static float[][] stats;
        public static int money;

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
            size = new PointF(displayRectangle.Width, displayRectangle.Height);
            gameObjects = new List<GameObject>();
            gameObjects.Add(new LaserTower(1, 2f, 2f, 2f, 10, 20, new PointF(250, 250), new PointF[] {new PointF(0, 0), new PointF(100, 0), new PointF(100, 100), new PointF(0,100) }, Color.Blue));
            //SetupWorld();
        }

        public void SetupWorld()
        {
            shapes[0] = new PointF[]
            {
                new PointF(0, 0), 
                new PointF(100, 0), 
                new PointF(100, 100), 
                new PointF(0, 100)
            };
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
