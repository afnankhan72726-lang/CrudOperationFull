using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index()

        {
            var students = _context.Students.ToList();
            return View(students);
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
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var student = _context.Students.Find(Id);
            if (student == null) return NotFound();
            return View(student);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student) {
            if (ModelState.IsValid) {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var student = _context.Students.Find(Id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int Id) 
        {
            var student = _context.Students.Find(Id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int Id) 
        {
            var student = _context.Students.Find(Id);
            if(student == null)
            {
                return NotFound();

            }
            return View(student);
        }
    }
}
