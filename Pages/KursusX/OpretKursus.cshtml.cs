using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt.Interfaces;
using Projekt.Models;

namespace Projekt.Pages.KursusX
{
    public class OpretKursusModel : PageModel
    {

        IRepository repo;

        [BindProperty]
        public Kursus Kursus { get; set; }

        public OpretKursusModel(IRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.AddKursus(Kursus);
            return RedirectToPage("Index");
            }
        

    }
} 
   