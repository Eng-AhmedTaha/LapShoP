using Microsoft.AspNetCore.Mvc;
using LapShop.Bl;
using LapShop.Models;
using LapShop.Utlities;
using Microsoft.AspNetCore.Authorization;

namespace LapShop.Areas.admin.Controllers
{
    [Authorize(Roles ="Admin,data entry")]
    [Area("admin")]
    public class ItemsController : Controller
    {
        public ItemsController(IItems item,ICategories category,
            IItemTypes itemTypes,IOs os)
        {
            oClsItems=item;
            oClsCategories = category;
            oClsItemTypes= itemTypes;
            oClsOs=os;
        }
        IItems oClsItems;
        ICategories oClsCategories;
        IItemTypes oClsItemTypes;
        IOs oClsOs;

        public IActionResult List()
        {

            ViewBag.lstCategories= oClsCategories.GetAll();
            var items= oClsItems.GetAllItemsData(null);
            return View(items);
        }

        public IActionResult Search(int id)
        {
            ViewBag.lstCategories = oClsCategories.GetAll();
            var items = oClsItems.GetAllItemsData(id);
            return View("List", items);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Edit(int? itemId)
        {
            var item = new Models.TbItem();
            ViewBag.lstCategories=oClsCategories.GetAll();
            ViewBag.lstItemTypes = oClsItemTypes.GetAll();
            ViewBag.lstOs = oClsOs.GetAll();
            if (itemId != null)
            {
                 item = oClsItems.GetById(Convert.ToInt32(itemId));
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbItem item, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit", item);

            item.ImageName = await Helper.UploadImage(Files, "Items");

            oClsItems.Save(item);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int itemId)
        {
            oClsItems.Dekete(itemId);
            return RedirectToAction("List");
        }
    }
}
