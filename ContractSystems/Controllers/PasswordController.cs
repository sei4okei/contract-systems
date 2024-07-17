using BusinessLogic.Interfaces;
using ContractSystems.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccess.Models;

namespace ContractSystems.Controllers
{
    public class PasswordController : Controller
    {
        private readonly IRecordService _recordService;

        public PasswordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _recordService.GetAllRecordsAsync();
            return View(records);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Record());
        }

        [HttpPost]
        public IActionResult Create(Record record)
        {
            if (ModelState.IsValid == false) return View(record);

            var result = _recordService.AddRecord(record);

            if (result == false) return View(record);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
