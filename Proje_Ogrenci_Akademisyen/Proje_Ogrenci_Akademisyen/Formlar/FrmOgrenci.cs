using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        void listele()
        {
            var degerler = from x in db.TblOgrenci
                           select new
                           {
                               x.OgrId,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrMail,
                               x.OgrBolum,
                               x.TblBolum.BolumAd,
                               x.OgrDurum
                           };
            dataGridView1.DataSource = degerler.Where(x => x.OgrDurum == true).ToList();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TblBolum", baglanti);
            //SqlDataReader dr = komut.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            CmbBlm.ValueMember = "BolumId";
            CmbBlm.DisplayMember = "BolumAd";
            CmbBlm.DataSource = ds;
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSyd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            MskdNum.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSfr.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            CmbBlm.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var x = db.TblOgrenci.Find(id);
            x.OgrDurum = false;
            db.SaveChanges();
            MessageBox.Show("Öğrenci sistemden silindi, silinen öğrencileri pasif öğrenciler listesi üzerinden görebilirsiniz.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var x = db.TblOgrenci.Find(id);
            x.OgrAd = TxtAd.Text;
            x.OgrSoyad = TxtSyd.Text;
            x.OgrNumara = MskdNum.Text;
            x.OgrMail = TxtMail.Text;
            x.OgrSifre = TxtSfr.Text;
            x.OgrBolum = int.Parse(CmbBlm.SelectedValue.ToString());
            db.SaveChanges();

            MessageBox.Show("Öğrenci bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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
