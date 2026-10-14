using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UberManagement.DTOs.Vehicle;
using UberManagement.Models;
using UberManagement.UnitOFWork;

namespace UberManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vehiclesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public vehiclesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleDTO dto)
        {
            var s = mapper.Map<Vehicle>(dto);
            await unitOfWork.VehicleRepo.Create(s);
            unitOfWork.Save();
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await unitOfWork.VehicleRepo.GetById(id);
            var res = mapper.Map<Vehicle>(s);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await unitOfWork.VehicleRepo.GetById(id);
            unitOfWork.VehicleRepo.Delete(s);
            unitOfWork.Save();
            return NoContent();
        }
    }
}
