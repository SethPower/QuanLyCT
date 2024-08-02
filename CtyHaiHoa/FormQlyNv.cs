using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyHaiHoa
{
    internal partial class FormQlyNv : Form
    {
        PhongBan pb = null;

    
        public FormQlyNv(PhongBan pb)
        {
            this.pb = pb;
            InitializeComponent();

            HienThi();
        }

        private void HienThi()
        {
            int i = 0;
            dgv.Rows.Clear();

            foreach (var item in pb.nv)
            {
                this.dgv.Rows.Add();
                this.dgv.Rows[i].Cells[0].Value = item.id;
                this.dgv.Rows[i].Cells[1].Value = item.ten;
                this.dgv.Rows[i].Cells[2].Value = item.tuoi;
                this.dgv.Rows[i].Cells[3].Value = item.cmnd;
                this.dgv.Rows[i].Cells[4].Value = item.nbd.ToString("dd/MM/yyyy");
                this.dgv.Rows[i].Cells[5].Value = item.chucvu;
                this.dgv.Rows[i].Cells[6].Value = item.luong;

                i++;

            }
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem xoa = new MenuItem("Xóa");
               
                xoa.Click += new EventHandler(gri_ctm_xoa);
                
                m.MenuItems.Add(xoa);
                




                m.Show(dgv, new Point(e.X, e.Y));

            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rw = e.RowIndex;
            int cel = e.ColumnIndex;

            string id = dgv[0, rw].Value.ToString();
            string dt = dgv[cel, rw].Value.ToString();

        
            NhanVien nv = new NhanVien(pb,id);


            switch (cel)
            {
                case 1:
                    nv.ten = dt;
                    break;
                case 2:
                    nv.tuoi = Int32.Parse(dt);
                    break;  
                case 3:
                    nv.cmnd = dt;
                    break;
                case 4:
                    nv.nbd = DateTime.ParseExact(dt,"dd/MM/yyyy", CultureInfo.InvariantCulture);
                    break;
                case 5:
                    nv.chucvu = dt;
                    break;
                case 6:
                    nv.luong = Int32.Parse(dt);
                    break;
            }

            pb.suaNhanVien(nv);

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
                    pb.xoaNhanVien(id);
                    pb.load();
                }

                HienThi();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
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

                    if (cellValue != null && cellValue.ToString().ToLower().Contains(txtTenNv.Text.ToLower()))
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
            savefile.FileName = "nhanvien.csv";
            savefile.Filter = "CSV (*.csv)|*.csv";

            if (savefile.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            PhongBan.xuatNhanVien(savefile.ToString(), dgv);
        }

        private void FormQlyNv_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormThemNV themnv = new FormThemNV(pb);
            themnv.ShowDialog(this);
            pb.load();
            HienThi();
        }
    }
}
