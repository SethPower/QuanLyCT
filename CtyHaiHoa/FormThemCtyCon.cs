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
    internal partial class FormThemCtyCon : Form
    {
        public FormThemCtyCon()
        {
            InitializeComponent();
            
        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                CtyCon ctcon = new CtyCon("id_" + CtyHaiHoa.genID());
                ctcon.ten = txtTen.Text;
                ctcon.tgd = txtTgd.Text;
                ctcon.ntl = txtNtl.Value.Date;
                ctcon.diachi = txtDc.Text;
                ctcon.sgp = Int32.Parse(txtSgp.Text);
                ctcon.ghichu = txtGc.Text;
                CtyHaiHoa.themCtyCon(ctcon);
                MessageBox.Show("Thêm thành công!");
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập sai thông tin!");
            }

        }
    }
}
