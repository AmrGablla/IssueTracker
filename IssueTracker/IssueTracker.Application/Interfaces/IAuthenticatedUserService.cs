using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
