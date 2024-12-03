using LapShop.Models;

namespace LapShop.Bl
{
    public interface IItemImages
    {
        public List<TbItemImage> GetByItemId(int id);
    }

    public class ClsItemImages : IItemImages
    {
        LapShopContext context;
        public ClsItemImages(LapShopContext ctx)
        {
            context = ctx;
        }

        public List<TbItemImage> GetByItemId(int id)
        {
            try
            {
                var item = context.TbItemImages.Where(a => a.ItemId == id).ToList();
                return item;
            }
            catch
            {
                return new List<TbItemImage>();
            }
        }
    }
}
