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
    internal partial class FormMain : Form
    {
        private CtyCon ctc;

        public FormMain()
        {

            InitializeComponent();

            new CtyHaiHoa();

            //biến cty cha
            txtTen.Text = CtyHaiHoa.ten;
            txtTgd.Text = CtyHaiHoa.tgd;
            txtNtl.Text = CtyHaiHoa.ntl.ToString() ;
            txtSgp.Text = CtyHaiHoa.sgp.ToString();
            txtDc.Text = CtyHaiHoa.diachi;
            txtGc.Text = CtyHaiHoa.ghichu;
            //biến cty 

            Hienthi();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CtyHaiHoa.ten = txtTen.Text;
            CtyHaiHoa.tgd = txtTgd.Text;
            CtyHaiHoa.ntl = txtNtl.Value.Date;
            CtyHaiHoa.sgp = Int32.Parse(txtSgp.Text);
            CtyHaiHoa.diachi = txtDc.Text;
            CtyHaiHoa.ghichu = txtGc.Text;
            CtyHaiHoa.sua();

            CtyHaiHoa.saveXML();

            MessageBox.Show("Lưu thành công!");
        }

        private void Hienthi()
        {

            int i = 0;
            dgv.Rows.Clear();
            
            foreach (var item in CtyHaiHoa.ctycon)
            {
                this.dgv.Rows.Add();
                this.dgv.Rows[i].Cells[0].Value = item.id;
                this.dgv.Rows[i].Cells[1].Value = item.ten;
                this.dgv.Rows[i].Cells[2].Value = item.tgd;
                this.dgv.Rows[i].Cells[3].Value = item.ntl.ToString("dd/MM/yyyy");
                this.dgv.Rows[i].Cells[4].Value = item.sgp;
                this.dgv.Rows[i].Cells[5].Value = item.diachi;
                this.dgv.Rows[i].Cells[6].Value = item.ghichu;
                this.dgv.Rows[i].Cells[7].Value = item.phongban.Count;
                i++;

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

                CtyCon ctc = new CtyCon(id);


                switch (cel)
                {
                    case 1:
                        ctc.ten = dt;
                        break;
                    case 2:
                        ctc.tgd = dt;
                        break;
                    case 3:
                        ctc.ntl = DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
                        break;
                    case 5:
                        ctc.diachi = dt;
                        break;
                    case 6:
                        ctc.ghichu = dt;
                        break;
                }

                CtyHaiHoa.suaCtycon(ctc);
            }
            catch (Exception)
            {
            }
            

        }

        private void dgv_MouseClick(object sender, MouseEventArgs  e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                MenuItem xoa = new MenuItem("Xóa");
                
                MenuItem qlypb = new MenuItem("Quản lý phòng ban");
                xoa.Click += new EventHandler(gri_ctm_xoa);
                qlypb.Click += new EventHandler(gri_ctm_qlypb);
               
                m.MenuItems.Add(xoa);
                
                m.MenuItems.Add(qlypb);

                m.Show(dgv, new Point(e.X, e.Y));

            }  
        }



        private void gri_ctm_qlypb(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dgv.CurrentCell.RowIndex;


                string id = dgv[0, rowindex].Value.ToString();

                ctc = new CtyCon(id);

                FormQlyPhongBan m = new FormQlyPhongBan(ctc);
                m.ShowDialog(this);
                CtyHaiHoa.load();
                Hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show("Chọn ô cần quản lý!");   
            }

       
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
                    CtyHaiHoa.xoaCtyCon(id);


                }
              

                Hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng chọn công ty con cần xóa!");
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

                    if (cellValue != null && cellValue.ToString().ToLower().Contains(txtTenCtycon.Text.ToLower())) 
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
            savefile.FileName = "ctycon.csv";
            // set filters - this can be done in properties as well
            savefile.Filter = "CSV (*.csv)|*.csv";

            if (savefile.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            CtyHaiHoa.xuatCtycon(savefile.ToString(),dgv);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
             
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu dữ liệu không?", "Thoát", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Hide();
                    CtyHaiHoa.saveXML();
                    Environment.Exit(0);
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormThemCtyCon t = new FormThemCtyCon();
            t.ShowDialog(this);
            Hienthi();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }

}
