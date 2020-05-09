using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenciesAPI.Models.DTOs
{
    public class CurrencyDTO
    {
        public int CurrencyId { get; set; }

        public String Name { get; set; }

        public int ColourId { get; set; }

        public int CountryCode { get; set; }
    }
}
