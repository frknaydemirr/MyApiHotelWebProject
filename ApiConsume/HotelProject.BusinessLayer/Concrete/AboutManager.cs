using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System.Collections.Generic;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    // Constructor eklenmeli!
    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void TDelete(About t)
    {
        _aboutDal.Delete(t);
    }

    public About TGetById(int id)
    {
        return _aboutDal.GetById(id);
    }

    public List<About> TGetList()
    {
        return _aboutDal.GetList();
    }

    public void TInsert(About t)
    {
        _aboutDal.Insert(t);
    }

    public void TUpdate(About t)
    {
        _aboutDal.Update(t);
    }
}
