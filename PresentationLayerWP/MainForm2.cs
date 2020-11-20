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
    public partial class MainForm2 : Form
    {
        public MainForm2()
        {
            InitializeComponent();
        }
        Clientes cliente = new Clientes();
        private void MainForm2_Load(object sender, EventArgs e)
        {

        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnclientes.Height;

        }

        private void btnfornecedores_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnfornecedores.Height;
        }

        private void btnprodutos_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnprodutos.Height;
        }

        private void btnquartos_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnquartos.Height;
        }

        private void btnusuarios_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnusuarios.Height;
        }
    }
}
