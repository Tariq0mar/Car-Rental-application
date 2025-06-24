using AutoMapper;
using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers;

[ApiController]
[Route("api/Booking")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService ?? throw new ArgumentException(nameof(userService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }


    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

    [HttpGet("user-search")]
    public async Task<ActionResult> GetFiltered([FromBody] UserFilteringQueryParameters query)
    {
        var filteredUsers = await _userService.GetFilteredAsync(query);
        return Ok(filteredUsers);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] UserBodyRequest user)
    {
        var newUser = _mapper.Map<User>(user);

        await _userService.AddAsync(newUser);
        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UserBodyRequest user)
    {
        var newUser = _mapper.Map<User>(user);
        newUser.Id = id;

        await _userService.UpdateAsync(newUser);
        return Ok(newUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok($"User with Id: {id} has been deleted");
    }
}