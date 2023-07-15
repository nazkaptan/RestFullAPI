using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFullAPI.Infrastructure.Repositories.Interface;
using RestFullAPI.Models.DTOs.User;
using RestFullAPI.Models.Entities.Concrete;

namespace RestFullAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;

        public AccountController(IAuthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationDTO model)
        {
            AppUser appUser = _mapper.Map<AppUser>(model);

            var user = _repository.Authentication(appUser.UserName, appUser.Password);

            if (user == null) return BadRequest(new { message = "User name or password is incorrect..!" });

            return Ok(user);
        }

    }
}
