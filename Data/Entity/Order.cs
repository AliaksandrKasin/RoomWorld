﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity
{
    public class Order : BaseEntity
    {
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public double Price { get; set; }

        public User User { get; set; }

        public Flat Flat { get; set; }
    }
}
