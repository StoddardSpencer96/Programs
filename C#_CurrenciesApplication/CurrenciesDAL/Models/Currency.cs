using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesDAL.Models
{
    public class Currency
    {
        //Scalar Properties
        public int Id { get; set; }

        public string Name { get; set; }

        //foreign keys
        public int ColourId { get; set;}

        public string CountryCode { get; set; }

        //navigation property
        //Many to many relationship with Country
        private List<Country> _countries;
        public List<Country> Countries
        {
           get {
                if (_countries == null)
                {
                    _countries = CountryManager.GetCountryList();
                }
                return _countries;
            }
        }
    }
}
