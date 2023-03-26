using EShopeApi.DBContext;
using EShopeApi.DTO;
using EShopeApi.Models;
using System.Text;

namespace EShopeApi.Repository.UserRegistraionRepo
{
    public class UserRegisterHelper:IuserRegisterHelper
    {

        //private instance 
        private readonly DataContext _context;

        //public Constructor
        public UserRegisterHelper(DataContext context)
        {
            _context = context;
        }

        //Methods implementation
        public UserRegister CreateUSer(userRegisterDto newuser)
        {
            try
            {
                UserRegister user = new UserRegister
                {
                    Email= newuser.Email,
                    Password= Encoding.Unicode.GetString(Convert.FromBase64String(newuser.Password!)),
                Phone = newuser.Phone,
                    Username = newuser.Username

                };
                _context.UserRegister.Add(user);
                _context.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                return null!;
            }
        }

        public void DeleteUser(int id)
        {
            UserRegister user = _context.UserRegister.Where(p => p.Userid == id).FirstOrDefault()!;
            _context.UserRegister.Remove(user!);
            _context.SaveChanges();
        }

        public ICollection<UserRegister> GetAll()
        {
            try
            {
                List<UserRegister> usersList = (from obj in _context.UserRegister
                                           orderby obj.Userid
                                           select obj).ToList();
                return usersList;

            }
            catch (Exception ex)
            {
                return null!;
            }
        }

        public UserRegister Getbyid(int id)
        {
            UserRegister user = (from obj in _context.UserRegister
                                where obj.Userid == id
                                select obj).FirstOrDefault()!;
            return user;
        }

        public bool isExist(int id)
        {
            return _context.UserRegister.Any(p => p.Userid == id);
        }

        public UserRegister UpdateUser(int id, userRegisterDto nweuser)
        {
            UserRegister user = (from obj in _context.UserRegister
                                 where obj.Userid == id
                                 select obj).FirstOrDefault()!;
            user.Phone=nweuser.Phone;
            user.Username=nweuser.Username;
            user.Password = Encoding.Unicode.GetString(Convert.FromBase64String(nweuser.Password!));
            user.Email=nweuser.Email;

            return user;
        }
    }
}
