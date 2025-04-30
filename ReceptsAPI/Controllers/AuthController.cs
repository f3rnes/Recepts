using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceptsAPI.AUTH;
using ReceptsAPI.Entity;
using ReceptsAPI.Repository;
using System.ComponentModel.DataAnnotations;

namespace ReceptsAPI.Controllers
{
   

        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly JwtCreator _jwtCreator;
            private readonly IUserRepository _userRepository;

            public AuthController(JwtCreator jwtCreator, IUserRepository userRepository)
            {
                _jwtCreator = jwtCreator;
                _userRepository = userRepository;
            }

            public record LoginRequest([Required] string Login, [Required] string Password);

            public record RegisterRequest(
                [Required] string FirstName,
                [Required] string LastName,
                [Required] string Login,
                [Required] string Password);

            public record TokenPair(string AccessToken, string RefreshToken);

            [HttpPost("login")]
            public ActionResult<TokenPair> Login([FromBody] LoginRequest loginRequest)
            {
                var users = _userRepository.GetAll();

                var user = users.FirstOrDefault(u => u.Login == loginRequest.Login);

                if (user == null)
                    return Unauthorized("Username is incorrect");

                if (user.Password != loginRequest.Password)
                    return Unauthorized("Password is incorrect");

                string refreshToken = Guid.NewGuid().ToString();

                _userRepository.SetRefreshToken(refreshToken,user.Id);

                string authToken = _jwtCreator.Create(user.Id, user.Role);

                return new TokenPair(authToken, refreshToken);
            }

            [HttpPost("register")]
            public ActionResult<TokenPair> Register([FromBody] RegisterRequest registerRequest)
            {
                User newUser = new()
                {
                    Login = registerRequest.Login,
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    Password = registerRequest.Password,
                    Role = "user"
                };

                if (_userRepository.Create(newUser) == null)
                    return BadRequest("User cannot be created");

                string refreshToken = Guid.NewGuid().ToString();

                _userRepository.SetRefreshToken(refreshToken, newUser.Id);

                string authToken = _jwtCreator.Create(newUser.Id, newUser.Role);

                return new TokenPair(authToken, refreshToken);
            }

            [HttpGet("refresh/{refreshToken}")]
            public ActionResult<TokenPair> Refresh([FromRoute] string refreshToken)
            {
                var users = _userRepository.GetAll();

                var user = users.FirstOrDefault(u => u.RefreshToken == refreshToken);

                if (user == null)
                    return Unauthorized("Refresh token is incorrect");

                string newRefreshToken = Guid.NewGuid().ToString();

                _userRepository.SetRefreshToken(newRefreshToken, user.Id);

                string authToken = _jwtCreator.Create(user.Id, user.Role);

                return new TokenPair(authToken, newRefreshToken);
            }

            [Authorize]
            [HttpGet]
            public ActionResult<List<User>> GetAllUsers()
            {
                return _userRepository.GetAll().ToList();
            }
        }
    }

