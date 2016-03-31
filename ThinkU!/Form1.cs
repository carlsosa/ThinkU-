using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThinkU_
{
    public partial class Form1 : MaterialForm
    {
        private bool playnest;

        public string[] Nombre { get; private set; }
        public string[] Ruta { get; private set; }
        public int Startindex { get; private set; }
        
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer1.Ctlcontrols;
            
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            
                axWindowsMediaPlayer1.Ctlcontrols.next();
                axWindowsMediaPlayer1.Ctlcontrols.previous();
            controls.next();
            controls.previous();
          
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Startindex = 0;
            playnest = false; 
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3;*|All Files|*.*";
            open.DefaultExt = ".mp4";

            if(open.ShowDialog() == DialogResult.OK)
            {
                 Nombre = open.SafeFileNames;
                 Ruta = open.FileNames;
                for(int i=0; i<= Nombre.Length -1; i++)
                {
                 
                        listBox1.Items.Add(Nombre[i]);
                  
                        Startindex = 0;
                        PlayA(0);
                    
                }
            }
        }

       

        public void PlayA(int lista)
        {
            if (listBox1.Items.Count <= 0)
            {
                return;
            }
            if (lista < 0)
            {
                return;
            }
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.URL = Ruta[lista];
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlcontrols.next();

            
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creado por Carlos Raul Sosa Alcantara");
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Con ThinkU! puedes reproducir videos y audio en Windows,seleciona tu archivo multimedia y luego presiona play");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Form(); 
           
     
        Button uno = new Button();
            uno.Text = "Ok";
            Label l= new Label();
            l.Text = "Deseas Cerrar?";
            
            form2.Size = new System.Drawing.Size(150, 150);
            l.Location = new Point(10, 10);
            form2.Controls.Add(l);
            uno.Location = new Point(10, 50);
            Button dos = new Button();
            dos.Text = "Cancel";
            dos.Location = new Point(10, 80);

            uno.DialogResult = DialogResult.OK;
            dos.DialogResult = DialogResult.Cancel;
            form2.Text = "?!";
            form2.FormBorderStyle = FormBorderStyle.FixedDialog;
            form2.AcceptButton = uno;
            form2.CancelButton = dos;
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Controls.Add(uno);
            form2.Controls.Add(dos);
            form2.MaximizeBox = false;
            form2.MinimizeBox = false;
            form2.ShowDialog();
            if(form2.DialogResult== DialogResult.OK)
            {
                form2.Dispose();
                Close();
            }
            else
            {
               
            }
            
        }

        private void WindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            int status = e.newState;

            if(status ==8)
            {
                status = e.newState;
            }
            if(Startindex == listBox1.Items.Count - 1)
            {
                Startindex = 0;
            }
            else if (Startindex >=0 && Startindex < listBox1.Items.Count - 1)
            {
                Startindex = Startindex + 1;
            }
            playnest = true;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Ctlcontrols.next();
            axWindowsMediaPlayer1.Ctlcontrols.previous();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuStrip1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void resize_a(object sender, EventArgs e)
        {
            if(WindowState== FormWindowState.Minimized)
            {
                ShowInTaskbar = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void mazimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.fullScreen = true;
            }
            else
            {
                MessageBox.Show("Solo puedes utilizar esta opcion cuando reproduces un video");
            }
          
            
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }
       
    }
}
