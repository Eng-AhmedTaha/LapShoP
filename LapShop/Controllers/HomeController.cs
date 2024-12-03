using Microsoft.AspNetCore.Mvc;
using LapShop.Models;
using Microsoft.EntityFrameworkCore;
using LapShop.Bl;

namespace LapShop.Controllers
{

    public class HomeController : Controller
    {
        IItems oClsItems;
        ISliders oClsSliders;
        ICategories oClsCategories;
        public HomeController(IItems item, ISliders oSliders, ICategories categories)
        {
            oClsItems = item;
            this.oClsSliders = oSliders;
            this.oClsCategories = categories;
        }
        public IActionResult Index()
        {
            VmHomePage vm = new VmHomePage();
            vm.lstAllItems = oClsItems.GetAllItemsData(null).Skip(20).Take(20).ToList();
            vm.lstRecommendedItems = oClsItems.GetAllItemsData(null).Skip(60).Take(10).ToList();
            vm.lstNewItems = oClsItems.GetAllItemsData(null).Skip(90).Take(10).ToList();
            vm.lstFreeDelivry = oClsItems.GetAllItemsData(null).Skip(200).Take(10).ToList();
            vm.lstSliders = oClsSliders.GetAll();
            vm.lstCategories= oClsCategories.GetAll().Take(4).ToList();
            return View(vm);
        }
    }
}
