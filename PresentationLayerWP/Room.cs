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
    public partial class Room : Form
    {
        public Room()
        {
            InitializeComponent();
            SingleResponse<Quarto> response = roomBLL.GetById(2);
            Quarto quarto = response.Data;
        }

        RoomBLL roomBLL = new RoomBLL();

        private void btncleanfields_Click(object sender, EventArgs e)
        {
            FormCleaner.Clear(this);
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            Quarto quarto = new Quarto();
            quarto.ValorBase = Convert.ToDouble(txtroombaseprice.Text);
            quarto.NumQuarto = txtroomnumber.Text;

            Response response = roomBLL.Insert(quarto);
            MessageBox.Show(response.Message);

            if (response.Success)
            {
                UpdateGridView();
            }
        }

        private void UpdateGridView()
        {
            QueryResponse<Quarto> response = roomBLL.GetAll();
            if (response.Success)
            {
                dgvroom.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void RoomRegisterForm_Load(object sender, EventArgs e)
        {
            cbcategory.DataSource = Enum.GetNames(typeof(TipoQuartos.EnumCategoria));
            UpdateGridView();
        }
    }
}
