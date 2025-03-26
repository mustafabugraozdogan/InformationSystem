using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Proje_Ogrenci_Akademisyen.Entity;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmOgrenciKayit : Form
    {
        public FrmOgrenciKayit()
        {
            InitializeComponent();
        }
        //Data Source=LENOVO\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True;Trust Server Certificate=True
        SqlConnection baglanti = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");

        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TblBolum",baglanti);
            //SqlDataReader dr = komut.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable();
            da.Fill(ds);
            CmbBlm.ValueMember = "BolumId";
            CmbBlm.DisplayMember = "BolumAd";
            CmbBlm.DataSource = ds;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //textBox1.Text = comboBox1.SelectedValue.ToString();
            if(TxtSfr.Text == TxtSt.Text)
            {
                TblOgrenci t = new TblOgrenci();
                t.OgrAd = TxtAd.Text;
                t.OgrSoyad = TxtSyd.Text;
                t.OgrNumara = MskdNu.Text;
                t.OgrBolum = int.Parse(CmbBlm.SelectedValue.ToString());
                t.OgrSifre = TxtSfr.Text;
                t.OgrSifre = TxtSt.Text;
                t.OgrMail = TxtMail.Text;
                db.TblOgrenci.Add(t);
                db.SaveChanges();
                MessageBox.Show("Öğrenci bilgileri sisteme başarılı bir şekilde kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Şifreler Uyuşmuyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
    }
}
