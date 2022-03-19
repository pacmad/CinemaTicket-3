using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db=db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Categories.ToListAsync());
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
                _db.Categories.Add(obj);
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

            var categoryFromDb =await _db.Categories.FindAsync(id);

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
                _db.Categories.Update(obj);
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

            var categoryFromDb = await _db.Categories.FindAsync(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(string? id)
        {
            var obj = await _db.Categories.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

                _db.Categories.Remove(obj);
               await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";

                return RedirectToAction("Index");
            
         
        }

    }
}
