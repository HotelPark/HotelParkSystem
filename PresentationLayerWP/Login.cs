using BLL;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayerWP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void logarbtn_Click(object sender, EventArgs e)
        {
            FuncionarioBLL bll = new FuncionarioBLL();
            Response r = bll.Autenticate(emailtxt.Text, senhatxt.Text);
            if (r.Success)
            {
                MainForm frm = new MainForm();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show(r.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.emailtxt.Text = "rafaelzinho@hotmail.com";
            this.senhatxt.Text = "123";
        }
    }
}
