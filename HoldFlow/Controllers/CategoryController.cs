using HoldFlow.BL.Interfaces;
using HoldFlow.DataAccess.IRepository;
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

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var categories = await _manager.GetAllAsync(); 
            return View("Index", categories);
        }

        // GET: Category/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _manager.FirstOrDefaultAsync(i=>i.Id==id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _manager.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _manager.FirstOrDefaultAsync(i => i.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _manager.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _manager.FirstOrDefaultAsync(i => i.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

    }
}
