﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModel.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
