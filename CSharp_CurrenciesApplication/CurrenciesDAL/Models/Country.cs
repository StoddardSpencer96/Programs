using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesDAL.Models
{
    public class Country
    {
        //Scalar Properties
        public string CountryCode { get; set; }

        public string Name { get; set; }

        //Navigation Properties
        //Many to many relationship with Currency table
        private List<Currency> _currencies;
        public List<Currency> Currencies
        {
            get {
                if (_currencies == null)
                {
                    _currencies = CurrencyManager.GetCurrencyListForCountry(CountryCode);
                }

                return _currencies;
            }
        }
    }
}
