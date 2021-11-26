using AutoMapper;
using HotelListing.Data;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager,
            ILogger<AccountController> logger,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            _logger.LogInformation($"Registration attempt for {userDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDto);
                user.UserName = userDto.Email;
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(error =>
                       ModelState.AddModelError(error.Code, error.Description)
                        ) ;                 //no hacer esto en produccion
                    return BadRequest(ModelState);
                }
                return Accepted();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Someting went wrong");
                return StatusCode(500, "Internal Server Error. Try again later");
            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDto)
        //{
        //    _logger.LogInformation($"Attempt to Login for {userLoginDto}");
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, false, false);
        //        if (!result.Succeeded)
        //        {
        //            return Unauthorized(userLoginDto);
        //        }
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex,$"Something went wrong in the {nameof(Login)}");
        //        return StatusCode(500, "Something went wrong in the login. Please try again later");
        //    }
        //}
    }
}
