using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyHaiHoa
{
    internal partial class FormThemNV : Form
    {
        PhongBan pb = null;
        public FormThemNV(PhongBan pb)
        {
            this.pb = pb;

            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien(pb, "id_" + CtyHaiHoa.genID());
                nv.ten = txtTen.Text;
                nv.tuoi = Int32.Parse(txtTuoi.Text);
                nv.cmnd = txtCmnd.Text;
                nv.nbd = txtNbd.Value.Date;
                nv.chucvu = txtCv.Text;
                nv.luong = Int32.Parse(txtLuong.Text);

                pb.themnv(nv);

                MessageBox.Show("Thêm nhân viên thành công.");
                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Nhập sai thông tin!");
            }

        }

        private void ThemNV_Load(object sender, EventArgs e)
        {

        }
    }
}
