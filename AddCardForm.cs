using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrelloApp;

namespace WindowsFormsApp3
{
    public partial class AddCardForm : Form
    {
        // Biến chứa toàn bộ dữ liệu thẻ mới tạo
        public TrelloCard NewCard { get; private set; }

        public AddCardForm()
        {
            InitializeComponent();
        }

       
        public void LoadOldData(string oldTitle, string oldMember, int oldChecked = 0, int oldTotal = 0, string oldLabel = "", string oldColorHex = "#0079BF", string oldLink = "")
        {
            txtTitle.Text = oldTitle;
            txtMember.Text = oldMember;

            // Nhận lại thông số Checklist
            nudCheckedItems.Value = oldChecked;
            nudTotalItems.Value = oldTotal;

            // Nhận lại Nhãn và Màu
            txtLabelText.Text = oldLabel;
            cboColor.Text = GetColorNameFromHex(oldColorHex);

            // Nhận lại Link
            txtLink.Text = oldLink;

            this.Text = "Chỉnh sửa Thẻ";
            btnSave.Text = "Lưu thay đổi";
        }

      
        private string GetColorNameFromHex(string hex)
        {
            if (string.IsNullOrEmpty(hex)) return "Xanh dương";
            switch (hex.ToUpper())
            {
                case "#EB5A46": return "Đỏ";
                case "#FF9F1A": return "Cam";
                case "#F2D600": return "Vàng";
                case "#61BD4F": return "Xanh lá";
                case "#0079BF": return "Xanh dương";
                case "#C377E0": return "Tím";
                case "#B3BAC5": return "Xám";
                default: return "Xanh dương";
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề thẻ!", "Thông báo");
                return;
            }

            // Lấy số liệu Checklist
            int checkedItems = (int)nudCheckedItems.Value;
            int totalItems = (int)nudTotalItems.Value;

            if (checkedItems > totalItems && totalItems > 0)
            {
                MessageBox.Show("Số mục đã xong không thể lớn hơn Tổng số mục!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã màu (Đã thêm .Trim() để dọn sạch khoảng trắng thừa tránh lỗi mất màu)
            string labelColor = "#0079BF";
            switch (cboColor.Text.Trim())
            {
                case "Đỏ": labelColor = "#EB5A46"; break;
                case "Cam": labelColor = "#FF9F1A"; break;
                case "Vàng": labelColor = "#F2D600"; break;
                case "Xanh lá": labelColor = "#61BD4F"; break;
                case "Xanh dương": labelColor = "#0079BF"; break;
                case "Tím": labelColor = "#C377E0"; break;
                case "Xám": labelColor = "#B3BAC5"; break;
            }

            // Đóng gói dữ liệu vào biến NewCard để gửi ra ngoài
            NewCard = new TrelloCard(
                title: txtTitle.Text.Trim(),
                label: txtLabelText.Text.Trim(),
                labelColor: labelColor,
                member: string.IsNullOrWhiteSpace(txtMember.Text) ? "Thành viên" : txtMember.Text.Trim(),
                checkedItems: checkedItems,
                totalItems: totalItems,
                link: txtLink.Text.Trim()
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddCardForm_Load(object sender, EventArgs e)
        {

        }
    }
}