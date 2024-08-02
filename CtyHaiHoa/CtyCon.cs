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
    class CtyCon
    {
        public string id { get; set; }
        public string ten { get; set; }

        public string tgd { get; set; }
        public DateTime ntl { get; set; }

        public int sgp { get; set; }
        public string diachi { get; set; }

        public string ghichu { get; set; }

        public List<PhongBan> phongban = new List<PhongBan>();

        public XElement data_CtyCon = CtyHaiHoa.data_CtyHaiHoa.Element("ctycon");

        public CtyCon(string idx)
        {
            id = idx;

            data_CtyCon = data_CtyCon.Element(id);
            if (data_CtyCon == null) { return; }

            load();
        }



        public void load()
        {
            phongban = new List<PhongBan>();

            ten = data_CtyCon.Element("ten").Value;
            tgd = data_CtyCon.Element("tgd").Value;
            ntl = DateTime.ParseExact(data_CtyCon.Element("ntl").Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);  
            sgp = Int32.Parse(data_CtyCon.Element("sgp").Value);
            diachi = data_CtyCon.Element("diachi").Value;
            ghichu = data_CtyCon.Element("ghichu").Value;

            IEnumerable<XNode> list = data_CtyCon.Element("phongban").Nodes();

            foreach (var item in list)
            {

                XDocument hehe = XDocument.Parse(item.ToString());
                PhongBan xxxpban = new PhongBan(this, hehe.Root.Name.ToString());
                xxxpban.ten = hehe.Element(xxxpban.id).Element("ten").Value;
                xxxpban.tentp = hehe.Element(xxxpban.id).Element("tentp").Value;

                phongban.Add(xxxpban);

            }
        }

        public string thempb(PhongBan pb)
        {
            string id = "id_" + CtyHaiHoa.genID();
            XElement root = new XElement(id);

            root.Add(new XElement("ten", pb.ten));
            root.Add(new XElement("tentp", pb.tentp));
            root.Add(new XElement("nhanvien"));

            data_CtyCon.Element("phongban").Add(root);

            phongban.Add(pb);

            return id;
        }

        public bool xoaPhongBan(string id)
        {
            data_CtyCon.Element("phongban").Element(id).Remove();
            CtyHaiHoa.data_CtyHaiHoa.Save(CtyHaiHoa.data_path);

             phongban.RemoveAll(item => id == item.id);

            return true;
        }

        public bool suaPhongBan(PhongBan pban)
        {
            data_CtyCon.Element("phongban").Element(pban.id).Element("ten").Value = pban.ten;
            data_CtyCon.Element("phongban").Element(pban.id).Element("tentp").Value = pban.tentp;
            return true;
        }


        public static void xuatPhongBan(string filename, DataGridView dataGridView1)
        {
            if (dataGridView1.Columns.Count != 0)
            {
                using (Stream stream = File.OpenWrite(new Uri(filename).LocalPath))
                {
                    stream.SetLength(0);
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine("ID" + "," + "Tên" + "," + "TGĐ" + "," + "Số nhân viên");

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.Visible) { continue; }

                            string line = string.Join(",", row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value);
                            writer.WriteLine(line);
                        }

                        writer.Flush();
                    }
                };
            }
        }
    }
}

