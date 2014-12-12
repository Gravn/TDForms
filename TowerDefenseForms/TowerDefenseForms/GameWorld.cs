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

        public DateTime Startgame,endTime;
        public static float deltaTime,spawntimer;

        //Bliver brugt af Enemy til at navigere. jagged array kunne give os flere baner.
        private Point[] path = new Point[]
        {
            new Point(128,512),
            new Point(512,512),
            new Point(512,128),
        };
        private BufferedGraphics backBuffer;
        public PointF size;

        //Designet til at holde billeder til GUI/Button objekter som blev brugt tit. Aldrig implementeret.
        public Image[] images;

        //De forskellige former i form af punkter. brugt af de fleste objekter.
        public static PointF[][] shapes = new PointF[10][];
        
        //Skulle indeholde data til diverse tårne, 1. tårntype, 2. level.
        public static float[][] towerstats;

        //Skulle indeholde spillerens stats, såsom penge, score, liv.
        public static float[] playerStats;

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
            
            //size til at begrænse diverse objekter til vinduet. Aldrig brugt.
            size = new PointF(displayRectangle.Width, displayRectangle.Height);
            gameObjects = new List<GameObject>();
            
            SetupWorld();
        }
        public void SetupWorld()
        {
            Startgame = DateTime.Now;
            //Her bliver points defineret.
            //Kunne være loaded fra fil hvis der var tid/tænkt over det.
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
                new PointF(32, 64),
            };

            shapes[2] = new PointF[]
            {
                new PointF(32, 64),
                new PointF(64, 32),
                new PointF(48, 16),
                new PointF(56, -16),
                new PointF(32,16),
                new PointF(8,-16),
                new PointF(16,16),
                new PointF(0,32)
            };
            
            //Tilføjer knapper i et grid.
            for (int i = 0; i < size.X / 64 - 1; i++)
            {
                for (int j = 0; j < size.Y / 64 - 1; j++)
                {
                    gameObjects.Add(new Button(63, 63, new PointF(i * 64, j * 64),"", Color.BlueViolet));
                }
            }

            //Her fjernes knapper fra grid, så der ikke kan bygges i enemypath.
            for(int i = 0; i<gameObjects.Count;i++)
            {
                for (int j =0; j < path[0].Y; j += 64)
                { 
                    if(gameObjects[i].position == new PointF(path[0].X,j))
                    {
                        gameObjects[i].Destroy(gameObjects[i]);
                    }
                }

                for (int j = path[0].X; j < path[1].X; j += 64)
                {
                    if (gameObjects[i].position == new PointF(j,path[1].Y))
                    {
                        gameObjects[i].Destroy(gameObjects[i]);
                    }
                }

                for (int j = path[2].Y; j < path[1].Y+64; j += 64)
                {
                    if (gameObjects[i].position == new PointF(path[2].X,j))
                    {
                        gameObjects[i].Destroy(gameObjects[i]);
                    }
                }

            }

            //Start towers.
                gameObjects.Add(new BombTower(1, 1f, 3f, 600f, 200f, .1f, 300, 200, new PointF(256, 320),shapes[0], Color.Red));
                gameObjects.Add(new LaserTower(1, 1f, 300, .5f, 2, 20, new PointF(256, 384), shapes[0], Color.Green));

            //gameObjects.Add(new NormalEnemy(2, 3000, 5, path, 10, new PointF(128, 0),shapes[0], Color.Blue));
            //gameObjects.Add(new NormalEnemy(2, 3000, 5, path, 10, new PointF(128, -128), shapes[0], Color.Blue));
            gameObjects.Add(new SpawningEnemy(2, 2000, 0, path, 100, new PointF(128,-256), shapes[0], 4, Color.Aquamarine));
        }

        public void GameLoop()
        {
            DateTime startTime = DateTime.Now;
            TimeSpan realDeltaTime = startTime - endTime;
            int milliseconds = realDeltaTime.Milliseconds > 0 ? realDeltaTime.Milliseconds : 1;
            deltaTime = 1 / (1000 / (float)milliseconds);
            endTime = DateTime.Now;

            //Her tjekkes knapperne der ligger i grid. Klikkes der instantieres et tårn.
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is Button)
                { 
                    if((gameObjects[i] as Button).Clicked())
                    {
                        //if stat money >= towerprice(from towerstats)
                        gameObjects.Add(new LaserTower(1, 1f, 300, 5f, 2, 20, new PointF(gameObjects[i].position.X, gameObjects[i].position.Y), shapes[0], Color.Green)); 
                        //stat money -= towercost(from towerstats)
                    }
                }
            }

            //måler tid siden starten af spillet. Bruges til at formindske tiden imellem spawns.
            TimeSpan gametime = DateTime.Now-Startgame;

            spawntimer += deltaTime;
            //Instantierer fjender i et interval.
            if (spawntimer > 3f-(gametime.Milliseconds/1000))
            {
                gameObjects.Add(new NormalEnemy(2, 3000, 5, path, 10, new PointF(128, -128), shapes[1], Color.Blue));
                gameObjects.Add(new SpawningEnemy(4, 2000, 0, path, 100, new PointF(128, -256), shapes[2], 4, Color.Aquamarine));
                spawntimer = 0;
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
