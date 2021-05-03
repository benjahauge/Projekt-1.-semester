using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt.Pages
{
    public class ExceptionsModel : PageModel
    {

        public string Error { get; set; }

        public void OnGet()
        {
            Error = TempData["Error"] as string;
        }
 
    }
}
