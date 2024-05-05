using HoldFlow.BL.Interfaces;
using HoldFlow.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HoldFlow.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPackageManager _manager;

        public PackageController(IPackageManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var packages = await _manager.GetPackages();
            return View("~/Views/Category/Index.cshtml", packages);
        }

        public async Task<IActionResult> Details(int id)
        {
            var package = await _manager.GetPackageById(id);
            return package != null ? View(package) : NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PackageDto package)
        {
            if (!ModelState.IsValid)
                return View(package);

            await _manager.AddPackage(package);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var package = await _manager.GetPackageById(id);

            return package != null ? View(package) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(PackageDto package)
        {
            if (!ModelState.IsValid)
                return View(package);

            await _manager.UpdatePackage(package);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var package = await _manager.GetPackageById(id);

            return package != null ? View(package) : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(PackageDto packageDto)
        {
            if (!ModelState.IsValid)
                return View();

            await _manager.DeletePackage(packageDto.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}