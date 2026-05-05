using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrelloApp;

namespace WindowsFormsApp3
{
    public partial class TrelloCardControl : UserControl
    {
        // Biến lưu trữ dữ liệu gốc của thẻ này
        public TrelloCard CardData { get; private set; }

        // Tạo 2 kênh liên lạc (Event) để báo cáo ra Form chính
        public event EventHandler CardDeleted;
        public event EventHandler<TrelloCard> CardEdited;

        public TrelloCardControl()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            AttachHoverEvent(this);
        }

        private void AttachHoverEvent(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Name != "lblLabel" && c.Name != "pnlLabel")
                {
                    c.MouseEnter += TrelloCardControl_MouseEnter;
                    c.MouseLeave += TrelloCardControl_MouseLeave;
                }
            }
        }

        // HÀM SETDATA: CĂN LỀ, TÔ MÀU VÀ SẮP XẾP GIAO DIỆN CHUẨN TRELLO
        public void SetData(TrelloCard cardData)
        {
            this.CardData = cardData; // Lưu lại dữ liệu gốc
            // Link
            if (!string.IsNullOrWhiteSpace(cardData.Link))
            {
                lblLink.Visible = true;
                lblLink.Tag = cardData.Link;
                lblLink.Location = new Point(10, 110); // Nằm dưới cùng
            }
            else
            {
                lblLink.Visible = false;
            }

            // Nhãn và Màu
            if (!string.IsNullOrWhiteSpace(cardData.Label))
            {
                lblLabel.Text = cardData.Label;
                lblLabel.Visible = true;
                lblLabel.BringToFront();
                lblLabel.Location = new Point(10, 15);
                try
                {
                    Color cardColor = ColorTranslator.FromHtml(cardData.LabelColor);
                    pnlLabel.BackColor = cardColor;
                    lblLabel.BackColor = cardColor;
                }
                catch
                {
                    pnlLabel.BackColor = Color.Gray;
                    lblLabel.BackColor = Color.Gray;
                }
            }
            else
            {
                pnlLabel.Visible = false;
                lblLabel.Visible = false;
            }

            // Giấu các chữ tĩnh (label1, label2)
            if (label1 != null) label1.Visible = false;
            if (label2 != null) label2.Visible = false;

            // Tiêu đề
            lblTitle.Text = cardData.Title;
            lblTitle.Location = new Point(10, 48);
            lblTitle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);

            // Thành viên
            lblMember.Text = !string.IsNullOrWhiteSpace(cardData.Member) ? cardData.Member : "Thành viên";
            lblMember.Location = new Point(10, 80);
            lblMember.Visible = true;

            // Checklist (Căn lề phải cực chuẩn)
            if (cardData.TotalItems > 0)
            {
                lblChecklist.Text = $"☑ {cardData.CheckedItems}/{cardData.TotalItems}";
                lblChecklist.Visible = true;
                int rightX = this.Width - lblChecklist.Width - 10;
                lblChecklist.Location = new Point(rightX, 80);
            }
            else
            {
                lblChecklist.Visible = false;
            }
        }

        // VẼ BO GÓC VÀ NỀN THẺ
        private void TrelloCardControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (GraphicsPath path = MakeRounded(rect, 7))
            {
                g.FillPath(new SolidBrush(this.BackColor), path);
                g.DrawPath(new Pen(Color.FromArgb(200, 205, 215), 1), path);
            }
        }

        private void TrelloCardControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(235, 236, 240);
        }

        private void TrelloCardControl_MouseLeave(object sender, EventArgs e)
        {
            Point mousePos = this.PointToClient(Cursor.Position);
            if (!this.ClientRectangle.Contains(mousePos))
            {
                this.BackColor = Color.White;
            }
        }

        private GraphicsPath MakeRounded(Rectangle r, int radius)
        {
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, radius * 2, radius * 2, 180, 90);
            p.AddArc(r.Right - radius * 2, r.Y, radius * 2, radius * 2, 270, 90);
            p.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            p.AddArc(r.X, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            p.CloseFigure();
            return p;
        }

        private void TrelloCardControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.Move);
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thẻ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Phát tín hiệu cho Form chính biết để xóa trong LinkedList
                CardDeleted?.Invoke(this, EventArgs.Empty);
            }
        }

        // NÚT CHỈNH SỬA THẺ
        private void mnuEdit_Click(object sender, EventArgs e)
        {
            using (AddCardForm frm = new AddCardForm())
            {
                int oldChecked = 0;
                int oldTotal = 0;
                if (lblChecklist.Visible && lblChecklist.Text.Contains("/"))
                {
                    string cleanText = lblChecklist.Text.Replace("☑ ", "").Trim();
                    string[] parts = cleanText.Split('/');
                    if (parts.Length == 2)
                    {
                        int.TryParse(parts[0], out oldChecked);
                        int.TryParse(parts[1], out oldTotal);
                    }
                }

                string oldLabel = lblLabel.Visible ? lblLabel.Text : "";
                string oldColorHex = lblLabel.Visible ? System.Drawing.ColorTranslator.ToHtml(lblLabel.BackColor) : "#0079BF";
                string oldLink = (lblLink.Tag != null) ? lblLink.Tag.ToString() : "";

                // GỌI HÀM BÊN ADDCARDFORM
                frm.LoadOldData(lblTitle.Text, lblMember.Text, oldChecked, oldTotal, oldLabel, oldColorHex, oldLink);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Phát tín hiệu gửi dữ liệu mới (frm.NewCard) ra cho Form chính cập nhật LinkedList
                    CardEdited?.Invoke(this, frm.NewCard);
                }
            }
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblLink.Tag != null && !string.IsNullOrWhiteSpace(lblLink.Tag.ToString()))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = lblLink.Tag.ToString(),
                        UseShellExecute = true
                    });
                }
                catch
                {
                    MessageBox.Show("Đường dẫn không hợp lệ!", "Lỗi");
                }
            }
        }

        private void TrelloCardControl_Load(object sender, EventArgs e) { }
        private void lblLabel_Click(object sender, EventArgs e) { }
    }
}