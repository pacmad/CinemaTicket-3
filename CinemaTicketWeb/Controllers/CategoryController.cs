﻿using CinemaTicket.Infrastructure.Data;
using CinemaTicket.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db=db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
    }
}
