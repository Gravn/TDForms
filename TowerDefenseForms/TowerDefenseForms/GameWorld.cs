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
        private Point[] path = new Point[]
        {
            new Point(100,450), 
            new Point(450,450),
            new Point(450,600),
        };
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
            gameObjects.Add(new BombTower(1, 2f, 3f, 600f, 100f, 0.1f,100,100, new PointF(200, 300), new PointF[] { new PointF(0, 0), new PointF(64, 0), new PointF(64, 64), new PointF(0,64) }, Color.Red));
            //gameObjects.Add(new LaserTower(1, 2f, 300, 0.1f, 10, 20, new PointF(500, 600), new PointF[] { new PointF(0, 0), new PointF(64, 0), new PointF(64, 64), new PointF(0, 64) }, Color.Green));

            gameObjects.Add(new NormalEnemy(10,100,5,path,10,new PointF(100,200),new PointF[]{ new PointF(0,0),new PointF(64,-32), new PointF(64,32) },Color.Blue));
            gameObjects.Add(new SpawningEnemy(10, 100, 0, path, 100, new PointF(100, 100), new PointF[] { new PointF(0, 0), new PointF(64, 0), new PointF(64, 64), new PointF(0, 64) }, 4));
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
            dc.Clear(Color.CornflowerBlue);
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(dc);
            }
            backBuffer.Render();
        }
    }
}
