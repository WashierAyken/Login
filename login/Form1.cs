using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace login
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\isac_\Documents\login.accdb;Jet OLEDB:Database Password=admin");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = textUser.Text;
            string password = textPassword.Text;

            if (user == "" || password == "")
            {
                MessageBox.Show("Llena los campos para poder iniciar sesion");
                return;

            }

            connection.Open();
            string da = "select password, user FROM login where password = '" + textPassword.Text + "' and user = '" + textUser.Text + "';";
            OleDbCommand cmd = new OleDbCommand(da, connection);
            OleDbDataReader readdb;
            readdb = cmd.ExecuteReader();
            Boolean register = readdb.HasRows;

            if (register)
            {

                MessageBox.Show("Bienvenido pana " + textUser.Text + " Sexo");
                entrada logeo = new entrada();
                this.Hide();
                logeo.Show();

            }
            else
            {
                MessageBox.Show("Identificate CTM");
                return;

            }
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MessageBox.Show("Conectado pa");
                connection.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("No conectado pa" + a.ToString());
            }
        }
    }
}
