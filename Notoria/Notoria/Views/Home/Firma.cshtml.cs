using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Notoria.Views.Home
{
    public class Firma : PageModel
    {
        private readonly ILogger<Firma> _logger;

        public Firma(ILogger<Firma> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}