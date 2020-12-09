﻿using IssueTracker.Application.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
