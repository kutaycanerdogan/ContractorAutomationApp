using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YukleniciOtomasyon.BLL.YukleniciOtomasyonServices.SatinAlma;
using YukleniciOtomasyon.Entities.Model.SatinAlma;

namespace YukleniciOtomasyon.WinUI.SatinAlma
{
    public partial class frmSatinAlmaBirimi : Form
    {
        SatinAlmalarService _satinAlmalarService;

        public frmSatinAlmaBirimi()
        {
            InitializeComponent();
            _satinAlmalarService = new SatinAlmalarService();
        }

        SatinAlmalar _satinAlmalar;

        public void SatinAlmaGetir()
        {
            dgvSatinAlmalariListele.DataSource = null;
            List<SatinAlmalar> satinAlmaListesi = _satinAlmalarService.TumSatinAlmalariGetirService();
            dgvSatinAlmalariListele.DataSource = satinAlmaListesi;
        }
        private void frmSatinAlmaBirimi_Load(object sender, EventArgs e)
        {
            SatinAlmaGetir();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void btnEkle_Click(object sender, EventArgs e)
        {
            frmyanSatinAlmaListele satinAlma = new frmyanSatinAlmaListele();
            satinAlma.Show();
        }

        public void btnGuncelle_Click(object sender, EventArgs e)
        {
            frmyanSatinAlmaListele satinAlma = new frmyanSatinAlmaListele();
            satinAlma.Tag = _satinAlmalar;
            satinAlma.Show();
        }
        private void txtPersonelAdiSoyadi_TextChanged(object sender, EventArgs e)
        {
            dgvSatinAlmalariListele.DataSource = null;
            List<SatinAlmalar> satinAlmaListesi = _satinAlmalarService.SatinAlmaAraService(txtPersonelAdiSoyadi.Text);
            dgvSatinAlmalariListele.DataSource = satinAlmaListesi;
        }

        private void dtpIsBaslangicTarihi_ValueChanged(object sender, EventArgs e)
        {
            dgvSatinAlmalariListele.DataSource = null;
            List<SatinAlmalar> satinAlmaListesi = _satinAlmalarService.SatinAlmaTarihAraService(dtpIlkTarih.Value, dtpSonTarih.Value);
            dgvSatinAlmalariListele.DataSource = satinAlmaListesi;
        }
        private void dgvSatinAlmalariListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSatinAlmalariListele.SelectedRows[0].DataBoundItem != null)
            {
                int seciliSatinAlma = Convert.ToInt32(dgvSatinAlmalariListele.SelectedRows[0].Cells[1].Value);
                _satinAlmalar = _satinAlmalarService.BirSatinAlmaGetirService(seciliSatinAlma);
            }

            /*
            for (int i = 0; i < dgvSatinAlmalariListele.RowCount; i++)
            {
                bool seciliCheckbox = (bool)dgvSatinAlmalariListele.Rows[i].Cells[0].Value;
                if (seciliCheckbox == true)
                {
                    
                }
            }*/

        }

        private void frmSatinAlmaBirimi_Load_1(object sender, EventArgs e)
        {
            dgvSatinAlmalariListele.DataSource = null;
            List<SatinAlmalar> satinAlmaListesi = _satinAlmalarService.TumSatinAlmalariGetirService();
            dgvSatinAlmalariListele.DataSource = satinAlmaListesi;
        }
    }
}
