
namespace LapShop.Models
{
    public class VmHomePage
    {
        public VmHomePage()
        {
            lstAllItems = new List<VwItem>();
            lstRecommendedItems = new List<VwItem>();
            lstNewItems = new List<VwItem>();
            lstFreeDelivry = new List<VwItem>();
            lstCategories = new List<TbCategory>();
        }
        public List<VwItem> lstAllItems { get; set; }
        public List<VwItem> lstRecommendedItems { get; set; }
        public List<VwItem> lstNewItems { get; set; }
        public List<VwItem> lstFreeDelivry { get; set; }
        public List<TbCategory> lstCategories { get; set; }
        public List<TbSlider> lstSliders { get; set; }
        public TbSettings Settings { get; set; }
    }
}
