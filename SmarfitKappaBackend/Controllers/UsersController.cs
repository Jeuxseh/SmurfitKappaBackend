using Microsoft.AspNetCore.Mvc;
using SmarfitKappaBackend.Interfaces;
using SmarfitKappaBackend.Models;
using SmurfitKappaBackend.Services;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        Result res = new Result();
        var users = _userService.GetAllUsers();
        res.GenericObject = users;
        return Ok(res);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Result res = new Result();
        var user = _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        res.GenericObject = user;
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _userService.AddUser(user);
        return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        Result res = new Result();
        if (id != user.UserId)
        {
            return BadRequest();
        }

        _userService.UpdateUser(user);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.DeleteUser(id);
        return NoContent();
    }
}