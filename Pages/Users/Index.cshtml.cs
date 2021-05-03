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
    public class IndexModel : PageModel
    {
        IUserRepository repo;

        public List<User> Userss { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IndexModel(IUserRepository repository)
        {
            repo = repository;
        }
        
        public IActionResult OnGet()
        {
            Userss = repo.GetAllUser();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Userss = repo.FilterUser(FilterCriteria);
            }
            return Page();
        }
    }
}
