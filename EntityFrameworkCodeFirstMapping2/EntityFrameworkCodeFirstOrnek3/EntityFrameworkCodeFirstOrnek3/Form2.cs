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
    public partial class Form2 : Form
    {
        Form1 mainForm;

        public Form2(Form1 frm)
        {
            mainForm = frm;
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Product urun = new Product()
            {
                AddedDate = DateTime.Now,
                IsActive = true,
                Name = txtUrunAdi.Text,
                QuantityPerUnit = txtBirimi.Text,
                UnitPrice = decimal.Parse(txtUrunFiyati.Text),
                UnitsInStock = short.Parse(txtStokMiktari.Text)
            };

            // Anlık kullanım için kullanılan bir metottur. using'e ait scope bittiği anda database objeleri kullanılmaz hale gelir...
            using(ProjectContext db = new ProjectContext())
            {
                db.Products.Add(urun);
                db.SaveChanges();
            }

            MessageBox.Show("Ürün kaydedildi...");
        }
    }
}
