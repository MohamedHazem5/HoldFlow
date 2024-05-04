using HoldFlow.BL.Interfaces;
using HoldFlow.Models.DTOs;

namespace HoldFlow.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryManager _manager;

        public InventoryController(IInventoryManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var inventories = await _manager.GetInventories();
            return View("~/Views/Category/Index.cshtml", inventories);
        }
        public async Task<IActionResult> Details(int id)
        {
            var inventory =await _manager.GetInventoryById(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventoryDto inventory)
        {
            if (ModelState.IsValid)
            {
                await _manager.AddInventory(inventory);
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var inventory = await _manager.GetInventoryById(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(InventoryDto inventory)
        {
            if (ModelState.IsValid)
            {
                await _manager.UpdateInventory(inventory);
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var inventory = await _manager.GetInventoryById(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(InventoryDto inventoryDto)
        {
            if (ModelState.IsValid)
            {
                await _manager.DeleteInventory(inventoryDto.Id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
