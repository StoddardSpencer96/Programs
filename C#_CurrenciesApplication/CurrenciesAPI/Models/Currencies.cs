using System;
using System.Collections.Generic;

namespace CurrenciesAPI.Models
{
    public partial class Currencies
    {
        public Currencies()
        {
            CurrenciesTypes = new HashSet<CurrenciesTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ColourId { get; set; }
        public string CountryCode { get; set; }

       
        public Countries CountryCodeNavigation { get; set; }

        //navigation properties
        public ICollection<CurrenciesTypes> CurrenciesTypes { get; set; }
    }
}
