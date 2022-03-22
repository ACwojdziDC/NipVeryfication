using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVat.Blazor.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiVat.Blazor.Server.Pages
{
    public class GetNipModel : PageModel
    {
        public string Nip { get; set; }
        public ClientModel Client { get; set; }
        public string ClientName { get; set; }
        public string ClientNip { get; set; }
        public string ErrorMessage = "";

        public string ClientStatus { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Nip = Request.Form[nameof(Nip)];
            if (Nip.All(char.IsDigit) & Nip.Length == 10)
            {
                Client = await ClientProcessor.LoadCustomer(Nip);
                ClientName = Client.Name;
                ClientNip = Client.Nip;
                ClientStatus = Client.StatusVat;
                ErrorMessage = Client.ErrorMessage;
            }
            else
            {
                ErrorMessage = "Poda³eœ nieprawid³owy numer NIP";
            }
          
            return Page();
        }

    }
}
