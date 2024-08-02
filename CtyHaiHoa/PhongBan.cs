using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CtyHaiHoa
{
    class PhongBan
    {
        public string id;
        public string ten;
        public string tentp;
        public List<NhanVien> nv = new List<NhanVien>();

        public XElement data_PhongBan = null;
        public PhongBan(CtyCon ctc, string id)
        {
            this.id = id;

            data_PhongBan = ctc.data_CtyCon.Element("phongban").Element(id);

            if (data_PhongBan == null) { return; }

            load();
        }

        public void load()
        {
            try
            {
                nv = new List<NhanVien>();
                ten = data_PhongBan.Element("ten").Value;
                tentp = data_PhongBan.Element("tentp").Value;


                IEnumerable<XNode> list = data_PhongBan.Element("nhanvien").Nodes();

                foreach (var item in list)
                {

                    XDocument hehe = XDocument.Parse(item.ToString());
                    NhanVien xxxnv = new NhanVien(this,hehe.Root.Name.ToString());


                    xxxnv.ten = hehe.Element(xxxnv.id).Element("ten").Value;
                    xxxnv.cmnd = hehe.Element(xxxnv.id).Element("cmnd").Value;
                    xxxnv.tuoi = Int32.Parse(hehe.Element(xxxnv.id).Element("tuoi").Value);
                    xxxnv.chucvu = hehe.Element(xxxnv.id).Element("chucvu").Value;
                    xxxnv.luong = Int32.Parse(hehe.Element(xxxnv.id).Element("luong").Value);
                    xxxnv.nbd = DateTime.ParseExact(hehe.Element(xxxnv.id).Element("nbd").Value, "dd/MM/yyyy", CultureInfo.InvariantCulture); 

                    nv.Add(xxxnv);
                }
            }
            catch (Exception)
            {

               
            }
          
        }

        public string themnv(NhanVien nvs)
        {
            string id = "id_" + CtyHaiHoa.genID() ;
            XElement root = new XElement(id);

            root.Add(new XElement("ten", nvs.ten));
            root.Add(new XElement("cmnd", nvs.cmnd));
            root.Add(new XElement("tuoi", nvs.tuoi));
            root.Add(new XElement("chucvu", nvs.chucvu));
            root.Add(new XElement("luong", nvs.luong));
            root.Add(new XElement("nbd", nvs.nbd.ToString("dd/MM/yyyy")));

            data_PhongBan.Element("nhanvien").Add(root);

            nv.Add(nvs);

            return id;
        }

        public bool xoaNhanVien(string id)
        {
            data_PhongBan.Element("nhanvien").Element(id).Remove();
            nv.RemoveAll(item => id == item.id);
            return true;
        }

        public bool suaNhanVien(NhanVien nvs)
        {
            data_PhongBan.Element("nhanvien").Element(nvs.id).Element("ten").Value = nvs.ten;
            data_PhongBan.Element("nhanvien").Element(nvs.id).Element("cmnd").Value = nvs.cmnd;
            data_PhongBan.Element("nhanvien").Element(nvs.id).Element("tuoi").Value = nvs.tuoi.ToString();
            data_PhongBan.Element("nhanvien").Element(nvs.id).Element("chucvu").Value = nvs.chucvu;
            data_PhongBan.Element("nhanvien").Element(nvs.id).Element("luong").Value = nvs.luong.ToString();
            data_PhongBan.Element("nhanvien").Element(nvs.id).Element("nbd").Value = nvs.nbd.ToString("dd/MM/yyyy");

            NhanVien nvh = nv.Where(item => nvs.id == item.id).First();

            nvh = nvs;

            return true;
        }

        public static void xuatNhanVien(string filename, DataGridView dataGridView1)
        {
            if (dataGridView1.Columns.Count != 0)
            {
                using (Stream stream = File.OpenWrite(new Uri(filename).LocalPath))
                {
                    stream.SetLength(0);
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine("ID" + "," + "Tên" + "," + "Tuổi" + "," + "CMND" + "," + "Ngày bắt đầu " + "," + "Chức vụ" + "," + "Lương");

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.Visible) { continue; }

                            string line = string.Join(",", row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value);
                            writer.WriteLine(line);
                        }

                        writer.Flush();
                    }
                };
            }
        }
    }
}
