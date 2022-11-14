using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Notoria.Views.Home
{
    public class CompraContratos : PageModel
    {
        private readonly ILogger<CompraContratos> _logger;

        public CompraContratos(ILogger<CompraContratos> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}