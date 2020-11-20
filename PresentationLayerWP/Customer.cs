using BLL;
using Common;
using Entities;
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
    public partial class Customer : Form
    {
        int id;

        public Customer()
        {
            InitializeComponent();
            SingleResponse<Cliente> response = clienteBLL.GetById(2);
            Cliente cliente = response.Data;
        }

        ClienteBLL clienteBLL = new ClienteBLL();

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = txtnome.Text;
            cliente.CPF = txtcpf.Text;
            cliente.RG = txtrg.Text;
            cliente.Telefone_1 = txttelefone1.Text;
            cliente.Telefone_2 = txttelefone2.Text;
            cliente.Email = txtemail.Text;
            cliente.Endereco = txtendereco.Text;
            cliente.Especial = cbespecial.Checked;

            Response response = clienteBLL.Insert(cliente);
            MessageBox.Show(response.Message);

            if (response.Success)
            {
                UpdateGridView();
            }
        }
        private void UpdateGridView()
        {
            QueryResponse<Cliente> response = clienteBLL.GetAll();
            if (response.Success)
            {
                dgvClientes.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }   

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            FormCleaner.Clear(this);
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente cliente = (Cliente)this.dgvClientes.SelectedRows[0].DataBoundItem;
            this.txttelefone1.Text = cliente.Telefone_1;
            this.txttelefone2.Text = cliente.Telefone_2;
            this.txtcpf.Text = cliente.CPF;
            this.txtemail.Text = cliente.Email;
            this.txtendereco.Text = cliente.Endereco;
            this.txtnome.Text = cliente.Nome;
            this.txtrg.Text = cliente.RG;
            this.id = cliente.ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
          
            cliente.ID = id;
        }
    }
}
