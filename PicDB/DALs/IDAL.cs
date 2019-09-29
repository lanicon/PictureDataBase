using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicDB.Models;

namespace PicDB.DALs
{
    public interface IDAL
    {
        void initialize();

        List<PictureModel> getPictures();
        List<PhotographerModel> getPhotographerList();
        PictureModel getPicture(int ID);
        EXIFModel getExif(int ID);
        IPTCModel GetIPTC(int ID);
        void save(PictureModel p);
        void delete(PictureModel p);
        void SaveIPTC(int id, IPTCModel iptc);
        PhotographerModel getPhotographer(int ID);
        PhotographerModel getPhotographerOfPicture(int pictureId);
        void SavePhotographer(int id, PhotographerModel photographer);
        void SaveNewPhotographer(PhotographerModel photographer);
    }
}
