using System;
using System.Collections.Generic;

namespace CurrenciesUI.Models
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
        public ICollection<CurrenciesTypes> CurrenciesTypes { get; set; }
    }
}
