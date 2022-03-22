using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVat.Blazor.Server.Models
{
    public class ClientModel
    {
        public string Nip { get; set; }
        public string Name { get; set; }
        public string StatusVat { get; set; }
        public string ErrorMessage { get; set; }


    }
}
