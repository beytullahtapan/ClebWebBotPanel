using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BotSettingManager : IBotSettingDal
    {
        IBotSettingDal _botSettingDal;

        public BotSettingManager(IBotSettingDal botSettingDal)
        {
            _botSettingDal = botSettingDal;
        }

        public void Delete(BotSetting t)
        {
            _botSettingDal.Delete(t);
        }

        public BotSetting GetById(int id)
        {
            return _botSettingDal.GetById(id);
        }

        public List<BotSetting> GetList()
        {
            return _botSettingDal.GetList();
        }

        public void Insert(BotSetting t)
        {
            _botSettingDal.Insert(t);
        }

        public void Update(BotSetting t)
        {
            _botSettingDal.Update(t);
        }
    }
}
