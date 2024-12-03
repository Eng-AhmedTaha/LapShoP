using Microsoft.AspNetCore.Mvc;
using LapShop.Models;
using LapShop.Bl;
using LapShop.Utlities;
using Microsoft.AspNetCore.Authorization;

namespace LapShop.Areas.admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("admin")]
    public class CategoriesController : Controller
    {
        public CategoriesController(ICategories category)
        {
            oClsCategories=category;
        }
        ICategories oClsCategories;
        public IActionResult List()
        {
            return View(oClsCategories.GetAll());
        }

        public IActionResult Edit(int? categoryId)
        {
            var category = new TbCategory();
            if (categoryId != null)
            {
                category = oClsCategories.GetById(Convert.ToInt32(categoryId));
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCategory category, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit", category);

            category.ImageName = await Helper.UploadImage(Files, "Categories");

            oClsCategories.Save(category);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int categoryId)
        {
            oClsCategories.Dekete(categoryId);
            return RedirectToAction("List");
        }

        async Task<string> UploadImage(List<IFormFile> Files)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads/Categories", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }
    }
}
