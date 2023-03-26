using EShopeApi.DBContext;
using EShopeApi.DTO;
using EShopeApi.Models;
using System.Text;

namespace EShopeApi.Repository.UserLoginRepo
{
    public class UserLoginHelper:IUserLoginHelper
    {

        //private instance 
        private readonly DataContext _context;

        //public Constructor
        public UserLoginHelper(DataContext context)
        {
            _context = context;
        }

        //methods implementation

        public UserLogin CreateUser(userLoginDto newuser)
        {
            try
            {
                UserLogin user = new UserLogin
                {
                    password = Encoding.Unicode.GetString(Convert.FromBase64String(newuser.password!)),
                    username = newuser.username,
                };
                _context.UserLogin.Add(user);
                _context.SaveChanges();
                return user;

            }
            catch (Exception ex) {
                return null!;
            }
        }

        public void DeleteUser(int id)
        {
            UserLogin user=_context.UserLogin.Where(p=>p.userid==id).FirstOrDefault()!;
            _context.UserLogin.Remove(user);
            _context.SaveChanges();
        }

        public ICollection<UserLogin> GetAll()
        {
            try
            {
                List<UserLogin> userlist = (from obj in _context.UserLogin
                                            select obj).OrderBy(p => p.userid).ToList();

                return userlist;
            }
            catch (Exception ex)
            {
                return null!;
            }
        }

        public UserLogin Getbyid(int id)
        {
            UserLogin user=(from obj in _context.UserLogin
                            where obj.userid==id
                            select obj).FirstOrDefault()!;
            return user;
        }

        public bool isExist(int id)
        {
            return _context.UserLogin.Any(p=>p.userid==id);
        }

        public UserLogin UpdateUser(int id, userLoginDto nweuser)
        {
            UserLogin user = (from obj in _context.UserLogin
                              where obj.userid == id
                              select obj).FirstOrDefault()!;
            user.username=nweuser.username;
            user.password = Encoding.Unicode.GetString(Convert.FromBase64String(nweuser.password!));
            _context.SaveChanges();
            return user;
        }


    }
}
