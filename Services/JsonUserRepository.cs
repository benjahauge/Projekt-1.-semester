using Projekt.Interfaces;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.Helpers;

namespace Projekt.Services
{
    public class JsonUserRepository : IUserRepository
    {

        string JsonFileName = @"Data\JsonUser.json";


        //Får alle filer fra JsonUser filen
        public List<User> GetAllUser()
        {
            return JsonFileReader.ReadJsonUser(JsonFileName);
        }

        //Tilføjer et user, hvor den automatisk giver det næste ID i rækkefølgen
        //Så man ikke selv skal skrive det ind manuelt
        public void AddUser(User u)
        {
            List<string> UserType = new List<string> { "Admin", "Underviser", "Kursist" };
            if (!UserType.Contains(u.UserType, StringComparer.OrdinalIgnoreCase))
            {
                throw new Exception("Denne UserType findes ikke. Prøv med Admin, Underviser eller Kursist.");
            }

            List<User> @users = GetAllUser().ToList();
            List<int> userIds = new List<int>();
            foreach (var us in users)
            {
                userIds.Add(us.ID);
            }
            if (userIds.Count != 0)
            {
                int start = userIds.Max();
                u.ID = start + 1;
            }
            else
            {
                u.ID = 1;
            }
            users.Add(u);
            JsonFileWritter.WriteToJsonUser(@users, JsonFileName);
        }

        //Her kan man søge efter en bestemt user
        public List<User> FilterUser(string criteria)
        {
            List<User> users = GetAllUser();
            List<User> filteredUsers = new List<User>();
            foreach (var u in users)
            {
                if (u.Navn.StartsWith(criteria))
                {
                    filteredUsers.Add(u);
                }
            }
            return filteredUsers;
        }

        //Her kan man hente en bestemt user fra Json filen, så man kan bruge
        //andre metoder til at gøre noget bestemt ved den enkelte user
        public User GetUser(int id)
        {
            foreach (var u in GetAllUser())
            {
                if (u.ID == id)
                    return u;
            }
            return new User();
        }

        //Her kan man fjerne en user
        public void RemoveUser(int id)
        {
            List<User> @users = GetAllUser().ToList();

            foreach (var u in @users)
            {
                if (u.ID == id)
                {
                    @users.Remove(u);
                    break;
                }
            }
            JsonFileWritter.WriteToJsonUser(@users, JsonFileName);
        }

        //Her kan man opdatere en user
        public void UpdateUser(User @us)
        {
            List<User> @users = GetAllUser().ToList();

            if (@users != null)
            {
                foreach (var u in @users)
                {
                    if (u.ID == @us.ID)
                    {
                        u.ID = us.ID;
                        u.Navn = us.Navn;
                        u.PassWord = us.PassWord;
                        u.Email = us.Email;
                        //u.UserType = us.UserType;
                    }
                }
            }
            JsonFileWritter.WriteToJsonUser(@users, JsonFileName);
        }
    }
}
