using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKiTucXa
{
    
    public partial class UpdateDeleteStudent : Form
    {
        hostelEntities1 hE = new hostelEntities1();
        public UpdateDeleteStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDeleteStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(405, 118);
        }

        private void ClearAll()
        {
            txtPhone.Clear();
            txtStudentName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtCollege.Clear();
            txtCCCD.Clear();
            txtRoomNo.Clear();
            txtRoomType.Clear();
            comboStatus.SelectedIndex = -1;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Int64 mobile = Int64.Parse(txtPhone.Text);
                var student = hE.newStudents.FirstOrDefault(s => s.mobile == mobile);

                if (student != null)
                {
                    txtStudentName.Text = student.name;
                    txtFather.Text = student.fname;
                    txtMother.Text = student.mname;
                    txtEmail.Text = student.email;
                    txtAddress.Text = student.paddress;
                    txtCollege.Text = student.college;
                    txtCCCD.Text = student.idproof;
                    txtRoomNo.Text = student.roomNo.ToString();
                    txtRoomType.Text = student.room.RoomType;
                    comboStatus.Text = student.living;
                }
                else
                {
                    ClearAll();
                    MessageBox.Show("Số điện thoại này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 mobile = Int64.Parse(txtPhone.Text);
            var student = hE.newStudents.FirstOrDefault(s => s.mobile == mobile);

            if (student != null)
            {
                student.name = txtStudentName.Text;
                student.fname = txtFather.Text;
                student.mname = txtMother.Text;
                student.email = txtEmail.Text;
                student.paddress = txtAddress.Text;
                student.college = txtCollege.Text;
                student.idproof = txtCCCD.Text;
                student.roomNo = Int64.Parse(txtRoomNo.Text);
                student.room.RoomType = txtRoomType.Text;
                student.living = comboStatus.Text;

                hE.SaveChanges();
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Int64 mobile = Int64.Parse(txtPhone.Text);
                var student = hE.newStudents.FirstOrDefault(s => s.mobile == mobile);

                if (student != null)
                {
                    hE.newStudents.Remove(student);
                    hE.SaveChanges();
                    ClearAll();
                    MessageBox.Show("Đã xóa hồ sơ sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
