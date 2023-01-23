using Microsoft.AspNetCore.Mvc;
using NP.Models;
using NP.DTOs.Test;
using AutoMapper;
using NP.Services;
namespace NP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestServices _TestServices;
         private readonly ISubjectServices _SubjectServices;
         
        private readonly IMapper _mapper;
        public TestController(ITestServices TestServices,IMapper mapper,ISubjectServices SubjectServices)
        {
            _TestServices = TestServices;
            _mapper = mapper;
            _SubjectServices = SubjectServices;
           
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _TestServices.GetAll();
            if(res == null){
                return NotFound("Test is empty");
            }
            var resDTO = _mapper.Map<List<TestDTO>>(res);
            
            return Ok(resDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _TestServices.Get(id);
            var resDTO = _mapper.Map<TestDTO>(res);
            if(resDTO == null){
                return NotFound("Data is empty");
            }
            return Ok(resDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTestDTO req)
        {
            ValiadateIds(req.SubjectId);
            if(ModelState.ErrorCount > 0){
                return BadRequest(ModelState);
            }
            var reqModel = _mapper.Map<Test>(req);
            var res = await _TestServices.Add(reqModel);
            if(res == null){
                return NotFound(); 
            }
            var resDTO = _mapper.Map<TestDTO>(res);
            return Ok(resDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTestDTO req)
        {
            
            ValiadateIds(req.SubjectId);
            if(ModelState.ErrorCount > 0){
                return BadRequest(ModelState);
            }

            var reqModel = _mapper.Map<Test>(req);
            var res = await _TestServices.Update(id,reqModel);
            if(res == null){
                return NotFound(); 
            }
            var resDTO = _mapper.Map<TestDTO>(res);
            return Ok(resDTO);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _TestServices.Delete(id);
            if(res == null){
                return NotFound();
            }
            var resDTO = _mapper.Map<TestDTO>(res);
            return Ok(resDTO);
        }

        private void ValiadateIds(int subjectId){
            var sub =  _SubjectServices.Get(subjectId);
           
            
            if(sub == null){
                ModelState.AddModelError(nameof(subjectId),$"{nameof(subjectId)} is invalid");
            }

        }
    }
}