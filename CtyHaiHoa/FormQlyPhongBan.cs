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
    internal partial class FormQlyPhongBan : Form
    {
        CtyCon ctc = null;
        PhongBan pb = null;

        public FormQlyPhongBan(CtyCon ctc)
        {

            this.ctc = ctc;

            InitializeComponent();
            Hienthi();
        }

        private void Hienthi()
        {
            int i = 0;
            dgv.Rows.Clear();

            foreach (var item in ctc.phongban)
            {
                this.dgv.Rows.Add();
                this.dgv.Rows[i].Cells[0].Value = item.id;
                this.dgv.Rows[i].Cells[1].Value = item.ten;
                this.dgv.Rows[i].Cells[2].Value = item.tentp;
                this.dgv.Rows[i].Cells[3].Value = item.nv.Count;

                i++;

            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem xoa = new MenuItem("Xóa");
                
                MenuItem qlynv = new MenuItem("Quản lý nhân viên");
                xoa.Click += new EventHandler(gri_ctm_xoa);
                qlynv.Click += new EventHandler(gri_ctm_qlynv);
                
                m.MenuItems.Add(xoa);
                
                m.MenuItems.Add(qlynv);




                m.Show(dgv, new Point(e.X, e.Y));

            }
        }



        private void gri_ctm_qlynv(object sender, EventArgs e)
        {
            int rowindex = dgv.CurrentCell.RowIndex;


            string id = dgv[0, rowindex].Value.ToString();

             pb = new PhongBan(ctc, id);

            FormQlyNv nv = new FormQlyNv(pb);
            nv.ShowDialog(this);

            Hienthi();
        }

        private void gri_ctm_xoa(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dgv.CurrentCell.RowIndex;


                string id = dgv[0, rowindex].Value.ToString();


                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ctc.xoaPhongBan(id);
                }

                Hienthi();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Vui lòng chọn phòng ban cần xóa!" +ex.Message);
            }

        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rw = e.RowIndex;
                int cel = e.ColumnIndex;

                string id = dgv[0, rw].Value.ToString();
                string dt = dgv[cel, rw].Value.ToString();

                PhongBan pb = new PhongBan(ctc, id);


                switch (cel)
                {
                    case 1:
                        pb.ten = dt;
                        break;
                    case 2:
                        pb.tentp = dt;
                        break;
                }

                ctc.suaPhongBan(pb);
            } catch (Exception)
            {

            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgv.CurrentCell = null;
            dgv.AllowUserToAddRows = false;
            dgv.ClearSelection();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;

            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    var cellValue = row.Cells[1].Value;

                    if (cellValue != null && cellValue.ToString().ToLower().Contains(txtTenPb.Text.ToLower()))
                    {
                        row.Visible = true;
                    }
                    else
                        row.Visible = false;

                }
            }
            catch (Exception)
            {
                
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = "phongban.csv";
            // set filters - this can be done in properties as well
            savefile.Filter = "CSV (*.csv)|*.csv";

            if (savefile.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            CtyCon.xuatPhongBan(savefile.ToString(), dgv);
        }

        private void FormQlyPhongBan_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormThemPb tpb = new FormThemPb(ctc);
            tpb.ShowDialog(this);
            Hienthi();
        }
    }
}
