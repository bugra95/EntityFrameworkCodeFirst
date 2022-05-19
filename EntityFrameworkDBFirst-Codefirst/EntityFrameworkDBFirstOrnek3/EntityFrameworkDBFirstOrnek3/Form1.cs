using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *  SQL Komutları:
 *  
    create database TelefonRehberi

    use TelefonRehberi

    create table Kisiler(
	    ID int not null primary key identity(1,1),
	    Ad nvarchar(24) not null,
	    Soyad nvarchar(24),
	    Telefon nvarchar(24)
    ) 
*/

namespace EntityFrameworkDBFirstOrnek3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TelefonRehberiEntities db;

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new TelefonRehberiEntities();

            btnGuncelle.Enabled = false;
            KisileriDoldur();
        }

        void KisileriDoldur()
        {
            lstKisiler.Items.Clear();

            foreach (Kisiler item in db.Kisilers.ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ID.ToString();
                lvi.SubItems.Add(item.Ad);
                lvi.SubItems.Add(item.Soyad);
                lvi.SubItems.Add(item.Telefon);
                lvi.Tag = item;

                lstKisiler.Items.Add(lvi);
            }
        }

        void Temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelefon.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            db.Kisilers.Add(new Kisiler()
            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                Telefon = txtTelefon.Text
            });

            bool sonuc = db.SaveChanges() > 0;

            MessageBox.Show(sonuc ? "Kişi rehbere başarıyla kaydedildi." : "Kayıt işlemi esnasında bir hata meydana geldi!");

            Temizle();
            KisileriDoldur();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            KisiAra(txtAra.Text);
        }

        void KisiAra(string aranacak)
        {
            lstKisiler.Items.Clear();

            foreach (Kisiler item in db.Kisilers.Where(kisi => kisi.Ad.StartsWith(aranacak) || kisi.Soyad.StartsWith(aranacak)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ID.ToString();
                lvi.SubItems.Add(item.Ad);
                lvi.SubItems.Add(item.Soyad);
                lvi.SubItems.Add(item.Telefon);
                lvi.Tag = item;

                lstKisiler.Items.Add(lvi);
            }
        }

        private void tsmSil_Click(object sender, EventArgs e)
        {
            if (lstKisiler.SelectedItems.Count <= 0)
                return;
            
            db.Kisilers.Remove(lstKisiler.SelectedItems[0].Tag as Kisiler);
            db.SaveChanges();

            KisileriDoldur();
        }

        Kisiler guncellenecek;
        private void tsmGuncelle_Click(object sender, EventArgs e)
        {
            if (lstKisiler.SelectedItems.Count <= 0)
                return;

            btnGuncelle.Enabled = true;
            btnKaydet.Enabled = false;

            guncellenecek = lstKisiler.SelectedItems[0].Tag as Kisiler;

            txtAd.Text = guncellenecek.Ad;
            txtSoyad.Text = guncellenecek.Soyad;
            txtTelefon.Text = guncellenecek.Telefon;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncellenecek.Ad = txtAd.Text;
            guncellenecek.Soyad = txtSoyad.Text;
            guncellenecek.Telefon = txtTelefon.Text;

            db.SaveChanges();
            MessageBox.Show("Kayıt güncellenmiştir...");

            btnKaydet.Enabled = true;
            btnGuncelle.Enabled = false;

            Temizle();
            KisileriDoldur();
        }
    }
}
