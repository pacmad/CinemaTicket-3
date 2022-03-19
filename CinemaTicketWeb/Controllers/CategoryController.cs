using CinemaTicket.Infrastructure.Data.Repositories;
using CinemaTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IApplicationDbRepository _db;

        public CategoryController(IApplicationDbRepository db)
        {
            _db=db;
        }

        public IActionResult Index()
        {
            return View( _db.All<Category>());
        }
        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
               ModelState.AddModelError("name", "The Display Order cannot exactly match the Name."); 
            }
            if (ModelState.IsValid)
            {
               await _db.AddAsync(obj);
               await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                

                return RedirectToAction("Index");
            }
         
            return View(obj);
        }


        //GET
        public async Task<IActionResult> Edit(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var categoryFromDb = await _db.GetByIdAsync<Category>(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name."); 
            }
            if (ModelState.IsValid)
            {
                _db.Update(obj);
               await _db.SaveChangesAsync();
                TempData["success"] = "Category edited successfully";

                return RedirectToAction("Index");
            }
         
            return View(obj);
        }

        //GET
        public async Task<IActionResult> Delete(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var categoryFromDb = await _db.GetByIdAsync<Category>(id);

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(Category obj)
        {
           
                 _db.Delete(obj);
               await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";

                return RedirectToAction("Index");
        }

    }
}
