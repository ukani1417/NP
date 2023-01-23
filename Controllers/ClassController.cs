using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NP.DTOs.Class;
using NP.Models;
using NP.Services;

namespace NP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        

        private readonly IClassServices _classservices;
        private readonly IMapper _mapper;
        public ClassController(IClassServices classservices,IMapper mapper)
        {
            this._classservices = classservices;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res =  await _classservices.GetAll();
            var resDTO = _mapper.Map<List<ClassDTO>>(res);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _classservices.Get(id);
            if(res == null){
                return NotFound();
            }
            var resDTO = _mapper.Map<ClassDTO>(res);
            return Ok(resDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddClassDTO req)
        {
            var reqModel = _mapper.Map<Class>(req);
            var res = await _classservices.Add(reqModel);
            if(res == null){
                return NotFound();
            }
            var resDTO = _mapper.Map<ClassDTO>(res);
            return Ok(resDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateClassDTO req)
        {
            var reqModel = _mapper.Map<Class>(req);
            var res = await _classservices.Update(id,reqModel); 
            if(res == null){
                return NotFound();
            }
            var resDTO = _mapper.Map<ClassDTO>(res);
           return Ok(resDTO);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _classservices.Delete(id); 
            var resDTO = _mapper.Map<ClassDTO>(res);
            return Ok(resDTO);
        }
    }
}