using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwayGameOfLife
{
    public partial class Game : Form
    {
        Arena arena;
        public Game(int x, int y)
        { 
            arena = new Arena(x/10,y/10);
            #region Making Form look right
            InitializeComponent();
            Size = new Size(x, y + panel1.Height);
            //I didn't find better way
            Close_Button.Size = new Size(panel1.Height, panel1.Height);
            Close_Button.Location = new Point(panel1.Width-panel1.Height, 0);
            Play_Button.Size = new Size(panel1.Height, panel1.Height);
            Play_Button.Location = new Point(panel1.Width - panel1.Height * 2 - 10, 0);
            #endregion
        }


        /// <summary>
        /// Represents game grid and works with that
        /// </summary>
        class Arena
        {
            public short[,] status { get; private set; }
            private short[,] tempstatus;

            public Arena(int x, int y)
            {
                status = new short[x, y];
                tempstatus = new short[x, y];
            }

            /// <summary>
            /// rewrites status according to game rules
            /// </summary>
            public void newGeneration()
            {
                short[,] temp;
                for (int i = 0; i < status.GetLength(0); i++)
                {
                    for(int j = 0; j < status.GetLength(1); j++)
                    {
                        if (status[i, j] == 0)
                        {
                            if(neighbours(1, i, j) == 3)
                            {
                                tempstatus[i, j] = 1;
                            }
                            else if (neighbours(-1, i,j) == 3)
                            {
                                tempstatus[i, j] = -1;
                            }
                            else
                            {
                                tempstatus[i, j] = 0;
                            }
                        }
                        else
                        {
                            if (neighbours(status[i, j], i, j) < 3 || neighbours(status[i, j], i, j) > 4)
                            {
                                tempstatus[i, j] = 0;
                            }
                            else
                            {
                                tempstatus[i, j] = status[i,j];
                            }
                        }
                    }
                }
                temp = status;
                status = tempstatus;
                tempstatus = temp;
            }

            /// <summary>
            /// returns number of neighbour of coresponding color
            /// </summary>
            /// <param name="color">color of neighbours</param>
            /// <param name="X">X coordinates</param>
            /// <param name="Y">Y coordinates</param>
            /// <returns></returns>
            private int neighbours(int color, int X, int Y)
            {
                int result = 0;
                for (int i = X-1; i <= X+1; i++)
                {
                    for (int j = Y-1; j <= Y+1; j++)
                    {
                        if (status[(i + status.GetLength(0)) % status.GetLength(0),(j + status.GetLength(1)) % status.GetLength(1)] == color)
                        {
                            result++;
                        }
                        
                    }
                }
                return result;
            }
        }

        private void Game_Arena_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Create grid
            {
                Pen pen = new Pen(Color.Black, 1);
                for (int i = 0; i <= Game_Arena.Width; i += 10)
                {
                    g.DrawLine(pen, i, 0, i, Game_Arena.Height);
                }
                for (int i = 0; i <= Game_Arena.Height; i += 10)
                {
                    g.DrawLine(pen, 0, i, Game_Arena.Width, i);
                }
            }

            //fill cells with right colors
            for (int i = 0; i < arena.status.GetLength(0); i++)
            {
                for (int j = 0; j < arena.status.GetLength(1); j++)
                {
                    switch (arena.status[i, j])
                    {
                        case -1:
                            g.FillRectangle(new SolidBrush(Color.Blue), i * 10 + 1, j * 10 + 1, 9, 9);
                            break;
                        case 0:
                            g.FillRectangle(new SolidBrush(Color.White), i*10 + 1, j * 10 + 1, 9, 9);
                            break;
                        case 1:
                            g.FillRectangle(new SolidBrush(Color.Red), i*10 + 1, j * 10 + 1, 9, 9);
                            break;
                    }
                }
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Launcher.Instance.Close();
        }

        #region Dragging
        private bool dragging = false;
        private Point CurPos;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            CurPos = Cursor.Position;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(CurPos));
                CurPos = Cursor.Position;
                Location = Point.Add(Location, new Size(dif));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion

        #region Setting up game arena
        private void Game_Arena_MouseClick(object sender, MouseEventArgs e)
        {
            Tuple<int,int> loc = new Tuple<int, int>(e.Location.X/10,e.Location.Y/10);
            const int max = 1;
            if (arena.status[loc.Item1, loc.Item2] < max)
            {
                arena.status[loc.Item1, loc.Item2]++;
            }
            else
            {
                arena.status[loc.Item1, loc.Item2] = -max;
            }
            Game_Arena.Refresh();
        }
        #endregion

        #region Starting simulation
        private void play_button_Click(object sender, EventArgs e)
        {
            if (Play_Button.Text == "P")
            {
                Play_Button.Text = "L";
                timer1.Enabled = true;
            }
            else
            {
                Play_Button.Text = "P";
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            arena.newGeneration();
            Game_Arena.Refresh();
        }
        #endregion
    }
}
