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
    public partial class StudentLeaved : Form
    {
        hostelEntities1 hE = new hostelEntities1();

        public StudentLeaved()
        {
            InitializeComponent();
        }

        private void StudentLeaved_Load(object sender, EventArgs e)
        {
            this.Location = new Point(405, 118);
            var result = from ns in hE.newStudents
                         join r in hE.rooms on ns.roomNo equals r.roomNo
                         where ns.living == "No"
                         select new
                         {
                             ns.mobile,
                             ns.name,
                             ns.fname,
                             ns.mname,
                             ns.email,
                             ns.paddress,
                             ns.college,
                             ns.idproof,
                             ns.roomNo,
                             r.RoomType,
                             ns.living
                         };
            guna2DataGridView1.DataSource = result.ToList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}