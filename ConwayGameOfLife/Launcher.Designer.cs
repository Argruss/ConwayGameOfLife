namespace ConwayGameOfLife
{
    partial class Launcher
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
            label1 = new System.Windows.Forms.Label();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            Launch = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(78, 62);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(138, 20);
            label1.TabIndex = 0;
            label1.Text = "Size of Game arena";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.Location = new System.Drawing.Point(83, 121);
            numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numericUpDown1.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(120, 27);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown2.Location = new System.Drawing.Point(83, 191);
            numericUpDown2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numericUpDown2.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(120, 27);
            numericUpDown2.TabIndex = 2;
            numericUpDown2.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // Launch
            // 
            Launch.Location = new System.Drawing.Point(105, 340);
            Launch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Launch.Name = "Launch";
            Launch.Size = new System.Drawing.Size(75, 29);
            Launch.TabIndex = 3;
            Launch.Text = "Launch";
            Launch.UseVisualStyleBackColor = true;
            Launch.Click += Launch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(21, 121);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 20);
            label2.TabIndex = 4;
            label2.Text = "Width";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(21, 191);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(54, 20);
            label3.TabIndex = 5;
            label3.Text = "Height";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(38, 270);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 20);
            label4.TabIndex = 6;
            label4.Text = "PvP";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown3.Location = new System.Drawing.Point(83, 268);
            numericUpDown3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new System.Drawing.Size(120, 27);
            numericUpDown3.TabIndex = 7;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(292, 474);
            Controls.Add(numericUpDown3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Launch);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Launcher";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button Launch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
    }
}

