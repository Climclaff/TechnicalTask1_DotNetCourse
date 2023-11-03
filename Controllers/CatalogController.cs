using Microsoft.AspNetCore.Mvc;
using TechnicalTask1_DotNetCourse.Models;
using TechnicalTask1_DotNetCourse.Repository.Interfaces;
using TechnicalTask1_DotNetCourse.Services.Interfaces;

namespace TechnicalTask1_DotNetCourse.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogRepository catalogRepository, ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
        public async Task<IActionResult> Index(int id)
        {
            Catalog catalog = await _catalogService.GetCatalogWithRecursiveChildren(id);
            if (catalog == null)
            {
                catalog = await _catalogService.GetCatalogWithRecursiveChildren();
                if (catalog == null)
                {
                    return View();
                }
            }

            return View(catalog);
        }

        public async Task<IActionResult> ExportFoldersToFile(string exportPath)
        {
            bool success = await _catalogService.ExportHierarchyToFile(exportPath);
            if (!success)
            {
                TempData["ExportMessage"] = "An error occured during export process";
                return RedirectToAction("Root", "Catalog"); ;
            } 
            TempData["ExportMessage"] = "Export Success";
            return RedirectToAction("Root", "Catalog"); ;
        }

        public async Task<IActionResult> ImportFoldersFromFile(string importPath)
        {
            bool success = await _catalogService.ImportFromFile(importPath);
            if (!success)
            {
                TempData["ImportMessage"] = "An error occured during import process";
                return RedirectToAction("Root", "Catalog"); ;
            }
            TempData["ImportMessage"] = "Import Success";
            return RedirectToAction("Root", "Catalog"); ;
        }
    }
}
