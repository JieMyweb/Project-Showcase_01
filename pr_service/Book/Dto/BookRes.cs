﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_service
{
    public class BookRes
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
        public string Material { get; set; }
        public string Packing { get; set; }
        public string DeliveryRemarks { get; set; }
    }
}
