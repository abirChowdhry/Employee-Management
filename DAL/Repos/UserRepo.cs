using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User, int>, IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.Uname.Equals(username) &&
            u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public User Insert(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public User Delete(string id)
        {
            throw new NotImplementedException();

        }

        public List<User> Show(string id)
        {
            throw new NotImplementedException();
        }

        public User GetByEmployeeCode(int code, string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Get(string id)
        {
            var users = DataAccessFactory.UserData().GetAll();
            var data = from u in users
                       where u.Uname == id
                       select u;
            return (User)data;
        }

        public User Update(User obj)
        {
            var ex = Get(obj.Uname);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;

        }
    }
}
