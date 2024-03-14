using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKiTucXa
{
    public partial class DNSV : Form
    {
        public DNSV()
        {
            InitializeComponent();
        }

        private void txtChangeLoginSV_Click(object sender, EventArgs e)
        {
            DNADMIN dNADMIN = new DNADMIN();
            dNADMIN.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoginSV_Click(object sender, EventArgs e)
        {
            if (txtUsernameSV.Text == "2" && txtPasswordSV.Text == "2")
            {
                DashBoardSV dashBoardSV = new DashBoardSV();
                dashBoardSV.Show();
                this.Hide();
            }
        }
    }
}
