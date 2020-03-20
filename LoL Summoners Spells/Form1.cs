using LoL_Summoners_Spells.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoL_Summoners_Spells
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Servidor.DataSource = Enum.GetValues(typeof(RiotSharp.Misc.Region)).Cast<RiotSharp.Misc.Region>().Where(region => 10 >= (int)region).ToList();
            Servidor.SelectedIndex = 2;
            
            NombreInvocador.Text = Settings.Default["Invocador"].ToString();
            ApiKey.Text = Settings.Default["Key"].ToString();

        }

        // ## ------------------ Permitir mover la ventana a través de los eventos del objeto (PANEL) ------------------ ## //

        private bool mouseDown;
        private Point lastLocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        // ## ------------------ Permitir mover la ventana a través de los eventos del objeto (PANEL) ------------------ ## //

        // ## ---- Cerrar aplicación y efecto fade out --- #
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FadeOut.Start();
        }

        bool hide = false;
        private void FadeOut_Tick(object sender, EventArgs e)
        {

            if (this.Opacity > 0)
            {
                this.Opacity = this.Opacity - 0.050;
            }
            else
            {
                if (!hide) { FadeOut.Stop(); Application.Exit(); }
                else { hide = false;  FadeOut.Stop(); this.Hide(); }
                 
            }
        }

        // ## ---- Cerrar aplicación y efecto fade out --- #


        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NombreInvocador.Text))
            {
                MessageBox.Show("No se ha introducido un nombre de invocador.",
               "Nombre de invocador necesario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrWhiteSpace(ApiKey.Text))
            {
                MessageBox.Show("Necesitas insertar el Key API generado en la página oficial de Riot.",
                    "Key API necesaria.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Comprobar que la Key y el nombre de invocador funcionan => Dar acceso a la segunda ventana.
                if (SharkiQuerys.Comprobar_Conexion(ApiKey.Text, NombreInvocador.Text, 
                    (RiotSharp.Misc.Region)Enum.Parse(typeof(RiotSharp.Misc.Region), Servidor.SelectedValue.ToString())))
                {
                    // Abrir
                    Settings.Default["Invocador"] = NombreInvocador.Text;
                    Settings.Default["Key"] = ApiKey.Text;
                    Settings.Default.Save();

                    InGame Ventana = new InGame();
                    hide = true;
                    FadeOut.Start();

                   
                    Ventana.Show();
           
                }
                else
                {
                    MessageBox.Show("No es posible establecer la conexión, es probable que la API KEY" +
                      " introducida sea inválida, haya caducado o exista algún problema con el servidor.",
                           "API Key erronea.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/Sharki0");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void GetRiotApi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://developer.riotgames.com/");
        }

     
    }
}
