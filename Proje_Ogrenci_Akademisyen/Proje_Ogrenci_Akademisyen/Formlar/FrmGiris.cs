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

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("Select * From TblOgrenci Where OgrNumara=@p1 and OgrSifre=@p2", baglanti);
            kmt.Parameters.AddWithValue("@p1", MskdNum.Text);
            kmt.Parameters.AddWithValue("@p2", TxtSfr.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                FrmOgrenciPanel frm = new FrmOgrenciPanel();
                frm.numara = MskdNum.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Numaranız veya şifreniz hatalı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void MskdNum_TextChanged(object sender, EventArgs e)
        {
            if(MskdNum.Text == "00000" && TxtSfr.Text == "000")
            {
                FrmMenu frm = new FrmMenu();
                frm.Show();
                this.Hide();
            }
        }

        private void TxtSfr_TextChanged(object sender, EventArgs e)
        {
            if (TxtSfr.Text == "000" && MskdNum.Text == "00000")
            {
                FrmMenu frm = new FrmMenu();
                frm.Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
