using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKiTucXa
{

    public partial class SignUpRent : Form
    {
        hostelEntities1 hE = new hostelEntities1();

        public SignUpRent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearAll()
        {
            txtStudentName.Clear();
            txtPhone.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtCollege.Clear();
            txtCCCD.Clear();
            comboRoomNo.SelectedIndex = -1;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (txtPhone.Text != "" && txtStudentName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmail.Text != "" && txtAddress.Text != "" && txtCollege.Text != "" && txtCCCD.Text != "" && comboRoomNo.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtPhone.Text);
                String name = txtStudentName.Text;
                String fname = txtFather.Text;
                String mname = txtMother.Text;
                String email = txtEmail.Text;
                String address = txtAddress.Text;
                String college = txtCollege.Text;
                String ccCD = txtCCCD.Text;
                Int64 roomNo = Int64.Parse(comboRoomNo.Text);

                using (var context = new hostelEntities1())
                {
                    var student = new newStudent()
                    {
                        mobile = mobile,
                        name = name,
                        fname = fname,
                        mname = mname,
                        email = email,
                        paddress = address,
                        college = college,
                        idproof = ccCD,
                        roomNo = roomNo
                    };

                    context.newStudents.Add(student);
                    var room = context.rooms.FirstOrDefault(r => r.roomNo == roomNo && r.Booked == "No");

                    if (room != null)
                    {
                        room.Booked = "Yes";
                    }

                    context.SaveChanges();
                }

                MessageBox.Show("Đăng kí thành công", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void SignUpRent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(405, 118);

            using (var context = new hostelEntities1())
            {
                var availableRooms = context.rooms.Where(r => r.roomStatus == "Yes" && r.Booked == "No").Select(r => r.roomNo).ToList();

                comboRoomNo.DataSource = availableRooms;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
