using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YukleniciOtomasyon.BLL.YukleniciOtomasyonServices.TanimTablolari;
using YukleniciOtomasyon.Entities.Model.TanimTablolari;

namespace YukleniciOtomasyon.WinUI.SatinAlma
{
    public partial class frmyanTedarikciFirma_Listele : Form
    {
        T_TedarikciFirmaService _tedarikciFirmaService;
        T_TedarikciFirma _tedarikciFirma;

        int seciliFirma;
        public frmyanTedarikciFirma_Listele()
        {
            InitializeComponent();
            _tedarikciFirmaService = new T_TedarikciFirmaService();
            _tedarikciFirma = new T_TedarikciFirma();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void TedarikciFirma()
        {
            dgvFirmaListele.DataSource = null;
            List<T_TedarikciFirma> tedarikciFirma = _tedarikciFirmaService.TumTedarikciFirmalariGetirService();
            dgvFirmaListele.DataSource = tedarikciFirma;
        }
        private void frmyanTedarikciFirma_Listele_Load(object sender, EventArgs e)
        {
            TedarikciFirma();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _tedarikciFirma.Ad = txtFirmaAdi.Text;
            _tedarikciFirma.Telefon = txtFirmaTelefonu.Text;
            _tedarikciFirma.EMail = txtFirmaMail.Text;
            _tedarikciFirma.Adres = txtFirmaAdresi.Text;

            dgvFirmaListele.DataSource = _tedarikciFirmaService.AddTedarikciFirmaService(_tedarikciFirma);
        }

        private void dgvFirmaListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvFirmaListele.RowCount; i++)
            {
                bool seciliCheckbox = (bool)dgvFirmaListele.Rows[i].Cells[0].Value;
                if (seciliCheckbox == true)
                {
                    seciliFirma = Convert.ToInt32(dgvFirmaListele.SelectedRows[0].Cells[1].Value);
                    _tedarikciFirma = _tedarikciFirmaService.BirTedarikciFirmaGetirService(seciliFirma);
                }
            }
        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            txtFirmaAdi.Text = _tedarikciFirma.Ad;
            txtFirmaTelefonu.Text = _tedarikciFirma.Telefon;
            txtFirmaMail.Text = _tedarikciFirma.EMail;
            txtFirmaAdresi.Text = _tedarikciFirma.Adres;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dgvFirmaListele.DataSource = null;
            dgvFirmaListele.DataSource = _tedarikciFirmaService.UpdateTedarikciFirmaService(_tedarikciFirma);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            dgvFirmaListele.DataSource = null;
            dgvFirmaListele.DataSource = _tedarikciFirmaService.DeleteTedarikciFirmaService(_tedarikciFirma);
        }

        private void btnKapat_MouseHover(object sender, EventArgs e)
        {
            lblOncekiFormaGit.Visible = true;
        }

        private void btnKapat_MouseLeave(object sender, EventArgs e)
        {
            lblOncekiFormaGit.Visible = false;
        }

        private void btnKaydet_MouseHover(object sender, EventArgs e)
        {
            lblKaydet.Visible = true;
        }

        private void btnKaydet_MouseLeave(object sender, EventArgs e)
        {
            lblKaydet.Visible = false;
        }

        private void btnGuncelle_MouseHover(object sender, EventArgs e)
        {
            lblguncelle.Visible = true;
        }

        private void btnGuncelle_MouseLeave(object sender, EventArgs e)
        {
            lblguncelle.Visible = false;
        }

        private void btnDuzenle_MouseHover(object sender, EventArgs e)
        {
            lblDuzenle.Visible = true;
        }

        private void btnDuzenle_MouseLeave(object sender, EventArgs e)
        {
            lblDuzenle.Visible = false;
        }

        private void btnSil_MouseHover(object sender, EventArgs e)
        {
            lblSil.Visible = true;
        }

        private void btnSil_MouseLeave(object sender, EventArgs e)
        {
            lblSil.Visible = false;
        }
    }
}
