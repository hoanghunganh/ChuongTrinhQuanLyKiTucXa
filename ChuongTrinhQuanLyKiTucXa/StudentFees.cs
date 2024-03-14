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

namespace ChuongTrinhQuanLyKiTucXa
{
    public partial class StudentFees : Form
    {
        hostelEntities1 hE = new hostelEntities1();

        public StudentFees()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentFees_Load(object sender, EventArgs e)
        {
            DateTime.Format = DateTimePickerFormat.Custom;
            DateTime.CustomFormat = "MMMM yyyy";
        }

        public void setDataGrid(int mobile)
        {
            var query = from f in hE.fees
                        where f.id == mobile
                        select f;

            guna2DataGridView1.DataSource = query.ToList();
        }

        private void ClearAll()
        {
            txtId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtRoomNo.Clear();
            txtRoomPrice.Clear();
            txtElecPrice.Clear();
            txtNetPrice.Clear();
            guna2DataGridView1.DataSource = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                int mobile = int.Parse(txtId.Text);

                var query = from s in hE.newStudents
                            where s.mobile == mobile
                            select new { s.name, s.email, s.roomNo };

                var result = query.FirstOrDefault();

                if (result != null)
                {
                    txtName.Text = result.name;
                    txtEmail.Text = result.email;
                    txtRoomNo.Text = result.roomNo.ToString();
                    setDataGrid(mobile);
                }
                else
                {
                    MessageBox.Show("Hồ sơ này không tồn tại!", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtRoomPrice.Text != "" && txtElecPrice.Text != "" && txtNetPrice.Text != "")
            {
                int mobile = int.Parse(txtId.Text);
                string month = DateTime.Text;
                float roomPrice = float.Parse(txtRoomPrice.Text);
                float ePrice = float.Parse(txtElecPrice.Text);
                float nPrice = float.Parse(txtNetPrice.Text);

                var query = from f in hE.fees
                            where f.id == mobile && f.fmonth == month
                            select f;

                if (query.FirstOrDefault() == null)
                {
                    hE.fees.Add(new fee()
                    {
                        id = mobile,
                        fmonth = month,
                        RoomPrice = roomPrice,
                        ElectricPrice = ePrice,
                        NetPrice = nPrice
                    });

                    hE.SaveChanges();

                    MessageBox.Show("Thêm thành công", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Không có lệ phí của " + DateTime.Text + " còn lại.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}