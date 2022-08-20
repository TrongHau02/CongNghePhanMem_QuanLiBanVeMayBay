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

namespace QuanLiBanVeMayBay
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult retThoat = MessageBox.Show("Bạn thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (retThoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ConnectData dt = new ConnectData();
            dt.Connect();
            string sql = "Select * from NHANVIEN where manv = '" + txtTaiKhoan.Text 
                + "' and matkhau = '" + txtMatKhau.Text + " ' ";
            SqlCommand com = new SqlCommand(sql, dt.conn);
            SqlDataReader reader = com.ExecuteReader();
            if(reader.Read() == false)
            {
                MessageBox.Show("Đăng nhập không thành công !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
                txtTaiKhoan.Focus();
            }
            else
            {
                this.Hide();
                frmMain main = new frmMain();
                main.Show();
            }
            dt.Disconnect();
        }
    }
}
