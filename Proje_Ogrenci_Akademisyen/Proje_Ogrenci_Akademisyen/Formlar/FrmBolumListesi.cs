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
    public partial class FrmBolumListesi : Form
    {
        public FrmBolumListesi()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void FrmBolumListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TblBolum
                           select new
                           {
                               x.BolumId,
                               x.BolumAd
                           };
            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);


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
