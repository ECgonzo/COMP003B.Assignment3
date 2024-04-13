
using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Mvc;


namespace COMP003B.Assignment3.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> _students = new List<Student>();

        public IActionResult Index()
        {
            return View(_students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                if (!_students.Any(s => s.Id == student.Id))
                {
                    _students.Add(student);
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _students.FirstOrDefault(p => p.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);

                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                _students.Remove(student);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
