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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProjeContext db;

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new ProjeContext();
            CategoryList();
        }

        void CategoryList()
        {
            lstKategoriler.Items.Clear();

            foreach (Category kategori in db.Categories.ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = kategori.ID.ToString();
                lvi.SubItems.Add(kategori.CategoryName);
                lvi.SubItems.Add(kategori.Description);

                lstKategoriler.Items.Add(lvi);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            db.Categories.Add(new Category()
            {
                CategoryName = txtKategoriAdi.Text,
                Description = txtAciklama.Text
            });
            db.SaveChanges();

            txtKategoriAdi.Text = string.Empty;
            txtAciklama.Text = string.Empty;

            CategoryList();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            this.Hide();
            Urunler frm = new Urunler();
            frm.Show();
        }
    }
}
