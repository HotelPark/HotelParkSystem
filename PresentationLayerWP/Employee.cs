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
    public partial class Employee : Form
    {
        int id;
        public Employee()
        {
            InitializeComponent();
            SingleResponse<Usuario> response = funcionarioBLL.GetById(2);
            Usuario funcionario = response.Data;
        }
        UsuarioBLL funcionarioBLL = new UsuarioBLL();

        private void btnregister_Click(object sender, EventArgs e)
        {
            Usuario funcionario = new Usuario();
            funcionario.Nome = nometxt.Text;
            funcionario.CPF = cpftxt.Text;
            funcionario.RG = rgtxt.Text;
            funcionario.Email = emailtxt.Text;
            funcionario.Endereco = enderecotxt.Text;
            funcionario.Telefone = teltxt.Text;
            funcionario.Senha = senhatxt.Text;
            if (senhatxt.Text != senhatxt2.Text)
            {
                MessageBox.Show("Senhas não coincidem");
            }
            //funcionario.IsAdm = cbadm.Checked;

            Response response = funcionarioBLL.Insert(funcionario);
            MessageBox.Show(response.Message);

            if (response.Success)
            {
                UpdateGridView();
            }
        }

        private void btnclearfields_Click(object sender, EventArgs e)
        {
            FormCleaner.Clear(this);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }
        private void Employee_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }
        private void UpdateGridView()
        {
            QueryResponse<Usuario> response = funcionarioBLL.GetAll();
            if (response.Success)
            {
                dgvemployee.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void dgvemployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Usuario funcionario = (Usuario).this.dgvemployee.SelectedRows[0].DataBoundItem;
            //this.nometxt.Text = funcionario.Nome;
            //this.cpftxt.Text = funcionario.CPF;
            //this.id = funcionario.ID;
        }
    }
}
