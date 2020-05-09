using System;
using System.Collections.Generic;

namespace CurrenciesUI.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Currencies = new HashSet<Currencies>();
        }

        public string CountryCode { get; set; }
        public string Name { get; set; }

        public ICollection<Currencies> Currencies { get; set; }
    }
}
