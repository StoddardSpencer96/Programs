using System;
using System.Collections.Generic;

namespace CurrenciesAPI.Models
{
    public partial class CurrenciesTypes
    {
        public int TypeId { get; set; }
        public int CurrenciesId { get; set; }

        public Currencies Currencies { get; set; }
        public Types Type { get; set; }
    }
}
