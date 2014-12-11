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
            new Point(128,512), 
            new Point(512,512),
            new Point(512,128),
        };
        private BufferedGraphics backBuffer;
        public PointF size;
        public Image[] images;
        public static PointF[][] shapes = new PointF[10][];
        public static float[][] stats;
        public static int money;

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
            size = new PointF(displayRectangle.Width, displayRectangle.Height);
            gameObjects = new List<GameObject>();
            
            SetupWorld();
        }
        public void SetupWorld()
        {
            shapes[0] = new PointF[]
            {
                new PointF(0,0),
                new PointF(64,0),
                new PointF(64,64),
                new PointF(0,64)
            };

            shapes[1] = new PointF[]
            {
                new PointF(0, 0),
                new PointF(64, 0),
                new PointF(64, 64),
                new PointF(0, 64)
            };

            shapes[2] = new PointF[]
            {
                new PointF(0, 0),
                new PointF(64, 0),
                new PointF(64, 64),
                new PointF(0, 64)
            };
            
            for (int i = 0; i < size.X / 64 - 1; i++)
            {
                for (int j = 0; j < size.Y / 64 - 1; j++)
                {
                    gameObjects.Add(new Button(63, 63, new PointF(i * 64, j * 64),"", Color.Black));
                }
            }

            gameObjects.Add(new BombTower(1, .1f, 3f, 600f, 100f,5f, 300, 200, new PointF(256, 256),shapes[0], Color.Red));
            gameObjects.Add(new LaserTower(1, .1f, 300, 5f, 2, 20, new PointF(256,384),shapes[0], Color.Green));

            gameObjects.Add(new NormalEnemy(2, 100, 5, path, 10, new PointF(128, 0),shapes[0], Color.Blue));
            gameObjects.Add(new NormalEnemy(2, 100, 5, path, 10, new PointF(128, -128), shapes[0], Color.Blue));
            gameObjects.Add(new SpawningEnemy(2, 100, 0, path, 100, new PointF(128,-256), shapes[0], 4));    
        }

        public void GameLoop()
        {
            DateTime startTime = DateTime.Now;
            TimeSpan realDeltaTime = startTime - endTime;
            int milliseconds = realDeltaTime.Milliseconds > 0 ? realDeltaTime.Milliseconds : 1;
            deltaTime = 1 / (1000 / (float)milliseconds);
            endTime = DateTime.Now;

            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Button)
                { 
                    if((gameObjects[i] as Button).Clicked())
                    {
                        //gameObjects.Add(new LaserTower(1, .01f, 300, 5f, 2, 20, new PointF(gameObjects[i].position.X, gameObjects[i].position.Y), shapes[0], Color.Green));      
                    }
                }
            }

            

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
