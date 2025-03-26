using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciPanel : Form
    {
        public FrmOgrenciPanel()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        public string numara;
        int ogrenciid;
        private void FrmOgrenciPanel_Load(object sender, EventArgs e)
        {
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);
            MskdNum.Text = numara;
            TxtAd.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrAd).FirstOrDefault();
            TxtSyd.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrSoyad).FirstOrDefault();
            TxtMail.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrMail).FirstOrDefault();
            TxtSfr.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.OgrSifre).FirstOrDefault();
            CmbBlm.Text = db.TblOgrenci.Where(x=>x.OgrNumara == numara).Select(y=>y.TblBolum.BolumAd.ToString()).FirstOrDefault();

             ogrenciid = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrId).FirstOrDefault();

            var sinavnotlari = (from x in db.TblNotlar
                                select new
                                {
                                    x.TblDersler.DersAd,
                                    x.Sinav1,
                                    x.Sinav2,
                                    x.Sinav3,
                                    x.Quiz1,
                                    x.Quiz2,
                                    x.Proje,
                                    x.Ortalama,
                                    x.Ogrenci
                                }).Where(y=>y.Ogrenci == ogrenciid).ToList();
            dataGridView1.DataSource = sinavnotlari;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(txtYenis.Text == txtYenifr.Text)
            {
                var deger = db.TblOgrenci.Find(ogrenciid);
                deger.OgrSifre = txtYenis.Text;
                db.SaveChanges();
                MessageBox.Show("Şifre başarılı bir şekilde değiştirildi.");
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor");
            }
            
        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            if (e.RowIndex % 2 == 0) // Çift indeksli satırlar
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(2, 52, 63); // Açık mavi
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White; // Beyaz yazı rengi
            }
            else // Tek indeksli satırlar
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 237, 204); // Açık gri
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // Siyah yazı rengi
            }

        }
    }
}
