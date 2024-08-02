using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CtyHaiHoa
{
    class NhanVien
    {

        PhongBan pb = null;
     

        public NhanVien(PhongBan pb,string idx)
        {

            this.pb = pb;
            this.id = idx;
            data_nv = pb.data_PhongBan.Element("nhanvien").Element(id);

            if (data_nv == null)
            {
                return;
            }
            load();
        }

        private void load()
        {
            this.ten = data_nv.Element("ten").Value;
            this.tuoi = Int32.Parse(data_nv.Element("tuoi").Value);
            this.cmnd = data_nv.Element("cmnd").Value;
            this.nbd = DateTime.ParseExact(data_nv.Element("nbd").Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);  
            this.chucvu = data_nv.Element("chucvu").Value;
            this.luong = Int32.Parse(data_nv.Element("luong").Value);
        }

        public string id { get; set; }

        private XElement data_nv;

        public string cmnd { get; set; }
        public string ten { get; set; }

        public int tuoi { get; set; }
        public DateTime nbd { get; set; }

        public string chucvu { get; set; }
        public int luong { get; set; }
    }
}
