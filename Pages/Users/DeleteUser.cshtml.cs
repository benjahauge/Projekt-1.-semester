using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Interfaces;
using Projekt.Models;

namespace Projekt.Pages.Users
{
    public class DeleteUserModel : PageModel
    {
        IUserRepository repo;

        [BindProperty]
        public User User { get; set; }

        public DeleteUserModel(IUserRepository repository)
        {
            repo = repository;
        }


        public IActionResult OnGet(int id)
        {
            User = repo.GetUser(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            repo.RemoveUser(id);
            return RedirectToPage("Index");
        }
    }
}
