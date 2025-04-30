﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ReceptsAPI.AUTH
{
    public class AuthOptions
    {
        public readonly string Issuer;
        public readonly string Audience;
        private readonly string Key;

        public AuthOptions(string issuer, string audience, string key)
        {
            Issuer = issuer;
            Audience = audience;
            Key = key;
        }

        public SymmetricSecurityKey GetSymmetricKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
