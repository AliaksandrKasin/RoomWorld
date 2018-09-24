﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    
    public class Flat : BaseEntity
    {
        
        [Required]
        public string Name { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Accommodates { get; set; }

        [Required]
        public string SpaceOffered { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }



        public ICollection<Amenties> Amentieses { get; set; }
        public ICollection<Extras> Extrases { get; set; }
        public ICollection<HouseRules> HouseRuleses { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Location Location { get; set; }
        public User User { get; set; }
    }
}
