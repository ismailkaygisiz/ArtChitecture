﻿using Core.Entities.Concrete;
using System;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}