﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class PersonParameters : RequestParameters
    {
        public PersonParameters()
        {
            OrderBy = "Name";
        }
        public string? SearchTerm { get; set; }
    }
}
