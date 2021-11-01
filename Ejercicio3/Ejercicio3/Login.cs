using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ejercicio3.ConexionBD;


namespace Ejercicio3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        ConexionDB conexion = new ConexionDB();
        Usuario usuario = new Usuario();
        private void AceptarButton_Click(object sender, EventArgs e)
        {


            if (CorreoTextBox.Text == "")
            {
                errorProvider1.SetError(CorreoTextBox, "Ingrese Usuario");
                CorreoTextBox.Focus();
                return;
            }
            if (ContraseniaTextBox.Text == "")
            {
                errorProvider1.SetError(ContraseniaTextBox, "Ingrese Contraseña");
                ContraseniaTextBox.Focus();
                return;
            }



            usuario.Correo = CorreoTextBox.Text;
            usuario.Clave = ContraseniaTextBox.Text;

            bool valido = conexion.ValidarUsuario(usuario);

            if (valido)
            {
                Cliente formulario = new Cliente();
                this.Hide();
                formulario.Show();

                //MessageBox.Show("Usuario Correcto.");
            }
            else
            {
                MessageBox.Show("Datos de Usuario Incorrecto.");
            }


        }
    }
}
