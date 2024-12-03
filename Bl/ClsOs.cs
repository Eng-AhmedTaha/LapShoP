using LapShop.Models;
namespace LapShop.Bl
{
    public interface IOs
    {
        public List<TbO> GetAll();
        public TbO GetById(int id);
        public bool Save(TbO os);
        public bool Dekete(int id);
    }

    public class ClsOs : IOs
    {
        LapShopContext context;
        public ClsOs(LapShopContext ctx)
        {
            context = ctx;
        }
        public List<TbO> GetAll()
        {
            try
            {
                var lstCategories = context.TbOs.Where(a=>a.CurrentState==1).ToList();
                return lstCategories;
            }
            catch
            {
                return new List<TbO>();
            }
        }

        public TbO GetById(int id)
        {
            try
            {
                var os = context.TbOs.FirstOrDefault(a => a.OsId == id && a.CurrentState==1);
                return os;
            }
            catch
            {
                return new TbO();
            }
        }

        public bool Save(TbO os)
        {
            try
            {
                if (os.OsId == 0)
                {
                    os.CreatedBy = "1";
                    os.CreatedDate = DateTime.Now;
                    context.TbOs.Add(os);
                }
                else
                {
                    os.UpdatedBy = "1";
                    os.UpdatedDate = DateTime.Now;
                    context.Entry(os).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Dekete(int id)
        {
            try
            {
                var os = GetById(id);
                os.CurrentState = 0;
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
