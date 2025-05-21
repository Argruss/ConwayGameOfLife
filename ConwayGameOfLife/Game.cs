using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConwayGameOfLife
{
    public partial class Game : Form {
        Arena arena;
        int? turns;
        public Game(int x, int y, int? turns = null) {
            arena = new Arena(x / 10, y / 10);
            this.turns = turns;
            #region Making Form look right
            InitializeComponent();
            Size = new Size(x, y + panel1.Height);
            //I didn't find better way
            Close_Button.Size = new Size(panel1.Height, panel1.Height);
            Close_Button.Location = new Point(panel1.Width - panel1.Height, 0);
            Play_Button.Size = new Size(panel1.Height, panel1.Height);
            Play_Button.Location = new Point(panel1.Width - panel1.Height * 2 - 10, 0);
            #endregion
        }


        /// <summary>
        /// Represents game grid and works with that
        /// </summary>
        enum Cells { white = 0, red, blue, red_dead, blue_dead }
        class Arena {
            public Cells[,] status { get; private set; }

            public Arena(int x, int y) {
                status = new Cells[x, y];
            }

            /// <summary>
            /// rewrites status according to game rules
            /// </summary>
            public void newGeneration() {
                Cells[,] temp = (Cells[,])status.Clone();
                for (int i = 0; i < status.GetLength(0); i++) {
                    for (int j = 0; j < status.GetLength(1); j++) {
                        if (IsWhite(i, j)) {
                            int red = neighbours(Cells.red, i, j);
                            int blue = neighbours(Cells.blue, i, j);
                            if (red != blue) {
                                if (red == 3)
                                    temp[i, j] = Cells.red;
                                else if (blue == 3)
                                    temp[i, j] = Cells.blue;
                            }
                        }
                        else //colored space
                        {
                            if (neighbours(status[i, j], i, j) < 3 || neighbours(status[i, j], i, j) > 4) {
                                if (status[i, j] == Cells.red) {
                                    temp[i, j] = Cells.red_dead;
                                }
                                else {
                                    temp[i, j] = Cells.blue_dead;
                                }
                            }
                            else {
                                temp[i, j] = status[i, j];
                            }
                        }
                    }
                }
                status = temp;
            }

            public bool IsWhite(int x, int y) {
                return status[x, y] is Cells.white or Cells.red_dead or Cells.blue_dead;
            }

            /// <summary>
            /// returns number of neighbours of coresponding color
            /// </summary>
            /// <param name="color">color of neighbours</param>
            /// <param name="X">X coordinates</param>
            /// <param name="Y">Y coordinates</param>
            /// <returns></returns>
            private int neighbours(Cells color, int X, int Y) {
                int result = 0;
                for (int i = X - 1; i <= X + 1; i++) {
                    for (int j = Y - 1; j <= Y + 1; j++) {
                        if (status[(i + status.GetLength(0)) % status.GetLength(0), (j + status.GetLength(1)) % status.GetLength(1)] == color) {
                            result++;
                        }

                    }
                }
                return result;
            }
        }

        private Pen pen = new Pen(Color.Black, 1);
        private SolidBrush blueBrush = new SolidBrush(Color.DarkBlue);
        private SolidBrush deadbluBrush = new SolidBrush(Color.DeepSkyBlue);
        private SolidBrush whiteBrush = new SolidBrush(Color.White);
        private SolidBrush redBrush = new SolidBrush(Color.DarkRed);
        private SolidBrush deadredBrush = new SolidBrush(Color.IndianRed);
        private void Game_Arena_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            //Create grid
            {
                for (int i = 0; i <= Game_Arena.Width; i += 10) {
                    g.DrawLine(pen, i, 0, i, Game_Arena.Height);
                }
                for (int i = 0; i <= Game_Arena.Height; i += 10) {
                    g.DrawLine(pen, 0, i, Game_Arena.Width, i);
                }
            }

            //fill cells with right colors
            for (int i = 0; i < arena.status.GetLength(0); i++) {
                for (int j = 0; j < arena.status.GetLength(1); j++) {
                    switch (arena.status[i, j]) {
                        case Cells.blue:
                            g.FillRectangle(blueBrush, i * 10 + 1, j * 10 + 1, 9, 9);
                            break;
                        case Cells.white:
                            g.FillRectangle(whiteBrush, i * 10 + 1, j * 10 + 1, 9, 9);
                            break;
                        case Cells.red:
                            g.FillRectangle(redBrush, i * 10 + 1, j * 10 + 1, 9, 9);
                            break;
                        case Cells.red_dead:
                            g.FillRectangle(deadredBrush, i * 10 + 1, j * 10 + 1, 9, 9);
                            break;
                        case Cells.blue_dead:
                            g.FillRectangle(deadbluBrush, i * 10 + 1, j * 10 + 1, 9, 9);
                            break;
                    }
                }
            }
        }

        private void Close_Button_Click(object sender, EventArgs e) {
            Launcher.Instance.Close();
        }

        #region Dragging
        private bool dragging = false;
        private Point CurPos;
        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            dragging = true;
            CurPos = Cursor.Position;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e) {
            if (dragging) {
                Point dif = Point.Subtract(Cursor.Position, new Size(CurPos));
                CurPos = Cursor.Position;
                Location = Point.Add(Location, new Size(dif));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e) {
            dragging = false;
        }
        #endregion

        #region Setting up game arena
        private bool painting = false;
        private Cells from = Cells.white, to = Cells.white;
        private void Game_Arena_MouseDown(object sender, MouseEventArgs e) {
            (int X, int Y) = (e.Location.X / 10, e.Location.Y / 10);
            painting = true;
            if (e.Button == MouseButtons.Left) {
                if (arena.status[X, Y] == Cells.red) {
                    from = Cells.red; to = Cells.white;
                }
                else {
                    from = Cells.white; to = Cells.red;
                }
            }
            else {
                if (arena.status[X, Y] == Cells.blue) {
                    from = Cells.blue; to = Cells.white;
                }
                else {
                    from = Cells.white; to = Cells.blue;
                }
            }
            arena.status[X, Y] = to;
            Game_Arena.Refresh();
        }

        private void Game_Arena_MouseUp(object sender, MouseEventArgs e) {
            painting = false;
        }

        private void Game_Arena_MouseMove(object sender, MouseEventArgs e) {
            if (painting) {
                (int X, int Y) = (e.Location.X / 10, e.Location.Y / 10);
                if (arena.status[X, Y] == from) {
                    arena.status[X, Y] = to;
                }
                Game_Arena.Refresh();
            }
        }

        #endregion

        #region Starting simulation
        private void play_button_Click(object sender, EventArgs e) {
            if (Play_Button.Text == "P") {
                Play_Button.Text = "L";
                timer1.Enabled = true;
            }
            else {
                Play_Button.Text = "P";
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (turns == null || turns-- > 0) {
                arena.newGeneration();
            }
            else {
                play_button_Click(sender, e);
                if (Majority() == Cells.red) {
                    WinText("Red Won");
                }
                else {
                    WinText("Blue Won");
                }

            }
                Game_Arena.Refresh();
        }

        private Cells Majority() {
            int blue = 0;
            int red = 0;
            for (int i = 0; i < arena.status.GetLength(0); i++) {
                for (int j = 0; j < arena.status.GetLength(1); j++) {
                    if (arena.status[i, j] is Cells.blue or Cells.blue_dead) blue++;
                    if (arena.status[i, j] is Cells.red or Cells.red_dead) red++;
                }
            }
            if (red == blue) return Cells.white;
            if (red > blue) return Cells.red;
            else return Cells.blue;
        }

        private void WinText(string text) {
            Label idk = new Label();
            idk.Parent = Game_Arena;
            idk.ForeColor = Color.DarkBlue;
            idk.BackColor = Color.Black;
            idk.Text = text;
            idk.Font = new Font("Comic Sans", 20);
            idk.Location = new Point(50, 50);
            idk.Size = new Size(100, 100);
            idk.Show();
        }
        #endregion


        private void trackBar1_ValueChanged(object sender, EventArgs e) {
            timer1.Interval = 200 / trackBar1.Value;
        }
    }
}
