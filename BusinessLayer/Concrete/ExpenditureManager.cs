using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExpenditureManager : IExpenditureDal
    {
        IExpenditureDal _expenditureDal;

        public ExpenditureManager(IExpenditureDal expenditureDal)
        {
            _expenditureDal = expenditureDal;
        }

        public void Delete(Expenditure t)
        {
            _expenditureDal.Delete(t);
        }

        public Expenditure GetById(int id)
        {
            return _expenditureDal.GetById(id);
        }

        public List<Expenditure> GetList()
        {
            return _expenditureDal.GetList();
        }

        public void Insert(Expenditure t)
        {
            _expenditureDal.Insert(t);
        }

        public void Update(Expenditure t)
        {
            _expenditureDal.Update(t);
        }
    }
}
