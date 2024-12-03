using LapShop.Models;
namespace LapShop.Bl
{
    public interface ISettings
    {
        public TbSettings GetAll();
        public bool Save(TbSettings setting);
    }

    public class ClsSettings : ISettings
    {
        LapShopContext context;
        public ClsSettings(LapShopContext ctx)
        {
            context = ctx;
        }
        public TbSettings GetAll()
        {
            try
            {
                var lstCategories = context.TbSettings.FirstOrDefault();
                return lstCategories;
            }
            catch
            {
                return new TbSettings();
            }
        }

        public bool Save(TbSettings setting)
        {
            try
            {
                context.Entry(setting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
