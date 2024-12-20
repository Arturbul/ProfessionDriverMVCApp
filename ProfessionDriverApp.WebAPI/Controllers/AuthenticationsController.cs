﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ProfessionDriverApp.Application.DTOs.Auth;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests.Update;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationsController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IUserRoleService _userRoleService;

        public AuthenticationsController(IConfiguration configuration, ILogger<AuthenticationsController> logger, UserManager<AppUser> userManager, IUserRoleService userRoleService, IUserService userService, IJwtService jwtService)
        {
            _configuration = configuration;
            _logger = logger;
            _userManager = userManager;
            _userRoleService = userRoleService;
            _userService = userService;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="model">A RegistrationModel object containing the user's registration details.</param>
        /// <remarks>
        /// Sample request with admin claim:
        /// <code>
        ///     POST api/authentications/register
        ///     {
        ///         "userName": "admin",
        ///         "password": "Ad123!",
        ///         "email": "user@example.com",
        ///         "role": "admin"
        ///     }
        /// </code>
        /// </remarks>
        /// <returns>
        ///   * Status201Created (no data): If the user is successfully registered, the method returns a 201 Created response with no content in the body.
        ///   * Status409Conflict (no data): If a user with the same username already exists, the method returns a 409 Conflict response with a message indicating the conflict.
        ///   * Status500InternalServerError (no data): If an unexpected error occurs during registration, the method returns a 500 Internal Server Error response with a generic error message. Consider providing more specific error details in a production environment.
        /// </returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            try
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result == null)
                {
                    return BadRequest();
                }
                return StatusCode(201, result);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (NullReferenceException e)
            {
                _logger.LogWarning("Login failed for user: {UserName}. Reason: {Message}", model.Email, e.Message);
                return Conflict();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Logs in a user and generates a JWT token and refresh token for authentication.
        /// </summary>
        /// <param name="model">A LoginModel object containing the user's login credentials (username and password).</param>
        /// <returns>
        ///   * Status200OK (with data): If the login is successful, the method returns a 200 OK response with a LoginResponse object containing the JWT token, its expiration date, and the refresh token.
        ///   * Status401Unauthorized (no data): If the username or password is incorrect, the method returns a 401 Unauthorized response.
        ///   * Status500InternalServerError (no data): If an unexpected error occurs during login, the method returns a 500 Internal Server Error response with a generic error message. Consider providing more specific error details in a production environment. 
        /// </returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                // Call the service method to perform the login
                var token = await _userService.Login(model);

                // Return the JWT token if login is successful
                _logger.LogInformation("Login succeeded for user: {UserName}", model.Identifier);
                return Ok(token);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Log unauthorized access attempt
                _logger.LogWarning("Login failed for user: {UserName}. Reason: {Message}", model.Identifier, ex.Message);
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.Message ?? "Unexpected error");
            }
        }

        [HttpPost("assign-user-to-role")]
        public async Task<IActionResult> AssignUserToRole([FromQuery] AssignUserToRoleRequest roleRequest)
        {
            try
            {
                var token = await _userService.AssignUserToRole(roleRequest);
                return Ok(token);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning role to user.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while assigning role.");
            }
        }

        [HttpPost("valid")]
        public IActionResult ValidToken([FromHeader] string Authorization)
        {
            try
            {
                var token = Authorization?.Replace("Bearer ", "").Trim();

                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Token is missing or malformed.");
                }
                var result = _jwtService.ValidateJwt(token);
                return Ok(new { valid = result });
            }
            catch (SecurityTokenValidationException)
            {
                return ValidationProblem("Token is undefined or expired.");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
