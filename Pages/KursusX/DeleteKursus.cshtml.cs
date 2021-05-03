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
    public class DeleteKursusModel : PageModel
    {
        IRepository repo;

        [BindProperty]
        public Kursus Kursus { get; set; }

        public DeleteKursusModel(IRepository repository)
        {
            repo = repository;
        }


        public IActionResult OnGet(int id)
        {
            Kursus = repo.GetKursus(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            repo.RemoveKursus(id);
            return RedirectToPage("Index");
        }
    }
}
