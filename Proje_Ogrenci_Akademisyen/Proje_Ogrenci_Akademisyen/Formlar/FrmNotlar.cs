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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            CmbDr.ValueMember = "DersID";
            CmbDr.DisplayMember = "DersAd";
            CmbDr.DataSource = db.TblDersler.ToList();
            comboBox1.ValueMember = "DersID";
            comboBox1.DisplayMember = "DersAd";
            comboBox1.DataSource = db.TblDersler.ToList();
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblNotlar t = new TblNotlar();
            t.Sinav1 = byte.Parse(TxtS1.Text);
            t.Sinav2 = byte.Parse(TxtS2.Text);
            t.Sinav3 = byte.Parse(TxtS3.Text);
            t.Proje = byte.Parse(TxtPr.Text);
            t.Quiz1 = byte.Parse(Txtq1.Text);
            t.Quiz2= byte.Parse(TxtQ2.Text);
            t.Ders = int.Parse(CmbDr.SelectedValue.ToString());
            t.Ogrenci = int.Parse(TxtOgr.Text);
            db.TblNotlar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci not bilgisi sisteme girildi");
        }

        private void BtnHesap_Click(object sender, EventArgs e)
        {
            byte s1, s2, s3, q1, q2, proje;
            double ort;
            s1 = Convert.ToByte(TxtS1.Text);
            s2 = Convert.ToByte(TxtS2.Text);
            s3 = Convert.ToByte(TxtS3.Text);
            q1 = Convert.ToByte(Txtq1.Text);
            q2 = Convert.ToByte(TxtQ2.Text);
            proje = Convert.ToByte(TxtPr.Text);
            ort = (s1 + s2 + s3 + q1 + q2 + proje) / 6;
            txtort.Text = ort.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.View_1.ToList();
            dataGridView1.DataSource = db.Notlar3();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.TblDersler.DersAd,
                               Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ders,
                           };
            int d = int.Parse(comboBox1.SelectedValue.ToString());
            dataGridView1.DataSource = degerler.Where(y=>y.Ders==d).ToList();
            dataGridView1.Columns["Ders"].Visible = false;
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.TblDersler.DersAd,
                               Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ogrenci,
                           };
            int i=int.Parse(MskdNum.Text);
            dataGridView1.DataSource=degerler.Where(y=> y.Ogrenci==i).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;
        }

        private void BtnAra2_Click(object sender, EventArgs e)
        {
            string no = MskdNum.Text;
            var deger = db.TblOgrenci.Where(x => x.OgrNumara == no).Select(y=>y.OgrId).FirstOrDefault();
           //txtid.Text = deger.ToString();
            var notlar = from x in db.TblNotlar
                         select new
                         {

                             x.NotID,
                             x.TblDersler.DersAd,
                             Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                             x.Sinav1,
                             x.Sinav2,
                             x.Sinav3,
                             x.Quiz1,
                             x.Quiz2,
                             x.Proje,
                             x.Ortalama,
                             x.Ogrenci,
                         };

            dataGridView1.DataSource=notlar.Where(z=>z.Ogrenci == deger).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var x = db.TblNotlar.Find(id);
            x.Sinav1 = int.Parse(TxtS1.Text);
            x.Sinav2 = int.Parse(TxtS2.Text);
            x.Sinav3 = int.Parse(TxtS3.Text);
            x.Quiz1 = int.Parse(Txtq1.Text);
            x.Quiz2 = int.Parse(TxtQ2.Text);
            x.Proje = int.Parse(TxtPr.Text);
            x.Ortalama = int.Parse(txtort.Text);
            db.SaveChanges();

            MessageBox.Show("Öğrenci notları güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtS1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtS2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtS3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Txtq1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtQ2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtort.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            TxtPr.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            // txtort.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            //CmbDr.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
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
