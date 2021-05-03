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
    public class OpretUserModel : PageModel
    {
        IUserRepository repo;

        [BindProperty]
        public User User { get; set; }

        public OpretUserModel(IUserRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet()
        {
            //Kursuss = repo.GetAllKursus();
            return Page();
        }


        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //repo.AddUser(User);
            ////Kursuss = repo.GetAllKursus();
            //return RedirectToPage("Index");

            try
            {
                repo.AddUser(User);
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToPage("/Exceptions");
            }

            return RedirectToPage("Index");
        }


    }
}
