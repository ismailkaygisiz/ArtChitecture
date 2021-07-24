﻿using Business.Abstract;
using Core.API;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller, IControllerRepository<User, IActionResult>
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyemail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyfirstname")]
        public IActionResult GetByFirstName(string firstName)
        {
            var result = _userService.GetByFirstName(firstName);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbylastname")]
        public IActionResult GetByLastName(string lastName)
        {
            var result = _userService.GetByLastName(lastName);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }


        [HttpGet("getclaims")]
        public IActionResult GetClaims(int userId)
        {
            var result = _userService.GetUserOperationClaims(userId);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}