using GamzeNurDemir_Hafta1.Entities;
using GamzeNurDemir_Hafta1.Models;
using System.Collections.Generic;
using System.Linq;

namespace GamzeNurDemir_Hafta1.Services
{
    public class UserService : IUserService
    {
        private readonly Hafta1DenemeDbContext _context;

        public UserService(Hafta1DenemeDbContext context)
        {
            _context = context;
        }

        public bool Create(User user)
        {
            user.CreatedAt = System.DateTime.Now;
            user.UpdatedAt = System.DateTime.Now;
            _context.Users.Add(user);
            int affected = _context.SaveChanges();
            return affected == 0 ? false : true;

        }

        public bool Delete(int userId)
        {
            var result = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            if (result == null) return false;
            result.IsDeleted = true;
            _context.Users.Update(result);
            int affected = _context.SaveChanges();
            return affected == 0 ? false : true;
        }

        public List<User> GetAllUser()
        {
            var result = _context.Users.ToList();
            return result;
        }

        public User GetUser(int id)
        {
           var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public bool Update(User user)
        {
            if (user == null) return false;

            _context.Users.Update(user);
            int affected = _context.SaveChanges();
            return affected == 0 ? false : true;
        }


    }
}
