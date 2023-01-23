using Microsoft.AspNetCore.Mvc;
using NP.Services;
using NP.DTOs.Subject;
using NP.Models;
using AutoMapper;
namespace NP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectServices _subjectServices;
        private readonly IMapper _mapper;
        public SubjectController(ISubjectServices subjectServices,IMapper mapper)
        {
            _subjectServices = subjectServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _subjectServices.GetAll();
            if(res == null){
                return NotFound("Data is empty");
            }
            var resDTO = _mapper.Map<List<SubjectDTO>>(res);
            
            return Ok(resDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _subjectServices.Get(id);
            var resDTO = _mapper.Map<SubjectDTO>(res);
            if(resDTO == null){
                return NotFound("Data is empty");
            }
            return Ok(resDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSubjectDTO req)
        {
            
            var reqModel = _mapper.Map<Subject>(req);
            var res = await _subjectServices.Add(reqModel);
            if(res == null){
                return NotFound(); 
            }
            var resDTO = _mapper.Map<SubjectDTO>(res);
            return Ok(resDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateSubjectDTO req)
        {
            var reqModel = _mapper.Map<Subject>(req);
            var res = await _subjectServices.Update(id,reqModel);
            if(res == null){
                return NotFound(); 
            }
            var resDTO = _mapper.Map<SubjectDTO>(res);
            return Ok(resDTO);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _subjectServices.Delete(id);
            if(res == null){
                return NotFound();
            }
            var resDTO = _mapper.Map<SubjectDTO>(res);
            return Ok(resDTO);
        }
    }
}