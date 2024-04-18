using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SafeBoxManager : ISafeBoxDal
    {
        ISafeBoxDal _safeBoxDal;

        public SafeBoxManager(ISafeBoxDal safeBoxDal)
        {
            _safeBoxDal = safeBoxDal;
        }

        public void Delete(SafeBox t)
        {
            _safeBoxDal.Delete(t);
        }

        public SafeBox GetById(int id)
        {
            return _safeBoxDal.GetById(id);
        }

        public List<SafeBox> GetList()
        {
            return _safeBoxDal.GetList();
        }

        public void Insert(SafeBox t)
        {
            _safeBoxDal.Insert(t);
        }

        public void Update(SafeBox t)
        {
            _safeBoxDal.Update(t);
        }
    }
}
