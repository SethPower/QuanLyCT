namespace CtyHaiHoa
{
    partial class FormThemNV
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCmnd = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.txtNbd = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtCv = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "CMND:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tuổi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày bắt đầu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chức vụ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lương:";
            // 
            // txtCmnd
            // 
            this.txtCmnd.Location = new System.Drawing.Point(68, 134);
            this.txtCmnd.Name = "txtCmnd";
            this.txtCmnd.Size = new System.Drawing.Size(184, 22);
            this.txtCmnd.TabIndex = 6;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(68, 32);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(184, 22);
            this.txtTen.TabIndex = 7;
            // 
            // txtTuoi
            // 
            this.txtTuoi.Location = new System.Drawing.Point(68, 86);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(184, 22);
            this.txtTuoi.TabIndex = 8;
            // 
            // txtLuong
            // 
            this.txtLuong.Location = new System.Drawing.Point(402, 134);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(200, 22);
            this.txtLuong.TabIndex = 10;
            // 
            // txtNbd
            // 
            this.txtNbd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNbd.Location = new System.Drawing.Point(402, 30);
            this.txtNbd.Name = "txtNbd";
            this.txtNbd.Size = new System.Drawing.Size(200, 22);
            this.txtNbd.TabIndex = 11;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(253, 210);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(93, 38);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtCv
            // 
            this.txtCv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCv.FormattingEnabled = true;
            this.txtCv.Items.AddRange(new object[] {
            "Trưởng Phòng ",
            "Kỹ Thuật Viên",
            "Coder",
            "Đồ Họa"});
            this.txtCv.Location = new System.Drawing.Point(402, 80);
            this.txtCv.Name = "txtCv";
            this.txtCv.Size = new System.Drawing.Size(200, 24);
            this.txtCv.TabIndex = 13;
            // 
            // FormThemNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 260);
            this.Controls.Add(this.txtCv);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtNbd);
            this.Controls.Add(this.txtLuong);
            this.Controls.Add(this.txtTuoi);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtCmnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormThemNV";
            this.Text = "ThemNV";
            this.Load += new System.EventHandler(this.ThemNV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCmnd;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.DateTimePicker txtNbd;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox txtCv;
    }
}