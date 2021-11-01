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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        ConexionDB conexion = new ConexionDB();
        Clientes clientes = new Clientes();

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            clientes.Nombre = NombreTextBox.Text;
            clientes.NumIdentidad = Convert.ToInt32(NumIdentidadTextBox.Text);
            clientes.Direccion = DireccionTextBox.Text;

            bool inserto = conexion.InsertarClientes(clientes);

            if (inserto)
            {
                MessageBox.Show("Cliente Registrado");

                NombreTextBox.Text = "";
                NumIdentidadTextBox.Clear();
                DireccionTextBox.Text = string.Empty;
                clientes = null;
            }
            else
            {
                MessageBox.Show("No se registró cliente.");
            }

        }
    }
}
