﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrenciesDAL.Models
{
    public class Colour
    {
        //Scalar Properties
        public int Id { get; set; }

        public string Name { get; set; }

        //navigation property
        //Many to one relationship with Currency
        private List<Currency> _currencies;
        public List<Currency> Currencies
        {
           get {
                if (_currencies == null)
                {
                    //_currencies = CurrencyManager.GetCurrency(Id);
                    _currencies = CurrencyManager.GetCurrencyListForColour(); //colour id
                }
                return _currencies;
            }
        }
    }
}
