using GamzeNurDemir_Hafta1.Entities;
using GamzeNurDemir_Hafta1.Models;
using System.Collections.Generic;

namespace GamzeNurDemir_Hafta1.Services
{
    public interface IUserService
    {
        bool Create(User user);
        bool Update(User user);
        bool Delete(int userId);
        List<User> GetAllUser();
        User GetUser(int id);
    }
}
