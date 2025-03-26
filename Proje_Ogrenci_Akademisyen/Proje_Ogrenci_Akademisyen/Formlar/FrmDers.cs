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
    public partial class FrmDers : Form
    {
        public FrmDers()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtDersAd.Text == "")
            {
                errorProvider1.SetError(TxtDersAd, "Ders adı boş geçilemez!");
            }
            else
            {
                TblDersler t = new TblDersler();
                t.DersAd = TxtDersAd.Text;
                db.TblDersler.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ders başarılı bir şekilde eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
