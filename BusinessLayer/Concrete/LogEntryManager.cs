using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LogEntryManager : ILogEntryDal
    {
        ILogEntryDal _logEntryDal;

        public LogEntryManager(ILogEntryDal logEntryDal)
        {
            _logEntryDal = logEntryDal;
        }

        public void Delete(LogEntry t)
        {
            _logEntryDal.Delete(t);
        }

        public LogEntry GetById(int id)
        {
            return _logEntryDal.GetById(id);
        }

        public List<LogEntry> GetList()
        {
            return _logEntryDal.GetList();
        }

        public void Insert(LogEntry t)
        {
            _logEntryDal.Insert(t);
        }

        public void Update(LogEntry t)
        {
            _logEntryDal.Update(t);
        }
    }
}
