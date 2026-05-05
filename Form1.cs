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
    public partial class Form1 : Form
    {
        

        // Dùng LinkedList để quản lý danh sách các Cột ngang
        private MyLinkedList<TrelloList> boardData = new MyLinkedList<TrelloList>();

        // Dùng LinkedList để quản lý danh sách Thẻ (Bài viết) nằm dọc bên trong từng Cột
        // (Sử dụng Dictionary để map 1 Cột -> 1 LinkedList Thẻ tương ứng)
        private Dictionary<TrelloList, MyLinkedList<TrelloCard>> linkedListCards = new Dictionary<TrelloList, MyLinkedList<TrelloCard>>();

        public Form1()
        {
            InitializeComponent();

            // Khởi tạo 1 cột và 1 thẻ mẫu đưa vào LinkedList
            TrelloList cotMau = new TrelloList("CẦN LÀM");
            boardData.AddLast(cotMau);

            MyLinkedList<TrelloCard> danhSachTheCotMau = new MyLinkedList<TrelloCard>();
            danhSachTheCotMau.AddLast(new TrelloCard("Thiết kế UI", "Nhãn", "#0079BF", "Sơn", 0, 0, ""));
            linkedListCards.Add(cotMau, danhSachTheCotMau);

            // Vẽ bảng ra màn hình
            RenderBoard();
        }

        // Hàm dọn dẹp và vẽ lại toàn bộ Bảng từ LinkedList
        private void RenderBoard()
        {
            flpBoard.Controls.Clear();
            int i = 0;

            // Duyệt từ đầu tàu (Head) đến khi hết danh sách (null)
            MyNode<TrelloList> currentList = boardData.Head;
            while (currentList != null)
            {
                CreateColumnUI(currentList.Value, i); // Truy cập dữ liệu qua đuôi .Value
                currentList = currentList.Next;       // Nhảy sang cột tiếp theo
                i++;
            }
        }

        // Hàm "Ma thuật" tự động sinh Cột và Thẻ bằng Code
        private void CreateColumnUI(TrelloList listData, int columnIndex)
        {
            // Tạo cái Panel nền cho Cột
            Panel pnlColumn = new Panel();
            pnlColumn.Size = new Size(320, flpBoard.Height - 30);
            pnlColumn.BackColor = Color.FromArgb(235, 236, 240);
            pnlColumn.Margin = new Padding(10);

            // Tạo Label Tiêu đề cột
            Label lblTitle = new Label();
            lblTitle.Text = listData.Name;
            lblTitle.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.AutoSize = true;
            pnlColumn.Controls.Add(lblTitle);

          
            ContextMenuStrip colMenu = new ContextMenuStrip();
            ToolStripMenuItem mnuEditCol = new ToolStripMenuItem("✏️ Chỉnh sửa tên cột");
            ToolStripMenuItem mnuDeleteCol = new ToolStripMenuItem("🗑️ Xóa cột");
            colMenu.Items.Add(mnuEditCol);
            colMenu.Items.Add(mnuDeleteCol);

            // Sự kiện Xóa cột (Xóa khỏi LinkedList)
            mnuDeleteCol.Click += (s, ev) =>
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa cột '{listData.Name}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    boardData.Remove(listData);        // Xóa cột
                    linkedListCards.Remove(listData);  // Xóa kho chứa thẻ của cột
                    RenderBoard();
                }
            };

            // Sự kiện Sửa tên cột
            mnuEditCol.Click += (s, ev) =>
            {
                using (AddColumnForm frm = new AddColumnForm())
                {
                    frm.LoadOldData(listData.Name);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        listData.Name = frm.ColumnName;
                        RenderBoard();
                    }
                }
            };
            pnlColumn.ContextMenuStrip = colMenu;
            lblTitle.ContextMenuStrip = colMenu;



            // Tạo FlowLayoutPanel dọc để chứa các Thẻ
            FlowLayoutPanel flpCards = new FlowLayoutPanel();
            flpCards.Location = new Point(5, 50);
            flpCards.Size = new Size(310, pnlColumn.Height - 110);
            flpCards.AutoScroll = true;
            flpCards.FlowDirection = FlowDirection.TopDown;
            flpCards.WrapContents = false;
            pnlColumn.Controls.Add(flpCards);

            // Xử lý kéo thả 
            flpCards.AllowDrop = true;
            flpCards.DragEnter += (sender, e) =>
            {
                if (e.Data.GetDataPresent(typeof(TrelloCardControl)))
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            };
            flpCards.DragDrop += (sender, e) =>
            {
                TrelloCardControl cardToMove = (TrelloCardControl)e.Data.GetData(typeof(TrelloCardControl));
                FlowLayoutPanel targetPanel = (FlowLayoutPanel)sender;
                if (cardToMove != null && targetPanel != null)
                {
                    targetPanel.Controls.Add(cardToMove);
                }
            };

         
            // lấy dữ liệu từ linkeslisst thẻ và vẽ lên màn hình
            // Đảm bảo cột này đã có danh sách liên kết lưu trữ thẻ
            if (!linkedListCards.ContainsKey(listData))
            {
                linkedListCards[listData] = new MyLinkedList<TrelloCard>(); 
            }

          
            MyNode<TrelloCard> currentCard = linkedListCards[listData].Head;
            while (currentCard != null)
            {
                TrelloCard cardData = currentCard.Value; // Lấy dữ liệu ra tạm
                TrelloCardControl cardUI = new TrelloCardControl();
                cardUI.SetData(cardData);
                cardUI.Margin = new Padding(5);

                cardUI.CardDeleted += (sender, e) =>
                {
                    linkedListCards[listData].Remove(cardData);
                    RenderBoard();
                };

                cardUI.CardEdited += (sender, newData) =>
                {
                    var node = linkedListCards[listData].Find(cardData);
                    if (node != null) node.Value = newData;
                    RenderBoard();
                };

                flpCards.Controls.Add(cardUI);

                currentCard = currentCard.Next; // Lệnh này để vòng lặp chạy tiếp
            }

            // Tạo nút "Thêm Thẻ" ở dưới cùng của cột
            Button btnAddCard = new Button();
            btnAddCard.Text = "+ Thêm thẻ";
            btnAddCard.Location = new Point(10, pnlColumn.Height - 45);
            btnAddCard.Size = new Size(300, 35);
            btnAddCard.FlatStyle = FlatStyle.Flat;
            btnAddCard.FlatAppearance.BorderSize = 0;

            
            btnAddCard.Click += (sender, e) =>
            {
                using (AddCardForm frm = new AddCardForm())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        
                        linkedListCards[listData].AddLast(frm.NewCard);
                        RenderBoard();
                    }
                }
            };
            pnlColumn.Controls.Add(btnAddCard);

            
            flpBoard.Controls.Add(pnlColumn);
        }

        private void label1_Click(object sender, EventArgs e) { }

        
        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            using (AddColumnForm frm = new AddColumnForm())
            {
               
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TrelloList newList = new TrelloList(frm.ColumnName);
                    boardData.AddLast(newList);
                    linkedListCards.Add(newList, new MyLinkedList<TrelloCard>());
                    RenderBoard();
                }
            }
        }

    }
            
}
        

    

