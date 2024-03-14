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
    public partial class AddNewRoom : Form
    {
        hostelEntities1 hE = new hostelEntities1();

        #region methods
        void LoadData()
        {
            var result = from c in hE.rooms
                         select new
                         {
                             RoomNo = c.roomNo,
                             RoomType = c.RoomType,
                             AmountBed = c.AmountBeds,
                             Equipment = c.Equipments,
                             Booked = c.Booked,
                             RoomStatus = c.roomStatus == "Yes" ? "Yes" : "No"
                         };
            DataGridView1.DataSource = result.ToList();
        }
        
        void Add()
        {
            String status;
            if (CheckBox1.Checked)
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }

            string roomNo = txtRoomNo1.Text;
            room existingRoom = hE.rooms.FirstOrDefault(r => r.roomNo.ToString() == roomNo);
            hE.rooms.Add(new room()
            {
                roomNo = int.Parse(roomNo),
                roomStatus = status,
                RoomType = txtTypeRoom1.Text,
                AmountBeds = int.Parse(txtAmountBed1.Text),
                Equipments = txtEquipment1.Text,
                Booked = "No"
            });
            hE.SaveChanges();
            LoadData();
        }

        void Update()
        {
            String status;
            if (CheckBox2.Checked)
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }
            string id = txtRoomNo2.Text;
            Int64 roomNo = Int64.Parse(id);
            room r = hE.rooms.Find(roomNo);
            if (r != null)
            {
                r.roomNo = Int64.Parse(txtRoomNo2.Text);
                r.roomStatus = status;
                r.RoomType = txtTypeRoom2.Text;
                r.AmountBeds = int.Parse(txtAmountBed2.Text);
                r.Equipments = txtEquipment2.Text;
                hE.SaveChanges();
                LoadData();
            }
        }

        void Search()
        {
            string roomNo = txtRoomNo2.Text;
            int roomNumber;
            if (int.TryParse(roomNo, out roomNumber))
            {
                room r = hE.rooms.Find(roomNumber);
                if (r != null)
                {
                    txtTypeRoom2.Text = r.RoomType;
                    txtAmountBed2.Text = r.AmountBeds.ToString();
                    txtEquipment2.Text = r.Equipments;

                    if (r.roomStatus == "Yes")
                    {
                        CheckBox2.Checked = true;
                    }
                    else
                    {
                        CheckBox2.Checked = false;
                    }

                    labelRooms.Text = "Phòng này đã tìm thấy";
                    labelRooms.Visible = true;
                }
                else
                {
                    labelRooms.Text = "Phòng này không tồn tại";
                    labelRooms.Visible = true;
                    CheckBox2.Checked = false;

                    txtTypeRoom2.Text = "";
                    txtAmountBed2.Text = "";
                    txtEquipment2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Số phòng không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        void Delete()
        {
            if (labelRooms.Text == "Phòng này đã tìm thấy")
            {
                string roomNo = txtRoomNo2.Text;
                Int64 roomNumber;
                if (Int64.TryParse(roomNo, out roomNumber))
                {
                    room r = hE.rooms.Find(roomNumber);
                    if (r != null)
                    {
                        hE.rooms.Remove(r);
                        hE.SaveChanges();

                        MessageBox.Show("Đã xóa phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa phòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Số phòng không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hãy tìm kiếm phòng trước khi xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        public AddNewRoom()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(405, 118);
            labelRooms.Visible = false;
            labelRoomExist.Visible = false;
            LoadData();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomNo1.Text))
            {
                MessageBox.Show("Bạn chưa nhập số phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtAmountBed1.Text))
            {
                MessageBox.Show("Bạn chưa nhập số giường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtTypeRoom1.Text))
            {
                MessageBox.Show("Bạn chưa nhập loại phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtEquipment1.Text))
            {
                MessageBox.Show("Bạn chưa nhập trang thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string roomNo = txtRoomNo1.Text;
                room existingRoom = hE.rooms.FirstOrDefault(r => r.roomNo.ToString() == roomNo);

                if (existingRoom != null)
                {
                    labelRoomExist.Text = "Phòng đã có";
                    labelRoomExist.Visible = true;
                }
                else
                {
                    Add();
                    MessageBox.Show("Thêm phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomNo2.Text))
            {
                MessageBox.Show("Bạn chưa chọn số phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Search();       
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
