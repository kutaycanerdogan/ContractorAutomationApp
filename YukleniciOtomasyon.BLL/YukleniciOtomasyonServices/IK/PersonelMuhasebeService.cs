using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YukleniciOtomasyon.DAL.RepositoryConcrete.IK;
using YukleniciOtomasyon.Entities.Model.IK;

namespace YukleniciOtomasyon.BLL.YukleniciOtomasyonServices.IK
{
    public class PersonelMuhasebeService
    {
        PersonelMuhasebeRepository _personelMuhasebeRepository;
        public PersonelMuhasebeService()
        {
            _personelMuhasebeRepository = new PersonelMuhasebeRepository();
        }


        public int AddPersonelMuhasebeService(PersonelMuhasebe personelMuhasebe)
        {
            try
            {
                return _personelMuhasebeRepository.AddItem(personelMuhasebe);
            }
            catch (Exception e)
            {
                MessageBox.Show("Hata : " + e.Message);
                throw;
            }
        }
        public int DeletePersonelMuhasebeService(PersonelMuhasebe personelMuhasebe)
        {
            try
            {
                return _personelMuhasebeRepository.DeleteItem(personelMuhasebe);
            }
            catch (Exception e)
            {
                MessageBox.Show("Hata: "+e.Message);
                throw;
            }            
        }

        public List<PersonelMuhasebe> TumPersonelMuhasebeleriGetirService()
        {
            try
            {
                return _personelMuhasebeRepository.GetAll().ToList();

            }
            catch (Exception e)
            {
                MessageBox.Show("Hata: " + e.Message);
                throw;
            }
        }

        public PersonelMuhasebe PersonelMuhasebeGetirService(int id)
        {
            try
            {
                return _personelMuhasebeRepository.GetById(id);

            }
            catch (Exception e)
            {
                MessageBox.Show("Hata: "+e.Message);
                throw;
            }
        }

        public int UpdatePersonelMuhasebeService(PersonelMuhasebe personelMuhasebe)
        {
            try
            {
                return _personelMuhasebeRepository.UpdateItem(personelMuhasebe);
            }
            catch (Exception e)
            {
                MessageBox.Show("Hata: "+e.Message);
                throw;
            }
        }
    }
}
