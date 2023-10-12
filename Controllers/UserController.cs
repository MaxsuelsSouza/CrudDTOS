using AutoMapper;
using CrudDTOS.DTOs;
using CrudDTOS.Model;
using CrudDTOS.Repository;
using CrudDTOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudDTOS.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;
        private readonly IRepositoryUser _repository;
        private readonly IMapper _mapper;

        public UserController(
            IMapper mapper,
            IUserServices services,
            IRepositoryUser repository
        )
        {
            _mapper = mapper;
            _repository = repository;
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDetailsDto dto)
        {


            _services.CreateUser(dto);

            return await _repository.SavesChangesAsync()
            ? Ok("Usuario foi criado com sucesso!")
            : BadRequest("Erro ao criar usuario");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _services.GetAllUser();
            return Ok(users.Select(User => _mapper.Map<UserDto>(User)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var user = await _services.GetOneUser(id);
            var UserDetails = _mapper.Map<UserDetailsDto>(user);
            return user != null
            ? Ok(UserDetails)
            : NotFound("Usuario nao encontrado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _services.GetOneUser(id);
            _services.DeleteUser(id, user);

            return await _repository.SavesChangesAsync()
            ? Ok("Usuario removido com sucesso")
            : BadRequest("Erro ao remover o usuario");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserDto userDto)
        {

            _services.UpdateUser(id, userDto);

            return await _repository.SavesChangesAsync()
            ? Ok("Usuario Atualizado com sucesso")
            : BadRequest("Erro ao Atualizar o usuario");
        }

        [HttpGet("/search")]
        public async Task<IActionResult> Get([FromQuery] string email)
        {
            var user = await _services.SearchOneUser(email);
            var userDetails = _mapper.Map<UserDetailsDto>(user);

            return Ok(userDetails);
        }
    }
}
