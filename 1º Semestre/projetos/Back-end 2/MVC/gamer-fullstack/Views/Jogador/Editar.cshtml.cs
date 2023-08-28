using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace gamer_fullstack.Views.Jogador
{
    public class Editar : PageModel
    {
        private readonly ILogger<Editar> _logger;

        public Editar(ILogger<Editar> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}