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
    public partial class DashBoardSV : Form
    {
        public DashBoardSV()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DNSV dNSV = new DNSV();
            dNSV.Show();
            this.Close();
        }

        private void btnManagerRooms_Click(object sender, EventArgs e)
        {
            SignUpRent signUpRent = new SignUpRent();
            signUpRent.Show();
        }

        private void btnPayFees_Click(object sender, EventArgs e)
        {
            PayFees payFees = new PayFees();
            payFees.Show();
        }
    }
}
