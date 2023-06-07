using Microsoft.AspNetCore.Mvc;
using Student_Smer.Models;
using Student_Smer.Repository;

namespace Student_Smer.Controllers
{
    public class SmerController : Controller
    {
        private readonly ISmerRepository _repository;
        public SmerController(ISmerRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index([FromQuery] string filter)
        {
            ViewData["filter"] = filter;
            if (string.IsNullOrEmpty(filter))
            {
                return View(_repository.GetAll());
            }
            else
            {
                return View(_repository.GetWithFilter(filter));
            }

        }

        public IActionResult Create()
        {
            return View("Edit", new Smer());
        }

        public IActionResult Edit(int id)
        {
            var s = _repository.GetSingle(id);
            if (s == null)
            {
                return RedirectToAction("Index");
            }
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Smer smer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(smer);
                }
                else
                {
                    _repository.Save(smer);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(smer);
            }


        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
