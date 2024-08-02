using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CtyHaiHoa
{
    class CtyHaiHoa
    {
        public static string data_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))+"\\CtyHaiHoa.xml";
        public static XElement data_CtyHaiHoa = null;

        public static String ten { get; set; }
        public static String tgd { get; set; }
        public static DateTime ntl { get; set; }
        public static int sgp { get; set; }
        public static String diachi { get; set; }
        public static List<CtyCon> ctycon = new List<CtyCon>();

        public static String ghichu { get; set; }


        public CtyHaiHoa()
        {

            if (data_CtyHaiHoa == null )
            {
                try
                {
                    data_CtyHaiHoa = XDocument.Parse(File.ReadAllText(data_path)).Element("CtyHaiHoa");

                } catch (Exception ex)
                {              
                    data_CtyHaiHoa = new XElement("CtyHaiHoa");
                    data_CtyHaiHoa.Add(new XElement("ten"));
                    data_CtyHaiHoa.Add(new XElement("tgd"));
                    data_CtyHaiHoa.Add(new XElement("ntl","01/01/1999"));
                    data_CtyHaiHoa.Add(new XElement("sgp","0"));
                    data_CtyHaiHoa.Add(new XElement("diachi"));
                    data_CtyHaiHoa.Add(new XElement("ghichu"));
                    data_CtyHaiHoa.Add(new XElement("ctycon"));
                   
                }

            }
                
            load();
        }

        public static void load()
        {

            ten = data_CtyHaiHoa.Element("ten").Value;
            tgd = data_CtyHaiHoa.Element("tgd").Value;
            ntl = DateTime.ParseExact(data_CtyHaiHoa.Element("ntl").Value, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
            sgp = Int32.Parse(data_CtyHaiHoa.Element("sgp").Value);
            diachi = data_CtyHaiHoa.Element("diachi").Value;
            ghichu = data_CtyHaiHoa.Element("ghichu").Value;

           ctycon = new List<CtyCon>();

            IEnumerable<XNode> list = data_CtyHaiHoa.Element("ctycon").Nodes();

            foreach (var item in list)
            {
                XDocument hehe = XDocument.Parse(item.ToString());
                CtyCon xxxctycon = new CtyCon(hehe.Root.Name.ToString());
                xxxctycon.ten = hehe.Element(xxxctycon.id).Element("ten").Value;
                Console.Write(xxxctycon.ten);
                ctycon.Add(xxxctycon);
            }
        }

        public static string themCtyCon(CtyCon ctyc)
        {
            XElement root = new XElement(ctyc.id);

            root.Add(new XElement("ten", ctyc.ten));
            root.Add(new XElement("tgd", ctyc.tgd));
            root.Add(new XElement("ntl", ctyc.ntl.ToString("dd/MM/yyyy")));
            root.Add(new XElement("sgp", ctyc.sgp));
            root.Add(new XElement("diachi", ctyc.diachi));
            root.Add(new XElement("ghichu", ctyc.ghichu));
            root.Add(new XElement("phongban", ""));

            data_CtyHaiHoa.Element("ctycon").Add(root);

            ctycon.Add(ctyc);

            return ctyc.id;
        }

        public static bool xoaCtyCon(string id)
        {
            data_CtyHaiHoa.Element("ctycon").Element(id).Remove();
            ctycon.RemoveAll(item => id == item.id);
            return true;
        }

        public static void xuatCtycon(string filename, DataGridView dataGridView1)
        {

            if (dataGridView1.Columns.Count != 0)
            {
                using (Stream stream = File.OpenWrite(new Uri(filename).LocalPath))
                {
                    stream.SetLength(0);
                    using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine("ID" + "," + "Tên" + "," + "TGĐ" + "," + "Ngày thành lập" + "," + "Số giấp phép" + "," + "Địa chỉ" + "," + "ghi chú" + "," + "Số phòng ban");

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.Visible) { continue; }

                            string line = string.Join(",", row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value, row.Cells[7].Value);
                            writer.WriteLine(line);
                        }

                        writer.Flush();
                    }
                };
            }

            
        }

        public static bool sua()
        {

            data_CtyHaiHoa.Element("ten").Value = ten;
            data_CtyHaiHoa.Element("tgd").Value = tgd;
            data_CtyHaiHoa.Element("ntl").Value = ntl.ToString("dd/MM/yyyy");
            data_CtyHaiHoa.Element("sgp").Value = sgp.ToString();
            data_CtyHaiHoa.Element("diachi").Value = diachi;
            data_CtyHaiHoa.Element("ghichu").Value = ghichu;

            return true;
        }

        public static bool suaCtycon(CtyCon ctyCon)
        {
            data_CtyHaiHoa.Element("ctycon").Element(ctyCon.id).Element("ten").Value = ctyCon.ten;
            data_CtyHaiHoa.Element("ctycon").Element(ctyCon.id).Element("tgd").Value = ctyCon.tgd;
            data_CtyHaiHoa.Element("ctycon").Element(ctyCon.id).Element("ntl").Value = ctyCon.ntl.ToString("dd/MM/yyyy");
            data_CtyHaiHoa.Element("ctycon").Element(ctyCon.id).Element("sgp").Value = ctyCon.sgp.ToString();
            data_CtyHaiHoa.Element("ctycon").Element(ctyCon.id).Element("diachi").Value = ctyCon.diachi;
            data_CtyHaiHoa.Element("ctycon").Element(ctyCon.id).Element("ghichu").Value = ctyCon.ghichu;
            return true;
        }

        public static string genID()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            string number = String.Format("{0:d5}", (DateTime.Now.Ticks / 10) % 1000000000);

            return number;
        }

        public static void saveXML()
        {
            data_CtyHaiHoa.Save(CtyHaiHoa.data_path);
        }

    }
}

