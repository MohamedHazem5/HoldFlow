using HoldFlow.BL.Interfaces;
using HoldFlow.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _manager;

        public ProductController(IProductManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _manager.GetProducts();
            return View("~/Views/Category/Index.cshtml", products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _manager.GetProductById(id);
            return product != null ? View(product) : NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _manager.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _manager.GetProductById(id);

            return product != null ? View(product) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ProductDto product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _manager.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _manager.GetProductById(id);

            return product != null ? View(product) : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return View();

            await _manager.DeleteProduct(productDto.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}