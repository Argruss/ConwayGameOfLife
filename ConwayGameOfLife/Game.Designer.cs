namespace ConwayGameOfLife
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            Game_Arena = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            trackBar1 = new System.Windows.Forms.TrackBar();
            Play_Button = new System.Windows.Forms.Button();
            Close_Button = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Game_Arena).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // Game_Arena
            // 
            Game_Arena.BackColor = System.Drawing.SystemColors.Control;
            Game_Arena.Dock = System.Windows.Forms.DockStyle.Fill;
            Game_Arena.Location = new System.Drawing.Point(0, 48);
            Game_Arena.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Game_Arena.Name = "Game_Arena";
            Game_Arena.Size = new System.Drawing.Size(250, 264);
            Game_Arena.TabIndex = 0;
            Game_Arena.TabStop = false;
            Game_Arena.Paint += Game_Arena_Paint;
            Game_Arena.MouseDown += Game_Arena_MouseDown;
            Game_Arena.MouseMove += Game_Arena_MouseMove;
            Game_Arena.MouseUp += Game_Arena_MouseUp;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.GrayText;
            panel1.Controls.Add(trackBar1);
            panel1.Controls.Add(Play_Button);
            panel1.Controls.Add(Close_Button);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(250, 48);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            trackBar1.Location = new System.Drawing.Point(53, 12);
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(77, 56);
            trackBar1.TabIndex = 4;
            trackBar1.Value = 1;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // Play_Button
            // 
            Play_Button.Location = new System.Drawing.Point(168, 0);
            Play_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Play_Button.Name = "Play_Button";
            Play_Button.Size = new System.Drawing.Size(38, 48);
            Play_Button.TabIndex = 3;
            Play_Button.Text = "P";
            Play_Button.UseVisualStyleBackColor = true;
            Play_Button.Click += play_button_Click;
            // 
            // Close_Button
            // 
            Close_Button.Location = new System.Drawing.Point(212, 0);
            Close_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Close_Button.Name = "Close_Button";
            Close_Button.Size = new System.Drawing.Size(38, 48);
            Close_Button.TabIndex = 2;
            Close_Button.Text = "X";
            Close_Button.UseVisualStyleBackColor = true;
            Close_Button.Click += Close_Button_Click;
            // 
            // timer1
            // 
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            // 
            // Game
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(250, 312);
            Controls.Add(Game_Arena);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Game";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Game";
            ((System.ComponentModel.ISupportInitialize)Game_Arena).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Game_Arena;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Button Play_Button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}