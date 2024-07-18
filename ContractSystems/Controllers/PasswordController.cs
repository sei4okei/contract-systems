using BusinessLogic.Interfaces;
using ContractSystems.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using BusinessLogic.Models;

namespace ContractSystems.Controllers
{
    public class PasswordController : Controller
    {
        private readonly IRecordService _recordService;

        public PasswordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public async Task<IActionResult> Index(string Query)
        {
            var records = await _recordService.GetAllRecordsAsync();

            if (Query == null || Query == "")
            {
                return View(records);
            }

            var filtered = await _recordService.GetFilteredRecordsAsync(Query);

            if (filtered == null || filtered.Count == 0)
            {
                ModelState.AddModelError("Query", "–езультатов не найдено, попробуйте другой запрос");
                return View(records);
            }

            return View(new IndexViewModel()
            {
                Query = Query,
                Records = filtered
            });
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

            var isTitleEmail = new EmailAddressAttribute().IsValid(record.Title);
            if (record.IsEmail && !isTitleEmail)
            {
                ModelState.AddModelError("Title", "¬ведите верную эл. почту.");
                return View(record);
            }

            var result = _recordService.AddRecord(record);

            if (result == false) return View(record);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            var record = await _recordService.GetRecordByIdAsync(id);

            if (record == null) return RedirectToAction("Index");

            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Record model)
        {
            if (!ModelState.IsValid) return View(model);

            var isTitleEmail = new EmailAddressAttribute().IsValid(model.Title);

            if (model.IsEmail && !isTitleEmail)
            {
                ModelState.AddModelError("Title", "¬ведите верную эл. почту.");
                return View(model);
            }

            var result = _recordService.EditRecord(model);

            if (result == false) return View(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _recordService.RemoveRecord(id);

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
