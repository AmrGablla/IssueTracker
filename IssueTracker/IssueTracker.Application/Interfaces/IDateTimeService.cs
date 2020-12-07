using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
