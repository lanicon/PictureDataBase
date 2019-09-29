using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicDB.Models;

namespace PicDB.DALs
{
    public class MockDAL : IDAL
    {
        public void delete(PictureModel p)
        {
            throw new NotImplementedException();
        }

        public EXIFModel getExif(int ID)
        {
            throw new NotImplementedException();
        }

        public IPTCModel GetIPTC(int ID)
        {
            throw new NotImplementedException();
        }

        public PhotographerModel getPhotographer(int ID)
        {
            throw new NotImplementedException();
        }

        public List<PhotographerModel> getPhotographerList()
        {
            throw new NotImplementedException();
        }

        public PhotographerModel getPhotographerOfPicture(int pictureId)
        {
            throw new NotImplementedException();
        }

        public PictureModel getPicture(int ID)
        {
            throw new NotImplementedException();
        }

        public List<PictureModel> GetPictures()
        {
            throw new NotImplementedException();
        }

        public List<PictureModel> getPictures()
        {
            throw new NotImplementedException();
        }

        public void initialize()
        {
            throw new NotImplementedException();
        }

        public void save(PictureModel p)
        {
            throw new NotImplementedException();
        }

        public void SaveIPTC(int id, IPTCModel iptc)
        {
            throw new NotImplementedException();
        }

        public void SaveNewPhotographer(PhotographerModel photographer)
        {
            throw new NotImplementedException();
        }

        public void SavePhotographer(int id, PhotographerModel photographer)
        {
            throw new NotImplementedException();
        }
    }
}
