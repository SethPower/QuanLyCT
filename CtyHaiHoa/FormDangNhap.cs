using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CtyHaiHoa
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            txtMk.PasswordChar = '*';
        }

        public void Login()
        {
            bool login = false;
            XmlDocument doc = new XmlDocument();
            string filename = @"E:\CtyHaiHoa\CtyHaiHoa\login.xml";
            doc.Load(filename);
            foreach (XmlNode node in doc.SelectNodes("//user"))
            {
                String Username = node.SelectSingleNode("username").InnerText;
                String Password = node.SelectSingleNode("password").InnerText;
                if (Username == txtTk.Text && Password == txtMk.Text)
                {
                    login = true;
                    break;
                }
                else
                {
                    login = false;
                }
            }
            if (login)
            {
                this.Hide();
                FormMain m = new FormMain();
                m.Show();

            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");

            }

        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtMk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
