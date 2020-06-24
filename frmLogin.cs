using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Khach_San.TRUY_VAN;
using Quan_Ly_Khach_San.GIAO_DIEN;

namespace Quan_Ly_Khach_San
{
    public partial class frmLogin : Form
    {
        private TaiKhoanF tk = new TaiKhoanF();
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Properties.Settings.Default.user;
        }
          

        //private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter) btn_DangNhap_Click(null, null);
        //}

        //private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter) btn_DangNhap_Click(null, null);
        //}


        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMK.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string pass = tk.LayPass(txtUsername.Text); //tìm mật khẩu cho chuỗi ở trong ô user
            if (pass != "")
            {
                if (txtPassword.Text == pass)//nếu mật khẩu ở ô pass trùng với chuỗi mật khẩu vừa tìm
                {
                    frmMain._taikhoan = txtUsername.Text; //biến tài khoản ở form main sẽ có tên 
                    Properties.Settings.Default.user = txtUsername.Text;//thuộc tính trong lớp này có tên
                    Properties.Settings.Default.Save();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai Mã nhân viên hoặc mật khẩu.");
                }
            }
            else
            {
                MessageBox.Show("Sai Mã nhân viên hoặc mật khẩu.");
            }
        }
    }
}
