using EShopeApi.DTO;
using EShopeApi.Repository.UserLoginRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {

        private readonly IUserLoginHelper _userLoginHelper;

        public UserLoginController(IUserLoginHelper userLoginHelper)
        {
            _userLoginHelper = userLoginHelper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var USers = _userLoginHelper.GetAll();
            return Ok(USers);
        }

        [HttpGet("{id}")]
        public IActionResult Getbyid(int id) { 
        
            if(!_userLoginHelper.isExist(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var User=_userLoginHelper.Getbyid(id);
            return Ok(User);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_userLoginHelper.isExist(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             _userLoginHelper.DeleteUser(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(userLoginDto user) { 
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(user == null)
            {
                return BadRequest();
            }
            var newuser=_userLoginHelper.CreateUser(user);
            return Ok(newuser);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, userLoginDto user)
        {
            if (!_userLoginHelper.isExist(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newuser = _userLoginHelper.UpdateUser(id, user);
            return Ok(newuser);
        }
    }
}
