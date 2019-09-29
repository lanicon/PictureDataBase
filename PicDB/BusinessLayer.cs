using PicDB.DALs;
using PicDB.Models;
using System;
using System.Collections.Generic;

namespace PicDB
{
    public class BusinessLayer
    {
        private IDAL _dal;

        public BusinessLayer()
        {
            _dal = DALFactory.getDAL();
        }

        public PictureModel getPicture(int ID)
        {
            return _dal.getPicture(ID);
        }

        public List<PictureModel> getPictureList()
        {
            return _dal.getPictures();
        }

        public EXIFModel getExif(int ID)
        {
            return _dal.getExif(ID);
        }

        public IPTCModel getIptc(int ID)
        {
            return _dal.GetIPTC(ID);
        }

        public void SaveIptc(int id, IPTCModel iptc)
        {
            _dal.SaveIPTC(id, iptc);
        }

        public PhotographerModel getPhotographer(int ID)
        {
            return _dal.getPhotographer(ID);
        }

        public PhotographerModel getPhotographerOfPicture(int pictureId)
        {
            return _dal.getPhotographerOfPicture(pictureId);
        }

        public List<PhotographerModel> getPhotographerList()
        {
            return _dal.getPhotographerList();
        }

        public void SavePhotographer(int id, PhotographerModel photographer)
        {
            _dal.SavePhotographer(id, photographer);
        }

        public void SaveNewPhotographer(PhotographerModel pm)
        {
            _dal.SaveNewPhotographer(pm);
        }
    }
}
