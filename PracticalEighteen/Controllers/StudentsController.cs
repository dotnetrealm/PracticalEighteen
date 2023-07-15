using Microsoft.AspNetCore.Mvc;
using PracticalEighteen.Domain.DTO;
using PracticalEighteen.Domain.Interfaces;

namespace PracticalEighteen.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Return list of students
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                IEnumerable<StudentModel> student = await _studentRepository.GetAllStudentsAsync();
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Return student information by id
        /// </summary>
        /// <param name="id">Student Id</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                StudentModel student = await _studentRepository.GetStudentByIdAsync(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Insert new student
        /// </summary>
        /// <param name="student">Student object</param>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] StudentModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (student == null) return BadRequest(ModelState);
                    int studentId = await _studentRepository.InsertStudentAsync(student);
                    student.Id = studentId;
                    return CreatedAtAction("GetStudentById", new { id = studentId }, student);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update studnet details
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <param name="student">Student model</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] StudentModel student)
        {
            try
            {
                if (student == null) return BadRequest(ModelState);
                bool isUpdated = await _studentRepository.UpdateStudentAsync(id, student);

                if (!isUpdated) return NotFound();
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete student by Id
        /// </summary>
        /// <param name="id">Student Id</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                bool isDeleted = await _studentRepository.DeleteStudentAsync(id);
                if (!isDeleted) return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
