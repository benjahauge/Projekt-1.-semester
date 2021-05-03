using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.Models;

namespace Projekt.Interfaces
{
    public interface IUserRepository
    {
        List<User> FilterUser(string criteria);
        List<User> GetAllUser();
        User GetUser(int id);
        void AddUser(User u);
        void UpdateUser(User u);
        void RemoveUser(int id);
    }
}
