using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkCodeFirstOrnek3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ProjectContext db = new ProjectContext();

            if(db.Users.Any(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Text))
            {
                lblError.Visible = false;
                
                this.Hide();
                Form2 frm = new Form2(this);
                frm.Show();
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Girdiğiniz kullanıcı adı ya da şifre hatalı!";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }
    }
}
