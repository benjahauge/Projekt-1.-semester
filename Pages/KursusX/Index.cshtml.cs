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
    public class IndexModel : PageModel
    {


        IRepository repo;
        public List<Kursus> Kursuss { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public IndexModel(IRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet()
        {
            Kursuss = repo.GetAllKursus();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Kursuss = repo.FilterKursus(FilterCriteria);
            }
            return Page();
        }






    }
}



