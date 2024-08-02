namespace CtyHaiHoa
{
    partial class FormThemCtyCon
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
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtTgd = new System.Windows.Forms.TextBox();
            this.txtDc = new System.Windows.Forms.TextBox();
            this.txtSgp = new System.Windows.Forms.TextBox();
            this.txtGc = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtNtl = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên giám đốc:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày thành lập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số giấy phép:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ghi chú:";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(160, 47);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(177, 22);
            this.txtTen.TabIndex = 6;
            // 
            // txtTgd
            // 
            this.txtTgd.Location = new System.Drawing.Point(160, 100);
            this.txtTgd.Name = "txtTgd";
            this.txtTgd.Size = new System.Drawing.Size(177, 22);
            this.txtTgd.TabIndex = 7;
            // 
            // txtDc
            // 
            this.txtDc.Location = new System.Drawing.Point(160, 152);
            this.txtDc.Name = "txtDc";
            this.txtDc.Size = new System.Drawing.Size(177, 22);
            this.txtDc.TabIndex = 8;
            // 
            // txtSgp
            // 
            this.txtSgp.Location = new System.Drawing.Point(540, 103);
            this.txtSgp.Name = "txtSgp";
            this.txtSgp.Size = new System.Drawing.Size(184, 22);
            this.txtSgp.TabIndex = 10;
            // 
            // txtGc
            // 
            this.txtGc.Location = new System.Drawing.Point(540, 152);
            this.txtGc.Name = "txtGc";
            this.txtGc.Size = new System.Drawing.Size(184, 22);
            this.txtGc.TabIndex = 11;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(337, 209);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(98, 32);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtNtl
            // 
            this.txtNtl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNtl.Location = new System.Drawing.Point(540, 46);
            this.txtNtl.Name = "txtNtl";
            this.txtNtl.Size = new System.Drawing.Size(184, 22);
            this.txtNtl.TabIndex = 13;
            // 
            // FormThemCtyCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 253);
            this.Controls.Add(this.txtNtl);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGc);
            this.Controls.Add(this.txtSgp);
            this.Controls.Add(this.txtDc);
            this.Controls.Add(this.txtTgd);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormThemCtyCon";
            this.Text = "ThemCtyCon";
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
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtTgd;
        private System.Windows.Forms.TextBox txtDc;
        private System.Windows.Forms.TextBox txtSgp;
        private System.Windows.Forms.TextBox txtGc;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker txtNtl;
    }
}