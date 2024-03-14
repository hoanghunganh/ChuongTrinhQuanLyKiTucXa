using System;
using System.Collections;
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
    public partial class PayFees : Form
    {
        hostelEntities1 hE = new hostelEntities1();

        public PayFees()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setDataGrid(Int64 mobile)
        {
            var query = from f in hE.fees
                        where f.id == mobile
                        select f;

            guna2DataGridView1.DataSource = query.ToList();
        }

        private void ClearAll()
        {
            txtPhone.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtRoomNo.Clear();
            guna2DataGridView1.DataSource = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text != "" && Int64.TryParse(txtPhone.Text, out Int64 parsedMobile))
            {
                var query = from s in hE.newStudents
                            where s.mobile == parsedMobile
                            select s;

                var student = query.FirstOrDefault();

                if (student != null)
                {
                    txtName.Text = student.name;
                    txtEmail.Text = student.email;
                    txtRoomNo.Text = student.roomNo.ToString();
                    setDataGrid(Int64.Parse(txtPhone.Text));
                }
                else
                {
                    MessageBox.Show("Hồ sơ này không tồn tại!", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PayFees_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text != "" && Int64.TryParse(txtPhone.Text, out Int64 parsedMobile))
            {
                var query = from f in hE.fees
                            where f.id == parsedMobile
                            select f;

                var fees = query.FirstOrDefault();

                if (fees != null)
                {
                    hE.fees.Remove(fees);
                    hE.SaveChanges();
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi phí phát sinh của tháng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}