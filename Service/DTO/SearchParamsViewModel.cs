﻿using System;

namespace Service
{
    public class SearchParamsViewModel
    {
        public string Country { get; set; }

        public string City { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }

    }
}