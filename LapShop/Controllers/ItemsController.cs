using Microsoft.AspNetCore.Mvc;
using LapShop.Bl;
using LapShop.Models;
namespace LapShop.Controllers
{
    public class ItemsController : Controller
    {
        IItems oItem;
        IItemImages oItemImages;
        public ItemsController(IItems iItem, IItemImages oItemImages)
        {
            oItem = iItem;
            this.oItemImages = oItemImages;
        }

        public IActionResult ItemDetails(int id)
        {
            var item =oItem.GetItemId(id);

            VmItemDetails vm = new VmItemDetails();
            vm.Item = item;
            vm.lstRecommendedItems = oItem.GetRecommendedItems(id).Take(20).ToList();
            vm.lstItemImages=oItemImages.GetByItemId(id);
            return View(vm);
        }

        public IActionResult ItemList()
        {
            return View();
        }
    }
}
