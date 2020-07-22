using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exam2.Models;

namespace Exam2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICakeRepository cakeRepository;
        public HomeController(AppDbContext context, ICategoryRepository categoryRepository, ICakeRepository cakeRepository)
        {
            this.context = context;
            this.categoryRepository = categoryRepository;
            this.cakeRepository = cakeRepository;
        }

        public IActionResult Index()
        {
            return View(categoryRepository.Get());
        }
        public IActionResult Category(int id)
        {
            var ctg = categoryRepository.Get(id);
            if (ctg == null)
            {
                return RedirectToAction("Error");
            }
            var cakes = (from c in context.Cakes where c.CategoryId == id && c.IsDeleted == false select c);
            ViewBag.Category = ctg;
            ViewBag.CategoryId = id;
            return View(cakes);
        }
        public IActionResult ViewCake(int id)
        {
            var cake = cakeRepository.Get(id);
            if (cake == null || cake.IsDeleted == true)
            {
                return RedirectToAction("Error");
            }
            ViewBag.Category = categoryRepository.Get(cake.CategoryId);
            return View(cake);
        }
        [HttpGet]
        public IActionResult CreateCake(int? CategoryId)
        {
            ViewBag.Categories = categoryRepository.Get();
            ViewBag.CategoryId = CategoryId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateCake(CakeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cake = cakeRepository.Create(new Cake()
                {
                    CategoryId = model.CategoryId,
                    ExpiryDate = model.ExpiryDate,
                    Ingredient = model.Ingredient,
                    ManufacturingDate = model.ManufacturingDate,
                    Name = model.Name,
                    IsDeleted = false,
                    Price = model.Price
                });
                return RedirectToAction("ViewCake", "Home", new { id = cake.CakeId });
            }
            ModelState.AddModelError("", "Có lỗi trong quá trình thực hiện, xin hãy thử lại!");
            return View();
        }
        [HttpGet]
        public IActionResult EditCake(int id)
        {
            var cake = cakeRepository.Get(id);
            if (cake == null || cake.IsDeleted == true)
            {
                return RedirectToAction("Error");
            }
            ViewBag.Categories = categoryRepository.Get();
            return View(cake);
        }
        [HttpPost]
        public IActionResult EditCake(Cake cake)
        {
            if (ModelState.IsValid)
                if (cakeRepository.Edit(cake) != null)
                    return RedirectToAction("ViewCake", "Home", new { id = cake.CakeId });
            ModelState.AddModelError("", "Có lỗi trong quá trình thực hiện, xin hãy thử lại!");
            return View();
        }
        public IActionResult RemoveCake(int id)
        {
            var cake = cakeRepository.Get(id);
            if (cake == null || cake.IsDeleted == true)
            {
                return RedirectToAction("Error");
            }
            cakeRepository.Remove(id);
            return RedirectToAction("Category", "Home", new { id = cake.CategoryId });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
