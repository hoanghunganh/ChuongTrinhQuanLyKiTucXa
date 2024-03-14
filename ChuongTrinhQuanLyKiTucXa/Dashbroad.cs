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
    public partial class Dashbroad : Form
    {
        public Dashbroad()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DNADMIN dNADMIN = new DNADMIN();
            dNADMIN.Show();
            this.Close();
        }

        private void btnManagerRooms_Click(object sender, EventArgs e)
        {
            AddNewRoom addNewRoom = new AddNewRoom();
            addNewRoom.Show();
        }

        private void btnUpdateDeleteStudent_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudent updateDeleteStudent = new UpdateDeleteStudent();
            updateDeleteStudent.Show();
        }

        private void btnPayFees_Click(object sender, EventArgs e)
        {
            StudentFees studentFees = new StudentFees();
            studentFees.Show();
        }

        private void btnAllStudents_Click(object sender, EventArgs e)
        {
            AllStudentLiving studentLiving = new AllStudentLiving();
            studentLiving.Show();
        }

        private void btnLeavedStudents_Click(object sender, EventArgs e)
        {
            StudentLeaved studentLeaved = new StudentLeaved();
            studentLeaved.Show();
        }

        private void Dashbroad_Load(object sender, EventArgs e)
        {

        }
    }
}
