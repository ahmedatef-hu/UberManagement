using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberManagement.Models;
using UberManagement.UnitOFWork;

namespace UberManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public usersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("GetByRole")]
        public async Task<IActionResult> GetByRole(string Role)
        {
            var s = await unitOfWork.UserRepo.GetByRole(Role);
            var res = mapper.Map<List<User>>(s);
            return Ok(res);
        }

        [HttpGet("SearchRiderName")]
        public async Task<IActionResult> Search(string Name)
        {
            var s = await unitOfWork.UserRepo.Search(Name);
            var res = mapper.Map<List<User>>(s);
            return Ok(res);
        }
    }
}
