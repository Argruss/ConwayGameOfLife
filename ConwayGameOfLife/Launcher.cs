using System;
using System.Windows.Forms;

namespace ConwayGameOfLife
{  
    public partial class Launcher : Form
    {
        public static Launcher Instance;
        public Launcher()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Launch_Click(object sender, EventArgs e)
        {
            Form form = new Game(10*(int)numericUpDown1.Value,10*(int)numericUpDown2.Value);
            form.Show();
            Hide();
        }
    }
}
