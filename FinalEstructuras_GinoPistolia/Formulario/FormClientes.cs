using FinalEstructuras_GinoPistolia.Clases;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalEstructuras_GinoPistolia
{
    public partial class FormClientes : Form
    {
        ColaClientes clientes = new ColaClientes();
        public FormClientes()
        {
            InitializeComponent();
        }
        private void FormClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("DNI", "DNI");
            dgvClientes.Columns.Add("NombreCompleto", "Nombre y Apellido");
            Restaurar();
            Eliminado();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clientes.Agregar(txtDNI.Text, txtNombre.Text, txtApellido.Text);
            Backup();
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            MostrarClientes(clientes.devolverRegistros());
        }
        public void MostrarClientes(List<Cliente> listaclientes)
        {
            dgvClientes.Rows.Clear();
            foreach (Cliente cliente in listaclientes)
            {
                dgvClientes.Rows.Add(cliente.DNI, cliente.Nombre + " " + cliente.Apellido);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clientes.Inicio != null)
            {
                clientes.Eliminar();
                MostrarClientes(clientes.devolverRegistros());
            }
            else
            {
                MessageBox.Show("Por el momento no hay registro de clientes para eliminar");
            }
        }
        public void Eliminado()
        {
            if (clientes.Inicio != null)
            {
                Backup();
                clientes.Eliminar();
            }
            else MessageBox.Show("Por el momento no hay registro de clientes para eliminar");
        }
        public void Backup()
        {
            List<Cliente> listaClientes = clientes.devolverRegistros();
            List<string> lista = new List<string>();
            foreach (var cliente in listaClientes)
            {
                lista.Add($"{cliente.DNI};{cliente.Nombre};{cliente.Apellido}");
            }
            using (StreamWriter escribir = File.CreateText("backup.txt"))
                foreach (string registro in lista)
                {
                    escribir.WriteLine(registro);
                }
        }
        public void Restaurar()
        {
            if (!File.Exists("backup.txt")) return;
            clientes.Vaciar();
            StreamReader lector = new StreamReader("backup.txt");
            string linea;
            while ((linea = lector.ReadLine()) != null)
            {
                var campos = linea.Split(';');
                if (campos.Length < 3) continue;

                clientes.Agregar(campos[0].Trim(), campos[1].Trim(), campos[2].Trim());
            }
            lector.Close();
            MostrarClientes(clientes.devolverRegistros());
        }
    }
}




