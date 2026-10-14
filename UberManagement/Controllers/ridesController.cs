using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberManagement.DTOs.Ride;
using UberManagement.Models;
using UberManagement.UnitOFWork;

namespace UberManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ridesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ridesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRideDTO dto)
        {
            var x = mapper.Map<Ride>(dto);
            await unitOfWork.RideRepo.Create(x);
            unitOfWork.Save();
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = await unitOfWork.RideRepo.GetById(id);
            var e = mapper.Map<GetRideDTO>(s);
            return Ok (e);
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetPagenation(int page, int pageSize)
        {
            var ss = await unitOfWork.RideRepo.GetPagenation(page, pageSize);
            var res = mapper.Map<List<GetRideDTO>>(ss);
            return Ok (res);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string PickUp)
        {
            var s = await unitOfWork.RideRepo.Search(PickUp);
            var res = mapper.Map<List<GetRideDTO>>(s);
            return Ok(res);
        }
    }
}
