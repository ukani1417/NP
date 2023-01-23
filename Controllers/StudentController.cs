using Microsoft.AspNetCore.Mvc;
using NP.Models;
using NP.Services;
using NP.DTOs.Student;
using AutoMapper;
namespace NP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        

        private readonly IStudentServices _studentservices;
        private readonly IMapper _mapper;

        public StudentController(IStudentServices studentservices,IMapper mapper)
        {
            this._studentservices = studentservices;
            this._mapper = mapper;
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
    }
}