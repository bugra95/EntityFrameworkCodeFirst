using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkCodeFirstOrnek4
{
    public partial class Urunler : Form
    {
        Form1 mainForm;

        public Urunler(Form1 frm)
        {
            mainForm = frm;
            InitializeComponent();
        }

        ProjeContext db;

        private void Urunler_Load(object sender, EventArgs e)
        {
            db = new ProjeContext();

            cmbKategori.DataSource = db.Categories.ToList();
            cmbKategori.DisplayMember = "CategoryName";
            cmbKategori.ValueMember = "ID";

            cmbKategori.SelectedIndex = -1;
            btnGuncelle.Enabled = false;

            ProductList();
        }

        void ProductList()
        {
            lstUrunler.Items.Clear();

            foreach (Product urun in db.Products.ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = urun.ID.ToString();
                lvi.SubItems.Add(urun.ProductName);
                lvi.SubItems.Add(urun.UnitsInStock.ToString());
                lvi.SubItems.Add(urun.UnitPrice.ToString());
                lvi.SubItems.Add(urun.Category.CategoryName);
                lvi.Tag = urun.ID;

                lstUrunler.Items.Add(lvi);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.ProductName = txtUrunAdi.Text;
            p.UnitPrice = nmrFiyat.Value;
            p.UnitsInStock = (short)nmrStokAdet.Value;
            p.CategoryID = (int)cmbKategori.SelectedValue;

            db.Products.Add(p);
            db.SaveChanges();

            Temizle();
            ProductList();
        }

        void Temizle()
        {
            txtUrunAdi.Text = string.Empty;
            cmbKategori.SelectedIndex = -1;
            nmrFiyat.Value = nmrFiyat.Minimum;
            nmrStokAdet.Value = nmrStokAdet.Minimum;
        }

        Product guncellenecek;

        private void lstUrunler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnGuncelle.Enabled = true;
            btnKaydet.Enabled = false;

            guncellenecek = db.Products.Find(lstUrunler.SelectedItems[0].Tag);

            cmbKategori.SelectedValue = guncellenecek.CategoryID;
            txtUrunAdi.Text = guncellenecek.ProductName;
            nmrFiyat.Value = (decimal)guncellenecek.UnitPrice;
            nmrStokAdet.Value = (decimal)guncellenecek.UnitsInStock;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncellenecek.CategoryID = (int)cmbKategori.SelectedValue;
            guncellenecek.ProductName = txtUrunAdi.Text;
            guncellenecek.UnitPrice = nmrFiyat.Value;
            guncellenecek.UnitsInStock = (short)nmrStokAdet.Value;

            db.SaveChanges();

            Temizle();
            ProductList();

            btnKaydet.Enabled = true;
            btnGuncelle.Enabled = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItems.Count <= 0)
                return;

            Product silinecek = db.Products.Find(lstUrunler.SelectedItems[0].Tag);

            db.Products.Remove(silinecek);
            db.SaveChanges();

            ProductList();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            Hide();
            mainForm.Show();
        }
    }
}
