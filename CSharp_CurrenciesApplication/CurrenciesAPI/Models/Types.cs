﻿using System;
using System.Collections.Generic;

namespace CurrenciesAPI.Models
{
    public partial class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CurrenciesTypes CurrenciesTypes { get; set; }
    }
}
