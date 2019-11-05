using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;

namespace Booom
{
    public partial class Form1 : Form
    {
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
        IntPtr wParam, IntPtr lParam);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Error 000x0228xx1337x1488", MessageBoxButtons.OK);
            Form1 Fm1 = new Form1();
            timer1.Enabled = true;
            for (; ;)
            {


                SoundPlayer player = new SoundPlayer("LowWave.wav");
                player.Play();
                this.Hide();
            }
        }

        int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            this.Hide();
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
            (IntPtr)APPCOMMAND_VOLUME_UP);
            if (i == 150)
            {
                timer1.Enabled = false;
                i = 0;
                Application.Exit();
            }
        }
    }
}
