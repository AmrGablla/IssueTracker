using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IssueTracker.Domain
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
