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

namespace YukleniciOtomasyon.WinUI
{
    public partial class frmyanMalzemeBilgisi_Listele : Form
    {
        T_MalzemeService _malzemeService;
        T_MalzemeFiyatService _malzemeFiyatService;

        T_Malzeme _malzeme;
        T_MalzemeFiyat _malzemeFiyati;
        public frmyanMalzemeBilgisi_Listele()
        {
            InitializeComponent();
            _malzemeService = new T_MalzemeService();
            _malzemeFiyatService = new T_MalzemeFiyatService();
            _malzeme = new T_Malzeme();
            _malzemeFiyati = new T_MalzemeFiyat();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool move;
        int mouse_x;
        int mouse_y;

        private void frmMalzemeBilgisi_Listele_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void frmMalzemeBilgisi_Listele_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void frmMalzemeBilgisi_Listele_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
        public void MalzemeListele()
        {
            dgvMalzemeListele.DataSource = null;
            List<T_Malzeme> malzemeListesi = _malzemeService.TumMalzemeleriGetirService();
            dgvMalzemeListele.DataSource = malzemeListesi;
        }
        private void frmyanMalzemeBilgisi_Listele_Load(object sender, EventArgs e)
        {
            if (Tag !=null)
            {
                _malzeme = (T_Malzeme)Tag;
            }
            MalzemeListele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _malzeme.MalzemeAdi = txtMalzemeAdi.Text;
            _malzeme.Tur = txtMalzemeTuru.Text;
            _malzeme.Adet = Convert.ToDecimal(txtMalzemeAdedi.Text);
            _malzeme.AdetTip = txtMalzemeAdetTipi.Text;
            _malzeme.En = Convert.ToDecimal(txtMalzemeEni.Text);
            _malzeme.Boy = Convert.ToDecimal(txtMalzemeBoyu.Text);
            _malzeme.Derinlik = Convert.ToDecimal(txtMalzemeDerinligi.Text);
            _malzeme.Agirlik = Convert.ToDecimal(txtMalzemeAgirligi.Text);
            _malzemeFiyati.BirimFiyat = Convert.ToDecimal(txtMalzemeFiyati.Text);

            dgvMalzemeListele.DataSource = _malzemeService.AddMalzemeService(_malzeme);
            dgvMalzemeListele.DataSource = _malzemeFiyatService.AddMalzemeFiyatService(_malzemeFiyati);
        }
        int seciliMalzeme;
        private void dgvMalzemeListele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvMalzemeListele.RowCount; i++)
            {
                bool seciliCheckbox = (bool)dgvMalzemeListele.Rows[i].Cells[0].Value;
                if (seciliCheckbox == true)
                {
                    seciliMalzeme = Convert.ToInt32(dgvMalzemeListele.SelectedRows[0].Cells[1].Value);
                    _malzeme = _malzemeService.BirMalzemeGetirService(seciliMalzeme);
                    _malzemeFiyati = _malzemeFiyatService.MalzemeFiyatiGetirService(seciliMalzeme);
                }
            }
        }
        private void btnDuzenleMalzemeOzellik_Click(object sender, EventArgs e)
        {
            txtMalzemeAdi.Text = _malzeme.MalzemeAdi;
            txtMalzemeTuru.Text = _malzeme.Tur;
            txtMalzemeAdedi.Text = _malzeme.Adet.ToString();
            txtMalzemeAdetTipi.Text = _malzeme.AdetTip;
            txtMalzemeEni.Text = _malzeme.En.ToString();
            txtMalzemeBoyu.Text = _malzeme.Boy.ToString();
            txtMalzemeDerinligi.Text = _malzeme.Derinlik.ToString();
            txtMalzemeAgirligi.Text = _malzeme.Agirlik.ToString();
            txtMalzemeFiyati.Text = _malzemeFiyati.BirimFiyat.ToString();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dgvMalzemeListele.DataSource = null;
            dgvMalzemeListele.DataSource = _malzemeService.UpdateMalzemeService(_malzeme);
            dgvMalzemeListele.DataSource = _malzemeFiyatService.UpdateMalzemeFiyatService(_malzemeFiyati);
        }
        private void txtMalzemeAdiAra_TextChanged(object sender, EventArgs e)
        {
            dgvMalzemeListele.DataSource = null;
            List<T_Malzeme> malzemeListesi = _malzemeService.MalzemeAraService(txtMalzemeAdi.Text);
            dgvMalzemeListele.DataSource = malzemeListesi;
        }


        private void btnSilMalzemeOzellik_Click(object sender, EventArgs e)
        {
            dgvMalzemeListele.DataSource = null;
            dgvMalzemeListele.DataSource = _malzemeService.DeleteMalzemeService(_malzeme);
            dgvMalzemeListele.DataSource = _malzemeFiyatService.DeleteMalzemeFiyatService(_malzemeFiyati);
        }

        private void btnKapat_MouseHover(object sender, EventArgs e)
        {
            lblOncekiFormaGit.Visible = true;
        }

        private void btnKapat_MouseLeave(object sender, EventArgs e)
        {
            lblOncekiFormaGit.Visible = false;
        }

        private void btnGuncelle_MouseHover(object sender, EventArgs e)
        {
            lblGuncelle.Visible = true;
        }

        private void btnGuncelle_MouseLeave(object sender, EventArgs e)
        {
            lblGuncelle.Visible = false;
        }

        private void btnKaydet_MouseHover(object sender, EventArgs e)
        {
            lblKaydet.Visible = true;
        }

        private void btnKaydet_MouseLeave(object sender, EventArgs e)
        {
            lblKaydet.Visible = false;
        }

        private void btnSilMalzemeOzellik_MouseHover(object sender, EventArgs e)
        {
            lblSilMalzemeOzellik.Visible = true;
        }

        private void btnSilMalzemeOzellik_MouseLeave(object sender, EventArgs e)
        {
            lblSilMalzemeOzellik.Visible = false;
        }

        private void btnDuzenleMalzemeOzellik_MouseHover(object sender, EventArgs e)
        {
            lblDuzenleMalzemeOzellik.Visible = true;
        }

        private void btnDuzenleMalzemeOzellik_MouseLeave(object sender, EventArgs e)
        {
            lblDuzenleMalzemeOzellik.Visible = false;
        }
    }
}
