using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LoL_Summoners_Spells
{

    public partial class InGame : Form
    {
        //  # ---- Suponponer la ventana ante todas las aplicaciones. ---- # ----

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        //  # ---- Suponponer la ventana ante todas las aplicaciones. ---- # ----

        public InGame()
        {
            InitializeComponent();
            this.TransparencyKey = (BackColor);
            this.WindowState = FormWindowState.Maximized;

        }

        List<PictureBox> ImagenCampeon = new List<PictureBox>();
        List<PictureBox> ImagenHechizos = new List<PictureBox>();
        private void InGame_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);


  
            // Lista imagen campeon
            ImagenCampeon.Add(Invocador1);
            ImagenCampeon.Add(Invocador2);
            ImagenCampeon.Add(Invocador3);
            ImagenCampeon.Add(Invocador4);
            ImagenCampeon.Add(Invocador5);

  
            // Lista imagen hechizos
            ImagenHechizos.Add(Inv1Spell1);
            ImagenHechizos.Add(Inv1Spell2);

            ImagenHechizos.Add(Inv2Spell1);
            ImagenHechizos.Add(Inv2Spell2);

            ImagenHechizos.Add(Inv3Spell1);
            ImagenHechizos.Add(Inv3Spell2);

            ImagenHechizos.Add(Inv4Spell1);
            ImagenHechizos.Add(Inv4Spell2);

            ImagenHechizos.Add(Inv5Spell1);
            ImagenHechizos.Add(Inv5Spell2);

            // ### ---------- ### //
        }
        Form1 Ventana = new Form1();
        private void InGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ventana.Show();
        }

   
        private void InGame_Resize(object sender, EventArgs e)
        {
            int centroCampeon = this.Width / 2 - (Invocador1.Size.Width / 2);
            int saltoCampeon = Invocador1.Size.Width + 10;

            Invocador3.Left = centroCampeon;
            Invocador4.Left = centroCampeon + saltoCampeon;
            Invocador2.Left = centroCampeon - saltoCampeon;
            Invocador5.Left = centroCampeon + saltoCampeon * 2;
            Invocador1.Left = centroCampeon - saltoCampeon * 2;


            int saltoHechizo = Inv1Spell1.Size.Width + 10;

            Inv3Spell1.Left = centroCampeon;
            TextInv3Spell1.Left = centroCampeon;
            Inv3Spell2.Left = centroCampeon + Inv1Spell1.Size.Width;
            TextInv3Spell2.Left = centroCampeon + Inv1Spell1.Size.Width;

            Inv4Spell1.Left = centroCampeon + Inv1Spell1.Size.Width + saltoHechizo;
            TextInv4Spell1.Left  = centroCampeon + Inv1Spell1.Size.Width + saltoHechizo;
            Inv4Spell2.Left = centroCampeon + (Inv1Spell1.Size.Width) * 2 + saltoHechizo;
            TextInv4Spell2.Left = centroCampeon + (Inv1Spell1.Size.Width) * 2 + saltoHechizo;

            Inv5Spell1.Left = centroCampeon + (Inv1Spell1.Size.Width) * 2 + saltoHechizo * 2;
            TextInv5Spell1.Left = centroCampeon + (Inv1Spell1.Size.Width) * 2 + saltoHechizo * 2;
            Inv5Spell2.Left = centroCampeon + (Inv1Spell1.Size.Width) * 3 + saltoHechizo * 2;
            TextInv5Spell2.Left = centroCampeon + (Inv1Spell1.Size.Width) * 3 + saltoHechizo * 2;

            Inv2Spell2.Left = centroCampeon - saltoHechizo;
            TextInv2Spell2.Left = centroCampeon - saltoHechizo;
            Inv2Spell1.Left = centroCampeon - Inv1Spell1.Size.Width - saltoHechizo;
            TextInv2Spell1.Left = centroCampeon - Inv1Spell1.Size.Width - saltoHechizo;

            Inv1Spell2.Left = centroCampeon - saltoHechizo * 2 - Inv1Spell1.Size.Width;
            TextInv1Spell2.Left = centroCampeon - saltoHechizo * 2 - Inv1Spell1.Size.Width;
            Inv1Spell1.Left = centroCampeon - Inv1Spell1.Size.Width * 2 - saltoHechizo * 2;
            TextInv1Spell1.Left = centroCampeon - Inv1Spell1.Size.Width * 2 - saltoHechizo * 2;
        }

        int _1Spell1 = 0;
        int _1Spell2 = 0;
        int _2Spell1 = 0;
        int _2Spell2 = 0;
        int _3Spell1 = 0;
        int _3Spell2 = 0;
        int _4Spell1 = 0;
        int _4Spell2 = 0;
        int _5Spell1 = 0;
        int _5Spell2 = 0;

        // Timers.
        private void Inv1Spell1_Click(object sender, EventArgs e) { if (!TimerInv1Spell1.Enabled) { TimerInv1Spell1.Start(); } else { TimerInv1Spell1.Stop(); TextInv1Spell1.Visible = false; _1Spell1 = 0; } }
        private void Inv1Spell2_Click(object sender, EventArgs e) { if (!TimerInv1Spell2.Enabled) { TimerInv1Spell2.Start(); } else { TimerInv1Spell2.Stop(); TextInv1Spell2.Visible = false; _1Spell2 = 0; } }
        private void Inv2Spell1_Click(object sender, EventArgs e) { if (!TimerInv2Spell1.Enabled) { TimerInv2Spell1.Start(); } else { TimerInv2Spell1.Stop(); TextInv2Spell1.Visible = false; _2Spell1 = 0; } }
        private void Inv2Spell2_Click(object sender, EventArgs e) { if (!TimerInv2Spell2.Enabled) { TimerInv2Spell2.Start(); } else { TimerInv2Spell2.Stop(); TextInv2Spell2.Visible = false; _2Spell2 = 0; } }
        private void Inv3Spell1_Click(object sender, EventArgs e) { if (!TimerInv3Spell1.Enabled) { TimerInv3Spell1.Start(); } else { TimerInv3Spell1.Stop(); TextInv3Spell1.Visible = false; _3Spell1 = 0; } }
        private void Inv3Spell2_Click(object sender, EventArgs e) { if (!TimerInv3Spell2.Enabled) { TimerInv3Spell2.Start(); } else { TimerInv3Spell2.Stop(); TextInv3Spell2.Visible = false; _3Spell2 = 0; } }
        private void Inv4Spell1_Click(object sender, EventArgs e) { if (!TimerInv4Spell1.Enabled) { TimerInv4Spell1.Start(); } else { TimerInv4Spell1.Stop(); TextInv4Spell1.Visible = false; _4Spell1 = 0; } }
        private void Inv4Spell2_Click(object sender, EventArgs e) { if (!TimerInv4Spell2.Enabled) { TimerInv4Spell2.Start(); } else { TimerInv4Spell2.Stop(); TextInv4Spell2.Visible = false; _4Spell2 = 0; } }
        private void Inv5Spell1_Click(object sender, EventArgs e) { if (!TimerInv5Spell1.Enabled) { TimerInv5Spell1.Start(); } else { TimerInv5Spell1.Stop(); TextInv5Spell1.Visible = false; _5Spell1 = 0; } }
        private void Inv5Spell2_Click(object sender, EventArgs e) { if (!TimerInv5Spell2.Enabled) { TimerInv5Spell2.Start(); } else { TimerInv5Spell2.Stop(); TextInv5Spell2.Visible = false; _5Spell2 = 0; } }


 

        private void TimerInv1Spell1_Tick(object sender, EventArgs e)
        {
            TextInv1Spell1.Visible = true;
            TextInv1Spell1.Text = SharkiQuerys.Hechizos[0].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[0].CooldownBurn) - _1Spell1 <= 0)
            {
                TimerInv1Spell1.Stop();
                TextInv1Spell1.Visible = false;
                _1Spell1 = 0;
            }
            else
            {
                _1Spell1++;
                TextInv1Spell1.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[0].CooldownBurn) - _1Spell1).ToString());
            }
        }

        private void TimerInv1Spell2_Tick(object sender, EventArgs e)
        {
            TextInv1Spell2.Visible = true;
            TextInv1Spell2.Text = SharkiQuerys.Hechizos[1].CooldownBurn;
            if ((Convert.ToInt32(SharkiQuerys.Hechizos[1].CooldownBurn) - _1Spell2) <= 0)
            {
                TimerInv1Spell2.Stop();
                TextInv1Spell2.Visible = false;
                _1Spell2 = 0;
                
            }
            else
            {
                _1Spell2++;
                TextInv1Spell2.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[1].CooldownBurn) - _1Spell2).ToString());
            }
        }

        private void TimerInv2Spell1_Tick(object sender, EventArgs e)
        {
            TextInv2Spell1.Visible = true;
            TextInv2Spell1.Text = SharkiQuerys.Hechizos[2].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[2].CooldownBurn) - _2Spell1 <= 0)
            {
                TimerInv2Spell1.Stop();
                TextInv2Spell1.Visible = false;
                _2Spell1 = 0;
            }
            else
            {
                _2Spell1++;
                TextInv2Spell1.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[2].CooldownBurn) - _2Spell1).ToString());
            }
        }

        private void TimerInv2Spell2_Tick(object sender, EventArgs e)
        {
            TextInv2Spell2.Visible = true;
            TextInv2Spell2.Text = SharkiQuerys.Hechizos[3].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[3].CooldownBurn) - _2Spell2 <= 0)
            {
                TimerInv2Spell2.Stop();
                TextInv2Spell2.Visible = false;
                _2Spell2 = 0;
            }
            else
            {
                _2Spell2++;
                TextInv2Spell2.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[3].CooldownBurn) - _2Spell2).ToString());
            }
        }

        private void TimerInv3Spell1_Tick(object sender, EventArgs e)
        {
            TextInv3Spell1.Visible = true;
            TextInv3Spell1.Text = SharkiQuerys.Hechizos[4].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[4].CooldownBurn) - _3Spell1 <= 0)
            {
                TimerInv3Spell1.Stop();
                TextInv3Spell1.Visible = false;
                _3Spell1 = 0;
            }
            else
            {
                _3Spell1++;
                TextInv3Spell1.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[4].CooldownBurn) - _3Spell1).ToString());
            }
        }

        private void TimerInv3Spell2_Tick(object sender, EventArgs e)
        {
            TextInv3Spell2.Visible = true;
            TextInv3Spell2.Text = SharkiQuerys.Hechizos[5].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[5].CooldownBurn) - _3Spell2 <= 0)
            {
                TimerInv3Spell2.Stop();
                TextInv3Spell2.Visible = false;
                _3Spell2 = 0;
            }
            else
            {
                _3Spell2++;
                TextInv3Spell2.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[5].CooldownBurn) - _3Spell2).ToString());
            }
        }

        private void TimerInv4Spell1_Tick(object sender, EventArgs e)
        {
            TextInv4Spell1.Visible = true;
            TextInv4Spell1.Text = SharkiQuerys.Hechizos[6].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[6].CooldownBurn) - _4Spell1 <= 0)
            {
                TimerInv4Spell1.Stop();
                TextInv4Spell1.Visible = false;
                _4Spell1 = 0;
            }
            else
            {
                _4Spell1++;
                TextInv4Spell1.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[6].CooldownBurn) - _4Spell1).ToString());
            }
        }

        private void TimerInv4Spell2_Tick(object sender, EventArgs e)
        {
            TextInv4Spell2.Visible = true;
            TextInv4Spell2.Text = SharkiQuerys.Hechizos[7].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[7].CooldownBurn) - _4Spell2 <= 0)
            {
                TimerInv4Spell2.Stop();
                TextInv4Spell2.Visible = false;
                _4Spell2 = 0;
            }
            else
            {
                _4Spell2++;
                TextInv4Spell2.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[7].CooldownBurn) - _4Spell2).ToString());
            }
        }

        private void TimerInv5Spell1_Tick(object sender, EventArgs e)
        {
            TextInv5Spell1.Visible = true;
            TextInv5Spell1.Text = SharkiQuerys.Hechizos[8].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[8].CooldownBurn) - _5Spell1 <= 0)
            {
                TimerInv5Spell1.Stop();
                TextInv5Spell1.Visible = false;
                _5Spell1 = 0;
            }
            else
            {
                _5Spell1++;
                TextInv5Spell1.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[8].CooldownBurn) - _5Spell1).ToString());
            }
        }

        private void TimerInv5Spell2_Tick(object sender, EventArgs e)
        {
            TextInv5Spell2.Visible = true;
            TextInv5Spell2.Text = SharkiQuerys.Hechizos[9].CooldownBurn;
            if (Convert.ToInt32(SharkiQuerys.Hechizos[9].CooldownBurn) - _5Spell2 <= 0)
            {
                TimerInv5Spell2.Stop();
                TextInv5Spell2.Visible = false;
                _5Spell2 = 0;
            }
            else
            {
                _5Spell2++;
                TextInv5Spell2.Text = ((Convert.ToInt32(SharkiQuerys.Hechizos[9].CooldownBurn) - _5Spell2).ToString());
            }
        }

        private void PreguntarSiActivo_Tick(object sender, EventArgs e)
        {
            PreguntarSiActivo.Interval = 5000;
            Process[] LoL = Process.GetProcessesByName("League of Legends");

            if (LoL.Length > 0) {
                
                SharkiQuerys.Obtener_Enemigos();

                if (!String.IsNullOrEmpty(SharkiQuerys._controlar_excepcion))
                {
                    PreguntarSiActivo.Stop();
                    MessageBox.Show("Es probable que el nombre de invocador introducido no coincida con el nombre de invocador de la " +
                        "partida o que el modo de juego en el que se está jugando actualmente no esté implementado. ",
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    SharkiQuerys._controlar_excepcion = "";
                    this.Close();
                    Ventana.Show();
                    return;
                }
                else
                {

                    for (int i = 0; i < ImagenCampeon.Count(); i++)
                    {
                        ImagenCampeon[i].ImageLocation = "http://opgg-static.akamaized.net/images/lol/champion/"
                            + SharkiQuerys.Enemigos[i].Image.Full;
                    }

                    for (int j = 0; j < ImagenHechizos.Count(); j++)
                    {
                        ImagenHechizos[j].ImageLocation = "http://ddragon.leagueoflegends.com/cdn/6.24.1/img/spell/"
                              + SharkiQuerys.Hechizos[j].Image.Full;
                    }
                    
                }

                this.Show();
                PreguntarSiActivo.Stop();
                PreguntarSiNOactivo.Start();
            } 
      

        }

        private void PreguntarSiNOactivo_Tick(object sender, EventArgs e)
        {
            PreguntarSiNOactivo.Interval = 5000;
            Process[] LoL = Process.GetProcessesByName("League of Legends");
            
            if(LoL.Length < 1)
            {
                this.Hide();
                // Arrays remove
                SharkiQuerys.Hechizos.RemoveRange(0, SharkiQuerys.Hechizos.Count - 1);
                SharkiQuerys.Enemigos.RemoveRange(0, SharkiQuerys.Enemigos.Count - 1);



                PreguntarSiActivo.Start();
                PreguntarSiNOactivo.Stop();
            }
        }

        // Fin timers.

    }
}
