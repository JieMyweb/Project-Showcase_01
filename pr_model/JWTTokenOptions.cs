﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_model
{
    public class JWTTokenOptions
    {
        public string Audience { get; set; }
        public string SecurityKey {  get; set; }
        public string Issuer {  get; set; }
    }
}
