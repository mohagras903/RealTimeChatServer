﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeChat.Models;
using RealTimeChat.Services;
namespace RealTimeChat.Controllers;

[Controller]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateAccount([FromBody] UserDto request)
    {
        await _authService.RegisterAsync(request);

        return CreatedAtAction(nameof(CreateAccount), request);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto request)
    {
        string res = await _authService.LoginAsync(request);
        if (res == "INVALID!")
            return BadRequest("Wrong Password!");

        return CreatedAtAction(nameof(Login), res);
    }
}

