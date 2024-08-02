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
    internal partial class FormThemPb : Form
    {
        CtyCon ctcc = null;
        public FormThemPb(CtyCon ctc)
        {
            ctcc = ctc;
            InitializeComponent();
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                PhongBan pb = new PhongBan(ctcc, "id_" + CtyHaiHoa.genID());
                pb.ten = txtTen.Text;
                pb.tentp = txtTtp.Text;
                ctcc.thempb(pb);
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Nhập sai thông tin!");
            }

        }
    }
}
