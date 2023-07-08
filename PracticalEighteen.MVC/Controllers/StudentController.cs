using Microsoft.AspNetCore.Mvc;
using PracticalEighteen.Domain.DTO;
using PracticalEighteen.Domain.Interfaces;

namespace PracticalEighteen.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<StudentModel> students = await _studentRepository.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> ViewAsync(int id)
        {
            StudentModel student = await _studentRepository.GetStudentByIdAsync(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new StudentModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentModel student)
        {
            //future date validation
            if (student.DOB > DateTime.Now)
                ModelState.AddModelError(nameof(StudentModel.DOB), $"Please enter a value less than or equal to {DateTime.Now.ToShortDateString()}.");

            if (ModelState.IsValid)
            {
                int id = await _studentRepository.InsertStudentAsync(student);
                TempData["UserId"] = id;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            StudentModel student = await _studentRepository.GetStudentByIdAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, StudentModel student)
        {
            bool isUpdated = await _studentRepository.UpdateStudentAsync(id, student);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool isDeleted = await _studentRepository.DeleteStudentAsync(id);
            if (isDeleted) return RedirectToAction("Index");
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public IActionResult PageNotFound() { return View(); }
    }
}
