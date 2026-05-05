using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class AddColumnForm : Form
    {
        // Hàm này dùng để mớm tên cột cũ vào khi người dùng chọn "Chỉnh sửa"
        public void LoadOldData(string oldName)
        {
            txtColumnName.Text = oldName;
            this.Text = "Chỉnh sửa Tên cột"; // Đổi tiêu đề cửa sổ
            btnSave.Text = "Lưu thay đổi";     // Đổi chữ trên nút bấm
        }

        // Tạo 1 biến public để Form1 có thể đọc được tên cột sau khi form này đóng lại
        public string ColumnName { get; private set; }

        public AddColumnForm()
        {
            InitializeComponent();
        }
        // Nhấp đúp vào nút "Thêm cột" ở màn hình thiết kế để tạo sự kiện này
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColumnName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên cột!", "Thông báo");
                return;
            }

            // Bỏ tên cột vào biến
            ColumnName = txtColumnName.Text.Trim();

            // Báo hiệu là người dùng đã bấm OK và đóng Form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Nhấp đúp vào nút "Hủy"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
