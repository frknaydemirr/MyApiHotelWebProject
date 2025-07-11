using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {

        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        //dependency injection uyguladık!
        public void TDelete(Subcribe t)
        {
             _subscribeDal.Delete(t);
        }

        public Subcribe TGetById(int id)
        {
            return _subscribeDal.GetById(id);
        }

        public List<Subcribe> TGetList()
        {
            return _subscribeDal.GetList();
        }

        public void TInsert(Subcribe t)
        {
             _subscribeDal.Insert(t);
        }

        public void TUpdate(Subcribe t)
        {
            _subscribeDal.Update(t);
        }
    }
}
