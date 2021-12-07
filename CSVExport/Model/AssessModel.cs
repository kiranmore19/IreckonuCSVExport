﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVExport.Model
{
    public class AssessModel
    {
        public string Key { get; set; }

        public string ArtikelCode { get; set; }

        public string ColorCode { get; set; }
        
        public string Description { get; set; }
        
        public int Price { get; set; }
        
        public int DiscountPrice { get; set; }
        
        public string DeliveredIn { get; set; }
        
        public string Q1 { get; set; }
        
        public int Size { get; set; }
        
        public string Color { get; set; }

    }
}
