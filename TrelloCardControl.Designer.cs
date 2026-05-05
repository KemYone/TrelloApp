namespace WindowsFormsApp3
{
    partial class TrelloCardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMember = new System.Windows.Forms.Label();
            this.lblChecklist = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.lblLabel = new System.Windows.Forms.Label();
            this.pnlLabel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ContextMenuStrip = this.contextMenuStrip2;
            this.lblTitle.Location = new System.Drawing.Point(111, 58);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 23);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Tiêu đề mẫu";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrelloCardControl_MouseDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(173, 52);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(172, 24);
            this.mnuEdit.Text = "Chỉnh Sửa Thẻ";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(172, 24);
            this.mnuDelete.Text = "Xóa Thẻ";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // lblMember
            // 
            this.lblMember.AutoSize = true;
            this.lblMember.ContextMenuStrip = this.contextMenuStrip2;
            this.lblMember.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMember.Location = new System.Drawing.Point(111, 98);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(97, 23);
            this.lblMember.TabIndex = 2;
            this.lblMember.Text = "Thành Viên";
            // 
            // lblChecklist
            // 
            this.lblChecklist.AutoSize = true;
            this.lblChecklist.ContextMenuStrip = this.contextMenuStrip2;
            this.lblChecklist.Location = new System.Drawing.Point(179, 23);
            this.lblChecklist.Name = "lblChecklist";
            this.lblChecklist.Size = new System.Drawing.Size(35, 23);
            this.lblChecklist.TabIndex = 3;
            this.lblChecklist.Text = "0/0";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(7, 121);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(98, 23);
            this.lblLink.TabIndex = 4;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "Link URL🔗";
            this.lblLink.Visible = false;
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblLabel.ForeColor = System.Drawing.Color.White;
            this.lblLabel.Location = new System.Drawing.Point(3, 21);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.lblLabel.Size = new System.Drawing.Size(58, 25);
            this.lblLabel.TabIndex = 5;
            this.lblLabel.Text = "Nhãn";
            this.lblLabel.Click += new System.EventHandler(this.lblLabel_Click);
            // 
            // pnlLabel
            // 
            this.pnlLabel.Location = new System.Drawing.Point(3, 3);
            this.pnlLabel.Name = "pnlLabel";
            this.pnlLabel.Size = new System.Drawing.Size(71, 10);
            this.pnlLabel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tiêu Đề";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thành Viên";
            // 
            // TrelloCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip2;
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlLabel);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblChecklist);
            this.Controls.Add(this.lblMember);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrelloCardControl";
            this.Size = new System.Drawing.Size(274, 144);
            this.Load += new System.EventHandler(this.TrelloCardControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TrelloCardControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrelloCardControl_MouseDown);
            this.MouseEnter += new System.EventHandler(this.TrelloCardControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TrelloCardControl_MouseLeave);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblChecklist;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.LinkLabel lblLink; // ĐÃ SỬA THÀNH LINKLABEL
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Panel pnlLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}