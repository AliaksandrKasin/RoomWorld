﻿using System.Collections.Generic;

namespace Service.DTO
{
    public class ConsultantViewModel
    {
        public string IdSignalR { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public ICollection<string> UsersInChat { get; set; }
    }
}
