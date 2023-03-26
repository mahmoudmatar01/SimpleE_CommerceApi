using EShopeApi.DTO;
using EShopeApi.Models;

namespace EShopeApi.Repository.UserLoginRepo
{
    public interface IUserLoginHelper
    {

        public ICollection<UserLogin> GetAll();
        public UserLogin Getbyid(int id);
        public void DeleteUser(int id);
        public UserLogin UpdateUser(int id, userLoginDto nweuser);
        public bool isExist(int id);
        public UserLogin CreateUser(userLoginDto newuser);

    }
}
