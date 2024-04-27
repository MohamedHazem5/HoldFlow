using HoldFlow.BL.Interfaces;

namespace HoldFlow.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryManager _manager;

        public InventoryController(IInventoryManager manager)
        {
            _manager = manager;
        }

        // GET: Inventory
        public async Task<IActionResult> Index()
        {
            var inventories = await _manager.GetAllAsync(); 
                                                            
            return View("~/Views/Category/Index.cshtml", inventories);
        }


        // GET: Inventory/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = _manager.FirstOrDefaultAsync(i => i.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _manager.AddAsync(inventory);
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = _manager.FirstOrDefaultAsync(i => i.Id == id);

            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _manager.Update(inventory);
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventory/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = _manager.FirstOrDefaultAsync(i => i.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }
    }
}
