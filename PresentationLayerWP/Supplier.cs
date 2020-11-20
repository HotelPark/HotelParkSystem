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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
            SingleResponse<Fornecedor> response = fornecedorBLL.GetById(2);
            Fornecedor fornecedor = response.Data;
        }

        FornecedorBLL fornecedorBLL = new FornecedorBLL();

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Razao_Social = txtnome.Text;
            fornecedor.CNPJ = txtcnpj.Text;
            fornecedor.Email = txtemail.Text;
            fornecedor.Telefone = txttel1.Text;
            //fornecedor.TipoServico = txtrazaosocial.Text;

            Response response = fornecedorBLL.Insert(fornecedor);
            MessageBox.Show(response.Message);

            if (response.Success)
            {
                //Só atualiza a grid se o insert funcionou.
                UpdateGridView();
            }
        }
        private void UpdateGridView()
        {
            QueryResponse<Fornecedor> response = fornecedorBLL.GetAll();
            if (response.Success)
            {
                dgvClientes.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void CadastroFornecedor_Load(object sender, EventArgs e)
        {
            UpdateGridView();
            this.txtnome.Text = "ProWay";
            this.txtcnpj.Text = "00799308000149";
            this.txtemail.Text = "proway@gmail.com";
            this.txttel1.Text = "123456789";
            this.txtrazaosocial.Text = "Ensino";
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            FormCleaner.Clear(this);
        }
    }
}
