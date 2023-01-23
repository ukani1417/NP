using Microsoft.AspNetCore.Mvc;
using NP.Models;
using NP.Services;
using NP.DTOs.Student;
using AutoMapper;
using NP.DTOs.StudentClass;

namespace NP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        

        private readonly IStudentServices _studentservices;
        private readonly IClassServices _classServices;
        private readonly IMapper _mapper;

        public StudentController(IStudentServices studentservices,IMapper mapper,IClassServices classServices)
        {
            this._studentservices = studentservices;
            this._mapper = mapper;
            this._classServices = classServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _studentservices.GetAll();
            var resDTO = _mapper.Map<List<StudentDTO>>(res);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           var res = await _studentservices.Get(id);
           if(res == null){
                return NotFound();
           }
           var resDTO = _mapper.Map<StudentDTO>(res);
           return Ok(resDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddStudentDTO req)
        {
            var reqModel = _mapper.Map<Student>(req);
            var res = await _studentservices.Add(reqModel);
            if(res == null){
                return BadRequest();
            }
            var resDTO = _mapper.Map<StudentDTO>(res);
            return Ok(resDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStudentDTO req)
        {
            var reqModel = _mapper.Map<Student>(req);
            var res = await _studentservices.Update(id,reqModel);
            if(res == null){
                return NotFound();
            }
            var resDTO = _mapper.Map<StudentDTO>(res);
            return Ok(resDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _studentservices.Delete(id);
            if(res == null){
                return NotFound();
            }
            var resDTO = _mapper.Map<StudentDTO>(res);
            return Ok(resDTO);
        }

        [HttpPost]
        [Route("AddClass")]
        public async Task<IActionResult> AddClass([FromBody] AddStudentClassDTO req){
            var student = await _studentservices.Get(req.StudentId);
            var classobj = await _classServices.Get(req.ClassId);

            if(student == null){
                return NotFound("Student is not exists");
            }           
            if(classobj == null){
                return NotFound("Class is not exists");
            }
            var res = await _studentservices.AddClass(req);
            if(res == null){
                return BadRequest(ModelState);
            }
            return Ok(res);
        }

        [HttpGet("getclass/{id}")]
       
        public async Task<IActionResult> GetClass(int id){
            var res = await _studentservices.GetClass(id);
            if(res == null){
                return NotFound("Student Id is invalid");
            }
            return Ok(res);
        }

        [HttpDelete("Removeclass")]
        public async Task<IActionResult> RemoveClass([FromBody]RemoveStudentClassDTO req){
            var student = await _studentservices.Get(req.StudentId);
            var classobj = await _classServices.Get(req.ClassId);

            if(student == null){
                return NotFound("Student is not exists");
            }           
            if(classobj == null){
                return NotFound("Class is not exists");
            }

            var res = await _studentservices.RemoveClass(req);
            if(res == null){
                return NotFound("Student is not registred in that class");
            }
            return Ok(res);
        }
    }

}