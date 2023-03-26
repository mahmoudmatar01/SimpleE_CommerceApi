using EShopeApi.DTO;
using EShopeApi.Models;

namespace EShopeApi.Repository.UserRegistraionRepo
{
    public interface IuserRegisterHelper
    {

        public ICollection<UserRegister> GetAll();
        public UserRegister Getbyid(int id);
        public void DeleteUser(int id);
        public UserRegister UpdateUser(int id, userRegisterDto nweuser);
        public bool isExist(int id);
        public UserRegister CreateUSer(userRegisterDto newuser);


    }
}
