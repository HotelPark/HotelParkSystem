using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayerWP
{
    public partial class MainForm : Form
    {
        Customer cadastrocliente = new Customer();
        Supplier cadastrofornecedor = new Supplier();
        Employee cadastrofuncionarios = new Employee();
        Room roomregisterform = new Room();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btncustomerregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            cadastrocliente.ShowDialog();
            this.Show();
        }

        private void btnsupplierregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            cadastrofornecedor.ShowDialog();
            this.Show();
        }

        private void btnemployeeregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            cadastrofuncionarios.ShowDialog();
            this.Show();
        }

        private void btnroomregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            roomregisterform.ShowDialog();
            this.Show();
        }
    }
}
