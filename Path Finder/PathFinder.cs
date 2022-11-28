using Path_Finder.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Path_Finder
{
    public partial class PathFinder : Form
    {
        private const int width = 24, height = 18, size = 25;
        private static int[,] Map = new int[height + 2, width + 2];
        private static int tempX, tempY, tempInt, Draw = 0, count;
        private static List<Block> walls = new List<Block>();
        private static Block[] Drts = new Block[] { new Block() { X = 0, Y = -1 }, 
            new Block() { X = 1, Y = 0 }, new Block() { X = 0, Y = 1 }, new Block() { X = -1, Y = 0 } };
        private static bool startFlag, destFlag, isFinding;
        private static Graphics g, G;
        private static List<Block> ListPath = new List<Block>(),
            ListAnim = new List<Block>(), ListPath2 = new List<Block>();
        private static Rectangle rectangle = new Rectangle() { Width = size - 1, Height = size - 1 };
        private static Block pFinding = new Block();
        private static Block pStart = new Block(), pDest = new Block();
        private static Block[,] MapAlgorithm = new Block[height + 2, width + 2];
        private static int WIDTH, HEIGHT;
        private static Bitmap bmpBG;
        private static Brush br = new SolidBrush(Color.FromArgb(64, 64, 64));
        private static Pen p = new Pen(br, 1);
        private static bool[,] visited = new bool[height + 2, width + 2];
        private static Block tmpP, tmpP2;
        private static Action action;
        private static Queue<Block> bfsQueue = new Queue<Block>();

        public PathFinder()
        {
            InitializeComponent();

            rDrawWall.Checked = true;
            action = BfsAlgorithm;

            for (int i = 0; i < height + 2; i++)
            {
                for (int j = 0; j < width + 2; j++) 
                    MapAlgorithm[i, j] = new Block();
            }
            for (int i = 0; i < width + 2; i++)
            {
                Map[0, i] = 1;
                Map[height + 1, i] = 1;
            }
            for (int i = 1; i < height + 1; i++)
            {
                Map[i, 0] = 1;
                Map[i, width + 1] = 1;
            }

            WIDTH = width * size;
            HEIGHT = height * size;
            bmpBG = new Bitmap(WIDTH + 1, HEIGHT + 1);
            G = Graphics.FromImage(bmpBG);
            for (int i = 0; i < Height + 1; i++) G.DrawLine(p, 0, i * size, WIDTH, i * size);
            for (int i = 0; i < Width + 1; i++) G.DrawLine(p, i * size, 0, i * size, HEIGHT);
            Table.Image = bmpBG;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 65;
            if (count < ListAnim.Count)
            {
                ListPath2.Add(ListAnim[count]);
                pFinding.X = ListAnim[count].X;
                pFinding.Y = ListAnim[count].Y;
                count++;
            }
            else
            {
                Stop();
            }
            Table.Invalidate();
        }

        private void Stop()
        {
            Table.MouseClick += Table_MouseClick;
            Table.MouseMove += Table_MouseMove;
            btnClear.Enabled = btnFind.Enabled = true;
            isFinding = false;
            timer1.Enabled = false;
            Table.Invalidate();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (startFlag && destFlag)
            {
                ListPath.Clear();
                ListPath2.Clear();
                ListAnim.Clear();
                action();
                lbStepsNum.Text = ListAnim.Count.ToString();

                Table.MouseClick -= Table_MouseClick;
                Table.MouseMove -= Table_MouseMove;
                isFinding = true; 
                count = 0; 
                timer1.Enabled = true;
                btnClear.Enabled = btnFind.Enabled = false;
                
            }
            else MessageBox.Show("Need Start And Dest!", "Error!");
            btnClear.Enabled = true;
            btnFind.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < height + 1; i++)
            {
                for (int j = 1; j < width + 1; j++) Map[i, j] = 0;
            }
            startFlag = false;
            destFlag = false;
            ListPath.Clear();
            ListPath2.Clear();
            walls.Clear();
            ListAnim.Clear();
            Table.Invalidate();
        }

        private void rClear_CheckedChanged(object sender, EventArgs e)
        {
            Draw = 1;
        }

        private void rDrawStart_CheckedChanged(object sender, EventArgs e)
        {
            Draw = 2;
        }
        private void rDrawDest_CheckedChanged(object sender, EventArgs e)
        {
            Draw = 3;
        }

        private void rDrawWall_CheckedChanged(object sender, EventArgs e)
        {
            Draw = 0;
        }
        private void Table_MouseClick(object sender, MouseEventArgs e)
        {
            tempX = e.X / size + 1;
            tempY = e.Y / size + 1;
            switch (Draw)
            {
                case 0: 
                    DrawWall(); 
                    break; 
                case 1: 
                    Clear(); 
                    break;
                case 2: 
                    DrawStart(); 
                    break;
                case 3: 
                    DrawDest(); 
                    break;
            }
            Table.Invalidate();
        }

        private void DrawStart()
        {
            if (startFlag) Map[pStart.Y, pStart.X] = 0;

            if (Map[tempY, tempX] == 1)
            {
                walls.RemoveAt(IndexOf(tempX, tempY));
            }
            else if (Map[tempY, tempX] == 3)
            {
                destFlag = false;
            }
            pStart.X = tempX;
            pStart.Y = tempY;
            startFlag = true;
            Map[tempY, tempX] = 2;
        }

        private void DrawDest()
        {
            if (destFlag) Map[pDest.Y, pDest.X] = 0;

            if (Map[tempY, tempX] == 1)
            {
                walls.RemoveAt(IndexOf(tempX, tempY));
            }
            else if (Map[tempY, tempX] == 2)
            {
                destFlag = false;
            }
            pDest.X = tempX;
            pDest.Y = tempY;
            destFlag = true;
            Map[tempY, tempX] = 3;
        }
        private void Table_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tempX = e.X / size + 1;
                tempY = e.Y / size + 1;
                if (Draw == 0)
                    DrawWall();
                else if (Draw == 1) 
                    Clear();
                Table.Invalidate();
            }
        }

        private void Clear()
        {
            if (Map[tempY, tempX] == 1) 
                walls.RemoveAt(IndexOf(tempX, tempY));
            else if (Map[tempY, tempX] == 2) 
                startFlag = false;
            else if (Map[tempY, tempX] == 3) 
                destFlag = false;
            Map[tempY, tempX] = 0;
        }

        private static int IndexOf(int x, int y)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i].X == x & walls[i].Y == y) return i;
            }
            return -1;
        }   

        private void Table_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            foreach (Block b in ListPath2)
            {
                rectangle.X = size * (b.X - 1) + 1;
                rectangle.Y = size * (b.Y - 1) + 1;
                g.FillRectangle(Brushes.BlanchedAlmond, rectangle);
            }
            if (isFinding)
            {
                rectangle.X = size * (pFinding.X - 1) + 1;
                rectangle.Y = size * (pFinding.Y - 1) + 1;
                g.FillRectangle(Brushes.DarkSalmon, rectangle);
            }
            else
            {
                foreach (Block b in ListPath)
                {
                    rectangle.X = size * (b.X - 1) + 1;
                    rectangle.Y = size * (b.Y - 1) + 1;
                    g.FillRectangle(Brushes.Plum, rectangle);
                }
            }
            foreach (Block b in walls)
            {
                rectangle.X = size * (b.X - 1) + 1;
                rectangle.Y = size * (b.Y - 1) + 1;
                g.FillRectangle(Brushes.Black, rectangle);
            }
            if (startFlag)
            {
                rectangle.X = size * (pStart.X - 1) + 1;
                rectangle.Y = size * (pStart.Y - 1) + 1;
                g.FillRectangle(Brushes.Red, rectangle);
            }
            if (destFlag)
            {
                rectangle.X = size * (pDest.X - 1) + 1;
                rectangle.Y = size * (pDest.Y - 1) + 1;
                g.FillRectangle(Brushes.Green, rectangle);
            }
        }

        private void DrawWall()
        {
            if (Map[tempY, tempX] == 0)
            {
                walls.Add(new Block() { X = tempX, Y = tempY });
                Map[tempY, tempX] = 1;
            }
            else if (Map[tempY, tempX] == 2)
            {
                startFlag = false;
                walls.Add(new Block() { X = tempX, Y = tempY });
                Map[tempY, tempX] = 1;
            }
            else if (Map[tempY, tempX] == 3)
            {
                destFlag = false;
                walls.Add(new Block() { X = tempX, Y = tempY });
                Map[tempY, tempX] = 1;
            }

        }

        private void BfsAlgorithm()
        {
            for (int i = 1; i < height + 1; i++)
            {
                for (int j = 1; j < width + 1; j++) visited[i, j] = false;
            }
            if (!Bfs(pStart.X, pStart.Y))
                MessageBox.Show("Can't Find Path!", "Error!");
        }

        private bool Bfs(int x, int y)
        {
            visited[y, x] = true;
            MapAlgorithm[y, x].X = MapAlgorithm[y, x].Y = -1;
            tmpP = new Block() { X = x, Y = y };
            bfsQueue.Enqueue(tmpP);
            while (bfsQueue.Count != 0)
            {
                tmpP = bfsQueue.Dequeue();
                ListAnim.Add(tmpP);
                for (int i = 0; i < 4; i++)
                {
                    tempY = tmpP.Y + Drts[i].Y;
                    tempX = tmpP.X + Drts[i].X;
                    if (Map[tempY, tempX] != 1 && !visited[tempY, tempX])
                    {
                        MapAlgorithm[tempY, tempX].X = tmpP.X;
                        MapAlgorithm[tempY, tempX].Y = tmpP.Y;
                        if (Map[tempY, tempX] == 3)
                        {
                            while (MapAlgorithm[tempY, tempX].X != -1)
                            {
                                tmpP = new Block() { X = tempX, Y = tempY };
                                ListPath.Add(tmpP);
                                tempInt = tempX;
                                tempX = MapAlgorithm[tempY, tempInt].X;
                                tempY = MapAlgorithm[tempY, tempInt].Y;
                            }
                            bfsQueue.Clear();
                            return true;
                        }
                        tmpP2 = new Block() { X = tempX, Y = tempY };
                        visited[tempY, tempX] = true;
                        bfsQueue.Enqueue(tmpP2);
                    }
                }
            }
            return false;
        }
    }
}
