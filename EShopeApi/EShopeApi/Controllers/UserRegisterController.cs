using EShopeApi.DTO;
using EShopeApi.Repository.UserRegistraionRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {

        public IuserRegisterHelper _userhelper;

        public UserRegisterController(IuserRegisterHelper userhelper)
        {
            _userhelper = userhelper;
        }



        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var USers = _userhelper.GetAll();
            return Ok(USers);
        }

        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {

            if (!_userhelper.isExist(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var User = _userhelper.Getbyid(id);
            return Ok(User);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_userhelper.isExist(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userhelper.DeleteUser(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(userRegisterDto user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (user == null)
            {
                return BadRequest();
            }
            var newuser = _userhelper.CreateUSer(user);
            return Ok(newuser);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, userRegisterDto user)
        {
            if (!_userhelper.isExist(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newuser = _userhelper.UpdateUser(id, user);
            return Ok(newuser);
        }
    }
}
