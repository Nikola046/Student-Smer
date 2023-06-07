using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Smer.Models;
using Student_Smer.Repository;

namespace Student_Smer.Controllers
{
    public class StudentController : Controller
    {
        readonly IStudentRepository _studentRepository;
        readonly ISmerRepository _smerRepository;

        public StudentController(IStudentRepository studentRepository, ISmerRepository smerRepository)
        {
            _studentRepository = studentRepository;
            _smerRepository = smerRepository;
        }

        public IActionResult Index([FromQuery] string filter)
        {
            if (filter == null)
            {
                filter = "";
            }

            var smer = _smerRepository.GetAll();
            var student = new List<Student>();


            if (string.IsNullOrEmpty(filter))
            {
                student = _studentRepository.GetAll().ToList();
            }
            else
            {
                student = _studentRepository.GetWithFilter(filter).ToList();
            }



            var ViewModel = new StudentListView
            {

                Students = student,
                Filter = filter
            };

            return View(ViewModel);

        }

        public IActionResult Details(int id)
        {
            var student = _studentRepository.GetSingle(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            student.Smer = _smerRepository.GetSingle(student.Smer?.SmerID ?? 0);

            return View(student);
        }

        public IActionResult Create()
        {
            var smerovi = _smerRepository.GetAll();
            ViewData["smerovi"] = new SelectList(smerovi, "SmerID", "NazivSmera");

            return View("Edit", new Student());
        }

        public IActionResult Edit(int Id)
        {
            var smerovi = _smerRepository.GetAll();
            ViewData["smerovi"] = new SelectList(smerovi, "SmerID", "NazivSmera");

            return View(_studentRepository.GetSingle(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var smerovi = _smerRepository.GetAll();
                    ViewData["smerovi"] = new SelectList(smerovi, "SmerID", "NazivSmera");

                    return View(student);
                }

                var result = _studentRepository.Save(student);
                if (result == -10)
                {
                    var smerovi = _smerRepository.GetAll();
                    ViewData["smerovi"] = new SelectList(smerovi, "SmerID", "NazivSmera");
                    ModelState.AddModelError("Sifra", "Šifra već postoji u bazi");

                    return View(student);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var smerovi = _smerRepository.GetAll();
                ViewData["smerovi"] = new SelectList(smerovi, "SmerID", "NazivSmera");

                return View(student);
            }
        }

        public IActionResult Delete(int Id)
        {
            var student = _studentRepository.GetSingle(Id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            _studentRepository.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
