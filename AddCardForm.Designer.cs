namespace WindowsFormsApp3
{
    partial class AddCardForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLabelText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.hihi = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudTotalItems = new System.Windows.Forms.NumericUpDown();
            this.nudCheckedItems = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(110, 30);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(260, 22);
            this.txtTitle.TabIndex = 0;
            // 
            // txtMember
            // 
            this.txtMember.Location = new System.Drawing.Point(110, 74);
            this.txtMember.Name = "txtMember";
            this.txtMember.Size = new System.Drawing.Size(260, 22);
            this.txtMember.TabIndex = 1;
            // 
            // cboColor
            // 
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Items.AddRange(new object[] {
            "Xanh dương",
            "Đỏ",
            "Cam",
            "Vàng",
            "Xanh lá",
            "Tím",
            "Xám"});
            this.cboColor.Location = new System.Drawing.Point(214, 127);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(156, 24);
            this.cboColor.TabIndex = 2;
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(110, 201);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(260, 22);
            this.txtLink.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(73, 308);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Thêm";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(203, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tiêu Đề";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thành Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Màu Nhãn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Link URL";
            // 
            // txtLabelText
            // 
            this.txtLabelText.Location = new System.Drawing.Point(214, 158);
            this.txtLabelText.Name = "txtLabelText";
            this.txtLabelText.Size = new System.Drawing.Size(156, 22);
            this.txtLabelText.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nhãn ";
            // 
            // hihi
            // 
            this.hihi.AutoSize = true;
            this.hihi.Location = new System.Drawing.Point(13, 251);
            this.hihi.Name = "hihi";
            this.hihi.Size = new System.Drawing.Size(61, 16);
            this.hihi.TabIndex = 12;
            this.hihi.Text = "Checklist";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "/";
            // 
            // nudTotalItems
            // 
            this.nudTotalItems.Location = new System.Drawing.Point(214, 251);
            this.nudTotalItems.Name = "nudTotalItems";
            this.nudTotalItems.Size = new System.Drawing.Size(84, 22);
            this.nudTotalItems.TabIndex = 14;
            // 
            // nudCheckedItems
            // 
            this.nudCheckedItems.Location = new System.Drawing.Point(110, 251);
            this.nudCheckedItems.Name = "nudCheckedItems";
            this.nudCheckedItems.Size = new System.Drawing.Size(84, 22);
            this.nudCheckedItems.TabIndex = 15;
            // 
            // AddCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 403);
            this.Controls.Add(this.nudCheckedItems);
            this.Controls.Add(this.nudTotalItems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hihi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLabelText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.txtMember);
            this.Controls.Add(this.txtTitle);
            this.Name = "AddCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCardForm";
            this.Load += new System.EventHandler(this.AddCardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckedItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLabelText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label hihi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudTotalItems;
        private System.Windows.Forms.NumericUpDown nudCheckedItems;
    }
}