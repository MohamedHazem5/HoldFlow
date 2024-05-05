using HoldFlow.BL.Interfaces;
using HoldFlow.DataAccess.IRepository;
using HoldFlow.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace HoldFlow.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _manager;

        public CategoryController(ICategoryManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _manager.GetCategories();
            return View("Index", categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _manager.GetCategoryById(id);
            return category != null ? View(category) : NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            if (!ModelState.IsValid)
                return View(category);

            await _manager.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _manager.GetCategoryById(id);

            return category != null ? View(category) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(CategoryDto category)
        {
            if (!ModelState.IsValid)
                return View(category);

            await _manager.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _manager.GetCategoryById(id);

            return category != null ? View(category) : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return View();

            await _manager.DeleteCategory(categoryDto.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}