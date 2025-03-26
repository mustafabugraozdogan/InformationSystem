using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ogrenci_Akademisyen.Formlar
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDersListesi frm = new FrmDersListesi();
            frm.Show();
        }

        private void BtnBlm_Click(object sender, EventArgs e)
        {
            FrmBolumListesi frm = new FrmBolumListesi();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBolumler frm = new FrmBolumler();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmNotlar frm = new FrmNotlar();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenciKayit frm = new FrmOgrenciKayit();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmDers frm = new FrmDers();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Turkcell Geleceği Yazanlar Eğitimi Kapsamında hazırlanmıştır. Projemizde akademisyen için kullanıcı adı: 00000 şifre: 000 şeklindedir. Akademisyen panelinden öğrenci,ders,bölüm,notlar gibi tüm işler gerçekleştirilebilir. Sisteme giriş yapan öğrenciler sadece kendine ait notları ve bilgileri görebilir.","Yardım Penceresi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
